using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalhoo
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private static string connectionPString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Trabalhodb; Integrated Security = True; Connect Timeout = 30";
        [STAThread]
        static void Main()
        {
            CriarBancoDeDadosETabela();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormCadastroProduto());
        }
        static void CriarBancoDeDadosETabela()
        {
            // Verifica se o banco de dados já existe
            bool bancoExiste = VerificarBancoDeDadosExiste();

            if (!bancoExiste)
            {
                // Cria o banco de dados
                CriarBancoDeDados();
            }

            // Verifica se a tabela já existe
            bool tabelaExiste = VerificarTabelaExiste();

            if (!tabelaExiste)
            {
                // Cria a tabela
                CriarTabelaProdutos();
            }
        }

        static bool VerificarBancoDeDadosExiste()
        {
            bool bancoExiste = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string verificarBancoQuery = $"SELECT COUNT(*) FROM sys.databases WHERE name = 'Trabalhodb'";

                using (SqlCommand command = new SqlCommand(verificarBancoQuery, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    bancoExiste = (count > 0);
                }

                connection.Close();
            }

            return bancoExiste;
        }

        static void CriarBancoDeDados()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createDatabaseQuery = $"CREATE DATABASE Trabalhodb";

                using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            Console.WriteLine("Banco de dados criado com sucesso!");
        }

        static bool VerificarTabelaExiste()
        {
            bool tabelaExiste = false;

            using (SqlConnection connection = new SqlConnection(connectionPString))
            {
                connection.Open();

                string verificarTabelaQuery = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Produtos'";

                using (SqlCommand command = new SqlCommand(verificarTabelaQuery, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    tabelaExiste = (count > 0);
                }

                connection.Close();
            }

            return tabelaExiste;
        }

        static void CriarTabelaProdutos()
        {
            using (SqlConnection connection = new SqlConnection(connectionPString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE Produtos (
                        Id INT PRIMARY KEY IDENTITY,
                        Nome VARCHAR(50) NOT NULL,
                        Preco DECIMAL(10, 2) NOT NULL,
                        Quantidade INT NOT NULL
                    )
                ";

                using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            Console.WriteLine("Tabela Produtos criada com sucesso!");
        }
    }

}
