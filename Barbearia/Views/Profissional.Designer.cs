
namespace Barbearia.Views
{
    partial class Profissional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profissional));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedButton3 = new Barbearia.Custom.RoundedButton();
            this.roundedButton2 = new Barbearia.Custom.RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtadd = new System.Windows.Forms.Label();
            this.dgProfissional = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfissional)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.roundedButton3);
            this.panel1.Controls.Add(this.roundedButton2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtadd);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 74);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 426);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(11, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 44);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnAdicionar);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(89, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Alterar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(159, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Excluir";
            // 
            // roundedButton3
            // 
            this.roundedButton3.BackColor = System.Drawing.Color.Transparent;
            this.roundedButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundedButton3.BackgroundImage")));
            this.roundedButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedButton3.BorderColor = System.Drawing.Color.Empty;
            this.roundedButton3.ButtonColor = System.Drawing.Color.Empty;
            this.roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton3.ForeColor = System.Drawing.Color.Transparent;
            this.roundedButton3.Location = new System.Drawing.Point(152, 10);
            this.roundedButton3.Name = "roundedButton3";
            this.roundedButton3.OnHoverBorderColor = System.Drawing.Color.Empty;
            this.roundedButton3.OnHoverButtonColor = System.Drawing.Color.Empty;
            this.roundedButton3.OnHoverTextColor = System.Drawing.Color.Empty;
            this.roundedButton3.Size = new System.Drawing.Size(53, 46);
            this.roundedButton3.TabIndex = 4;
            this.roundedButton3.TextColor = System.Drawing.Color.Empty;
            this.roundedButton3.UseVisualStyleBackColor = false;
            this.roundedButton3.Click += new System.EventHandler(this.BtnExcluir);
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.Transparent;
            this.roundedButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundedButton2.BackgroundImage")));
            this.roundedButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedButton2.BorderColor = System.Drawing.Color.Empty;
            this.roundedButton2.ButtonColor = System.Drawing.Color.Empty;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.ForeColor = System.Drawing.Color.Transparent;
            this.roundedButton2.Location = new System.Drawing.Point(81, 10);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.OnHoverBorderColor = System.Drawing.Color.Empty;
            this.roundedButton2.OnHoverButtonColor = System.Drawing.Color.Empty;
            this.roundedButton2.OnHoverTextColor = System.Drawing.Color.Empty;
            this.roundedButton2.Size = new System.Drawing.Size(53, 46);
            this.roundedButton2.TabIndex = 3;
            this.roundedButton2.TextColor = System.Drawing.Color.Empty;
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.BtnAlterar);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Barbersoft.Properties.Resources.Logo_Empresa_Barbersoft1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(586, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtadd
            // 
            this.txtadd.AutoSize = true;
            this.txtadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtadd.ForeColor = System.Drawing.Color.White;
            this.txtadd.Location = new System.Drawing.Point(11, 57);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(51, 13);
            this.txtadd.TabIndex = 1;
            this.txtadd.Text = "Adicionar";
            // 
            // dgProfissional
            // 
            this.dgProfissional.AllowUserToAddRows = false;
            this.dgProfissional.AllowUserToDeleteRows = false;
            this.dgProfissional.AllowUserToResizeColumns = false;
            this.dgProfissional.AllowUserToResizeRows = false;
            this.dgProfissional.BackgroundColor = System.Drawing.Color.White;
            this.dgProfissional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgProfissional.Location = new System.Drawing.Point(0, 73);
            this.dgProfissional.Name = "dgProfissional";
            this.dgProfissional.ReadOnly = true;
            this.dgProfissional.RowTemplate.Height = 25;
            this.dgProfissional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProfissional.Size = new System.Drawing.Size(863, 423);
            this.dgProfissional.TabIndex = 2;
            // 
            // Profissional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 496);
            this.Controls.Add(this.dgProfissional);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Profissional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profissional";
            this.Load += new System.EventHandler(this.FormProfissionalLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfissional)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Custom.RoundedButton roundedButton3;
        private Custom.RoundedButton roundedButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtadd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgProfissional;
    }
}