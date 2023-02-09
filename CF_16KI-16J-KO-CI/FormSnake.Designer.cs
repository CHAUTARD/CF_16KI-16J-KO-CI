namespace CF_16KI_16J_KO_CI
{
    partial class FormSnake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSnake));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGroupe1 = new System.Windows.Forms.DataGridView();
            this.Rang1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Joueur1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dossard1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvGroupe2 = new System.Windows.Forms.DataGridView();
            this.Rang2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Joueur2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dossard2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvGroupe3 = new System.Windows.Forms.DataGridView();
            this.Rang3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Joueur3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dossard3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvGroupe4 = new System.Windows.Forms.DataGridView();
            this.Rang4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Joueur4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dossard4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poule1Edition = new System.Windows.Forms.ToolStripMenuItem();
            this.poule2Edition = new System.Windows.Forms.ToolStripMenuItem();
            this.poule3Edition = new System.Windows.Forms.ToolStripMenuItem();
            this.poule4Edition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCorrection = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe3)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe4)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGroupe1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Groupe 1";
            // 
            // dgvGroupe1
            // 
            this.dgvGroupe1.AllowDrop = true;
            this.dgvGroupe1.AllowUserToAddRows = false;
            this.dgvGroupe1.AllowUserToDeleteRows = false;
            this.dgvGroupe1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupe1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rang1,
            this.Joueur1,
            this.Dossard1,
            this.Club1});
            this.dgvGroupe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupe1.Location = new System.Drawing.Point(3, 16);
            this.dgvGroupe1.Name = "dgvGroupe1";
            this.dgvGroupe1.ReadOnly = true;
            this.dgvGroupe1.Size = new System.Drawing.Size(496, 181);
            this.dgvGroupe1.TabIndex = 0;
            this.dgvGroupe1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGroupe1_DragDrop);
            this.dgvGroupe1.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGroupe1_DragOver);
            this.dgvGroupe1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe1_MouseDown);
            this.dgvGroupe1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe1_MouseMove);
            // 
            // Rang1
            // 
            this.Rang1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rang1.HeaderText = "Rang";
            this.Rang1.Name = "Rang1";
            this.Rang1.ReadOnly = true;
            this.Rang1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rang1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rang1.Width = 39;
            // 
            // Joueur1
            // 
            this.Joueur1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Joueur1.HeaderText = "Joueur";
            this.Joueur1.Name = "Joueur1";
            this.Joueur1.ReadOnly = true;
            this.Joueur1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Joueur1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Joueur1.Width = 45;
            // 
            // Dossard1
            // 
            this.Dossard1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Dossard1.HeaderText = "Dos.";
            this.Dossard1.Name = "Dossard1";
            this.Dossard1.ReadOnly = true;
            this.Dossard1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dossard1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dossard1.ToolTipText = "Dossard";
            this.Dossard1.Width = 35;
            // 
            // Club1
            // 
            this.Club1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Club1.HeaderText = "Club";
            this.Club1.Name = "Club1";
            this.Club1.ReadOnly = true;
            this.Club1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Club1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Club1.Width = 34;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGroupe2);
            this.groupBox2.Location = new System.Drawing.Point(533, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Groupe 2";
            // 
            // dgvGroupe2
            // 
            this.dgvGroupe2.AllowDrop = true;
            this.dgvGroupe2.AllowUserToAddRows = false;
            this.dgvGroupe2.AllowUserToDeleteRows = false;
            this.dgvGroupe2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupe2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rang2,
            this.Joueur2,
            this.Dossard2,
            this.Club2});
            this.dgvGroupe2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupe2.Location = new System.Drawing.Point(3, 16);
            this.dgvGroupe2.Name = "dgvGroupe2";
            this.dgvGroupe2.ReadOnly = true;
            this.dgvGroupe2.Size = new System.Drawing.Size(493, 181);
            this.dgvGroupe2.TabIndex = 0;
            this.dgvGroupe2.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGroupe2_DragDrop);
            this.dgvGroupe2.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGroupe2_DragOver);
            this.dgvGroupe2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe2_MouseDown);
            this.dgvGroupe2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe2_MouseMove);
            // 
            // Rang2
            // 
            this.Rang2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rang2.HeaderText = "Rang";
            this.Rang2.Name = "Rang2";
            this.Rang2.ReadOnly = true;
            this.Rang2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rang2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rang2.Width = 39;
            // 
            // Joueur2
            // 
            this.Joueur2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Joueur2.HeaderText = "Joueur";
            this.Joueur2.Name = "Joueur2";
            this.Joueur2.ReadOnly = true;
            this.Joueur2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Joueur2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Joueur2.Width = 45;
            // 
            // Dossard2
            // 
            this.Dossard2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Dossard2.HeaderText = "Dos.";
            this.Dossard2.Name = "Dossard2";
            this.Dossard2.ReadOnly = true;
            this.Dossard2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dossard2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dossard2.ToolTipText = "Dossard";
            this.Dossard2.Width = 35;
            // 
            // Club2
            // 
            this.Club2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Club2.HeaderText = "Club";
            this.Club2.Name = "Club2";
            this.Club2.ReadOnly = true;
            this.Club2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Club2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Club2.Width = 34;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvGroupe3);
            this.groupBox3.Location = new System.Drawing.Point(12, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 200);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Groupe 3";
            // 
            // dgvGroupe3
            // 
            this.dgvGroupe3.AllowDrop = true;
            this.dgvGroupe3.AllowUserToAddRows = false;
            this.dgvGroupe3.AllowUserToDeleteRows = false;
            this.dgvGroupe3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupe3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rang3,
            this.Joueur3,
            this.Dossard3,
            this.Club3});
            this.dgvGroupe3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupe3.Location = new System.Drawing.Point(3, 16);
            this.dgvGroupe3.Name = "dgvGroupe3";
            this.dgvGroupe3.ReadOnly = true;
            this.dgvGroupe3.Size = new System.Drawing.Size(493, 181);
            this.dgvGroupe3.TabIndex = 0;
            this.dgvGroupe3.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGroupe3_DragDrop);
            this.dgvGroupe3.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGroupe3_DragOver);
            this.dgvGroupe3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe3_MouseDown);
            this.dgvGroupe3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe3_MouseMove);
            // 
            // Rang3
            // 
            this.Rang3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rang3.HeaderText = "Rang";
            this.Rang3.Name = "Rang3";
            this.Rang3.ReadOnly = true;
            this.Rang3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rang3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rang3.Width = 39;
            // 
            // Joueur3
            // 
            this.Joueur3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Joueur3.HeaderText = "Joueur";
            this.Joueur3.Name = "Joueur3";
            this.Joueur3.ReadOnly = true;
            this.Joueur3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Joueur3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Joueur3.Width = 45;
            // 
            // Dossard3
            // 
            this.Dossard3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Dossard3.HeaderText = "Dos.";
            this.Dossard3.Name = "Dossard3";
            this.Dossard3.ReadOnly = true;
            this.Dossard3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dossard3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dossard3.ToolTipText = "Dossard";
            this.Dossard3.Width = 35;
            // 
            // Club3
            // 
            this.Club3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Club3.HeaderText = "Club";
            this.Club3.Name = "Club3";
            this.Club3.ReadOnly = true;
            this.Club3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Club3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Club3.Width = 34;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvGroupe4);
            this.groupBox4.Location = new System.Drawing.Point(533, 234);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(499, 200);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Groupe 4";
            // 
            // dgvGroupe4
            // 
            this.dgvGroupe4.AllowDrop = true;
            this.dgvGroupe4.AllowUserToAddRows = false;
            this.dgvGroupe4.AllowUserToDeleteRows = false;
            this.dgvGroupe4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupe4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rang4,
            this.Joueur4,
            this.Dossard4,
            this.Club4});
            this.dgvGroupe4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupe4.Location = new System.Drawing.Point(3, 16);
            this.dgvGroupe4.Name = "dgvGroupe4";
            this.dgvGroupe4.ReadOnly = true;
            this.dgvGroupe4.Size = new System.Drawing.Size(493, 181);
            this.dgvGroupe4.TabIndex = 0;
            this.dgvGroupe4.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGroupe4_DragDrop);
            this.dgvGroupe4.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGroupe4_DragOver);
            this.dgvGroupe4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe4_MouseDown);
            this.dgvGroupe4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGroupe4_MouseMove);
            // 
            // Rang4
            // 
            this.Rang4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rang4.HeaderText = "Rang";
            this.Rang4.Name = "Rang4";
            this.Rang4.ReadOnly = true;
            this.Rang4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rang4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rang4.Width = 39;
            // 
            // Joueur4
            // 
            this.Joueur4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Joueur4.HeaderText = "Joueur";
            this.Joueur4.Name = "Joueur4";
            this.Joueur4.ReadOnly = true;
            this.Joueur4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Joueur4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Joueur4.Width = 45;
            // 
            // Dossard4
            // 
            this.Dossard4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Dossard4.HeaderText = "Dos.";
            this.Dossard4.Name = "Dossard4";
            this.Dossard4.ReadOnly = true;
            this.Dossard4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dossard4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dossard4.ToolTipText = "Dossard";
            this.Dossard4.Width = 35;
            // 
            // Club4
            // 
            this.Club4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Club4.HeaderText = "Club";
            this.Club4.Name = "Club4";
            this.Club4.ReadOnly = true;
            this.Club4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Club4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Club4.Width = 34;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtMessages);
            this.groupBox5.Location = new System.Drawing.Point(15, 449);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1017, 129);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Messages";
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(0, 19);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(1011, 104);
            this.txtMessages.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.poule1Edition,
            this.poule2Edition,
            this.poule3Edition,
            this.poule4Edition});
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "Edition";
            // 
            // poule1Edition
            // 
            this.poule1Edition.Name = "poule1Edition";
            this.poule1Edition.Size = new System.Drawing.Size(113, 22);
            this.poule1Edition.Text = "Poule 1";
            this.poule1Edition.Click += new System.EventHandler(this.poule1Edition_Click);
            // 
            // poule2Edition
            // 
            this.poule2Edition.Name = "poule2Edition";
            this.poule2Edition.Size = new System.Drawing.Size(113, 22);
            this.poule2Edition.Text = "Poule 2";
            this.poule2Edition.Click += new System.EventHandler(this.poule2Edition_Click);
            // 
            // poule3Edition
            // 
            this.poule3Edition.Name = "poule3Edition";
            this.poule3Edition.Size = new System.Drawing.Size(113, 22);
            this.poule3Edition.Text = "Poule 3";
            this.poule3Edition.Click += new System.EventHandler(this.poule3Edition_Click);
            // 
            // poule4Edition
            // 
            this.poule4Edition.Name = "poule4Edition";
            this.poule4Edition.Size = new System.Drawing.Size(113, 22);
            this.poule4Edition.Text = "Poule 4";
            this.poule4Edition.Click += new System.EventHandler(this.poule4Edition_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.Close_64;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(933, 588);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 90);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Fermeture";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCorrection
            // 
            this.btnCorrection.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.Correct_64;
            this.btnCorrection.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCorrection.Location = new System.Drawing.Point(15, 588);
            this.btnCorrection.Name = "btnCorrection";
            this.btnCorrection.Size = new System.Drawing.Size(99, 90);
            this.btnCorrection.TabIndex = 5;
            this.btnCorrection.Text = "Correction";
            this.btnCorrection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCorrection.UseVisualStyleBackColor = true;
            this.btnCorrection.Visible = false;
            this.btnCorrection.Click += new System.EventHandler(this.btnCorrection_Click);
            // 
            // FormSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 691);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCorrection);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormSnake";
            this.Text = "Mise en poule";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupe4)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGroupe1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvGroupe2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvGroupe3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvGroupe4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rang1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joueur1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dossard1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rang2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joueur2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dossard2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rang3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joueur3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dossard3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rang4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joueur4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dossard4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnCorrection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poule1Edition;
        private System.Windows.Forms.ToolStripMenuItem poule2Edition;
        private System.Windows.Forms.ToolStripMenuItem poule3Edition;
        private System.Windows.Forms.ToolStripMenuItem poule4Edition;
        private System.Windows.Forms.Button btnClose;
    }
}