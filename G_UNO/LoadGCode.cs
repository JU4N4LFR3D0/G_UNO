using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G_UNO
{
    public partial class LoadGCode : Form
    {
        #region Inicializar
        public List<string> GetGCode
        {
            get
            {
                return gcode_richTextBox.Text.toLinesList();
            }
        }
        public LoadGCode()
        {
            InitializeComponent();
        }
        #endregion
        #region Metodos
        void LoadFileText()
        {
            if (gcode_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(gcode_openFileDialog.FileName)) return;
                gcode_richTextBox.SelectedText = File.ReadAllText(gcode_openFileDialog.FileName);
            }
        }
        #endregion
        #region Eventos
        private void acceptbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(gcode_richTextBox.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void openfile_toolStripButton_Click(object sender, EventArgs e)
        {
            LoadFileText();
        }
        private void LoadGCode_Shown(object sender, EventArgs e)
        {
            LoadFileText();
        }
        #endregion


    }
}
