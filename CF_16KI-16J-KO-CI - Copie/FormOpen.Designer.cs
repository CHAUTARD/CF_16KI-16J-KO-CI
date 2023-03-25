namespace CF_16KI_16J_KO_CI
{
    partial class FormOpen
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TreeViewCompetition = new System.Windows.Forms.TreeView();
            this.BtnCreer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(764, 12);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(24, 23);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = "X";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestion de Critérium 16 joueurs en Classement intégral 2023";
            // 
            // TreeViewCompetition
            // 
            this.TreeViewCompetition.BackColor = System.Drawing.Color.Black;
            this.TreeViewCompetition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeViewCompetition.ForeColor = System.Drawing.Color.White;
            this.TreeViewCompetition.Location = new System.Drawing.Point(12, 92);
            this.TreeViewCompetition.Name = "TreeViewCompetition";
            this.TreeViewCompetition.Size = new System.Drawing.Size(498, 346);
            this.TreeViewCompetition.TabIndex = 2;
            this.TreeViewCompetition.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCompetition_AfterSelect);
            // 
            // BtnCreer
            // 
            this.BtnCreer.BackColor = System.Drawing.Color.DarkGray;
            this.BtnCreer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreer.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.FileOpen_48;
            this.BtnCreer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCreer.Location = new System.Drawing.Point(545, 92);
            this.BtnCreer.Name = "BtnCreer";
            this.BtnCreer.Size = new System.Drawing.Size(243, 61);
            this.BtnCreer.TabIndex = 4;
            this.BtnCreer.Text = "Créer une nouvelle compétition";
            this.BtnCreer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCreer.UseVisualStyleBackColor = false;
            this.BtnCreer.Click += new System.EventHandler(this.BtnCreer_Click);
            // 
            // FormOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCreer);
            this.Controls.Add(this.TreeViewCompetition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOpen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView TreeViewCompetition;
        private System.Windows.Forms.Button BtnCreer;
    }
}