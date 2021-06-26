
namespace sebduruz_GameOfLife
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gameAreaPanel = new System.Windows.Forms.Panel();
            this.startBreakButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.cycleGenLabel = new System.Windows.Forms.Label();
            this.livingCellsLabel = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.livingCellMaxLabel = new System.Windows.Forms.Label();
            this.livingCellMinLabel = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.lastCycleButton = new System.Windows.Forms.Button();
            this.nextCycleButton = new System.Windows.Forms.Button();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.borderCheckBox = new System.Windows.Forms.CheckBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.cellColorTextLabel = new System.Windows.Forms.Label();
            this.confirmCellSizeChangeButton = new System.Windows.Forms.Button();
            this.buttonSizeLabel = new System.Windows.Forms.Label();
            this.cellSizeNumericValue = new System.Windows.Forms.NumericUpDown();
            this.rulesGroupBox = new System.Windows.Forms.GroupBox();
            this.wikiFRLabel = new System.Windows.Forms.LinkLabel();
            this.wikiEnLinkLabel = new System.Windows.Forms.LinkLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createGridBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.infoLabel = new System.Windows.Forms.Label();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.cellColorChooserDialog = new System.Windows.Forms.ColorDialog();
            this.statsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.actionsGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSizeNumericValue)).BeginInit();
            this.rulesGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.infoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameAreaPanel
            // 
            this.gameAreaPanel.Location = new System.Drawing.Point(12, 28);
            this.gameAreaPanel.Name = "gameAreaPanel";
            this.gameAreaPanel.Size = new System.Drawing.Size(700, 700);
            this.gameAreaPanel.TabIndex = 0;
            // 
            // startBreakButton
            // 
            this.startBreakButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startBreakButton.Location = new System.Drawing.Point(6, 19);
            this.startBreakButton.Name = "startBreakButton";
            this.startBreakButton.Size = new System.Drawing.Size(219, 45);
            this.startBreakButton.TabIndex = 1;
            this.startBreakButton.Text = "Démarrer / Pause";
            this.startBreakButton.UseVisualStyleBackColor = true;
            this.startBreakButton.Click += new System.EventHandler(this.StartButtonClicked);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(6, 173);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(219, 45);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Réinitialiser";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButtonClicked);
            // 
            // cycleGenLabel
            // 
            this.cycleGenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cycleGenLabel.AutoSize = true;
            this.cycleGenLabel.Location = new System.Drawing.Point(13, 23);
            this.cycleGenLabel.Name = "cycleGenLabel";
            this.cycleGenLabel.Size = new System.Drawing.Size(100, 13);
            this.cycleGenLabel.TabIndex = 4;
            this.cycleGenLabel.Text = "Cycles effectués : 0";
            // 
            // livingCellsLabel
            // 
            this.livingCellsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livingCellsLabel.AutoSize = true;
            this.livingCellsLabel.Location = new System.Drawing.Point(13, 49);
            this.livingCellsLabel.Name = "livingCellsLabel";
            this.livingCellsLabel.Size = new System.Drawing.Size(101, 13);
            this.livingCellsLabel.TabIndex = 5;
            this.livingCellsLabel.Text = "Cellules vivantes : 0";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 500;
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.Controls.Add(this.livingCellMaxLabel);
            this.statsGroupBox.Controls.Add(this.livingCellMinLabel);
            this.statsGroupBox.Controls.Add(this.cycleGenLabel);
            this.statsGroupBox.Controls.Add(this.livingCellsLabel);
            this.statsGroupBox.Location = new System.Drawing.Point(718, 537);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(233, 127);
            this.statsGroupBox.TabIndex = 6;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Statistiques";
            // 
            // livingCellMaxLabel
            // 
            this.livingCellMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livingCellMaxLabel.AutoSize = true;
            this.livingCellMaxLabel.Location = new System.Drawing.Point(13, 98);
            this.livingCellMaxLabel.Name = "livingCellMaxLabel";
            this.livingCellMaxLabel.Size = new System.Drawing.Size(66, 13);
            this.livingCellMaxLabel.TabIndex = 7;
            this.livingCellMaxLabel.Text = "Maximum : 0";
            // 
            // livingCellMinLabel
            // 
            this.livingCellMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livingCellMinLabel.AutoSize = true;
            this.livingCellMinLabel.Location = new System.Drawing.Point(13, 74);
            this.livingCellMinLabel.Name = "livingCellMinLabel";
            this.livingCellMinLabel.Size = new System.Drawing.Size(63, 13);
            this.livingCellMinLabel.TabIndex = 6;
            this.livingCellMinLabel.Text = "Minimum : 0";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speedTrackBar.LargeChange = 1;
            this.speedTrackBar.Location = new System.Drawing.Point(6, 131);
            this.speedTrackBar.Maximum = 80;
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(219, 45);
            this.speedTrackBar.TabIndex = 7;
            this.speedTrackBar.Value = 10;
            this.speedTrackBar.ValueChanged += new System.EventHandler(this.SpeedTrackBarValueChanded);
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(85, 163);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(78, 13);
            this.speedLabel.TabIndex = 8;
            this.speedLabel.Text = "Vitesse : 50 ms";
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Controls.Add(this.lastCycleButton);
            this.actionsGroupBox.Controls.Add(this.nextCycleButton);
            this.actionsGroupBox.Controls.Add(this.startBreakButton);
            this.actionsGroupBox.Controls.Add(this.resetButton);
            this.actionsGroupBox.Location = new System.Drawing.Point(718, 28);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(233, 227);
            this.actionsGroupBox.TabIndex = 9;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Actions";
            // 
            // lastCycleButton
            // 
            this.lastCycleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lastCycleButton.Location = new System.Drawing.Point(6, 122);
            this.lastCycleButton.Name = "lastCycleButton";
            this.lastCycleButton.Size = new System.Drawing.Size(219, 45);
            this.lastCycleButton.TabIndex = 5;
            this.lastCycleButton.Text = "Dernier Cycle";
            this.lastCycleButton.UseVisualStyleBackColor = true;
            this.lastCycleButton.Click += new System.EventHandler(this.LastCycleButtonClick);
            // 
            // nextCycleButton
            // 
            this.nextCycleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextCycleButton.Location = new System.Drawing.Point(6, 70);
            this.nextCycleButton.Name = "nextCycleButton";
            this.nextCycleButton.Size = new System.Drawing.Size(219, 45);
            this.nextCycleButton.TabIndex = 4;
            this.nextCycleButton.Text = "Prochain Cycle";
            this.nextCycleButton.UseVisualStyleBackColor = true;
            this.nextCycleButton.Click += new System.EventHandler(this.NextCycleClicked);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.borderCheckBox);
            this.settingsGroupBox.Controls.Add(this.colorLabel);
            this.settingsGroupBox.Controls.Add(this.cellColorTextLabel);
            this.settingsGroupBox.Controls.Add(this.confirmCellSizeChangeButton);
            this.settingsGroupBox.Controls.Add(this.buttonSizeLabel);
            this.settingsGroupBox.Controls.Add(this.cellSizeNumericValue);
            this.settingsGroupBox.Controls.Add(this.speedLabel);
            this.settingsGroupBox.Controls.Add(this.speedTrackBar);
            this.settingsGroupBox.Location = new System.Drawing.Point(718, 271);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(233, 182);
            this.settingsGroupBox.TabIndex = 10;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Paramètres";
            // 
            // borderCheckBox
            // 
            this.borderCheckBox.AutoSize = true;
            this.borderCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.borderCheckBox.Checked = true;
            this.borderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.borderCheckBox.Location = new System.Drawing.Point(3, 94);
            this.borderCheckBox.Name = "borderCheckBox";
            this.borderCheckBox.Size = new System.Drawing.Size(119, 17);
            this.borderCheckBox.TabIndex = 14;
            this.borderCheckBox.Text = "Activer les bordures";
            this.borderCheckBox.UseVisualStyleBackColor = true;
            this.borderCheckBox.CheckedChanged += new System.EventHandler(this.BordersCheckedChanged);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorLabel.Location = new System.Drawing.Point(120, 62);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(45, 15);
            this.colorLabel.TabIndex = 12;
            this.colorLabel.Text = "            ";
            this.colorLabel.BackColorChanged += new System.EventHandler(this.ColorLabelBackColorChanged);
            this.colorLabel.Click += new System.EventHandler(this.ColorLabelClick);
            // 
            // cellColorTextLabel
            // 
            this.cellColorTextLabel.AutoSize = true;
            this.cellColorTextLabel.Location = new System.Drawing.Point(3, 62);
            this.cellColorTextLabel.Name = "cellColorTextLabel";
            this.cellColorTextLabel.Size = new System.Drawing.Size(101, 13);
            this.cellColorTextLabel.TabIndex = 11;
            this.cellColorTextLabel.Text = "Couleur des cellules";
            this.cellColorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // confirmCellSizeChangeButton
            // 
            this.confirmCellSizeChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmCellSizeChangeButton.Location = new System.Drawing.Point(172, 26);
            this.confirmCellSizeChangeButton.Name = "confirmCellSizeChangeButton";
            this.confirmCellSizeChangeButton.Size = new System.Drawing.Size(53, 20);
            this.confirmCellSizeChangeButton.TabIndex = 5;
            this.confirmCellSizeChangeButton.Text = "Valider";
            this.confirmCellSizeChangeButton.UseVisualStyleBackColor = true;
            this.confirmCellSizeChangeButton.Visible = false;
            this.confirmCellSizeChangeButton.Click += new System.EventHandler(this.ConfirmCellSizeChangeButtonClick);
            // 
            // buttonSizeLabel
            // 
            this.buttonSizeLabel.AutoSize = true;
            this.buttonSizeLabel.Location = new System.Drawing.Point(3, 28);
            this.buttonSizeLabel.Name = "buttonSizeLabel";
            this.buttonSizeLabel.Size = new System.Drawing.Size(90, 13);
            this.buttonSizeLabel.TabIndex = 10;
            this.buttonSizeLabel.Text = "Taille des cellules";
            this.buttonSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cellSizeNumericValue
            // 
            this.cellSizeNumericValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cellSizeNumericValue.Location = new System.Drawing.Point(120, 26);
            this.cellSizeNumericValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cellSizeNumericValue.Name = "cellSizeNumericValue";
            this.cellSizeNumericValue.Size = new System.Drawing.Size(43, 20);
            this.cellSizeNumericValue.TabIndex = 9;
            this.cellSizeNumericValue.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.cellSizeNumericValue.ValueChanged += new System.EventHandler(this.CellSizeNumericValueValueChanged);
            // 
            // rulesGroupBox
            // 
            this.rulesGroupBox.Controls.Add(this.wikiFRLabel);
            this.rulesGroupBox.Controls.Add(this.wikiEnLinkLabel);
            this.rulesGroupBox.Location = new System.Drawing.Point(718, 670);
            this.rulesGroupBox.Name = "rulesGroupBox";
            this.rulesGroupBox.Size = new System.Drawing.Size(233, 58);
            this.rulesGroupBox.TabIndex = 11;
            this.rulesGroupBox.TabStop = false;
            this.rulesGroupBox.Text = "Règles";
            // 
            // wikiFRLabel
            // 
            this.wikiFRLabel.AutoSize = true;
            this.wikiFRLabel.Location = new System.Drawing.Point(169, 30);
            this.wikiFRLabel.Name = "wikiFRLabel";
            this.wikiFRLabel.Size = new System.Drawing.Size(45, 13);
            this.wikiFRLabel.TabIndex = 1;
            this.wikiFRLabel.TabStop = true;
            this.wikiFRLabel.Text = "Wiki FR";
            this.wikiFRLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WikiFRLabelClicked);
            // 
            // wikiEnLinkLabel
            // 
            this.wikiEnLinkLabel.AutoSize = true;
            this.wikiEnLinkLabel.Location = new System.Drawing.Point(13, 30);
            this.wikiEnLinkLabel.Name = "wikiEnLinkLabel";
            this.wikiEnLinkLabel.Size = new System.Drawing.Size(46, 13);
            this.wikiEnLinkLabel.TabIndex = 0;
            this.wikiEnLinkLabel.TabStop = true;
            this.wikiEnLinkLabel.Text = "Wiki EN";
            this.wikiEnLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WikiENLabelClicked);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.langueToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(970, 24);
            this.menuStrip.TabIndex = 12;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importToolStripMenuItem.Text = "Importer";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.ImportClick);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exportToolStripMenuItem.Text = "Exporter";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportClick);
            // 
            // langueToolStripMenuItem
            // 
            this.langueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fRToolStripMenuItem,
            this.toolStripMenuItem1});
            this.langueToolStripMenuItem.Name = "langueToolStripMenuItem";
            this.langueToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.langueToolStripMenuItem.Text = "Language";
            // 
            // fRToolStripMenuItem
            // 
            this.fRToolStripMenuItem.Name = "fRToolStripMenuItem";
            this.fRToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.fRToolStripMenuItem.Text = "FR";
            this.fRToolStripMenuItem.Click += new System.EventHandler(this.FRToolStripMenuClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 22);
            this.toolStripMenuItem1.Text = "EN";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ENToolStripMenuClick);
            // 
            // createGridBackgroundWorker
            // 
            this.createGridBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.createGridBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Location = new System.Drawing.Point(6, 42);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(219, 24);
            this.loadingProgressBar.Step = 5;
            this.loadingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.loadingProgressBar.TabIndex = 0;
            this.loadingProgressBar.Visible = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(31, 26);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(167, 13);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "Chargement de la grille en cours...";
            this.infoLabel.Visible = false;
            // 
            // loadingPanel
            // 
            this.loadingPanel.Location = new System.Drawing.Point(0, 27);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(712, 701);
            this.loadingPanel.TabIndex = 13;
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.infoLabel);
            this.infoGroupBox.Controls.Add(this.loadingProgressBar);
            this.infoGroupBox.Location = new System.Drawing.Point(718, 459);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(233, 72);
            this.infoGroupBox.TabIndex = 14;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "Informations";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 740);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.rulesGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.actionsGroupBox);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.gameAreaPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Game Of Life";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.actionsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSizeNumericValue)).EndInit();
            this.rulesGroupBox.ResumeLayout(false);
            this.rulesGroupBox.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.infoGroupBox.ResumeLayout(false);
            this.infoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gameAreaPanel;
        private System.Windows.Forms.Button startBreakButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label cycleGenLabel;
        private System.Windows.Forms.Label livingCellsLabel;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.GroupBox statsGroupBox;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Button nextCycleButton;
        private System.Windows.Forms.Label livingCellMaxLabel;
        private System.Windows.Forms.Label livingCellMinLabel;
        private System.Windows.Forms.GroupBox rulesGroupBox;
        private System.Windows.Forms.LinkLabel wikiEnLinkLabel;
        private System.Windows.Forms.LinkLabel wikiFRLabel;
        private System.Windows.Forms.Label buttonSizeLabel;
        private System.Windows.Forms.NumericUpDown cellSizeNumericValue;
        private System.Windows.Forms.Button confirmCellSizeChangeButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker createGridBackgroundWorker;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Panel loadingPanel;
        private System.Windows.Forms.GroupBox infoGroupBox;
        private System.Windows.Forms.Label cellColorTextLabel;
        private System.Windows.Forms.ColorDialog cellColorChooserDialog;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button lastCycleButton;
        private System.Windows.Forms.CheckBox borderCheckBox;
        private System.Windows.Forms.ToolStripMenuItem langueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

