namespace KelimeEzber
{
    partial class SoruForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoruForm));
            labelSkor = new Label();
            labelSoru = new Label();
            buttonSecenek1 = new Button();
            buttonSecenek2 = new Button();
            buttonSecenek3 = new Button();
            buttonSecenek4 = new Button();
            buttonQuizBitir = new Button();
            labelKelime = new Label();
            SuspendLayout();
            // 
            // labelSkor
            // 
            labelSkor.AutoSize = true;
            labelSkor.BackColor = SystemColors.GradientActiveCaption;
            labelSkor.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelSkor.Location = new Point(613, 9);
            labelSkor.Name = "labelSkor";
            labelSkor.Size = new Size(74, 33);
            labelSkor.TabIndex = 1;
            labelSkor.Text = "skor";
            // 
            // labelSoru
            // 
            labelSoru.AutoSize = true;
            labelSoru.BackColor = SystemColors.GradientActiveCaption;
            labelSoru.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelSoru.Location = new Point(12, 9);
            labelSoru.Name = "labelSoru";
            labelSoru.Size = new Size(75, 33);
            labelSoru.TabIndex = 2;
            labelSoru.Text = "soru";
            // 
            // buttonSecenek1
            // 
            buttonSecenek1.BackColor = SystemColors.ButtonFace;
            buttonSecenek1.Font = new Font("Arial Narrow", 20F, FontStyle.Bold);
            buttonSecenek1.Location = new Point(6, 161);
            buttonSecenek1.Name = "buttonSecenek1";
            buttonSecenek1.Size = new Size(370, 103);
            buttonSecenek1.TabIndex = 3;
            buttonSecenek1.Text = "button1";
            buttonSecenek1.UseVisualStyleBackColor = false;
            buttonSecenek1.Click += SecenekButton_Click;
            // 
            // buttonSecenek2
            // 
            buttonSecenek2.BackColor = SystemColors.ButtonFace;
            buttonSecenek2.Font = new Font("Arial Narrow", 20F, FontStyle.Bold);
            buttonSecenek2.Location = new Point(382, 161);
            buttonSecenek2.Name = "buttonSecenek2";
            buttonSecenek2.Size = new Size(372, 103);
            buttonSecenek2.TabIndex = 4;
            buttonSecenek2.Text = "button2";
            buttonSecenek2.UseVisualStyleBackColor = false;
            buttonSecenek2.Click += SecenekButton_Click;
            // 
            // buttonSecenek3
            // 
            buttonSecenek3.BackColor = SystemColors.ButtonFace;
            buttonSecenek3.Font = new Font("Arial Narrow", 20F, FontStyle.Bold);
            buttonSecenek3.Location = new Point(6, 270);
            buttonSecenek3.Name = "buttonSecenek3";
            buttonSecenek3.Size = new Size(370, 106);
            buttonSecenek3.TabIndex = 5;
            buttonSecenek3.Text = "button3";
            buttonSecenek3.UseVisualStyleBackColor = false;
            buttonSecenek3.Click += SecenekButton_Click;
            // 
            // buttonSecenek4
            // 
            buttonSecenek4.BackColor = SystemColors.ButtonFace;
            buttonSecenek4.Font = new Font("Arial Narrow", 20F, FontStyle.Bold);
            buttonSecenek4.Location = new Point(382, 270);
            buttonSecenek4.Name = "buttonSecenek4";
            buttonSecenek4.Size = new Size(372, 106);
            buttonSecenek4.TabIndex = 6;
            buttonSecenek4.Text = "button4";
            buttonSecenek4.UseVisualStyleBackColor = false;
            buttonSecenek4.Click += SecenekButton_Click;
            // 
            // buttonQuizBitir
            // 
            buttonQuizBitir.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonQuizBitir.Location = new Point(6, 382);
            buttonQuizBitir.Name = "buttonQuizBitir";
            buttonQuizBitir.Size = new Size(748, 34);
            buttonQuizBitir.TabIndex = 7;
            buttonQuizBitir.Text = "Bitir";
            buttonQuizBitir.UseVisualStyleBackColor = true;
            buttonQuizBitir.Click += buttonQuizBitir_Click;
            // 
            // labelKelime
            // 
            labelKelime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelKelime.BackColor = Color.RosyBrown;
            labelKelime.BorderStyle = BorderStyle.FixedSingle;
            labelKelime.Font = new Font("Arial Narrow", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            labelKelime.ForeColor = SystemColors.ButtonHighlight;
            labelKelime.Location = new Point(6, 64);
            labelKelime.Name = "labelKelime";
            labelKelime.Size = new Size(748, 94);
            labelKelime.TabIndex = 1;
            labelKelime.Text = "label1";
            labelKelime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SoruForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(766, 434);
            Controls.Add(labelKelime);
            Controls.Add(buttonQuizBitir);
            Controls.Add(buttonSecenek4);
            Controls.Add(buttonSecenek3);
            Controls.Add(buttonSecenek2);
            Controls.Add(buttonSecenek1);
            Controls.Add(labelSoru);
            Controls.Add(labelSkor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SoruForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoruForm";
            Load += SoruForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelSkor;
        private Label labelSoru;
        private Button buttonSecenek1;
        private Button buttonSecenek2;
        private Button buttonSecenek3;
        private Button buttonSecenek4;
        private Button buttonQuizBitir;
        private Label labelKelime;
    }
}