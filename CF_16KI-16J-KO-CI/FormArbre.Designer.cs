/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
namespace CF_16KI_16J_KO_CI
{
    partial class FormArbre
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArbre));
            this.dgvPartie = new System.Windows.Forms.DataGridView();
            this.Partie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoAb1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Joueur1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Joueur2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoAb2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Score11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arbitre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_Futur8 = new System.Windows.Forms.Label();
            this.lb_Futur7 = new System.Windows.Forms.Label();
            this.lbArbitre4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lb_Futur6 = new System.Windows.Forms.Label();
            this.lb_Futur5 = new System.Windows.Forms.Label();
            this.lbArbitre3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lb_Futur4 = new System.Windows.Forms.Label();
            this.lb_Futur3 = new System.Windows.Forms.Label();
            this.lbArbitre2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lb_Futur2 = new System.Windows.Forms.Label();
            this.lb_Futur1 = new System.Windows.Forms.Label();
            this.lbArbitre1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.bt_suivant = new System.Windows.Forms.Button();
            this.bt_precedent = new System.Windows.Forms.Button();
            this.gbTirageAuSort = new System.Windows.Forms.GroupBox();
            this.rbTirageD = new System.Windows.Forms.RadioButton();
            this.rbTirageC = new System.Windows.Forms.RadioButton();
            this.dataGridViewDispo = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ficheDePartieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arbreDeClassementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartie)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.gbTirageAuSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDispo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPartie
            // 
            this.dgvPartie.AllowUserToAddRows = false;
            this.dgvPartie.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Partie,
            this.FoAb1,
            this.Joueur1,
            this.Joueur2,
            this.FoAb2,
            this.Score11,
            this.Score12,
            this.Score13,
            this.Score14,
            this.Score15,
            this.Arbitre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartie.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPartie.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPartie.Location = new System.Drawing.Point(12, 27);
            this.dgvPartie.Name = "dgvPartie";
            this.dgvPartie.ReadOnly = true;
            this.dgvPartie.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPartie.Size = new System.Drawing.Size(863, 119);
            this.dgvPartie.TabIndex = 7;
            this.dgvPartie.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartie_CellClick);
            // 
            // Partie
            // 
            this.Partie.Frozen = true;
            this.Partie.HeaderText = "Partie";
            this.Partie.Name = "Partie";
            this.Partie.ReadOnly = true;
            this.Partie.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Partie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Partie.Width = 60;
            // 
            // FoAb1
            // 
            this.FoAb1.Frozen = true;
            this.FoAb1.HeaderText = "F/A";
            this.FoAb1.Name = "FoAb1";
            this.FoAb1.ReadOnly = true;
            this.FoAb1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FoAb1.Width = 30;
            // 
            // Joueur1
            // 
            this.Joueur1.Frozen = true;
            this.Joueur1.HeaderText = "Joueur 1";
            this.Joueur1.Name = "Joueur1";
            this.Joueur1.ReadOnly = true;
            this.Joueur1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Joueur1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Joueur1.Width = 200;
            // 
            // Joueur2
            // 
            this.Joueur2.Frozen = true;
            this.Joueur2.HeaderText = "Joueur 2";
            this.Joueur2.Name = "Joueur2";
            this.Joueur2.ReadOnly = true;
            this.Joueur2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Joueur2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Joueur2.Width = 200;
            // 
            // FoAb2
            // 
            this.FoAb2.Frozen = true;
            this.FoAb2.HeaderText = "F/A";
            this.FoAb2.Name = "FoAb2";
            this.FoAb2.ReadOnly = true;
            this.FoAb2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FoAb2.Width = 30;
            // 
            // Score11
            // 
            this.Score11.Frozen = true;
            this.Score11.HeaderText = "Score1";
            this.Score11.Name = "Score11";
            this.Score11.ReadOnly = true;
            this.Score11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Score11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Score11.Width = 60;
            // 
            // Score12
            // 
            this.Score12.Frozen = true;
            this.Score12.HeaderText = "Score2";
            this.Score12.Name = "Score12";
            this.Score12.ReadOnly = true;
            this.Score12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Score12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Score12.Width = 60;
            // 
            // Score13
            // 
            this.Score13.Frozen = true;
            this.Score13.HeaderText = "Score3";
            this.Score13.Name = "Score13";
            this.Score13.ReadOnly = true;
            this.Score13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Score13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Score13.Width = 60;
            // 
            // Score14
            // 
            this.Score14.Frozen = true;
            this.Score14.HeaderText = "Score4";
            this.Score14.Name = "Score14";
            this.Score14.ReadOnly = true;
            this.Score14.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Score14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Score14.Width = 60;
            // 
            // Score15
            // 
            this.Score15.Frozen = true;
            this.Score15.HeaderText = "Score5";
            this.Score15.Name = "Score15";
            this.Score15.ReadOnly = true;
            this.Score15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Score15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Score15.Width = 60;
            // 
            // Arbitre
            // 
            this.Arbitre.Frozen = true;
            this.Arbitre.HeaderText = "Arbitre";
            this.Arbitre.Name = "Arbitre";
            this.Arbitre.ReadOnly = true;
            this.Arbitre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Arbitre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Arbitre.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel8);
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 231);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Places 9 / 16 ( Bas )";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lb_Futur8);
            this.panel5.Controls.Add(this.lb_Futur7);
            this.panel5.Controls.Add(this.lbArbitre4);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Location = new System.Drawing.Point(275, 127);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(237, 91);
            this.panel5.TabIndex = 12;
            // 
            // lb_Futur8
            // 
            this.lb_Futur8.AutoSize = true;
            this.lb_Futur8.Location = new System.Drawing.Point(14, 66);
            this.lb_Futur8.Name = "lb_Futur8";
            this.lb_Futur8.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur8.TabIndex = 18;
            this.lb_Futur8.Text = "lb_Futur8";
            // 
            // lb_Futur7
            // 
            this.lb_Futur7.AutoSize = true;
            this.lb_Futur7.Location = new System.Drawing.Point(14, 29);
            this.lb_Futur7.Name = "lb_Futur7";
            this.lb_Futur7.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur7.TabIndex = 17;
            this.lb_Futur7.Text = "lb_Futur7";
            // 
            // lbArbitre4
            // 
            this.lbArbitre4.AutoSize = true;
            this.lbArbitre4.ForeColor = System.Drawing.Color.Green;
            this.lbArbitre4.Location = new System.Drawing.Point(33, 1);
            this.lbArbitre4.Name = "lbArbitre4";
            this.lbArbitre4.Size = new System.Drawing.Size(46, 13);
            this.lbArbitre4.TabIndex = 13;
            this.lbArbitre4.Text = "Arbitre : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(77, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "contre";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.lb_Futur6);
            this.panel6.Controls.Add(this.lb_Futur5);
            this.panel6.Controls.Add(this.lbArbitre3);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Location = new System.Drawing.Point(14, 127);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(239, 91);
            this.panel6.TabIndex = 11;
            // 
            // lb_Futur6
            // 
            this.lb_Futur6.AutoSize = true;
            this.lb_Futur6.Location = new System.Drawing.Point(20, 66);
            this.lb_Futur6.Name = "lb_Futur6";
            this.lb_Futur6.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur6.TabIndex = 16;
            this.lb_Futur6.Text = "lb_Futur1";
            // 
            // lb_Futur5
            // 
            this.lb_Futur5.AutoSize = true;
            this.lb_Futur5.Location = new System.Drawing.Point(20, 20);
            this.lb_Futur5.Name = "lb_Futur5";
            this.lb_Futur5.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur5.TabIndex = 15;
            this.lb_Futur5.Text = "lb_Futur5";
            // 
            // lbArbitre3
            // 
            this.lbArbitre3.AutoSize = true;
            this.lbArbitre3.ForeColor = System.Drawing.Color.Green;
            this.lbArbitre3.Location = new System.Drawing.Point(35, 0);
            this.lbArbitre3.Name = "lbArbitre3";
            this.lbArbitre3.Size = new System.Drawing.Size(46, 13);
            this.lbArbitre3.TabIndex = 12;
            this.lbArbitre3.Text = "Arbitre : ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(86, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "contre";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.lb_Futur4);
            this.panel7.Controls.Add(this.lb_Futur3);
            this.panel7.Controls.Add(this.lbArbitre2);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Location = new System.Drawing.Point(275, 19);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(237, 91);
            this.panel7.TabIndex = 10;
            // 
            // lb_Futur4
            // 
            this.lb_Futur4.AutoSize = true;
            this.lb_Futur4.Location = new System.Drawing.Point(14, 64);
            this.lb_Futur4.Name = "lb_Futur4";
            this.lb_Futur4.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur4.TabIndex = 14;
            this.lb_Futur4.Text = "lb_Futur4";
            // 
            // lb_Futur3
            // 
            this.lb_Futur3.AutoSize = true;
            this.lb_Futur3.Location = new System.Drawing.Point(14, 21);
            this.lb_Futur3.Name = "lb_Futur3";
            this.lb_Futur3.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur3.TabIndex = 13;
            this.lb_Futur3.Text = "lb_Futur3";
            // 
            // lbArbitre2
            // 
            this.lbArbitre2.AutoSize = true;
            this.lbArbitre2.ForeColor = System.Drawing.Color.Green;
            this.lbArbitre2.Location = new System.Drawing.Point(33, 1);
            this.lbArbitre2.Name = "lbArbitre2";
            this.lbArbitre2.Size = new System.Drawing.Size(46, 13);
            this.lbArbitre2.TabIndex = 11;
            this.lbArbitre2.Text = "Arbitre : ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(77, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "contre";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.lb_Futur2);
            this.panel8.Controls.Add(this.lb_Futur1);
            this.panel8.Controls.Add(this.lbArbitre1);
            this.panel8.Controls.Add(this.label18);
            this.panel8.Location = new System.Drawing.Point(16, 19);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(237, 91);
            this.panel8.TabIndex = 9;
            // 
            // lb_Futur2
            // 
            this.lb_Futur2.AutoSize = true;
            this.lb_Futur2.Location = new System.Drawing.Point(18, 64);
            this.lb_Futur2.Name = "lb_Futur2";
            this.lb_Futur2.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur2.TabIndex = 12;
            this.lb_Futur2.Text = "lb_Futur2";
            // 
            // lb_Futur1
            // 
            this.lb_Futur1.AutoSize = true;
            this.lb_Futur1.Location = new System.Drawing.Point(18, 21);
            this.lb_Futur1.Name = "lb_Futur1";
            this.lb_Futur1.Size = new System.Drawing.Size(51, 13);
            this.lb_Futur1.TabIndex = 11;
            this.lb_Futur1.Text = "lb_Futur1";
            // 
            // lbArbitre1
            // 
            this.lbArbitre1.AutoSize = true;
            this.lbArbitre1.ForeColor = System.Drawing.Color.Green;
            this.lbArbitre1.Location = new System.Drawing.Point(33, -1);
            this.lbArbitre1.Name = "lbArbitre1";
            this.lbArbitre1.Size = new System.Drawing.Size(46, 13);
            this.lbArbitre1.TabIndex = 10;
            this.lbArbitre1.Text = "Arbitre : ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(84, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "contre";
            // 
            // bt_suivant
            // 
            this.bt_suivant.Enabled = false;
            this.bt_suivant.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.suivant_64;
            this.bt_suivant.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_suivant.Location = new System.Drawing.Point(117, 395);
            this.bt_suivant.Name = "bt_suivant";
            this.bt_suivant.Size = new System.Drawing.Size(90, 90);
            this.bt_suivant.TabIndex = 12;
            this.bt_suivant.Text = "Suivant";
            this.bt_suivant.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_suivant.UseVisualStyleBackColor = true;
            this.bt_suivant.Click += new System.EventHandler(this.bt_suivant_Click);
            // 
            // bt_precedent
            // 
            this.bt_precedent.Enabled = false;
            this.bt_precedent.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.precedent_641;
            this.bt_precedent.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_precedent.Location = new System.Drawing.Point(12, 395);
            this.bt_precedent.Name = "bt_precedent";
            this.bt_precedent.Size = new System.Drawing.Size(90, 90);
            this.bt_precedent.TabIndex = 11;
            this.bt_precedent.Text = "Précédent";
            this.bt_precedent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_precedent.UseVisualStyleBackColor = true;
            // 
            // gbTirageAuSort
            // 
            this.gbTirageAuSort.Controls.Add(this.rbTirageD);
            this.gbTirageAuSort.Controls.Add(this.rbTirageC);
            this.gbTirageAuSort.Location = new System.Drawing.Point(550, 305);
            this.gbTirageAuSort.Name = "gbTirageAuSort";
            this.gbTirageAuSort.Size = new System.Drawing.Size(325, 84);
            this.gbTirageAuSort.TabIndex = 10;
            this.gbTirageAuSort.TabStop = false;
            this.gbTirageAuSort.Text = "Tirage au sort";
            // 
            // rbTirageD
            // 
            this.rbTirageD.AutoSize = true;
            this.rbTirageD.Location = new System.Drawing.Point(196, 33);
            this.rbTirageD.Name = "rbTirageD";
            this.rbTirageD.Size = new System.Drawing.Size(104, 17);
            this.rbTirageD.TabIndex = 1;
            this.rbTirageD.Text = "( D ) Sélectionné";
            this.rbTirageD.UseVisualStyleBackColor = true;
            this.rbTirageD.CheckedChanged += new System.EventHandler(this.rbTirageD_CheckedChanged);
            // 
            // rbTirageC
            // 
            this.rbTirageC.AutoSize = true;
            this.rbTirageC.Checked = true;
            this.rbTirageC.Location = new System.Drawing.Point(36, 33);
            this.rbTirageC.Name = "rbTirageC";
            this.rbTirageC.Size = new System.Drawing.Size(103, 17);
            this.rbTirageC.TabIndex = 0;
            this.rbTirageC.TabStop = true;
            this.rbTirageC.Text = "( C ) Sélectionné";
            this.rbTirageC.UseVisualStyleBackColor = true;
            this.rbTirageC.CheckedChanged += new System.EventHandler(this.rbTirageC_CheckedChanged);
            // 
            // dataGridViewDispo
            // 
            this.dataGridViewDispo.AllowUserToAddRows = false;
            this.dataGridViewDispo.AllowUserToDeleteRows = false;
            this.dataGridViewDispo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDispo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom});
            this.dataGridViewDispo.Location = new System.Drawing.Point(580, 158);
            this.dataGridViewDispo.Name = "dataGridViewDispo";
            this.dataGridViewDispo.ReadOnly = true;
            this.dataGridViewDispo.Size = new System.Drawing.Size(295, 119);
            this.dataGridViewDispo.TabIndex = 7;
            // 
            // Nom
            // 
            this.Nom.Frozen = true;
            this.Nom.HeaderText = "Disponible";
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            this.Nom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nom.Width = 250;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.Close_64;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(785, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 90);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Fermeture";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheDePartieToolStripMenuItem,
            this.arbreDeClassementToolStripMenuItem,
            this.classementToolStripMenuItem});
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "Edition";
            // 
            // ficheDePartieToolStripMenuItem
            // 
            this.ficheDePartieToolStripMenuItem.Name = "ficheDePartieToolStripMenuItem";
            this.ficheDePartieToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.ficheDePartieToolStripMenuItem.Text = "Fiche de partie";
            this.ficheDePartieToolStripMenuItem.Click += new System.EventHandler(this.fichesDePartiesToolStripMenuItem_Click);
            // 
            // arbreDeClassementToolStripMenuItem
            // 
            this.arbreDeClassementToolStripMenuItem.Name = "arbreDeClassementToolStripMenuItem";
            this.arbreDeClassementToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.arbreDeClassementToolStripMenuItem.Text = "Arbre de Classement";
            this.arbreDeClassementToolStripMenuItem.Click += new System.EventHandler(this.arbreDeClassementToolStripMenuItem_Click);
            // 
            // classementToolStripMenuItem
            // 
            this.classementToolStripMenuItem.Enabled = false;
            this.classementToolStripMenuItem.Name = "classementToolStripMenuItem";
            this.classementToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.classementToolStripMenuItem.Text = "Classement";
            this.classementToolStripMenuItem.Click += new System.EventHandler(this.classementToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            // 
            // FormArbre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 497);
            this.Controls.Add(this.dgvPartie);
            this.Controls.Add(this.bt_suivant);
            this.Controls.Add(this.bt_precedent);
            this.Controls.Add(this.gbTirageAuSort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewDispo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormArbre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classement ( 1/8 de Finale )";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartie)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.gbTirageAuSort.ResumeLayout(false);
            this.gbTirageAuSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDispo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridViewDispo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbTirageAuSort;
        private System.Windows.Forms.RadioButton rbTirageD;
        private System.Windows.Forms.RadioButton rbTirageC;
        private System.Windows.Forms.Label lbArbitre4;
        private System.Windows.Forms.Label lbArbitre3;
        private System.Windows.Forms.Label lbArbitre2;
        private System.Windows.Forms.Label lbArbitre1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.Button bt_precedent;
        private System.Windows.Forms.Button bt_suivant;
        private System.Windows.Forms.DataGridView dgvPartie;
        private System.Windows.Forms.Label lb_Futur8;
        private System.Windows.Forms.Label lb_Futur7;
        private System.Windows.Forms.Label lb_Futur6;
        private System.Windows.Forms.Label lb_Futur5;
        private System.Windows.Forms.Label lb_Futur4;
        private System.Windows.Forms.Label lb_Futur3;
        private System.Windows.Forms.Label lb_Futur2;
        private System.Windows.Forms.Label lb_Futur1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ficheDePartieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem arbreDeClassementToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partie;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FoAb1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joueur1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joueur2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FoAb2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arbitre;
        private System.Windows.Forms.ToolStripMenuItem classementToolStripMenuItem;
    }
}