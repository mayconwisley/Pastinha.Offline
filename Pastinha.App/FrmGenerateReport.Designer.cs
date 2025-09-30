namespace Pastinha.App
{
    partial class FrmGenerateReport
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
			groupBox1 = new GroupBox();
			label1 = new Label();
			MktDateFinalReport = new MaskedTextBox();
			MktDateInitialReport = new MaskedTextBox();
			BtnGenerate = new Button();
			PbProcessando = new ProgressBar();
			LblProcessando = new Label();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(MktDateFinalReport);
			groupBox1.Controls.Add(MktDateInitialReport);
			groupBox1.Location = new Point(16, 14);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(200, 59);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Data";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(88, 25);
			label1.Name = "label1";
			label1.Size = new Size(13, 15);
			label1.TabIndex = 1;
			label1.Text = "a";
			// 
			// MktDateFinalReport
			// 
			MktDateFinalReport.Location = new Point(107, 22);
			MktDateFinalReport.Mask = "00/00/0000";
			MktDateFinalReport.Name = "MktDateFinalReport";
			MktDateFinalReport.Size = new Size(76, 23);
			MktDateFinalReport.TabIndex = 1;
			MktDateFinalReport.ValidatingType = typeof(DateTime);
			// 
			// MktDateInitialReport
			// 
			MktDateInitialReport.Location = new Point(6, 22);
			MktDateInitialReport.Mask = "00/00/0000";
			MktDateInitialReport.Name = "MktDateInitialReport";
			MktDateInitialReport.Size = new Size(76, 23);
			MktDateInitialReport.TabIndex = 0;
			MktDateInitialReport.ValidatingType = typeof(DateTime);
			// 
			// BtnGenerate
			// 
			BtnGenerate.Location = new Point(246, 24);
			BtnGenerate.Name = "BtnGenerate";
			BtnGenerate.Size = new Size(113, 45);
			BtnGenerate.TabIndex = 0;
			BtnGenerate.Text = "Gerar";
			BtnGenerate.UseVisualStyleBackColor = true;
			BtnGenerate.Click += BtnGenerate_Click;
			// 
			// PbProcessando
			// 
			PbProcessando.Location = new Point(96, 79);
			PbProcessando.Name = "PbProcessando";
			PbProcessando.Size = new Size(268, 23);
			PbProcessando.TabIndex = 1;
			PbProcessando.Visible = false;
			// 
			// LblProcessando
			// 
			LblProcessando.AutoSize = true;
			LblProcessando.Location = new Point(12, 83);
			LblProcessando.Name = "LblProcessando";
			LblProcessando.Size = new Size(74, 15);
			LblProcessando.TabIndex = 2;
			LblProcessando.Text = "Processando";
			LblProcessando.Visible = false;
			// 
			// FrmGenerateReport
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(376, 114);
			Controls.Add(LblProcessando);
			Controls.Add(PbProcessando);
			Controls.Add(BtnGenerate);
			Controls.Add(groupBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FrmGenerateReport";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Gerar Relatório";
			Load += FrmGenerateReport_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBox1;
        private MaskedTextBox MktDateInitialReport;
        private Button BtnGenerate;
        private Label label1;
        private MaskedTextBox MktDateFinalReport;
		private ProgressBar PbProcessando;
		private Label LblProcessando;
	}
}