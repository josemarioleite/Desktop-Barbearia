
namespace Barbersoft.Views.FormCrud
{
    partial class ContaPagarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaPagarForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbFornecedor = new System.Windows.Forms.ComboBox();
            this.dtLancamento = new CustomControls.RJControls.DateTimePickerCustom();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtVencimento = new CustomControls.RJControls.DateTimePickerCustom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.tbFornecedorNome = new System.Windows.Forms.TextBox();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 54);
            this.panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(529, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 47);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(13, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(143, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Conta à Pagar";
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.DisplayMember = "Nome";
            this.cbFornecedor.FormattingEnabled = true;
            this.cbFornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbFornecedor.Location = new System.Drawing.Point(305, 168);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(65, 23);
            this.cbFornecedor.TabIndex = 13;
            this.cbFornecedor.ValueMember = "Id";
            this.cbFornecedor.Click += new System.EventHandler(this.AbrirFornecedor);
            // 
            // dtLancamento
            // 
            this.dtLancamento.BorderColor = System.Drawing.Color.Black;
            this.dtLancamento.BorderSize = 0;
            this.dtLancamento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtLancamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLancamento.Location = new System.Drawing.Point(15, 89);
            this.dtLancamento.MaxDate = new System.DateTime(2021, 7, 14, 0, 0, 0, 0);
            this.dtLancamento.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtLancamento.Name = "dtLancamento";
            this.dtLancamento.Size = new System.Drawing.Size(265, 35);
            this.dtLancamento.SkinColor = System.Drawing.Color.White;
            this.dtLancamento.TabIndex = 41;
            this.dtLancamento.TextColor = System.Drawing.Color.Black;
            this.dtLancamento.Value = new System.DateTime(2021, 7, 14, 0, 0, 0, 0);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel4.Location = new System.Drawing.Point(28, 126);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 1);
            this.panel4.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label3.Location = new System.Drawing.Point(26, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "Data de Lançamento";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(296, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 38);
            this.button1.TabIndex = 43;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnSalvar);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(192, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 38);
            this.button2.TabIndex = 42;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BtnSair);
            // 
            // dtVencimento
            // 
            this.dtVencimento.BorderColor = System.Drawing.Color.Black;
            this.dtVencimento.BorderSize = 0;
            this.dtVencimento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVencimento.Location = new System.Drawing.Point(294, 89);
            this.dtVencimento.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtVencimento.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtVencimento.Name = "dtVencimento";
            this.dtVencimento.Size = new System.Drawing.Size(263, 35);
            this.dtVencimento.SkinColor = System.Drawing.Color.White;
            this.dtVencimento.TabIndex = 46;
            this.dtVencimento.TextColor = System.Drawing.Color.Black;
            this.dtVencimento.Value = new System.DateTime(2021, 7, 14, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel2.Location = new System.Drawing.Point(305, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 1);
            this.panel2.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(305, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "Data de Vencimento";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.Location = new System.Drawing.Point(27, 168);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(253, 23);
            this.txtDescricao.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(25, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label4.Location = new System.Drawing.Point(303, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "Fornecedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label5.Location = new System.Drawing.Point(28, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 53;
            this.label5.Text = "Situação";
            // 
            // cbSituacao
            // 
            this.cbSituacao.DisplayMember = "Nome";
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbSituacao.Location = new System.Drawing.Point(30, 230);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(252, 23);
            this.cbSituacao.TabIndex = 52;
            this.cbSituacao.ValueMember = "Id";
            this.cbSituacao.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label6.Location = new System.Drawing.Point(528, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 55;
            this.label6.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.White;
            this.txtValor.Location = new System.Drawing.Point(305, 230);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(252, 23);
            this.txtValor.TabIndex = 56;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeyDown);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // tbFornecedorNome
            // 
            this.tbFornecedorNome.BackColor = System.Drawing.Color.White;
            this.tbFornecedorNome.Location = new System.Drawing.Point(376, 168);
            this.tbFornecedorNome.Name = "tbFornecedorNome";
            this.tbFornecedorNome.ReadOnly = true;
            this.tbFornecedorNome.Size = new System.Drawing.Size(181, 23);
            this.tbFornecedorNome.TabIndex = 57;
            // 
            // txtSituacao
            // 
            this.txtSituacao.BackColor = System.Drawing.Color.White;
            this.txtSituacao.Location = new System.Drawing.Point(30, 259);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.Size = new System.Drawing.Size(253, 23);
            this.txtSituacao.TabIndex = 58;
            this.txtSituacao.Visible = false;
            // 
            // ContaPagarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 366);
            this.Controls.Add(this.txtSituacao);
            this.Controls.Add(this.tbFornecedorNome);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSituacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtVencimento);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtLancamento);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFornecedor);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContaPagarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conta à Pagar";
            this.Load += new System.EventHandler(this.Load_ContaPagar);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbFornecedor;
        private CustomControls.RJControls.DateTimePickerCustom dtLancamento;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CustomControls.RJControls.DateTimePickerCustom dtVencimento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox tbFornecedorNome;
        private System.Windows.Forms.TextBox txtSituacao;
    }
}