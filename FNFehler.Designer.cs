﻿namespace FotoNamen
{
    partial class FFehler
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
        private void InitializeComponent()
        {
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lKamera = new System.Windows.Forms.Label();
            this.lHersteller = new System.Windows.Forms.Label();
            this.lDtDigit = new System.Windows.Forms.Label();
            this.lDtOrig = new System.Windows.Forms.Label();
            this.lDtMain = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lDatei = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pb1.Location = new System.Drawing.Point(12, 12);
            this.pb1.MinimumSize = new System.Drawing.Size(200, 200);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(547, 375);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb1.TabIndex = 3;
            this.pb1.TabStop = false;
            this.pb1.WaitOnLoad = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lDatei);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lKamera);
            this.groupBox1.Controls.Add(this.lHersteller);
            this.groupBox1.Controls.Add(this.lDtDigit);
            this.groupBox1.Controls.Add(this.lDtOrig);
            this.groupBox1.Controls.Add(this.lDtMain);
            this.groupBox1.Location = new System.Drawing.Point(12, 393);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilddaten";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kamera:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hersteller:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "digitalisiert:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Original:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Main:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lKamera
            // 
            this.lKamera.AutoSize = true;
            this.lKamera.Location = new System.Drawing.Point(72, 81);
            this.lKamera.Name = "lKamera";
            this.lKamera.Size = new System.Drawing.Size(43, 13);
            this.lKamera.TabIndex = 4;
            this.lKamera.Text = "Kamera";
            // 
            // lHersteller
            // 
            this.lHersteller.AutoSize = true;
            this.lHersteller.Location = new System.Drawing.Point(72, 68);
            this.lHersteller.Name = "lHersteller";
            this.lHersteller.Size = new System.Drawing.Size(51, 13);
            this.lHersteller.TabIndex = 3;
            this.lHersteller.Text = "Hersteller";
            // 
            // lDtDigit
            // 
            this.lDtDigit.AutoSize = true;
            this.lDtDigit.Location = new System.Drawing.Point(72, 42);
            this.lDtDigit.Name = "lDtDigit";
            this.lDtDigit.Size = new System.Drawing.Size(39, 13);
            this.lDtDigit.TabIndex = 2;
            this.lDtDigit.Text = "DtDigit";
            // 
            // lDtOrig
            // 
            this.lDtOrig.AutoSize = true;
            this.lDtOrig.Location = new System.Drawing.Point(72, 29);
            this.lDtOrig.Name = "lDtOrig";
            this.lDtOrig.Size = new System.Drawing.Size(37, 13);
            this.lDtOrig.TabIndex = 1;
            this.lDtOrig.Text = "DtOrig";
            // 
            // lDtMain
            // 
            this.lDtMain.AutoSize = true;
            this.lDtMain.Location = new System.Drawing.Point(72, 16);
            this.lDtMain.Name = "lDtMain";
            this.lDtMain.Size = new System.Drawing.Size(43, 13);
            this.lDtMain.TabIndex = 0;
            this.lDtMain.Text = "lDtMain";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(403, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "abbrechen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(484, 499);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "weiter";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Datei:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lDatei
            // 
            this.lDatei.AutoSize = true;
            this.lDatei.Location = new System.Drawing.Point(72, 55);
            this.lDatei.Name = "lDatei";
            this.lDatei.Size = new System.Drawing.Size(32, 13);
            this.lDatei.TabIndex = 10;
            this.lDatei.Text = "Datei";
            // 
            // fFehler
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(568, 533);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pb1);
            this.Name = "fFehler";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fehler";
            this.Shown += new System.EventHandler(this.fFehler_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lKamera;
        private System.Windows.Forms.Label lHersteller;
        private System.Windows.Forms.Label lDtDigit;
        private System.Windows.Forms.Label lDtOrig;
        private System.Windows.Forms.Label lDtMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lDatei;
    }
}