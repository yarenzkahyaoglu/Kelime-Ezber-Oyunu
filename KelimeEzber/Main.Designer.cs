namespace KelimeEzber
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            groupBox1 = new GroupBox();
            comboBoxSozluk = new ComboBox();
            buttonCıkıs = new Button();
            buttonBaslat = new Button();
            buttonYukle = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxSozluk);
            groupBox1.Location = new Point(7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(505, 69);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sözlük";
            // 
            // comboBoxSozluk
            // 
            comboBoxSozluk.FormattingEnabled = true;
            comboBoxSozluk.Location = new Point(7, 30);
            comboBoxSozluk.Name = "comboBoxSozluk";
            comboBoxSozluk.Size = new Size(493, 33);
            comboBoxSozluk.TabIndex = 4;
            // 
            // buttonCıkıs
            // 
            buttonCıkıs.Location = new Point(395, 81);
            buttonCıkıs.Name = "buttonCıkıs";
            buttonCıkıs.Size = new Size(112, 34);
            buttonCıkıs.TabIndex = 10;
            buttonCıkıs.Text = "Çıkış";
            buttonCıkıs.UseVisualStyleBackColor = true;
            buttonCıkıs.Click += buttonCıkıs_Click;
            // 
            // buttonBaslat
            // 
            buttonBaslat.Location = new Point(277, 81);
            buttonBaslat.Name = "buttonBaslat";
            buttonBaslat.Size = new Size(112, 34);
            buttonBaslat.TabIndex = 9;
            buttonBaslat.Text = "Başlat";
            buttonBaslat.UseVisualStyleBackColor = true;
            buttonBaslat.Click += buttonBaslat_Click;
            // 
            // buttonYukle
            // 
            buttonYukle.Location = new Point(159, 81);
            buttonYukle.Name = "buttonYukle";
            buttonYukle.Size = new Size(112, 34);
            buttonYukle.TabIndex = 8;
            buttonYukle.Text = "Yükle";
            buttonYukle.UseVisualStyleBackColor = true;
            buttonYukle.Click += buttonYukle_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 130);
            Controls.Add(buttonCıkıs);
            Controls.Add(buttonBaslat);
            Controls.Add(buttonYukle);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kelime Ezber";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox comboBoxSozluk;
        private Button buttonCıkıs;
        private Button buttonBaslat;
        private Button buttonYukle;
    }
}
