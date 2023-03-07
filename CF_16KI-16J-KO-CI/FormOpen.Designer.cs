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
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewCompetition = new System.Windows.Forms.TreeView();
            this.btnCreer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(764, 12);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(24, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "X";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
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
            // treeViewCompetition
            // 
            this.treeViewCompetition.BackColor = System.Drawing.Color.Black;
            this.treeViewCompetition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewCompetition.ForeColor = System.Drawing.Color.White;
            this.treeViewCompetition.Location = new System.Drawing.Point(12, 92);
            this.treeViewCompetition.Name = "treeViewCompetition";
            this.treeViewCompetition.Size = new System.Drawing.Size(498, 346);
            this.treeViewCompetition.TabIndex = 2;
            this.treeViewCompetition.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCompetition_AfterSelect);
            // 
            // btnCreer
            // 
            this.btnCreer.BackColor = System.Drawing.Color.DarkGray;
            this.btnCreer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreer.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.FileOpen_48;
            this.btnCreer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreer.Location = new System.Drawing.Point(545, 92);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(243, 61);
            this.btnCreer.TabIndex = 4;
            this.btnCreer.Text = "Créer une nouvelle compétition";
            this.btnCreer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreer.UseVisualStyleBackColor = false;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // FormOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreer);
            this.Controls.Add(this.treeViewCompetition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOpen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewCompetition;
        private System.Windows.Forms.Button btnCreer;
    }
}