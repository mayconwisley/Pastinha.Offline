namespace Pastinha.App
{
    partial class FrmStatusFired
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
            label2 = new Label();
            label1 = new Label();
            TxtDescription = new TextBox();
            TxtCode = new TextBox();
            groupBox2 = new GroupBox();
            DgvData = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            CodeStatus = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
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
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(TxtDescription);
            groupBox1.Controls.Add(TxtCode);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(361, 74);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status Demitido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 19);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Descrição";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Código";
            // 
            // TxtDescription
            // 
            TxtDescription.Location = new Point(78, 37);
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(277, 23);
            TxtDescription.TabIndex = 3;
            // 
            // TxtCode
            // 
            TxtCode.Location = new Point(6, 37);
            TxtCode.Name = "TxtCode";
            TxtCode.Size = new Size(66, 23);
            TxtCode.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DgvData);
            groupBox2.Location = new Point(12, 92);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(361, 234);
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
            DgvData.Columns.AddRange(new DataGridViewColumn[] { Id, CodeStatus, Description });
            DgvData.Location = new Point(6, 22);
            DgvData.MultiSelect = false;
            DgvData.Name = "DgvData";
            DgvData.ReadOnly = true;
            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvData.Size = new Size(349, 206);
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
            // CodeStatus
            // 
            CodeStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CodeStatus.DataPropertyName = "CodeStatus";
            CodeStatus.HeaderText = "Código";
            CodeStatus.Name = "CodeStatus";
            CodeStatus.ReadOnly = true;
            CodeStatus.Width = 71;
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Descrição";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 83;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(379, 12);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(114, 38);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "&Salvar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnAlter
            // 
            BtnAlter.Enabled = false;
            BtnAlter.Location = new Point(379, 56);
            BtnAlter.Name = "BtnAlter";
            BtnAlter.Size = new Size(114, 38);
            BtnAlter.TabIndex = 3;
            BtnAlter.Text = "&Alterar";
            BtnAlter.UseVisualStyleBackColor = true;
            BtnAlter.Click += BtnAlter_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Enabled = false;
            BtnDelete.Location = new Point(379, 100);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(114, 38);
            BtnDelete.TabIndex = 4;
            BtnDelete.Text = "&Excluir";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // FrmStatusFired
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 338);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAlter);
            Controls.Add(BtnSave);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmStatusFired";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Status Demitido";
            Load += FrmStatusFired_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox TxtCode;
        private TextBox TxtDescription;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private DataGridView DgvData;
        private Button BtnSave;
        private Button BtnAlter;
        private Button BtnDelete;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn CodeStatus;
        private DataGridViewTextBoxColumn Description;
    }
}