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
        //la clase LoadGCode permite cargar desde un archivo .gcode los codigos g o escribirlos directamente en el textbox
        #region Inicializar
        public List<string> GetGCode //devuelve la lista de codigos g
        {
            get
            {
                return gcode_richTextBox.Text.toLinesList(); //los genera del text en el richtextbox
            }
        }
        public LoadGCode()
        {
            InitializeComponent();
        }
        #endregion
        #region Metodos
        void LoadFileText() //este metodo abre una ventana para seleccionar un archivo .gcode o .txt
        {
            if (gcode_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(gcode_openFileDialog.FileName)) return; //si el archivo existe
                gcode_richTextBox.SelectedText = File.ReadAllText(gcode_openFileDialog.FileName); //entonces carga el contenido en el richtextbox
            }
        }
        #endregion
        #region Eventos
        private void acceptbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(gcode_richTextBox.Text)) //si el texto en el richtextbox no es vacio entonces cierra con estado OK
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void cancelbtn_Click(object sender, EventArgs e) //cancelar
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void openfile_toolStripButton_Click(object sender, EventArgs e)
        {
            LoadFileText(); //boton de abrir ventana para cargar archivo .gcode
        }
        private void LoadGCode_Shown(object sender, EventArgs e)
        {
            LoadFileText(); //al cargarse por primera vez la ventana se abre una segunda para buscar un archivo .gcode
        }
        #endregion


    }
}
