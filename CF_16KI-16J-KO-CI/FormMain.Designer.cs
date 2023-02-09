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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGroupe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSexe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDivision = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pointage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Dossard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Licence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.bntSnake = new System.Windows.Forms.Button();
            this.btnExcelQualifies = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Critérium Fédéral";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.cmbCategorie);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbGroupe);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbTour);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbSexe);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbDivision);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 78);
            this.panel1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "ddd d MMMM yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(543, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(543, 42);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(206, 21);
            this.cmbCategorie.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Catégorie :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date :";
            // 
            // cmbGroupe
            // 
            this.cmbGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupe.FormattingEnabled = true;
            this.cmbGroupe.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbGroupe.Location = new System.Drawing.Point(355, 37);
            this.cmbGroupe.Name = "cmbGroupe";
            this.cmbGroupe.Size = new System.Drawing.Size(58, 21);
            this.cmbGroupe.TabIndex = 7;
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
            // cmbTour
            // 
            this.cmbTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTour.FormattingEnabled = true;
            this.cmbTour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbTour.Location = new System.Drawing.Point(355, 4);
            this.cmbTour.Name = "cmbTour";
            this.cmbTour.Size = new System.Drawing.Size(58, 21);
            this.cmbTour.TabIndex = 5;
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
            // cmbSexe
            // 
            this.cmbSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexe.FormattingEnabled = true;
            this.cmbSexe.Items.AddRange(new object[] {
            "Messieurs",
            "Dames"});
            this.cmbSexe.Location = new System.Drawing.Point(89, 37);
            this.cmbSexe.Name = "cmbSexe";
            this.cmbSexe.Size = new System.Drawing.Size(167, 21);
            this.cmbSexe.TabIndex = 3;
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
            // cmbDivision
            // 
            this.cmbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDivision.FormattingEnabled = true;
            this.cmbDivision.Location = new System.Drawing.Point(89, 4);
            this.cmbDivision.Name = "cmbDivision";
            this.cmbDivision.Size = new System.Drawing.Size(167, 21);
            this.cmbDivision.TabIndex = 1;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pointage,
            this.Dossard,
            this.Nom,
            this.Licence,
            this.Classement,
            this.Club});
            this.dataGridView1.Location = new System.Drawing.Point(12, 137);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 440);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Pointage
            // 
            this.Pointage.FillWeight = 60F;
            this.Pointage.Frozen = true;
            this.Pointage.HeaderText = "Pointage";
            this.Pointage.Name = "Pointage";
            this.Pointage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Dossard
            // 
            this.Dossard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Dossard.FillWeight = 40F;
            this.Dossard.Frozen = true;
            this.Dossard.HeaderText = "Dossard";
            this.Dossard.Name = "Dossard";
            this.Dossard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dossard.Width = 71;
            // 
            // Nom
            // 
            this.Nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nom.FillWeight = 200F;
            this.Nom.Frozen = true;
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.Width = 54;
            // 
            // Licence
            // 
            this.Licence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Licence.Frozen = true;
            this.Licence.HeaderText = "Licence";
            this.Licence.Name = "Licence";
            this.Licence.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Licence.Width = 70;
            // 
            // Classement
            // 
            this.Classement.Frozen = true;
            this.Classement.HeaderText = "Classement";
            this.Classement.Name = "Classement";
            this.Classement.Width = 80;
            // 
            // Club
            // 
            this.Club.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Club.Frozen = true;
            this.Club.HeaderText = "Club";
            this.Club.Name = "Club";
            this.Club.Width = 53;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsx";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Fichier des qualifié(e)s";
            // 
            // btnAbout
            // 
            this.btnAbout.AutoSize = true;
            this.btnAbout.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.About_32;
            this.btnAbout.Location = new System.Drawing.Point(756, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(43, 50);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.Close_64;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(636, 595);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 90);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Fermeture";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bntSnake
            // 
            this.bntSnake.Enabled = false;
            this.bntSnake.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.Snack_64;
            this.bntSnake.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bntSnake.Location = new System.Drawing.Point(183, 595);
            this.bntSnake.Name = "bntSnake";
            this.bntSnake.Size = new System.Drawing.Size(152, 90);
            this.bntSnake.TabIndex = 4;
            this.bntSnake.Text = "Mise en poule";
            this.bntSnake.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntSnake.UseVisualStyleBackColor = true;
            this.bntSnake.Click += new System.EventHandler(this.bntSnake_Click);
            // 
            // btnExcelQualifies
            // 
            this.btnExcelQualifies.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelQualifies.Image")));
            this.btnExcelQualifies.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcelQualifies.Location = new System.Drawing.Point(12, 595);
            this.btnExcelQualifies.Name = "btnExcelQualifies";
            this.btnExcelQualifies.Size = new System.Drawing.Size(152, 90);
            this.btnExcelQualifies.TabIndex = 3;
            this.btnExcelQualifies.Text = "Fichier Excel des qualifié(e)s";
            this.btnExcelQualifies.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcelQualifies.UseVisualStyleBackColor = true;
            this.btnExcelQualifies.Click += new System.EventHandler(this.btnExcelQualifies_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 699);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.bntSnake);
            this.Controls.Add(this.btnExcelQualifies);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Critérium Fédéral - 16 joueurs - Classement intégral";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDivision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSexe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGroupe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExcelQualifies;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bntSnake;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pointage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dossard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Licence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club;
        private System.Windows.Forms.Button btnAbout;
    }
}

