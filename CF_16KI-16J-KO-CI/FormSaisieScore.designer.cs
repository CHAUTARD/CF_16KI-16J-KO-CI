/*
 * Created by SharpDevelop.
 * User: CHAUTARD
 * Date: 01/03/2023
 * Time: 17:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CF_16KI_16J_KO_CI
{
	partial class FormSaisieScore
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbForfaitLes2;
		private System.Windows.Forms.RadioButton rbForfaitJoueur2;
		private System.Windows.Forms.RadioButton rbForfaitJoueur1;
		private System.Windows.Forms.RadioButton rbForfaitNeant;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbAbandonLes2;
		private System.Windows.Forms.RadioButton rbAbandonJoueur2;
		private System.Windows.Forms.RadioButton rbAbandonJoueur1;
		private System.Windows.Forms.RadioButton rbAbandonNeant;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbScore5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbScore4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbScore3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbScore2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbScore1;
		private System.Windows.Forms.Button btClear;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Label label7;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaisieScore));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbForfaitLes2 = new System.Windows.Forms.RadioButton();
            this.rbForfaitJoueur2 = new System.Windows.Forms.RadioButton();
            this.rbForfaitJoueur1 = new System.Windows.Forms.RadioButton();
            this.rbForfaitNeant = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAbandonLes2 = new System.Windows.Forms.RadioButton();
            this.rbAbandonJoueur2 = new System.Windows.Forms.RadioButton();
            this.rbAbandonJoueur1 = new System.Windows.Forms.RadioButton();
            this.rbAbandonNeant = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbScore5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbScore4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbScore3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbScore2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbScore1 = new System.Windows.Forms.TextBox();
            this.lbPartie = new System.Windows.Forms.RichTextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.rbForfaitLes2);
            this.groupBox1.Controls.Add(this.rbForfaitJoueur2);
            this.groupBox1.Controls.Add(this.rbForfaitJoueur1);
            this.groupBox1.Controls.Add(this.rbForfaitNeant);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 63);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forfait";
            // 
            // rbForfaitLes2
            // 
            this.rbForfaitLes2.Location = new System.Drawing.Point(457, 19);
            this.rbForfaitLes2.Name = "rbForfaitLes2";
            this.rbForfaitLes2.Size = new System.Drawing.Size(140, 24);
            this.rbForfaitLes2.TabIndex = 3;
            this.rbForfaitLes2.Text = "les deux";
            this.rbForfaitLes2.UseVisualStyleBackColor = true;
            this.rbForfaitLes2.CheckedChanged += new System.EventHandler(this.rbForfaitLes2_CheckedChanged);
            // 
            // rbForfaitJoueur2
            // 
            this.rbForfaitJoueur2.Location = new System.Drawing.Point(301, 19);
            this.rbForfaitJoueur2.Name = "rbForfaitJoueur2";
            this.rbForfaitJoueur2.Size = new System.Drawing.Size(140, 24);
            this.rbForfaitJoueur2.TabIndex = 2;
            this.rbForfaitJoueur2.Text = "Joueur 2";
            this.rbForfaitJoueur2.UseVisualStyleBackColor = true;
            this.rbForfaitJoueur2.CheckedChanged += new System.EventHandler(this.rbForfaitJoueur2_CheckedChanged);
            // 
            // rbForfaitJoueur1
            // 
            this.rbForfaitJoueur1.Location = new System.Drawing.Point(155, 19);
            this.rbForfaitJoueur1.Name = "rbForfaitJoueur1";
            this.rbForfaitJoueur1.Size = new System.Drawing.Size(140, 24);
            this.rbForfaitJoueur1.TabIndex = 1;
            this.rbForfaitJoueur1.Text = "Joueur 1";
            this.rbForfaitJoueur1.UseVisualStyleBackColor = true;
            this.rbForfaitJoueur1.CheckedChanged += new System.EventHandler(this.rbForfaitJoueur1_CheckedChanged);
            // 
            // rbForfaitNeant
            // 
            this.rbForfaitNeant.Checked = true;
            this.rbForfaitNeant.Location = new System.Drawing.Point(7, 19);
            this.rbForfaitNeant.Name = "rbForfaitNeant";
            this.rbForfaitNeant.Size = new System.Drawing.Size(140, 24);
            this.rbForfaitNeant.TabIndex = 0;
            this.rbForfaitNeant.TabStop = true;
            this.rbForfaitNeant.Text = "néant";
            this.rbForfaitNeant.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.rbAbandonLes2);
            this.groupBox2.Controls.Add(this.rbAbandonJoueur2);
            this.groupBox2.Controls.Add(this.rbAbandonJoueur1);
            this.groupBox2.Controls.Add(this.rbAbandonNeant);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 49);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Abandon";
            // 
            // rbAbandonLes2
            // 
            this.rbAbandonLes2.Location = new System.Drawing.Point(457, 19);
            this.rbAbandonLes2.Name = "rbAbandonLes2";
            this.rbAbandonLes2.Size = new System.Drawing.Size(140, 24);
            this.rbAbandonLes2.TabIndex = 3;
            this.rbAbandonLes2.Text = "les deux";
            this.rbAbandonLes2.UseVisualStyleBackColor = true;
            this.rbAbandonLes2.CheckedChanged += new System.EventHandler(this.rbAbandonLes2_CheckedChanged);
            // 
            // rbAbandonJoueur2
            // 
            this.rbAbandonJoueur2.Location = new System.Drawing.Point(301, 19);
            this.rbAbandonJoueur2.Name = "rbAbandonJoueur2";
            this.rbAbandonJoueur2.Size = new System.Drawing.Size(140, 24);
            this.rbAbandonJoueur2.TabIndex = 2;
            this.rbAbandonJoueur2.Text = "Joueur 2";
            this.rbAbandonJoueur2.UseVisualStyleBackColor = true;
            this.rbAbandonJoueur2.CheckedChanged += new System.EventHandler(this.rbAbandonJoueur2_CheckedChanged);
            // 
            // rbAbandonJoueur1
            // 
            this.rbAbandonJoueur1.Location = new System.Drawing.Point(155, 19);
            this.rbAbandonJoueur1.Name = "rbAbandonJoueur1";
            this.rbAbandonJoueur1.Size = new System.Drawing.Size(140, 24);
            this.rbAbandonJoueur1.TabIndex = 1;
            this.rbAbandonJoueur1.Text = "Joueur 1";
            this.rbAbandonJoueur1.UseVisualStyleBackColor = true;
            this.rbAbandonJoueur1.CheckedChanged += new System.EventHandler(this.rbAbandonJoueur1_CheckedChanged);
            // 
            // rbAbandonNeant
            // 
            this.rbAbandonNeant.Checked = true;
            this.rbAbandonNeant.Location = new System.Drawing.Point(7, 19);
            this.rbAbandonNeant.Name = "rbAbandonNeant";
            this.rbAbandonNeant.Size = new System.Drawing.Size(140, 24);
            this.rbAbandonNeant.TabIndex = 0;
            this.rbAbandonNeant.TabStop = true;
            this.rbAbandonNeant.Text = "néant";
            this.rbAbandonNeant.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbScore5);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbScore4);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbScore3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbScore2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbScore1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(613, 127);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Saisie des scores";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(15, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(554, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Saisisser un nombre ( 8 où -8 par exemple)  et valider par la touche [Tab]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(412, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "5";
            // 
            // tbScore5
            // 
            this.tbScore5.Enabled = false;
            this.tbScore5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScore5.Location = new System.Drawing.Point(397, 51);
            this.tbScore5.Name = "tbScore5";
            this.tbScore5.Size = new System.Drawing.Size(48, 24);
            this.tbScore5.TabIndex = 4;
            this.tbScore5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScore5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbScore5KeyPress);
            this.tbScore5.Leave += new System.EventHandler(this.TbScore5Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(349, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "4";
            // 
            // tbScore4
            // 
            this.tbScore4.Enabled = false;
            this.tbScore4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScore4.Location = new System.Drawing.Point(331, 51);
            this.tbScore4.Name = "tbScore4";
            this.tbScore4.Size = new System.Drawing.Size(48, 24);
            this.tbScore4.TabIndex = 3;
            this.tbScore4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScore4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbScore4KeyPress);
            this.tbScore4.Leave += new System.EventHandler(this.TbScore4Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(273, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "3";
            // 
            // tbScore3
            // 
            this.tbScore3.Enabled = false;
            this.tbScore3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScore3.Location = new System.Drawing.Point(258, 51);
            this.tbScore3.Name = "tbScore3";
            this.tbScore3.Size = new System.Drawing.Size(48, 24);
            this.tbScore3.TabIndex = 2;
            this.tbScore3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScore3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbScore3KeyPress);
            this.tbScore3.Leave += new System.EventHandler(this.TbScore3Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(198, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "2";
            // 
            // tbScore2
            // 
            this.tbScore2.Enabled = false;
            this.tbScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScore2.Location = new System.Drawing.Point(183, 51);
            this.tbScore2.Name = "tbScore2";
            this.tbScore2.Size = new System.Drawing.Size(48, 24);
            this.tbScore2.TabIndex = 1;
            this.tbScore2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScore2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbScore2KeyPress);
            this.tbScore2.Leave += new System.EventHandler(this.TbScore2Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(118, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "1";
            // 
            // tbScore1
            // 
            this.tbScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScore1.Location = new System.Drawing.Point(103, 51);
            this.tbScore1.Name = "tbScore1";
            this.tbScore1.Size = new System.Drawing.Size(48, 24);
            this.tbScore1.TabIndex = 0;
            this.tbScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScore1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbScore1KeyPress);
            this.tbScore1.Leave += new System.EventHandler(this.TbScore1Leave);
            // 
            // lbPartie
            // 
            this.lbPartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPartie.Location = new System.Drawing.Point(12, 12);
            this.lbPartie.Name = "lbPartie";
            this.lbPartie.ReadOnly = true;
            this.lbPartie.Size = new System.Drawing.Size(613, 116);
            this.lbPartie.TabIndex = 12;
            this.lbPartie.Text = "";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.abandon1;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(475, 429);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(142, 45);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "Abandon";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.BtCancelClick);
            // 
            // btClear
            // 
            this.btClear.CausesValidation = false;
            this.btClear.Image = global::CF_16KI_16J_KO_CI.Properties.Resources.gomme1;
            this.btClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClear.Location = new System.Drawing.Point(249, 429);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(142, 45);
            this.btClear.TabIndex = 9;
            this.btClear.Text = "Scores";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.BtClearClick);
            // 
            // FormSaisieScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(639, 492);
            this.Controls.Add(this.lbPartie);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSaisieScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saisie d\'une partie";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.RichTextBox lbPartie;
    }
}
