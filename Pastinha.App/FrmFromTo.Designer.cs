namespace Pastinha.App
{
    partial class FrmFromTo
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
            TxtTo = new TextBox();
            label2 = new Label();
            TxtFrom = new TextBox();
            label1 = new Label();
            BtnDelete = new Button();
            BtnAlter = new Button();
            BtnSave = new Button();
            groupBox2 = new GroupBox();
            DgvListFromTo = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListFromTo).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtTo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TxtFrom);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 77);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "De-Para";
            // 
            // TxtTo
            // 
            TxtTo.Location = new Point(70, 37);
            TxtTo.Name = "TxtTo";
            TxtTo.Size = new Size(58, 23);
            TxtTo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 19);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "Para";
            // 
            // TxtFrom
            // 
            TxtFrom.Location = new Point(6, 37);
            TxtFrom.Name = "TxtFrom";
            TxtFrom.Size = new Size(58, 23);
            TxtFrom.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 0;
            label1.Text = "De";
            // 
            // BtnDelete
            // 
            BtnDelete.Enabled = false;
            BtnDelete.Location = new Point(312, 96);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(94, 37);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "&Excluir";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnAlter
            // 
            BtnAlter.Enabled = false;
            BtnAlter.Location = new Point(312, 53);
            BtnAlter.Name = "BtnAlter";
            BtnAlter.Size = new Size(94, 37);
            BtnAlter.TabIndex = 2;
            BtnAlter.Text = "&Alterar";
            BtnAlter.UseVisualStyleBackColor = true;
            BtnAlter.Click += BtnAlter_Click;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(312, 12);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(94, 37);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "&Salvar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DgvListFromTo);
            groupBox2.Location = new Point(12, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(294, 144);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lista";
            // 
            // DgvListFromTo
            // 
            DgvListFromTo.AllowUserToAddRows = false;
            DgvListFromTo.AllowUserToDeleteRows = false;
            DgvListFromTo.AllowUserToOrderColumns = true;
            DgvListFromTo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DgvListFromTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvListFromTo.BackgroundColor = SystemColors.Control;
            DgvListFromTo.BorderStyle = BorderStyle.Fixed3D;
            DgvListFromTo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListFromTo.Dock = DockStyle.Fill;
            DgvListFromTo.Location = new Point(3, 19);
            DgvListFromTo.MultiSelect = false;
            DgvListFromTo.Name = "DgvListFromTo";
            DgvListFromTo.ReadOnly = true;
            DgvListFromTo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvListFromTo.Size = new Size(288, 122);
            DgvListFromTo.TabIndex = 0;
            DgvListFromTo.CellDoubleClick += DgvListFromTo_CellDoubleClick;
            // 
            // FrmFromTo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 253);
            Controls.Add(groupBox2);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAlter);
            Controls.Add(BtnSave);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmFromTo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "De Para";
            Load += FrmFromTo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvListFromTo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox TxtTo;
        private Label label2;
        private TextBox TxtFrom;
        private Label label1;
        private Button BtnDelete;
        private Button BtnAlter;
        private Button BtnSave;
        private GroupBox groupBox2;
        private DataGridView DgvListFromTo;
    }
}