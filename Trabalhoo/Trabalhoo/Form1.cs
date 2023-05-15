using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalhoo
{
    public partial class FormCadastroProduto : Form
    {
        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtQuantidade;
        private Button btnCadastrar;
        private Button btnExibir;
        private TextBox txtExcluir;
        private Button btnExcluir;
     

        private SqlConnection connection;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Trabalhodb;Integrated Security=True;Connect Timeout=10;Encrypt=False";

        // Lista para armazenar os produtos cadastrados
        private List<Produto> listaProdutos;
        private void ConfigureDatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
        }
        public FormCadastroProduto()
        {
            InitializeComponent();
            ConfigureDatabaseConnection();
            // Inicializa a lista de produtos
            listaProdutos = new List<Produto>();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            decimal preco = decimal.Parse(txtPreco.Text);
            int quantidade = int.Parse(txtQuantidade.Text);

            string query = "INSERT INTO Produtos (Nome, Preco, Quantidade) VALUES (@Nome, @Preco, @Quantidade)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Preco", preco);
                command.Parameters.AddWithValue("@Quantidade", quantidade);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Produto cadastrado com sucesso!");
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            string query = "SELECT Id, Nome, Preco, Quantidade FROM Produtos";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string message = "";

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);
                        decimal preco = reader.GetDecimal(2);
                        int quantidade = reader.GetInt32(3);

                        message += $"ID : {id},Nome: {nome}, Preço: {preco}, Quantidade: {quantidade}\n";
                    }

                    if (message == "")
                    {
                        MessageBox.Show("Não há produtos para exibir.");
                    }
                    else
                    {
                        MessageBox.Show(message, "Produtos");
                    }
                }
                connection.Close();
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtExcluir.Text);

            string query = "DELETE FROM Produtos WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Produto excluído com sucesso!");
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!");
                }
            }
        }
    


        private void LimparCampos()
                {
                    txtNome.Clear();
                    txtPreco.Clear();
                    txtQuantidade.Clear();
                }
            }

    // Classe Produto
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}

