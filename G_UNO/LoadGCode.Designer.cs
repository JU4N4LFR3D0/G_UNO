
namespace G_UNO
{
    partial class LoadGCode
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
            this.guno_toolStrip = new System.Windows.Forms.ToolStrip();
            this.gcode_richTextBox = new System.Windows.Forms.RichTextBox();
            this.acceptbtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.gcode_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openfile_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.guno_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // guno_toolStrip
            // 
            this.guno_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfile_toolStripButton});
            this.guno_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.guno_toolStrip.Name = "guno_toolStrip";
            this.guno_toolStrip.Size = new System.Drawing.Size(634, 25);
            this.guno_toolStrip.TabIndex = 0;
            // 
            // gcode_richTextBox
            // 
            this.gcode_richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcode_richTextBox.DetectUrls = false;
            this.gcode_richTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcode_richTextBox.Location = new System.Drawing.Point(0, 29);
            this.gcode_richTextBox.Name = "gcode_richTextBox";
            this.gcode_richTextBox.Size = new System.Drawing.Size(634, 391);
            this.gcode_richTextBox.TabIndex = 1;
            this.gcode_richTextBox.Text = "";
            // 
            // acceptbtn
            // 
            this.acceptbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptbtn.Location = new System.Drawing.Point(547, 426);
            this.acceptbtn.Name = "acceptbtn";
            this.acceptbtn.Size = new System.Drawing.Size(75, 23);
            this.acceptbtn.TabIndex = 2;
            this.acceptbtn.Text = "Aceptar";
            this.acceptbtn.UseVisualStyleBackColor = true;
            this.acceptbtn.Click += new System.EventHandler(this.acceptbtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelbtn.Location = new System.Drawing.Point(466, 426);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 3;
            this.cancelbtn.Text = "Cancelar";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // gcode_openFileDialog
            // 
            this.gcode_openFileDialog.Filter = "GCODE Files (*.gcode)|*.gcode|TXT Files (*.txt)|*.txt|All files (*.*)|*.*";
            this.gcode_openFileDialog.Title = "Abrir documento de codigo g";
            // 
            // openfile_toolStripButton
            // 
            this.openfile_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openfile_toolStripButton.Image = global::G_UNO.Properties.Resources.file_import_solid;
            this.openfile_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openfile_toolStripButton.Name = "openfile_toolStripButton";
            this.openfile_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openfile_toolStripButton.ToolTipText = "Abrir archivo";
            this.openfile_toolStripButton.Click += new System.EventHandler(this.openfile_toolStripButton_Click);
            // 
            // LoadGCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.acceptbtn);
            this.Controls.Add(this.gcode_richTextBox);
            this.Controls.Add(this.guno_toolStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "LoadGCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cargar Código G";
            this.Shown += new System.EventHandler(this.LoadGCode_Shown);
            this.guno_toolStrip.ResumeLayout(false);
            this.guno_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip guno_toolStrip;
        private System.Windows.Forms.ToolStripButton openfile_toolStripButton;
        private System.Windows.Forms.RichTextBox gcode_richTextBox;
        private System.Windows.Forms.Button acceptbtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.OpenFileDialog gcode_openFileDialog;
    }
}