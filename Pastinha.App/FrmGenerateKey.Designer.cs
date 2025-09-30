namespace Pastinha.App
{
    partial class FrmGenerateKey
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            NumAmount = new NumericUpDown();
            label2 = new Label();
            CbxBytes = new ComboBox();
            RTxtKeys = new RichTextBox();
            BtnGenerate = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumAmount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "Bytes";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NumAmount);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(CbxBytes);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(151, 75);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gerar Keys";
            // 
            // NumAmount
            // 
            NumAmount.Location = new Point(65, 37);
            NumAmount.Name = "NumAmount";
            NumAmount.Size = new Size(69, 23);
            NumAmount.TabIndex = 4;
            NumAmount.TextAlign = HorizontalAlignment.Right;
            NumAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 19);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Quantidade";
            // 
            // CbxBytes
            // 
            CbxBytes.FormattingEnabled = true;
            CbxBytes.Items.AddRange(new object[] { "16", "24", "32" });
            CbxBytes.Location = new Point(6, 36);
            CbxBytes.Name = "CbxBytes";
            CbxBytes.Size = new Size(53, 23);
            CbxBytes.TabIndex = 1;
            // 
            // RTxtKeys
            // 
            RTxtKeys.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RTxtKeys.Location = new Point(12, 105);
            RTxtKeys.Name = "RTxtKeys";
            RTxtKeys.ReadOnly = true;
            RTxtKeys.Size = new Size(655, 227);
            RTxtKeys.TabIndex = 2;
            RTxtKeys.Text = "";
            // 
            // BtnGenerate
            // 
            BtnGenerate.Location = new Point(508, 12);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(159, 87);
            BtnGenerate.TabIndex = 3;
            BtnGenerate.Text = "&Gerar";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // FrmGenerateKey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 341);
            Controls.Add(BtnGenerate);
            Controls.Add(RTxtKeys);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmGenerateKey";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerar Chave";
            Load += FrmGenerateKey_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumAmount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private ComboBox CbxBytes;
        private Label label2;
        private RichTextBox RTxtKeys;
        private Button BtnGenerate;
        private NumericUpDown NumAmount;
    }
}