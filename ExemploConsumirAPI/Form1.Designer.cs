namespace ExemploConsumirAPI
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMarcador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudLinha = new System.Windows.Forms.NumericUpDown();
            this.nudColuna = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnJogar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRetorno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLinha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColuna)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(50, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(421, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "http://192.168.1.5:9000/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marcador:";
            // 
            // cmbMarcador
            // 
            this.cmbMarcador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMarcador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMarcador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarcador.FormattingEnabled = true;
            this.cmbMarcador.Items.AddRange(new object[] {
            "X",
            "O"});
            this.cmbMarcador.Location = new System.Drawing.Point(73, 51);
            this.cmbMarcador.Name = "cmbMarcador";
            this.cmbMarcador.Size = new System.Drawing.Size(121, 21);
            this.cmbMarcador.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Linha:";
            // 
            // nudLinha
            // 
            this.nudLinha.Location = new System.Drawing.Point(74, 87);
            this.nudLinha.Name = "nudLinha";
            this.nudLinha.Size = new System.Drawing.Size(120, 20);
            this.nudLinha.TabIndex = 5;
            // 
            // nudColuna
            // 
            this.nudColuna.Location = new System.Drawing.Point(73, 113);
            this.nudColuna.Name = "nudColuna";
            this.nudColuna.Size = new System.Drawing.Size(120, 20);
            this.nudColuna.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Coluna:";
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(27, 150);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(444, 23);
            this.btnJogar.TabIndex = 8;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRetorno);
            this.groupBox1.Location = new System.Drawing.Point(200, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retorno da API";
            // 
            // txtRetorno
            // 
            this.txtRetorno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRetorno.Location = new System.Drawing.Point(3, 16);
            this.txtRetorno.Multiline = true;
            this.txtRetorno.Name = "txtRetorno";
            this.txtRetorno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRetorno.Size = new System.Drawing.Size(265, 81);
            this.txtRetorno.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 186);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.nudColuna);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudLinha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMarcador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exemplo Consumir API";
            ((System.ComponentModel.ISupportInitialize)(this.nudLinha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColuna)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMarcador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudLinha;
        private System.Windows.Forms.NumericUpDown nudColuna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRetorno;
    }
}

