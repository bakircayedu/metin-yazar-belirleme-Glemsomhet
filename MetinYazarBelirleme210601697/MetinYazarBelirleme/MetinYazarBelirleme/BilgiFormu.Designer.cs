namespace MetinYazarBelirleme
{
    partial class BilgiFormu
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
            this.txtToplamCumle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToplamKelime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrtalama = new System.Windows.Forms.TextBox();
            this.lstCumleler = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toplam cümle sayısı: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtToplamCumle
            // 
            this.txtToplamCumle.Location = new System.Drawing.Point(168, 15);
            this.txtToplamCumle.Name = "txtToplamCumle";
            this.txtToplamCumle.ReadOnly = true;
            this.txtToplamCumle.Size = new System.Drawing.Size(100, 20);
            this.txtToplamCumle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Toplam kelime sayısı: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtToplamKelime
            // 
            this.txtToplamKelime.Location = new System.Drawing.Point(168, 48);
            this.txtToplamKelime.Name = "txtToplamKelime";
            this.txtToplamKelime.ReadOnly = true;
            this.txtToplamKelime.Size = new System.Drawing.Size(100, 20);
            this.txtToplamKelime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ortalama kelime sayısı: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrtalama
            // 
            this.txtOrtalama.Location = new System.Drawing.Point(168, 81);
            this.txtOrtalama.Name = "txtOrtalama";
            this.txtOrtalama.ReadOnly = true;
            this.txtOrtalama.Size = new System.Drawing.Size(100, 20);
            this.txtOrtalama.TabIndex = 5;
            // 
            // lstCumleler
            // 
            this.lstCumleler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCumleler.FormattingEnabled = true;
            this.lstCumleler.Location = new System.Drawing.Point(168, 107);
            this.lstCumleler.Name = "lstCumleler";
            this.lstCumleler.Size = new System.Drawing.Size(290, 277);
            this.lstCumleler.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cümlelerdeki kelime sayıları:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(274, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 86);
            this.button1.TabIndex = 7;
            this.button1.Text = "&Kapat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BilgiFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 399);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstCumleler);
            this.Controls.Add(this.txtOrtalama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtToplamKelime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToplamCumle);
            this.Controls.Add(this.label1);
            this.Name = "BilgiFormu";
            this.Text = "Bilgi Formu";
            this.Load += new System.EventHandler(this.BilgiFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToplamCumle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToplamKelime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrtalama;
        private System.Windows.Forms.ListBox lstCumleler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}