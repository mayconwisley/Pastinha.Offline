namespace Pastinha.App
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            LblInfoService = new Label();
            MenuMain = new MenuStrip();
            MenuConfiguracao = new ToolStripMenuItem();
            SubMenuPasta = new ToolStripMenuItem();
            SubMenuOffline = new ToolStripMenuItem();
            SubMenuStatusFired = new ToolStripMenuItem();
            MenuFromTo = new ToolStripMenuItem();
            SubMenuFromToEmpresa = new ToolStripMenuItem();
            SubMenuFromToTipoColaborador = new ToolStripMenuItem();
            SubMenuFromToColaborador = new ToolStripMenuItem();
            MenuUtility = new ToolStripMenuItem();
            SubMenuGenerateKey = new ToolStripMenuItem();
            SubMenuService = new ToolStripMenuItem();
            SubMenuServiceStart = new ToolStripMenuItem();
            SubMenuServiceStop = new ToolStripMenuItem();
            SubMenuOpenFolder = new ToolStripMenuItem();
            SubMenuOpenFolderInput = new ToolStripMenuItem();
            SubMenuOpenFolderOutput = new ToolStripMenuItem();
            SubMenuOpenFolderError = new ToolStripMenuItem();
            SubMenuOpenFolderLog = new ToolStripMenuItem();
            SubMenuOpenFolderOffline = new ToolStripMenuItem();
            MenuReport = new ToolStripMenuItem();
            SubMenuReportList = new ToolStripMenuItem();
            TimeMain = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            StatusMain = new StatusStrip();
            ToolLblInfo = new ToolStripStatusLabel();
            panel2 = new Panel();
            MenuMain.SuspendLayout();
            panel1.SuspendLayout();
            StatusMain.SuspendLayout();
            SuspendLayout();
            // 
            // LblInfoService
            // 
            LblInfoService.AutoSize = true;
            LblInfoService.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblInfoService.Location = new Point(3, 9);
            LblInfoService.Name = "LblInfoService";
            LblInfoService.Size = new Size(16, 25);
            LblInfoService.TabIndex = 2;
            LblInfoService.Text = ".";
            // 
            // MenuMain
            // 
            MenuMain.BackColor = Color.Transparent;
            MenuMain.Items.AddRange(new ToolStripItem[] { MenuConfiguracao, MenuFromTo, MenuUtility, MenuReport });
            MenuMain.Location = new Point(0, 0);
            MenuMain.Name = "MenuMain";
            MenuMain.Size = new Size(1169, 24);
            MenuMain.TabIndex = 3;
            MenuMain.Text = "menuStrip1";
            // 
            // MenuConfiguracao
            // 
            MenuConfiguracao.DropDownItems.AddRange(new ToolStripItem[] { SubMenuPasta, SubMenuOffline, SubMenuStatusFired });
            MenuConfiguracao.Name = "MenuConfiguracao";
            MenuConfiguracao.Size = new Size(96, 20);
            MenuConfiguracao.Text = "Configurações";
            MenuConfiguracao.Visible = false;
            // 
            // SubMenuPasta
            // 
            SubMenuPasta.Name = "SubMenuPasta";
            SubMenuPasta.Size = new Size(180, 22);
            SubMenuPasta.Text = "Pastas";
            SubMenuPasta.Click += SubMenuPasta_Click;
            // 
            // SubMenuOffline
            // 
            SubMenuOffline.Name = "SubMenuOffline";
            SubMenuOffline.Size = new Size(180, 22);
            SubMenuOffline.Text = "Offline";
            SubMenuOffline.Click += SubMenuOffline_Click;
            // 
            // SubMenuStatusFired
            // 
            SubMenuStatusFired.Name = "SubMenuStatusFired";
            SubMenuStatusFired.Size = new Size(180, 22);
            SubMenuStatusFired.Text = "Status Demitido";
            SubMenuStatusFired.Click += SubMenuStatusFired_Click;
            // 
            // MenuFromTo
            // 
            MenuFromTo.DropDownItems.AddRange(new ToolStripItem[] { SubMenuFromToEmpresa, SubMenuFromToTipoColaborador, SubMenuFromToColaborador });
            MenuFromTo.Name = "MenuFromTo";
            MenuFromTo.Size = new Size(61, 20);
            MenuFromTo.Text = "De-Para";
            // 
            // SubMenuFromToEmpresa
            // 
            SubMenuFromToEmpresa.Name = "SubMenuFromToEmpresa";
            SubMenuFromToEmpresa.Size = new Size(167, 22);
            SubMenuFromToEmpresa.Text = "Empresa";
            SubMenuFromToEmpresa.Click += SubMenuFromToEmpresa_Click;
            // 
            // SubMenuFromToTipoColaborador
            // 
            SubMenuFromToTipoColaborador.Name = "SubMenuFromToTipoColaborador";
            SubMenuFromToTipoColaborador.Size = new Size(167, 22);
            SubMenuFromToTipoColaborador.Text = "Tipo Colaborador";
            SubMenuFromToTipoColaborador.Click += SubMenuFromToTipoColaborador_Click;
            // 
            // SubMenuFromToColaborador
            // 
            SubMenuFromToColaborador.Name = "SubMenuFromToColaborador";
            SubMenuFromToColaborador.Size = new Size(167, 22);
            SubMenuFromToColaborador.Text = "Colaborador";
            SubMenuFromToColaborador.Click += SubMenuFromToColaborador_Click;
            // 
            // MenuUtility
            // 
            MenuUtility.DropDownItems.AddRange(new ToolStripItem[] { SubMenuGenerateKey, SubMenuService, SubMenuOpenFolder });
            MenuUtility.Name = "MenuUtility";
            MenuUtility.Size = new Size(64, 20);
            MenuUtility.Text = "Utilitário";
            // 
            // SubMenuGenerateKey
            // 
            SubMenuGenerateKey.Name = "SubMenuGenerateKey";
            SubMenuGenerateKey.Size = new Size(180, 22);
            SubMenuGenerateKey.Text = "Gerar Chaves";
            SubMenuGenerateKey.Click += SubMenuGenerateKey_Click;
            // 
            // SubMenuService
            // 
            SubMenuService.DropDownItems.AddRange(new ToolStripItem[] { SubMenuServiceStart, SubMenuServiceStop });
            SubMenuService.Name = "SubMenuService";
            SubMenuService.Size = new Size(180, 22);
            SubMenuService.Text = "Serviço";
            // 
            // SubMenuServiceStart
            // 
            SubMenuServiceStart.Name = "SubMenuServiceStart";
            SubMenuServiceStart.Size = new Size(106, 22);
            SubMenuServiceStart.Text = "Iniciar";
            SubMenuServiceStart.Click += SubMenuServiceStart_Click;
            // 
            // SubMenuServiceStop
            // 
            SubMenuServiceStop.Name = "SubMenuServiceStop";
            SubMenuServiceStop.Size = new Size(106, 22);
            SubMenuServiceStop.Text = "Parar";
            SubMenuServiceStop.Click += SubMenuServiceStop_Click;
            // 
            // SubMenuOpenFolder
            // 
            SubMenuOpenFolder.DropDownItems.AddRange(new ToolStripItem[] { SubMenuOpenFolderInput, SubMenuOpenFolderOutput, SubMenuOpenFolderError, SubMenuOpenFolderLog, SubMenuOpenFolderOffline });
            SubMenuOpenFolder.Name = "SubMenuOpenFolder";
            SubMenuOpenFolder.Size = new Size(180, 22);
            SubMenuOpenFolder.Text = "Abrir Pastas";
            // 
            // SubMenuOpenFolderInput
            // 
            SubMenuOpenFolderInput.Name = "SubMenuOpenFolderInput";
            SubMenuOpenFolderInput.Size = new Size(114, 22);
            SubMenuOpenFolderInput.Text = "Entrada";
            SubMenuOpenFolderInput.Click += SubMenuOpenFolderInput_Click;
            // 
            // SubMenuOpenFolderOutput
            // 
            SubMenuOpenFolderOutput.Name = "SubMenuOpenFolderOutput";
            SubMenuOpenFolderOutput.Size = new Size(114, 22);
            SubMenuOpenFolderOutput.Text = "Saída";
            SubMenuOpenFolderOutput.Click += SubMenuOpenFolderOutput_Click;
            // 
            // SubMenuOpenFolderError
            // 
            SubMenuOpenFolderError.Name = "SubMenuOpenFolderError";
            SubMenuOpenFolderError.Size = new Size(114, 22);
            SubMenuOpenFolderError.Text = "Erro";
            SubMenuOpenFolderError.Click += SubMenuOpenFolderError_Click;
            // 
            // SubMenuOpenFolderLog
            // 
            SubMenuOpenFolderLog.Name = "SubMenuOpenFolderLog";
            SubMenuOpenFolderLog.Size = new Size(114, 22);
            SubMenuOpenFolderLog.Text = "Log";
            SubMenuOpenFolderLog.Click += SubMenuOpenFolderLog_Click;
            // 
            // SubMenuOpenFolderOffline
            // 
            SubMenuOpenFolderOffline.Name = "SubMenuOpenFolderOffline";
            SubMenuOpenFolderOffline.Size = new Size(114, 22);
            SubMenuOpenFolderOffline.Text = "Offline";
            SubMenuOpenFolderOffline.Click += SubMenuOpenFolderOffline_Click;
            // 
            // MenuReport
            // 
            MenuReport.DropDownItems.AddRange(new ToolStripItem[] { SubMenuReportList });
            MenuReport.Name = "MenuReport";
            MenuReport.Size = new Size(66, 20);
            MenuReport.Text = "Relatório";
            // 
            // SubMenuReportList
            // 
            SubMenuReportList.Name = "SubMenuReportList";
            SubMenuReportList.Size = new Size(180, 22);
            SubMenuReportList.Text = "Listar";
            SubMenuReportList.Click += SubMenuReportList_Click;
            // 
            // TimeMain
            // 
            TimeMain.Interval = 1000;
            TimeMain.Tick += TimeMain_Tick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(LblInfoService);
            panel1.Location = new Point(12, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1145, 96);
            panel1.TabIndex = 4;
            // 
            // StatusMain
            // 
            StatusMain.Items.AddRange(new ToolStripItem[] { ToolLblInfo });
            StatusMain.Location = new Point(0, 634);
            StatusMain.Name = "StatusMain";
            StatusMain.Size = new Size(1169, 22);
            StatusMain.TabIndex = 5;
            StatusMain.Text = "statusStrip1";
            // 
            // ToolLblInfo
            // 
            ToolLblInfo.Name = "ToolLblInfo";
            ToolLblInfo.Size = new Size(254, 17);
            ToolLblInfo.Text = "Desenvolvido por Maycon Wisley - Versão 1.1.0";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Location = new Point(12, 129);
            panel2.Name = "panel2";
            panel2.Size = new Size(1145, 502);
            panel2.TabIndex = 6;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 656);
            Controls.Add(panel2);
            Controls.Add(StatusMain);
            Controls.Add(panel1);
            Controls.Add(MenuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuMain;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pastinha.exe";
            Load += FrmMain_Load;
            MenuMain.ResumeLayout(false);
            MenuMain.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            StatusMain.ResumeLayout(false);
            StatusMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LblInfoService;
        private MenuStrip MenuMain;
        private ToolStripMenuItem MenuConfiguracao;
        private ToolStripMenuItem SubMenuPasta;
        private ToolStripMenuItem MenuUtility;
        private ToolStripMenuItem SubMenuGenerateKey;
        private ToolStripMenuItem SubMenuService;
        private ToolStripMenuItem SubMenuServiceStart;
        private ToolStripMenuItem SubMenuServiceStop;
        private ToolStripMenuItem SubMenuOpenFolder;
        private ToolStripMenuItem SubMenuOpenFolderInput;
        private ToolStripMenuItem SubMenuOpenFolderOutput;
        private ToolStripMenuItem SubMenuOpenFolderLog;
        private System.Windows.Forms.Timer TimeMain;
        private Panel panel1;
        private StatusStrip StatusMain;
        private ToolStripStatusLabel ToolLblInfo;
        private ToolStripMenuItem SubMenuOpenFolderError;
        private Panel panel2;
        private ToolStripMenuItem MenuReport;
        private ToolStripMenuItem SubMenuReportList;
        private ToolStripMenuItem SubMenuOffline;
        private ToolStripMenuItem SubMenuStatusFired;
        private ToolStripMenuItem SubMenuOpenFolderOffline;
        private ToolStripMenuItem MenuFromTo;
        private ToolStripMenuItem SubMenuFromToEmpresa;
        private ToolStripMenuItem SubMenuFromToTipoColaborador;
        private ToolStripMenuItem SubMenuFromToColaborador;
    }
}
