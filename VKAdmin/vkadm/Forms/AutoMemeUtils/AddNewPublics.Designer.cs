
namespace VKAdmin.vkadm.Forms.AutoMem
{
    partial class AddNewPublics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewPublics));
            this.addMore = new System.Windows.Forms.Button();
            this.link = new System.Windows.Forms.TextBox();
            this.ready = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listPublics = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addMore
            // 
            this.addMore.BackColor = System.Drawing.Color.DarkOrange;
            this.addMore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.addMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMore.Location = new System.Drawing.Point(9, 38);
            this.addMore.Name = "addMore";
            this.addMore.Size = new System.Drawing.Size(336, 33);
            this.addMore.TabIndex = 0;
            this.addMore.Text = "Add";
            this.addMore.UseVisualStyleBackColor = false;
            this.addMore.Click += new System.EventHandler(this.addMore_Click);
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(12, 12);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(333, 20);
            this.link.TabIndex = 1;
            // 
            // ready
            // 
            this.ready.BackColor = System.Drawing.Color.Brown;
            this.ready.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ready.Location = new System.Drawing.Point(351, 38);
            this.ready.Name = "ready";
            this.ready.Size = new System.Drawing.Size(86, 33);
            this.ready.TabIndex = 0;
            this.ready.Text = "Ready";
            this.ready.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(351, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "< Put link";
            // 
            // listPublics
            // 
            this.listPublics.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listPublics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listPublics.FormattingEnabled = true;
            this.listPublics.Location = new System.Drawing.Point(9, 78);
            this.listPublics.Name = "listPublics";
            this.listPublics.Size = new System.Drawing.Size(336, 351);
            this.listPublics.TabIndex = 3;
            this.listPublics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPublics_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(352, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 65);
            this.label2.TabIndex = 4;
            this.label2.Text = "For delete public\r\nclick to\r\npublic which\r\nyou want remove\r\nin left bar";
            // 
            // AddNewPublics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(443, 435);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listPublics);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.link);
            this.Controls.Add(this.ready);
            this.Controls.Add(this.addMore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewPublics";
            this.Text = "Add New Public";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewPublics_FormClosing);
            this.Load += new System.EventHandler(this.AddNewPublics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addMore;
        private System.Windows.Forms.TextBox link;
        private System.Windows.Forms.Button ready;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listPublics;
        private System.Windows.Forms.Label label2;
    }
}