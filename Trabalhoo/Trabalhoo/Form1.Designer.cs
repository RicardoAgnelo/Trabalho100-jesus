using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Trabalhoo
{
    partial class FormCadastroProduto
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        /// 
        private bool nome = false;
        private bool quantidade = false;
        private bool preco = false;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnExibir = new System.Windows.Forms.Button();
            this.txtExcluir = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtPreco.Validating += txtpreco_Validating;
            this.txtQuantidade.Validating += txtQuantidade_Validating;
            this.txtNome.Validating += txtNome_Validating;
            this.txtExcluir.Validating += txtExcluir_Validating;
            this.btnCadastrar.Enabled = false;
            this.btnExcluir.Enabled = false;
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();


            void txtpreco_Validating(object sender, CancelEventArgs e)
            {
                if (!int.TryParse(txtPreco.Text, out _))
                {
                    e.Cancel = true;
                    txtPreco.Focus();
                    errorProvider1.SetError(txtPreco, "Digite um valor numérico válido.");
                }
                else
                {
                    preco = true;
                    UpdateCadastrarButtonState();
                    errorProvider1.SetError(txtPreco, "");
                }
            }
             void txtQuantidade_Validating(object sender, CancelEventArgs e)
            {
                if (!int.TryParse(txtQuantidade.Text, out _))
                {
                    e.Cancel = true;
                    txtQuantidade.Focus();
                    errorProvider1.SetError(txtQuantidade, "Digite um valor numérico válido.");
                }
                else
                {
                    quantidade = true;
                    UpdateCadastrarButtonState();
                    errorProvider1.SetError(txtQuantidade, "");
                }
            }
             void txtNome_Validating(object sender, CancelEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    e.Cancel = true;
                    txtNome.Focus();
                    errorProvider1.SetError(txtNome, "Este campo é obrigatório.");
                }
                else
                {

                    nome = true;
                    UpdateCadastrarButtonState();
                    errorProvider1.SetError(txtNome, "");
                }
            }
            void txtExcluir_Validating(object sender, CancelEventArgs e)
            {
                if (!int.TryParse(txtExcluir.Text, out _))
                {
                    e.Cancel = true;
                    txtExcluir.Focus();
                    errorProvider1.SetError(txtExcluir, "Digite um valor numérico válido.");
                    btnExcluir.Enabled = false;
                }
                else
                {
                    quantidade = true;
                    btnExcluir.Enabled = true;
                    UpdateCadastrarButtonState();
                    errorProvider1.SetError(txtExcluir, "");
                }
            }

            void UpdateCadastrarButtonState()
            {
                if ( preco && nome && quantidade) { // Função que verifica a validade dos campos

                btnCadastrar.Enabled = true;
                }
            }
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(80, 50);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 20);
            this.txtNome.TabIndex = 0;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(80, 80);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(200, 20);
            this.txtPreco.TabIndex = 1;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(80, 110);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(200, 20);
            this.txtQuantidade.TabIndex = 2;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(80, 140);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(200, 23);
            this.btnCadastrar.TabIndex = 3;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnExibir
            // 
            this.btnExibir.Location = new System.Drawing.Point(80, 170);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(200, 23);
            this.btnExibir.TabIndex = 4;
            this.btnExibir.Text = "Exibir Produtos";
            this.btnExibir.UseVisualStyleBackColor = true;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // txtExcluir
            // 
            this.txtExcluir.Location = new System.Drawing.Point(80, 200);
            this.txtExcluir.Name = "txtExcluir";
            this.txtExcluir.Size = new System.Drawing.Size(200, 20);
            this.txtExcluir.TabIndex = 5;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(80, 230);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(200, 23);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = "Excluir Produto";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // Criação dos rótulos (labels)
            Label lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.AutoSize = true;
            lblNome.Location = new Point(30, 50); // Define a posição do rótulo na tela

            Label lblPreco = new Label();
            lblPreco.Text = "Preço:";
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(30, 80);

            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new Point(10, 110);

            Label lblExcluir = new Label();
            lblExcluir.Text = "Exlcuir:";
            lblExcluir.AutoSize = true;
            lblExcluir.Location = new Point(30, 200);
            // 
            // FormCadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 329);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnExibir);
            this.Controls.Add(this.txtExcluir);
            this.Controls.Add(lblNome);
            this.Controls.Add(lblPreco);
            this.Controls.Add(lblExcluir);
            this.Controls.Add(lblQuantidade);
            this.Controls.Add(this.btnExcluir);
            this.Name = "FormCadastroProduto";
            this.Text = "Cadastro de Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

