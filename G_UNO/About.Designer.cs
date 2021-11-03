
namespace G_UNO
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.guno_statusStrip = new System.Windows.Forms.StatusStrip();
            this.versiontoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.about_txt = new System.Windows.Forms.Label();
            this.guno_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // guno_statusStrip
            // 
            this.guno_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versiontoolStripStatusLabel});
            this.guno_statusStrip.Location = new System.Drawing.Point(0, 339);
            this.guno_statusStrip.Name = "guno_statusStrip";
            this.guno_statusStrip.Size = new System.Drawing.Size(484, 22);
            this.guno_statusStrip.TabIndex = 0;
            this.guno_statusStrip.Text = "statusStrip1";
            // 
            // versiontoolStripStatusLabel
            // 
            this.versiontoolStripStatusLabel.Name = "versiontoolStripStatusLabel";
            this.versiontoolStripStatusLabel.Size = new System.Drawing.Size(29, 17);
            this.versiontoolStripStatusLabel.Text = "V1.0";
            // 
            // about_txt
            // 
            this.about_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.about_txt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_txt.Location = new System.Drawing.Point(12, 9);
            this.about_txt.Name = "about_txt";
            this.about_txt.Size = new System.Drawing.Size(460, 330);
            this.about_txt.TabIndex = 1;
            this.about_txt.Text = resources.GetString("about_txt.Text");
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.about_txt);
            this.Controls.Add(this.guno_statusStrip);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "About";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.guno_statusStrip.ResumeLayout(false);
            this.guno_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip guno_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel versiontoolStripStatusLabel;
        private System.Windows.Forms.Label about_txt;
    }
}