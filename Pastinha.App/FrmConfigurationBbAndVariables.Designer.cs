namespace Pastinha.App
{
    partial class FrmConfigurationBbAndVariables
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
            GbKey = new GroupBox();
            BtnGenerateKey = new Button();
            TxtKey = new TextBox();
            CbxBytes = new ComboBox();
            label1 = new Label();
            GbBD = new GroupBox();
            BtnSearch = new Button();
            TxtPathBd = new TextBox();
            label2 = new Label();
            BtnSave = new Button();
            PbSalvando = new ProgressBar();
            LblInfoSalvando = new Label();
            GbKey.SuspendLayout();
            GbBD.SuspendLayout();
            SuspendLayout();
            // 
            // GbKey
            // 
            GbKey.Controls.Add(BtnGenerateKey);
            GbKey.Controls.Add(TxtKey);
            GbKey.Controls.Add(CbxBytes);
            GbKey.Controls.Add(label1);
            GbKey.Location = new Point(12, 12);
            GbKey.Name = "GbKey";
            GbKey.Size = new Size(483, 77);
            GbKey.TabIndex = 0;
            GbKey.TabStop = false;
            GbKey.Text = "Key";
            // 
            // BtnGenerateKey
            // 
            BtnGenerateKey.Location = new Point(390, 36);
            BtnGenerateKey.Name = "BtnGenerateKey";
            BtnGenerateKey.Size = new Size(75, 23);
            BtnGenerateKey.TabIndex = 2;
            BtnGenerateKey.Text = "Gerar Key";
            BtnGenerateKey.UseVisualStyleBackColor = true;
            BtnGenerateKey.Click += BtnGenerateKey_Click;
            // 
            // TxtKey
            // 
            TxtKey.Location = new Point(65, 36);
            TxtKey.Name = "TxtKey";
            TxtKey.ReadOnly = true;
            TxtKey.Size = new Size(319, 23);
            TxtKey.TabIndex = 1;
            // 
            // CbxBytes
            // 
            CbxBytes.FormattingEnabled = true;
            CbxBytes.Items.AddRange(new object[] { "16", "24", "32" });
            CbxBytes.Location = new Point(6, 36);
            CbxBytes.Name = "CbxBytes";
            CbxBytes.Size = new Size(53, 23);
            CbxBytes.TabIndex = 0;
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
            // GbBD
            // 
            GbBD.Controls.Add(BtnSearch);
            GbBD.Controls.Add(TxtPathBd);
            GbBD.Controls.Add(label2);
            GbBD.Location = new Point(12, 95);
            GbBD.Name = "GbBD";
            GbBD.Size = new Size(483, 75);
            GbBD.TabIndex = 1;
            GbBD.TabStop = false;
            GbBD.Text = "BD";
            // 
            // BtnSearch
            // 
            BtnSearch.Location = new Point(390, 37);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(75, 23);
            BtnSearch.TabIndex = 1;
            BtnSearch.Text = "Procurar";
            BtnSearch.UseVisualStyleBackColor = true;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // TxtPathBd
            // 
            TxtPathBd.Location = new Point(6, 37);
            TxtPathBd.Name = "TxtPathBd";
            TxtPathBd.Size = new Size(378, 23);
            TxtPathBd.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 0;
            label2.Text = "Local BD";
            // 
            // BtnSave
            // 
            BtnSave.Enabled = false;
            BtnSave.Location = new Point(12, 194);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 23);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Salvar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // PbSalvando
            // 
            PbSalvando.Location = new Point(96, 194);
            PbSalvando.Name = "PbSalvando";
            PbSalvando.Size = new Size(399, 23);
            PbSalvando.TabIndex = 3;
            // 
            // LblInfoSalvando
            // 
            LblInfoSalvando.AutoSize = true;
            LblInfoSalvando.BackColor = Color.Transparent;
            LblInfoSalvando.Location = new Point(266, 176);
            LblInfoSalvando.Name = "LblInfoSalvando";
            LblInfoSalvando.Size = new Size(64, 15);
            LblInfoSalvando.TabIndex = 4;
            LblInfoSalvando.Text = "Salvando...";
            // 
            // FrmConfigurationBbAndVariables
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 229);
            Controls.Add(LblInfoSalvando);
            Controls.Add(PbSalvando);
            Controls.Add(BtnSave);
            Controls.Add(GbBD);
            Controls.Add(GbKey);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConfigurationBbAndVariables";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurações";
            FormClosing += FrmConfigurationBbAndVariables_FormClosing;
            Load += FrmConfigurationBbAndVariables_Load;
            GbKey.ResumeLayout(false);
            GbKey.PerformLayout();
            GbBD.ResumeLayout(false);
            GbBD.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GbKey;
        private TextBox TxtKey;
        private ComboBox CbxBytes;
        private Label label1;
        private GroupBox GbBD;
        private Button BtnGenerateKey;
        private Label label2;
        private Button BtnSearch;
        private TextBox TxtPathBd;
        private Button BtnSave;
        private ProgressBar PbSalvando;
        private Label LblInfoSalvando;
    }
}