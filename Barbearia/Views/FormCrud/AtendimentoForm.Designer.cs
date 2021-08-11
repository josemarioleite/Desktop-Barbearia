
namespace Barbersoft.Views.FormCrud
{
    partial class formAtendimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAtendimento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbProfissional = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.linhaSituacao = new System.Windows.Forms.Panel();
            this.lblData = new System.Windows.Forms.Label();
            this.linhaData = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtData = new System.Windows.Forms.MaskedTextBox();
            this.tbClienteNome = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 54);
            this.panel1.TabIndex = 14;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(13, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(131, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Atendimento";
            // 
            // cbCliente
            // 
            this.cbCliente.BackColor = System.Drawing.Color.White;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(14, 113);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(71, 23);
            this.cbCliente.TabIndex = 34;
            this.cbCliente.Click += new System.EventHandler(this.Cliente_CBClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(10, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Cliente";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel2.Location = new System.Drawing.Point(14, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 1);
            this.panel2.TabIndex = 32;
            // 
            // cbProfissional
            // 
            this.cbProfissional.BackColor = System.Drawing.Color.White;
            this.cbProfissional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbProfissional.FormattingEnabled = true;
            this.cbProfissional.Location = new System.Drawing.Point(341, 111);
            this.cbProfissional.Name = "cbProfissional";
            this.cbProfissional.Size = new System.Drawing.Size(264, 23);
            this.cbProfissional.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(337, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Profissional";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel3.Location = new System.Drawing.Point(341, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 1);
            this.panel3.TabIndex = 35;
            // 
            // cbSituacao
            // 
            this.cbSituacao.BackColor = System.Drawing.Color.White;
            this.cbSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Location = new System.Drawing.Point(14, 183);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(269, 23);
            this.cbSituacao.TabIndex = 40;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.lblSituacao.Location = new System.Drawing.Point(11, 165);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(52, 15);
            this.lblSituacao.TabIndex = 39;
            this.lblSituacao.Text = "Situação";
            // 
            // linhaSituacao
            // 
            this.linhaSituacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.linhaSituacao.Location = new System.Drawing.Point(13, 212);
            this.linhaSituacao.Name = "linhaSituacao";
            this.linhaSituacao.Size = new System.Drawing.Size(270, 1);
            this.linhaSituacao.TabIndex = 38;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.lblData.Location = new System.Drawing.Point(338, 165);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(121, 15);
            this.lblData.TabIndex = 43;
            this.lblData.Text = "Data do Atendimento";
            // 
            // linhaData
            // 
            this.linhaData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.linhaData.Location = new System.Drawing.Point(341, 212);
            this.linhaData.Name = "linhaData";
            this.linhaData.Size = new System.Drawing.Size(264, 1);
            this.linhaData.TabIndex = 45;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 232);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(624, 58);
            this.panel5.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(314, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 38);
            this.button1.TabIndex = 20;
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
            this.button2.Location = new System.Drawing.Point(211, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 38);
            this.button2.TabIndex = 19;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BtnSair);
            // 
            // dtData
            // 
            this.dtData.BackColor = System.Drawing.Color.White;
            this.dtData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtData.Location = new System.Drawing.Point(341, 186);
            this.dtData.Mask = "00/00/0000";
            this.dtData.Name = "dtData";
            this.dtData.ReadOnly = true;
            this.dtData.Size = new System.Drawing.Size(264, 16);
            this.dtData.TabIndex = 47;
            this.dtData.ValidatingType = typeof(System.DateTime);
            // 
            // tbClienteNome
            // 
            this.tbClienteNome.BackColor = System.Drawing.Color.White;
            this.tbClienteNome.Location = new System.Drawing.Point(91, 113);
            this.tbClienteNome.Name = "tbClienteNome";
            this.tbClienteNome.ReadOnly = true;
            this.tbClienteNome.Size = new System.Drawing.Size(192, 23);
            this.tbClienteNome.TabIndex = 58;
            // 
            // formAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 290);
            this.Controls.Add(this.tbClienteNome);
            this.Controls.Add(this.dtData);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.linhaData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.cbSituacao);
            this.Controls.Add(this.lblSituacao);
            this.Controls.Add(this.linhaSituacao);
            this.Controls.Add(this.cbProfissional);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formAtendimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atendimento";
            this.Load += new System.EventHandler(this.AtendimentoLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Atendimento_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbProfissional;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Panel linhaSituacao;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Panel linhaData;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox dtData;
        private System.Windows.Forms.TextBox tbClienteNome;
    }
}