namespace Pastinha.App
{
    partial class FrmOffline
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
            BtnSearchPath = new Button();
            TxtSeacherPath = new TextBox();
            groupBox2 = new GroupBox();
            DgvData = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            PathOffline = new DataGridViewTextBoxColumn();
            IsOffline = new DataGridViewCheckBoxColumn();
            BtnSave = new Button();
            BtnAlter = new Button();
            BtnDelete = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvData).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnSearchPath);
            groupBox1.Controls.Add(TxtSeacherPath);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(466, 82);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Arquivamento Offline";
            // 
            // BtnSearchPath
            // 
            BtnSearchPath.Location = new Point(381, 22);
            BtnSearchPath.Name = "BtnSearchPath";
            BtnSearchPath.Size = new Size(75, 23);
            BtnSearchPath.TabIndex = 2;
            BtnSearchPath.Text = "Procurar";
            BtnSearchPath.UseVisualStyleBackColor = true;
            BtnSearchPath.Click += BtnSearchPath_Click;
            // 
            // TxtSeacherPath
            // 
            TxtSeacherPath.Location = new Point(6, 22);
            TxtSeacherPath.Name = "TxtSeacherPath";
            TxtSeacherPath.Size = new Size(369, 23);
            TxtSeacherPath.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DgvData);
            groupBox2.Location = new Point(12, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(466, 147);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dados";
            // 
            // DgvData
            // 
            DgvData.AllowUserToAddRows = false;
            DgvData.AllowUserToDeleteRows = false;
            DgvData.AllowUserToOrderColumns = true;
            DgvData.BackgroundColor = SystemColors.Control;
            DgvData.BorderStyle = BorderStyle.Fixed3D;
            DgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvData.Columns.AddRange(new DataGridViewColumn[] { Id, PathOffline, IsOffline });
            DgvData.Location = new Point(6, 22);
            DgvData.MultiSelect = false;
            DgvData.Name = "DgvData";
            DgvData.ReadOnly = true;
            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvData.Size = new Size(450, 119);
            DgvData.TabIndex = 0;
            DgvData.CellDoubleClick += DgvData_CellDoubleClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // PathOffline
            // 
            PathOffline.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            PathOffline.DataPropertyName = "PathOffline";
            PathOffline.HeaderText = "Caminho Offline";
            PathOffline.Name = "PathOffline";
            PathOffline.ReadOnly = true;
            PathOffline.Width = 110;
            // 
            // IsOffline
            // 
            IsOffline.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IsOffline.DataPropertyName = "IsOffline";
            IsOffline.HeaderText = "Offile";
            IsOffline.Name = "IsOffline";
            IsOffline.ReadOnly = true;
            IsOffline.Width = 42;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(484, 12);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(92, 32);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "&Salvar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnAlter
            // 
            BtnAlter.Enabled = false;
            BtnAlter.Location = new Point(484, 50);
            BtnAlter.Name = "BtnAlter";
            BtnAlter.Size = new Size(92, 32);
            BtnAlter.TabIndex = 2;
            BtnAlter.Text = "&Alterar";
            BtnAlter.UseVisualStyleBackColor = true;
            BtnAlter.Click += BtnAlter_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Enabled = false;
            BtnDelete.Location = new Point(484, 88);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(92, 32);
            BtnDelete.TabIndex = 2;
            BtnDelete.Text = "&Excluir";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // FrmOffline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 255);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAlter);
            Controls.Add(BtnSave);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmOffline";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Offline";
            Load += FrmOffline_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox TxtSeacherPath;
        private Button BtnSearchPath;
        private GroupBox groupBox2;
        private Button BtnSave;
        private Button BtnAlter;
        private Button BtnDelete;
        private DataGridView DgvData;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn PathOffline;
        private DataGridViewCheckBoxColumn IsOffline;
    }
}