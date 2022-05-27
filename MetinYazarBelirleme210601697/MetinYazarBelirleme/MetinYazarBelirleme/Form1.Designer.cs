namespace MetinYazarBelirleme
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMetinYukle = new System.Windows.Forms.Button();
            this.txtDosyaYolu = new System.Windows.Forms.TextBox();
            this.btnStackOku = new System.Windows.Forms.Button();
            this.btnHash = new System.Windows.Forms.Button();
            this.lstKelimeler = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lstBasit = new System.Windows.Forms.ListBox();
            this.lblDosya = new System.Windows.Forms.Label();
            this.btnBilgi = new System.Windows.Forms.Button();
            this.btnAgac = new System.Windows.Forms.Button();
            this.btnKelimeler = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMetinYukle
            // 
            this.btnMetinYukle.Location = new System.Drawing.Point(9, 10);
            this.btnMetinYukle.Margin = new System.Windows.Forms.Padding(2);
            this.btnMetinYukle.Name = "btnMetinYukle";
            this.btnMetinYukle.Size = new System.Drawing.Size(112, 31);
            this.btnMetinYukle.TabIndex = 0;
            this.btnMetinYukle.Text = "&Metin Yükle";
            this.btnMetinYukle.UseVisualStyleBackColor = true;
            this.btnMetinYukle.Click += new System.EventHandler(this.btnMetinYukle_Click);
            // 
            // txtDosyaYolu
            // 
            this.txtDosyaYolu.Location = new System.Drawing.Point(126, 15);
            this.txtDosyaYolu.Margin = new System.Windows.Forms.Padding(2);
            this.txtDosyaYolu.Name = "txtDosyaYolu";
            this.txtDosyaYolu.ReadOnly = true;
            this.txtDosyaYolu.Size = new System.Drawing.Size(212, 20);
            this.txtDosyaYolu.TabIndex = 1;
            this.txtDosyaYolu.TextChanged += new System.EventHandler(this.txtDosyaYolu_TextChanged);
            // 
            // btnStackOku
            // 
            this.btnStackOku.Enabled = false;
            this.btnStackOku.Location = new System.Drawing.Point(341, 8);
            this.btnStackOku.Margin = new System.Windows.Forms.Padding(2);
            this.btnStackOku.Name = "btnStackOku";
            this.btnStackOku.Size = new System.Drawing.Size(112, 31);
            this.btnStackOku.TabIndex = 2;
            this.btnStackOku.Text = "&Stack\'e Oku";
            this.btnStackOku.UseVisualStyleBackColor = true;
            this.btnStackOku.Click += new System.EventHandler(this.btnStackOku_Click);
            // 
            // btnHash
            // 
            this.btnHash.Enabled = false;
            this.btnHash.Location = new System.Drawing.Point(458, 8);
            this.btnHash.Margin = new System.Windows.Forms.Padding(2);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(112, 31);
            this.btnHash.TabIndex = 3;
            this.btnHash.Text = "&Hash Tablo Oluştur";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // lstKelimeler
            // 
            this.lstKelimeler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstKelimeler.FormattingEnabled = true;
            this.lstKelimeler.Location = new System.Drawing.Point(126, 48);
            this.lstKelimeler.Name = "lstKelimeler";
            this.lstKelimeler.Size = new System.Drawing.Size(445, 342);
            this.lstKelimeler.Sorted = true;
            this.lstKelimeler.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(818, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // lstBasit
            // 
            this.lstBasit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBasit.FormattingEnabled = true;
            this.lstBasit.Location = new System.Drawing.Point(577, 48);
            this.lstBasit.Name = "lstBasit";
            this.lstBasit.Size = new System.Drawing.Size(229, 342);
            this.lstBasit.TabIndex = 6;
            // 
            // lblDosya
            // 
            this.lblDosya.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDosya.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDosya.Location = new System.Drawing.Point(575, 9);
            this.lblDosya.Name = "lblDosya";
            this.lblDosya.Size = new System.Drawing.Size(231, 30);
            this.lblDosya.TabIndex = 7;
            this.lblDosya.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBilgi
            // 
            this.btnBilgi.Enabled = false;
            this.btnBilgi.Location = new System.Drawing.Point(9, 48);
            this.btnBilgi.Name = "btnBilgi";
            this.btnBilgi.Size = new System.Drawing.Size(112, 31);
            this.btnBilgi.TabIndex = 8;
            this.btnBilgi.Text = "&Bilgi Formu";
            this.btnBilgi.UseVisualStyleBackColor = true;
            this.btnBilgi.Click += new System.EventHandler(this.btnBilgi_Click);
            // 
            // btnAgac
            // 
            this.btnAgac.Enabled = false;
            this.btnAgac.Location = new System.Drawing.Point(9, 85);
            this.btnAgac.Name = "btnAgac";
            this.btnAgac.Size = new System.Drawing.Size(112, 31);
            this.btnAgac.TabIndex = 9;
            this.btnAgac.Text = "&Ağaca Aktar";
            this.btnAgac.UseVisualStyleBackColor = true;
            this.btnAgac.Click += new System.EventHandler(this.btnAgac_Click);
            // 
            // btnKelimeler
            // 
            this.btnKelimeler.Enabled = false;
            this.btnKelimeler.Location = new System.Drawing.Point(9, 122);
            this.btnKelimeler.Name = "btnKelimeler";
            this.btnKelimeler.Size = new System.Drawing.Size(112, 63);
            this.btnKelimeler.TabIndex = 10;
            this.btnKelimeler.Text = "En Sık Kullanılan Kelimeleri Getir";
            this.btnKelimeler.UseVisualStyleBackColor = true;
            this.btnKelimeler.Click += new System.EventHandler(this.btnKelimeler_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 435);
            this.Controls.Add(this.btnKelimeler);
            this.Controls.Add(this.btnAgac);
            this.Controls.Add(this.btnBilgi);
            this.Controls.Add(this.lblDosya);
            this.Controls.Add(this.lstBasit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstKelimeler);
            this.Controls.Add(this.btnHash);
            this.Controls.Add(this.btnStackOku);
            this.Controls.Add(this.txtDosyaYolu);
            this.Controls.Add(this.btnMetinYukle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "BMGülbe - METİN YAZARI BELİRLEME";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMetinYukle;
        private System.Windows.Forms.TextBox txtDosyaYolu;
        private System.Windows.Forms.Button btnStackOku;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.ListBox lstKelimeler;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ListBox lstBasit;
        private System.Windows.Forms.Label lblDosya;
        private System.Windows.Forms.Button btnBilgi;
        private System.Windows.Forms.Button btnAgac;
        private System.Windows.Forms.Button btnKelimeler;
    }
}

