namespace FotoNamen
{
    partial class fFNMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFNMain));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.tbName = new System.Windows.Forms.TextBox();
      this.cbName = new System.Windows.Forms.CheckBox();
      this.lCrea = new System.Windows.Forms.Label();
      this.lChan = new System.Windows.Forms.Label();
      this.lVerz = new System.Windows.Forms.Label();
      this.bVerz = new System.Windows.Forms.Button();
      this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.bBearb = new System.Windows.Forms.Button();
      this.lGr = new System.Windows.Forms.Label();
      this.lDat = new System.Windows.Forms.Label();
      this.bAuswert = new System.Windows.Forms.Button();
      this.lAnz = new System.Windows.Forms.Label();
      this.pb1 = new System.Windows.Forms.PictureBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.lFertig = new System.Windows.Forms.Label();
      this.lWarten = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.tbPrfix = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.rbDigitized = new System.Windows.Forms.RadioButton();
      this.rbOriginal = new System.Windows.Forms.RadioButton();
      this.rbMain = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.rbFragen = new System.Windows.Forms.RadioButton();
      this.gbHilfe = new System.Windows.Forms.GroupBox();
      this.lHilfe = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
      this.groupBox3.SuspendLayout();
      this.gbHilfe.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.tbName);
      this.groupBox1.Controls.Add(this.cbName);
      this.groupBox1.Controls.Add(this.lCrea);
      this.groupBox1.Controls.Add(this.lChan);
      this.groupBox1.Controls.Add(this.lVerz);
      this.groupBox1.Controls.Add(this.bVerz);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(393, 144);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Verzeichnis";
      // 
      // tbName
      // 
      this.tbName.Location = new System.Drawing.Point(9, 101);
      this.tbName.Name = "tbName";
      this.tbName.Size = new System.Drawing.Size(378, 20);
      this.tbName.TabIndex = 4;
      this.tbName.Text = "*";
      this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
      // 
      // cbName
      // 
      this.cbName.AutoSize = true;
      this.cbName.Location = new System.Drawing.Point(9, 78);
      this.cbName.Name = "cbName";
      this.cbName.Size = new System.Drawing.Size(176, 17);
      this.cbName.TabIndex = 5;
      this.cbName.Text = "nur Dateien, die beginnen mit ...";
      this.cbName.UseVisualStyleBackColor = true;
      this.cbName.Click += new System.EventHandler(this.cbName_Click);
      // 
      // lCrea
      // 
      this.lCrea.AutoSize = true;
      this.lCrea.Location = new System.Drawing.Point(6, 29);
      this.lCrea.Name = "lCrea";
      this.lCrea.Size = new System.Drawing.Size(48, 13);
      this.lCrea.TabIndex = 4;
      this.lCrea.Text = "erzeugt?";
      // 
      // lChan
      // 
      this.lChan.AutoSize = true;
      this.lChan.Location = new System.Drawing.Point(6, 42);
      this.lChan.Name = "lChan";
      this.lChan.Size = new System.Drawing.Size(55, 13);
      this.lChan.TabIndex = 3;
      this.lChan.Text = "geändert?";
      // 
      // lVerz
      // 
      this.lVerz.AutoSize = true;
      this.lVerz.Location = new System.Drawing.Point(6, 16);
      this.lVerz.Name = "lVerz";
      this.lVerz.Size = new System.Drawing.Size(67, 13);
      this.lVerz.TabIndex = 2;
      this.lVerz.Text = "Verzeichnis?";
      // 
      // bVerz
      // 
      this.bVerz.Location = new System.Drawing.Point(307, 45);
      this.bVerz.Name = "bVerz";
      this.bVerz.Size = new System.Drawing.Size(80, 23);
      this.bVerz.TabIndex = 1;
      this.bVerz.Text = "ändern";
      this.bVerz.UseVisualStyleBackColor = true;
      this.bVerz.Click += new System.EventHandler(this.tbVerz_Click);
      this.bVerz.MouseEnter += new System.EventHandler(this.bVerz_MouseEnter);
      // 
      // fbd1
      // 
      this.fbd1.Description = "Verzeichnis mit den Fotos";
      this.fbd1.ShowNewFolderButton = false;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.bBearb);
      this.groupBox2.Controls.Add(this.lGr);
      this.groupBox2.Controls.Add(this.lDat);
      this.groupBox2.Controls.Add(this.bAuswert);
      this.groupBox2.Controls.Add(this.lAnz);
      this.groupBox2.Location = new System.Drawing.Point(12, 162);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(393, 75);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Inhalt";
      // 
      // bBearb
      // 
      this.bBearb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bBearb.Location = new System.Drawing.Point(307, 42);
      this.bBearb.Name = "bBearb";
      this.bBearb.Size = new System.Drawing.Size(80, 23);
      this.bBearb.TabIndex = 10;
      this.bBearb.Text = "testen";
      this.bBearb.UseVisualStyleBackColor = true;
      this.bBearb.Click += new System.EventHandler(this.bBearb_Click);
      this.bBearb.MouseEnter += new System.EventHandler(this.bBearb_MouseEnter);
      // 
      // lGr
      // 
      this.lGr.AutoSize = true;
      this.lGr.Location = new System.Drawing.Point(6, 42);
      this.lGr.Name = "lGr";
      this.lGr.Size = new System.Drawing.Size(42, 13);
      this.lGr.TabIndex = 9;
      this.lGr.Text = "Größe?";
      // 
      // lDat
      // 
      this.lDat.AutoSize = true;
      this.lDat.Location = new System.Drawing.Point(6, 29);
      this.lDat.Name = "lDat";
      this.lDat.Size = new System.Drawing.Size(44, 13);
      this.lDat.TabIndex = 8;
      this.lDat.Text = "Datum?";
      // 
      // bAuswert
      // 
      this.bAuswert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bAuswert.Location = new System.Drawing.Point(307, 11);
      this.bAuswert.Name = "bAuswert";
      this.bAuswert.Size = new System.Drawing.Size(80, 23);
      this.bAuswert.TabIndex = 7;
      this.bAuswert.Text = "auswerten";
      this.bAuswert.UseVisualStyleBackColor = true;
      this.bAuswert.Click += new System.EventHandler(this.bAuswert_Click);
      this.bAuswert.MouseEnter += new System.EventHandler(this.bAuswert_MouseEnter);
      // 
      // lAnz
      // 
      this.lAnz.AutoSize = true;
      this.lAnz.Location = new System.Drawing.Point(6, 16);
      this.lAnz.Name = "lAnz";
      this.lAnz.Size = new System.Drawing.Size(39, 13);
      this.lAnz.TabIndex = 6;
      this.lAnz.Text = "Fotos?";
      // 
      // pb1
      // 
      this.pb1.Location = new System.Drawing.Point(411, 12);
      this.pb1.Name = "pb1";
      this.pb1.Size = new System.Drawing.Size(248, 257);
      this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb1.TabIndex = 2;
      this.pb1.TabStop = false;
      this.pb1.WaitOnLoad = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.lFertig);
      this.groupBox3.Controls.Add(this.lWarten);
      this.groupBox3.Controls.Add(this.button1);
      this.groupBox3.Controls.Add(this.tbPrfix);
      this.groupBox3.Controls.Add(this.label2);
      this.groupBox3.Controls.Add(this.rbDigitized);
      this.groupBox3.Controls.Add(this.rbOriginal);
      this.groupBox3.Controls.Add(this.rbMain);
      this.groupBox3.Controls.Add(this.label1);
      this.groupBox3.Controls.Add(this.rbFragen);
      this.groupBox3.Location = new System.Drawing.Point(12, 243);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(393, 116);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "umbenennen";
      // 
      // lFertig
      // 
      this.lFertig.AutoSize = true;
      this.lFertig.BackColor = System.Drawing.Color.Lime;
      this.lFertig.Location = new System.Drawing.Point(60, 92);
      this.lFertig.Name = "lFertig";
      this.lFertig.Size = new System.Drawing.Size(33, 13);
      this.lFertig.TabIndex = 13;
      this.lFertig.Text = "fertig!";
      this.lFertig.Visible = false;
      // 
      // lWarten
      // 
      this.lWarten.AutoSize = true;
      this.lWarten.BackColor = System.Drawing.Color.Red;
      this.lWarten.ForeColor = System.Drawing.Color.White;
      this.lWarten.Location = new System.Drawing.Point(6, 92);
      this.lWarten.Name = "lWarten";
      this.lWarten.Size = new System.Drawing.Size(48, 13);
      this.lWarten.TabIndex = 12;
      this.lWarten.Text = "warten...";
      this.lWarten.Visible = false;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(307, 82);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(80, 23);
      this.button1.TabIndex = 11;
      this.button1.Text = "umbenennen";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbPrfix
      // 
      this.tbPrfix.Location = new System.Drawing.Point(149, 56);
      this.tbPrfix.Name = "tbPrfix";
      this.tbPrfix.Size = new System.Drawing.Size(238, 20);
      this.tbPrfix.TabIndex = 10;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(46, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(97, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Präfix neuer Name:";
      // 
      // rbDigitized
      // 
      this.rbDigitized.AutoSize = true;
      this.rbDigitized.Enabled = false;
      this.rbDigitized.Location = new System.Drawing.Point(246, 32);
      this.rbDigitized.Name = "rbDigitized";
      this.rbDigitized.Size = new System.Drawing.Size(65, 17);
      this.rbDigitized.TabIndex = 8;
      this.rbDigitized.Text = "Digitized";
      this.rbDigitized.UseVisualStyleBackColor = true;
      // 
      // rbOriginal
      // 
      this.rbOriginal.AutoSize = true;
      this.rbOriginal.Enabled = false;
      this.rbOriginal.Location = new System.Drawing.Point(246, 14);
      this.rbOriginal.Name = "rbOriginal";
      this.rbOriginal.Size = new System.Drawing.Size(60, 17);
      this.rbOriginal.TabIndex = 7;
      this.rbOriginal.Text = "Original";
      this.rbOriginal.UseVisualStyleBackColor = true;
      // 
      // rbMain
      // 
      this.rbMain.AutoSize = true;
      this.rbMain.Enabled = false;
      this.rbMain.Location = new System.Drawing.Point(149, 32);
      this.rbMain.Name = "rbMain";
      this.rbMain.Size = new System.Drawing.Size(48, 17);
      this.rbMain.TabIndex = 6;
      this.rbMain.Text = "Main";
      this.rbMain.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(137, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "bei unterschiedliche Zeiten:";
      // 
      // rbFragen
      // 
      this.rbFragen.AutoSize = true;
      this.rbFragen.Checked = true;
      this.rbFragen.Enabled = false;
      this.rbFragen.Location = new System.Drawing.Point(149, 14);
      this.rbFragen.Name = "rbFragen";
      this.rbFragen.Size = new System.Drawing.Size(79, 17);
      this.rbFragen.TabIndex = 4;
      this.rbFragen.TabStop = true;
      this.rbFragen.Text = "nachfragen";
      this.rbFragen.UseVisualStyleBackColor = true;
      // 
      // gbHilfe
      // 
      this.gbHilfe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.gbHilfe.Controls.Add(this.lHilfe);
      this.gbHilfe.Location = new System.Drawing.Point(411, 275);
      this.gbHilfe.Name = "gbHilfe";
      this.gbHilfe.Size = new System.Drawing.Size(247, 84);
      this.gbHilfe.TabIndex = 4;
      this.gbHilfe.TabStop = false;
      this.gbHilfe.Text = "Hilfe";
      // 
      // lHilfe
      // 
      this.lHilfe.AutoEllipsis = true;
      this.lHilfe.AutoSize = true;
      this.lHilfe.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lHilfe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.lHilfe.Location = new System.Drawing.Point(3, 16);
      this.lHilfe.Margin = new System.Windows.Forms.Padding(3);
      this.lHilfe.Name = "lHilfe";
      this.lHilfe.Size = new System.Drawing.Size(57, 13);
      this.lHilfe.TabIndex = 0;
      this.lHilfe.Text = "keine Hilfe";
      // 
      // fFNMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(670, 362);
      this.Controls.Add(this.gbHilfe);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.pb1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "fFNMain";
      this.Text = "Foto-Namen aus Datum";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.gbHilfe.ResumeLayout(false);
      this.gbHilfe.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.Button bVerz;
        private System.Windows.Forms.Label lVerz;
        private System.Windows.Forms.Label lCrea;
        private System.Windows.Forms.Label lChan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bAuswert;
        private System.Windows.Forms.Label lAnz;
        private System.Windows.Forms.Label lDat;
        private System.Windows.Forms.Label lGr;
        private System.Windows.Forms.Button bBearb;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbDigitized;
        private System.Windows.Forms.RadioButton rbOriginal;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbFragen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPrfix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lFertig;
        private System.Windows.Forms.Label lWarten;
        private System.Windows.Forms.CheckBox cbName;
        private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.GroupBox gbHilfe;
    private System.Windows.Forms.Label lHilfe;
  }
}

