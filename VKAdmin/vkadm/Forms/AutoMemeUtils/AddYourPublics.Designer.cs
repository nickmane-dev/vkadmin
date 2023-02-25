
namespace VKAdmin.vkadm.Forms.AutoMemeUtils
{
    partial class AddYourPublics
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
            this.listPublics = new System.Windows.Forms.ListBox();
            this.ready = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listPublics
            // 
            this.listPublics.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listPublics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listPublics.FormattingEnabled = true;
            this.listPublics.Location = new System.Drawing.Point(12, 51);
            this.listPublics.Name = "listPublics";
            this.listPublics.Size = new System.Drawing.Size(336, 351);
            this.listPublics.TabIndex = 9;
            // 
            // ready
            // 
            this.ready.BackColor = System.Drawing.Color.Brown;
            this.ready.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ready.Location = new System.Drawing.Point(12, 12);
            this.ready.Name = "ready";
            this.ready.Size = new System.Drawing.Size(336, 33);
            this.ready.TabIndex = 5;
            this.ready.Text = "Ready";
            this.ready.UseVisualStyleBackColor = false;
            this.ready.Click += new System.EventHandler(this.ready_Click);
            // 
            // AddYourPublics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(364, 415);
            this.Controls.Add(this.listPublics);
            this.Controls.Add(this.ready);
            this.Name = "AddYourPublics";
            this.Text = "AddYourPublics";
            this.Load += new System.EventHandler(this.AddYourPublics_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listPublics;
        private System.Windows.Forms.Button ready;
    }
}