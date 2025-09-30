namespace Pastinha.App
{
	partial class FrmFolder
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
			label5 = new Label();
			CbIsDelete = new CheckBox();
			BtnSearchPathLog = new Button();
			BtnSearchPathError = new Button();
			BtnSearchPathOutput = new Button();
			BtnSearchPathInput = new Button();
			TxtPathLog = new TextBox();
			TxtPathError = new TextBox();
			TxtPathOutput = new TextBox();
			TxtPathInput = new TextBox();
			label3 = new Label();
			label4 = new Label();
			label2 = new Label();
			label1 = new Label();
			BtnSave = new Button();
			BtnAlter = new Button();
			BtnDelete = new Button();
			groupBox2 = new GroupBox();
			DgvListPaths = new DataGridView();
			Id = new DataGridViewTextBoxColumn();
			PathInput = new DataGridViewTextBoxColumn();
			PathOutput = new DataGridViewTextBoxColumn();
			PathError = new DataGridViewTextBoxColumn();
			PathLog = new DataGridViewTextBoxColumn();
			IsDelete = new DataGridViewCheckBoxColumn();
			DaysDelete = new DataGridViewTextBoxColumn();
			NumDays = new NumericUpDown();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DgvListPaths).BeginInit();
			((System.ComponentModel.ISupportInitialize)NumDays).BeginInit();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(NumDays);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(CbIsDelete);
			groupBox1.Controls.Add(BtnSearchPathLog);
			groupBox1.Controls.Add(BtnSearchPathError);
			groupBox1.Controls.Add(BtnSearchPathOutput);
			groupBox1.Controls.Add(BtnSearchPathInput);
			groupBox1.Controls.Add(TxtPathLog);
			groupBox1.Controls.Add(TxtPathError);
			groupBox1.Controls.Add(TxtPathOutput);
			groupBox1.Controls.Add(TxtPathInput);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(15, 11);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(528, 234);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Pastas";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(132, 202);
			label5.Name = "label5";
			label5.Size = new Size(29, 15);
			label5.TabIndex = 8;
			label5.Text = "Dias";
			// 
			// CbIsDelete
			// 
			CbIsDelete.AutoSize = true;
			CbIsDelete.Location = new Point(6, 202);
			CbIsDelete.Name = "CbIsDelete";
			CbIsDelete.Size = new Size(86, 19);
			CbIsDelete.TabIndex = 8;
			CbIsDelete.Text = "Deletar Log";
			CbIsDelete.UseVisualStyleBackColor = true;
			// 
			// BtnSearchPathLog
			// 
			BtnSearchPathLog.Location = new Point(445, 169);
			BtnSearchPathLog.Name = "BtnSearchPathLog";
			BtnSearchPathLog.Size = new Size(75, 23);
			BtnSearchPathLog.TabIndex = 7;
			BtnSearchPathLog.Text = "Procurar";
			BtnSearchPathLog.UseVisualStyleBackColor = true;
			BtnSearchPathLog.Click += BtnSearchPathLog_Click;
			// 
			// BtnSearchPathError
			// 
			BtnSearchPathError.Location = new Point(445, 125);
			BtnSearchPathError.Name = "BtnSearchPathError";
			BtnSearchPathError.Size = new Size(75, 23);
			BtnSearchPathError.TabIndex = 5;
			BtnSearchPathError.Text = "Procurar";
			BtnSearchPathError.UseVisualStyleBackColor = true;
			BtnSearchPathError.Click += BtnSearchPathError_Click;
			// 
			// BtnSearchPathOutput
			// 
			BtnSearchPathOutput.Location = new Point(445, 81);
			BtnSearchPathOutput.Name = "BtnSearchPathOutput";
			BtnSearchPathOutput.Size = new Size(75, 23);
			BtnSearchPathOutput.TabIndex = 3;
			BtnSearchPathOutput.Text = "Procurar";
			BtnSearchPathOutput.UseVisualStyleBackColor = true;
			BtnSearchPathOutput.Click += BtnSearchPathOutput_Click;
			// 
			// BtnSearchPathInput
			// 
			BtnSearchPathInput.Location = new Point(445, 37);
			BtnSearchPathInput.Name = "BtnSearchPathInput";
			BtnSearchPathInput.Size = new Size(75, 23);
			BtnSearchPathInput.TabIndex = 1;
			BtnSearchPathInput.Text = "Procurar";
			BtnSearchPathInput.UseVisualStyleBackColor = true;
			BtnSearchPathInput.Click += BtnSearchPathInput_Click;
			// 
			// TxtPathLog
			// 
			TxtPathLog.Location = new Point(6, 169);
			TxtPathLog.Name = "TxtPathLog";
			TxtPathLog.Size = new Size(433, 23);
			TxtPathLog.TabIndex = 6;
			// 
			// TxtPathError
			// 
			TxtPathError.Location = new Point(6, 125);
			TxtPathError.Name = "TxtPathError";
			TxtPathError.Size = new Size(433, 23);
			TxtPathError.TabIndex = 4;
			// 
			// TxtPathOutput
			// 
			TxtPathOutput.Location = new Point(6, 81);
			TxtPathOutput.Name = "TxtPathOutput";
			TxtPathOutput.Size = new Size(433, 23);
			TxtPathOutput.TabIndex = 2;
			// 
			// TxtPathInput
			// 
			TxtPathInput.Location = new Point(6, 37);
			TxtPathInput.Name = "TxtPathInput";
			TxtPathInput.Size = new Size(433, 23);
			TxtPathInput.TabIndex = 0;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(6, 151);
			label3.Name = "label3";
			label3.Size = new Size(27, 15);
			label3.TabIndex = 0;
			label3.Text = "Log";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(6, 107);
			label4.Name = "label4";
			label4.Size = new Size(28, 15);
			label4.TabIndex = 0;
			label4.Text = "Erro";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 63);
			label2.Name = "label2";
			label2.Size = new Size(35, 15);
			label2.TabIndex = 0;
			label2.Text = "Saída";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 19);
			label1.Name = "label1";
			label1.Size = new Size(47, 15);
			label1.TabIndex = 0;
			label1.Text = "Entrada";
			// 
			// BtnSave
			// 
			BtnSave.Location = new Point(558, 12);
			BtnSave.Name = "BtnSave";
			BtnSave.Size = new Size(96, 42);
			BtnSave.TabIndex = 2;
			BtnSave.Text = "&Salvar";
			BtnSave.UseVisualStyleBackColor = true;
			BtnSave.Click += BtnSave_Click;
			// 
			// BtnAlter
			// 
			BtnAlter.Enabled = false;
			BtnAlter.Location = new Point(558, 60);
			BtnAlter.Name = "BtnAlter";
			BtnAlter.Size = new Size(96, 42);
			BtnAlter.TabIndex = 3;
			BtnAlter.Text = "&Alterar";
			BtnAlter.UseVisualStyleBackColor = true;
			BtnAlter.Click += BtnAlter_Click;
			// 
			// BtnDelete
			// 
			BtnDelete.Enabled = false;
			BtnDelete.Location = new Point(558, 108);
			BtnDelete.Name = "BtnDelete";
			BtnDelete.Size = new Size(96, 42);
			BtnDelete.TabIndex = 4;
			BtnDelete.Text = "&Excluir";
			BtnDelete.UseVisualStyleBackColor = true;
			BtnDelete.Click += BtnDelete_Click;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(DgvListPaths);
			groupBox2.Location = new Point(12, 251);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(642, 256);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Lista de Pastas";
			// 
			// DgvListPaths
			// 
			DgvListPaths.AllowUserToAddRows = false;
			DgvListPaths.AllowUserToDeleteRows = false;
			DgvListPaths.AllowUserToOrderColumns = true;
			DgvListPaths.BackgroundColor = SystemColors.Control;
			DgvListPaths.BorderStyle = BorderStyle.Fixed3D;
			DgvListPaths.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DgvListPaths.Columns.AddRange(new DataGridViewColumn[] { Id, PathInput, PathOutput, PathError, PathLog, IsDelete, DaysDelete });
			DgvListPaths.Location = new Point(6, 22);
			DgvListPaths.MultiSelect = false;
			DgvListPaths.Name = "DgvListPaths";
			DgvListPaths.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DgvListPaths.Size = new Size(625, 228);
			DgvListPaths.TabIndex = 0;
			DgvListPaths.CellDoubleClick += DgvListPaths_CellDoubleClick;
			// 
			// Id
			// 
			Id.DataPropertyName = "Id";
			Id.HeaderText = "Id";
			Id.Name = "Id";
			Id.ReadOnly = true;
			Id.Visible = false;
			// 
			// PathInput
			// 
			PathInput.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			PathInput.DataPropertyName = "PathInput";
			PathInput.HeaderText = "Entrada";
			PathInput.Name = "PathInput";
			PathInput.ReadOnly = true;
			PathInput.Width = 72;
			// 
			// PathOutput
			// 
			PathOutput.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			PathOutput.DataPropertyName = "PathOutput";
			PathOutput.HeaderText = "Saída";
			PathOutput.Name = "PathOutput";
			PathOutput.ReadOnly = true;
			PathOutput.Width = 60;
			// 
			// PathError
			// 
			PathError.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			PathError.DataPropertyName = "PathError";
			PathError.HeaderText = "Erro";
			PathError.Name = "PathError";
			PathError.Width = 53;
			// 
			// PathLog
			// 
			PathLog.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			PathLog.DataPropertyName = "PathLog";
			PathLog.HeaderText = "Log";
			PathLog.Name = "PathLog";
			PathLog.ReadOnly = true;
			PathLog.Width = 52;
			// 
			// IsDelete
			// 
			IsDelete.DataPropertyName = "IsDelete";
			IsDelete.HeaderText = "Deletar Log";
			IsDelete.Name = "IsDelete";
			// 
			// DaysDelete
			// 
			DaysDelete.DataPropertyName = "DaysDelete";
			DaysDelete.HeaderText = "Dias";
			DaysDelete.Name = "DaysDelete";
			// 
			// NumDays
			// 
			NumDays.Location = new Point(167, 198);
			NumDays.Name = "NumDays";
			NumDays.Size = new Size(40, 23);
			NumDays.TabIndex = 10;
			NumDays.Value = new decimal(new int[] { 30, 0, 0, 0 });
			// 
			// FrmFolder
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(666, 534);
			Controls.Add(groupBox2);
			Controls.Add(BtnDelete);
			Controls.Add(BtnAlter);
			Controls.Add(BtnSave);
			Controls.Add(groupBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FrmFolder";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Pastas";
			Load += FrmFolder_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)DgvListPaths).EndInit();
			((System.ComponentModel.ISupportInitialize)NumDays).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private Label label1;
		private Button BtnSearchPathInput;
		private TextBox TxtPathInput;
		private Button BtnSearchPathLog;
		private Button BtnSearchPathOutput;
		private TextBox TxtPathLog;
		private TextBox TxtPathOutput;
		private Label label3;
		private Label label2;
		private Button BtnSave;
		private Button BtnAlter;
		private Button BtnDelete;
		private GroupBox groupBox2;
		private DataGridView DgvListPaths;
		private Button BtnSearchPathError;
		private TextBox TxtPathError;
		private Label label4;
		private CheckBox CbIsDelete;
		private Label label5;
		private DataGridViewTextBoxColumn Id;
		private DataGridViewTextBoxColumn PathInput;
		private DataGridViewTextBoxColumn PathOutput;
		private DataGridViewTextBoxColumn PathError;
		private DataGridViewTextBoxColumn PathLog;
		private DataGridViewCheckBoxColumn IsDelete;
		private DataGridViewTextBoxColumn DaysDelete;
		private NumericUpDown NumDays;
	}
}