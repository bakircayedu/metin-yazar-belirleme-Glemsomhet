namespace MetinYazarBelirleme
{
    partial class HashTabloFormu
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
            this.lstKelimeler = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKelime = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTekrar = new System.Windows.Forms.TextBox();
            this.btnKapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstKelimeler
            // 
            this.lstKelimeler.FormattingEnabled = true;
            this.lstKelimeler.Location = new System.Drawing.Point(12, 12);
            this.lstKelimeler.Name = "lstKelimeler";
            this.lstKelimeler.Size = new System.Drawing.Size(227, 420);
            this.lstKelimeler.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(248, 12);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(144, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Kelime: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtKelime
            // 
            this.txtKelime.Location = new System.Drawing.Point(248, 50);
            this.txtKelime.Name = "txtKelime";
            this.txtKelime.Size = new System.Drawing.Size(144, 20);
            this.txtKelime.TabIndex = 2;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(248, 76);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(144, 42);
            this.btnAra.TabIndex = 3;
            this.btnAra.Text = "&Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(248, 141);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tekrar Sayısı:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtTekrar
            // 
            this.txtTekrar.Location = new System.Drawing.Point(248, 174);
            this.txtTekrar.Name = "txtTekrar";
            this.txtTekrar.ReadOnly = true;
            this.txtTekrar.Size = new System.Drawing.Size(144, 20);
            this.txtTekrar.TabIndex = 5;
            // 
            // btnKapat
            // 
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnKapat.Location = new System.Drawing.Point(248, 356);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(144, 76);
            this.btnKapat.TabIndex = 6;
            this.btnKapat.Text = "&Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // HashTabloFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 450);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.txtTekrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtKelime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstKelimeler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "HashTabloFormu";
            this.Text = "HashTabloFormu";
            this.Load += new System.EventHandler(this.HashTabloFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstKelimeler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKelime;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTekrar;
        private System.Windows.Forms.Button btnKapat;
    }
}