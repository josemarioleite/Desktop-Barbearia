
namespace Barbersoft.Views
{
    partial class AtendimentoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtendimentoView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.cbDados = new System.Windows.Forms.ComboBox();
            this.cbPesquisa = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtadd = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgAtendimento = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtendimento)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.lblDataFinal);
            this.panel1.Controls.Add(this.lblDataInicial);
            this.panel1.Controls.Add(this.dtFinal);
            this.panel1.Controls.Add(this.dtInicial);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cbDados);
            this.panel1.Controls.Add(this.cbPesquisa);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtadd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 123);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(287, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Cancelar";
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(285, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(51, 44);
            this.button5.TabIndex = 50;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BtnCancelar);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(222, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Fechar";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(215, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 44);
            this.button4.TabIndex = 48;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BtnFechar);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDataFinal.ForeColor = System.Drawing.Color.White;
            this.lblDataFinal.Location = new System.Drawing.Point(290, 82);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(29, 13);
            this.lblDataFinal.TabIndex = 47;
            this.lblDataFinal.Text = "Final";
            this.lblDataFinal.Visible = false;
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDataInicial.ForeColor = System.Drawing.Color.White;
            this.lblDataInicial.Location = new System.Drawing.Point(191, 82);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(34, 13);
            this.lblDataInicial.TabIndex = 46;
            this.lblDataInicial.Text = "Início";
            this.lblDataInicial.Visible = false;
            // 
            // dtFinal
            // 
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFinal.Location = new System.Drawing.Point(292, 97);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(95, 20);
            this.dtFinal.TabIndex = 45;
            this.dtFinal.Visible = false;
            // 
            // dtInicial
            // 
            this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicial.Location = new System.Drawing.Point(193, 97);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(95, 20);
            this.dtInicial.TabIndex = 44;
            this.dtInicial.Visible = false;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(430, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 30);
            this.button3.TabIndex = 43;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnLimpar);
            // 
            // cbDados
            // 
            this.cbDados.BackColor = System.Drawing.Color.White;
            this.cbDados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDados.FormattingEnabled = true;
            this.cbDados.Location = new System.Drawing.Point(193, 97);
            this.cbDados.Name = "cbDados";
            this.cbDados.Size = new System.Drawing.Size(194, 21);
            this.cbDados.TabIndex = 42;
            // 
            // cbPesquisa
            // 
            this.cbPesquisa.BackColor = System.Drawing.Color.White;
            this.cbPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPesquisa.FormattingEnabled = true;
            this.cbPesquisa.Items.AddRange(new object[] {
            "Cliente",
            "Data",
            "Profissional",
            "Situação"});
            this.cbPesquisa.Location = new System.Drawing.Point(68, 97);
            this.cbPesquisa.Name = "cbPesquisa";
            this.cbPesquisa.Size = new System.Drawing.Size(119, 21);
            this.cbPesquisa.TabIndex = 41;
            this.cbPesquisa.SelectedValueChanged += new System.EventHandler(this.ValorSelecionado);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(393, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 30);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnPesquisar);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Pesquisar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Visualizar";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(8, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 44);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnVisualizar);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackgroundImage = global::Barbersoft.Properties.Resources.Delete;
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(146, 10);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(51, 44);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(77, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 44);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdicionar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(153, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Excluir";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Barbersoft.Properties.Resources.Logo_Empresa_Barbersoft1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(550, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 44);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtadd
            // 
            this.txtadd.AutoSize = true;
            this.txtadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtadd.ForeColor = System.Drawing.Color.White;
            this.txtadd.Location = new System.Drawing.Point(77, 57);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(51, 13);
            this.txtadd.TabIndex = 1;
            this.txtadd.Text = "Adicionar";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgAtendimento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 398);
            this.panel2.TabIndex = 3;
            // 
            // dgAtendimento
            // 
            this.dgAtendimento.AllowUserToAddRows = false;
            this.dgAtendimento.AllowUserToDeleteRows = false;
            this.dgAtendimento.AllowUserToResizeColumns = false;
            this.dgAtendimento.AllowUserToResizeRows = false;
            this.dgAtendimento.BackgroundColor = System.Drawing.Color.White;
            this.dgAtendimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgAtendimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAtendimento.Location = new System.Drawing.Point(0, 0);
            this.dgAtendimento.MultiSelect = false;
            this.dgAtendimento.Name = "dgAtendimento";
            this.dgAtendimento.ReadOnly = true;
            this.dgAtendimento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgAtendimento.RowTemplate.Height = 25;
            this.dgAtendimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAtendimento.Size = new System.Drawing.Size(809, 398);
            this.dgAtendimento.TabIndex = 0;
            // 
            // AtendimentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 521);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AtendimentoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atendimento";
            this.Load += new System.EventHandler(this.AtendimentoLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Atendimento_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAtendimento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtadd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgAtendimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbDados;
        private System.Windows.Forms.ComboBox cbPesquisa;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.DateTimePicker dtInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
    }
}