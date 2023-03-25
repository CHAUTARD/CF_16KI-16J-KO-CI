/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
namespace CF_16KI_16J_KO_CI
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbTable = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbCategorie = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbGroupe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbTour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbSexe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbDivision = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pointage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Dossard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Licence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BntSnake = new System.Windows.Forms.Button();
            this.BtnExcelQualifies = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParamétresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.préférenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AProposDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(596, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Critérium Fédéral - 16 Joueurs - 4 Poules - Classement intégral";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CmbTable);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CmbCategorie);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CmbGroupe);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbTour);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CmbSexe);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CmbDivision);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 78);
            this.panel1.TabIndex = 1;
            // 
            // CmbTable
            // 
            this.CmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTable.FormattingEnabled = true;
            this.CmbTable.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.CmbTable.Location = new System.Drawing.Point(626, 37);
            this.CmbTable.Name = "CmbTable";
            this.CmbTable.Size = new System.Drawing.Size(121, 21);
            this.CmbTable.TabIndex = 12;
            this.CmbTable.SelectedIndexChanged += new System.EventHandler(this.CmbTable_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Numéro 1ére table :";
            // 
            // CmbCategorie
            // 
            this.CmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategorie.FormattingEnabled = true;
            this.CmbCategorie.Location = new System.Drawing.Point(541, 9);
            this.CmbCategorie.Name = "CmbCategorie";
            this.CmbCategorie.Size = new System.Drawing.Size(206, 21);
            this.CmbCategorie.TabIndex = 10;
            this.CmbCategorie.SelectedIndexChanged += new System.EventHandler(this.CmbCategorie_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Catégorie :";
            // 
            // CmbGroupe
            // 
            this.CmbGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGroupe.FormattingEnabled = true;
            this.CmbGroupe.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.CmbGroupe.Location = new System.Drawing.Point(355, 37);
            this.CmbGroupe.Name = "CmbGroupe";
            this.CmbGroupe.Size = new System.Drawing.Size(58, 21);
            this.CmbGroupe.TabIndex = 7;
            this.CmbGroupe.SelectedIndexChanged += new System.EventHandler(this.CmbGroupe_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Groupe :";
            // 
            // CmbTour
            // 
            this.CmbTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTour.FormattingEnabled = true;
            this.CmbTour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.CmbTour.Location = new System.Drawing.Point(355, 4);
            this.CmbTour.Name = "CmbTour";
            this.CmbTour.Size = new System.Drawing.Size(58, 21);
            this.CmbTour.TabIndex = 5;
            this.CmbTour.SelectedIndexChanged += new System.EventHandler(this.CmbTour_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tour :";
            // 
            // CmbSexe
            // 
            this.CmbSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSexe.FormattingEnabled = true;
            this.CmbSexe.Items.AddRange(new object[] {
            "Messieurs",
            "Dames"});
            this.CmbSexe.Location = new System.Drawing.Point(89, 37);
            this.CmbSexe.Name = "CmbSexe";
            this.CmbSexe.Size = new System.Drawing.Size(167, 21);
            this.CmbSexe.TabIndex = 3;
            this.CmbSexe.SelectedIndexChanged += new System.EventHandler(this.CmbSexe_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sexe :";
            // 
            // CmbDivision
            // 
            this.CmbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDivision.FormattingEnabled = true;
            this.CmbDivision.Location = new System.Drawing.Point(89, 4);
            this.CmbDivision.Name = "CmbDivision";
            this.CmbDivision.Size = new System.Drawing.Size(167, 21);
            this.CmbDivision.TabIndex = 1;
            this.CmbDivision.SelectedIndexChanged += new System.EventHandler(this.CmbDivision_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Division :";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pointage,
            this.Dossard,
            this.Nom,
            this.Licence,
            this.Classement,
            this.Club});
            this.DataGridView1.Location = new System.Drawing.Point(12, 158);
            this.DataGridView1.MultiSelect = false;
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(776, 427);
            this.DataGridView1.TabIndex = 2;
            this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.DataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
            this.DataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_ColumnHeaderMouseClick);
            this.DataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
            // 
            // Pointage
            // 
            this.Pointage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Pointage.FillWeight = 60F;
            this.Pointage.Frozen = true;
            this.Pointage.HeaderText = "Pointage";
            this.Pointage.Name = "Pointage";
            this.Pointage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Pointage.Width = 70;
            // 
            // Dossard
            // 
            this.Dossard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Dossard.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dossard.FillWeight = 40F;
            this.Dossard.Frozen = true;
            this.Dossard.HeaderText = "Dossard";
            this.Dossard.Name = "Dossard";
            this.Dossard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dossard.Width = 70;
            // 
            // Nom
            // 
            this.Nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Nom.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nom.FillWeight = 210F;
            this.Nom.Frozen = true;
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.Width = 200;
            // 
            // Licence
            // 
            this.Licence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Licence.DefaultCellStyle = dataGridViewCellStyle4;
            this.Licence.Frozen = true;
            this.Licence.HeaderText = "Licence";
            this.Licence.Name = "Licence";
            this.Licence.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Licence.Width = 70;
            // 
            // Classement
            // 
            this.Classement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Classement.DefaultCellStyle = dataGridViewCellStyle5;
            this.Classement.Frozen = true;
            this.Classement.HeaderText = "Classement";
            this.Classement.Name = "Classement";
            this.Classement.Width = 80;
            // 
            // Club
            // 
            this.Club.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Club.DefaultCellStyle = dataGridViewCellStyle6;
            this.Club.Frozen = true;
            this.Club.HeaderText = "Club";
            this.Club.Name = "Club";
            this.Club.Width = 240;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsx";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Fichier des qualifié(e)s";
            // 
            // BtnClose
            // 
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.Close_64;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnClose.Location = new System.Drawing.Point(698, 602);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(90, 90);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "Fermeture";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BntSnake
            // 
            this.BntSnake.Enabled = false;
            this.BntSnake.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.Snack_64;
            this.BntSnake.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BntSnake.Location = new System.Drawing.Point(144, 602);
            this.BntSnake.Name = "BntSnake";
            this.BntSnake.Size = new System.Drawing.Size(90, 90);
            this.BntSnake.TabIndex = 4;
            this.BntSnake.Text = "Mise en poule";
            this.BntSnake.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BntSnake.UseVisualStyleBackColor = true;
            this.BntSnake.Click += new System.EventHandler(this.BntSnake_Click);
            // 
            // BtnExcelQualifies
            // 
            this.BtnExcelQualifies.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcelQualifies.Image")));
            this.BtnExcelQualifies.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExcelQualifies.Location = new System.Drawing.Point(12, 602);
            this.BtnExcelQualifies.Name = "BtnExcelQualifies";
            this.BtnExcelQualifies.Size = new System.Drawing.Size(109, 90);
            this.BtnExcelQualifies.TabIndex = 3;
            this.BtnExcelQualifies.Text = "Excel des qualifiés";
            this.BtnExcelQualifies.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnExcelQualifies.UseVisualStyleBackColor = true;
            this.BtnExcelQualifies.Click += new System.EventHandler(this.BtnExcelQualifies_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outilsToolStripMenuItem,
            this.préférenceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParamétresToolStripMenuItem});
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            this.outilsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.outilsToolStripMenuItem.Text = "Outils";
            // 
            // ParamétresToolStripMenuItem
            // 
            this.ParamétresToolStripMenuItem.Name = "ParamétresToolStripMenuItem";
            this.ParamétresToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ParamétresToolStripMenuItem.Text = "Préférences";
            this.ParamétresToolStripMenuItem.Click += new System.EventHandler(this.ParamétresToolStripMenuItem_Click);
            // 
            // préférenceToolStripMenuItem
            // 
            this.préférenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AProposDeToolStripMenuItem});
            this.préférenceToolStripMenuItem.Name = "préférenceToolStripMenuItem";
            this.préférenceToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.préférenceToolStripMenuItem.Text = "Aide";
            // 
            // AProposDeToolStripMenuItem
            // 
            this.AProposDeToolStripMenuItem.Name = "AProposDeToolStripMenuItem";
            this.AProposDeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.AProposDeToolStripMenuItem.Text = "A propos de ...";
            this.AProposDeToolStripMenuItem.Click += new System.EventHandler(this.AProposDeToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(800, 702);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BntSnake);
            this.Controls.Add(this.BtnExcelQualifies);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Critérium Fédéral - 16 joueurs - Classement intégral";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbDivision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbSexe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbGroupe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbCategorie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Button BtnExcelQualifies;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BntSnake;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox CmbTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem préférenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AProposDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParamétresToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pointage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dossard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Licence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club;
    }
}

