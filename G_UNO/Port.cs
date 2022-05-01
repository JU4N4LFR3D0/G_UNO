using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace G_UNO
{
    public partial class Port : Form 
    {
        //la clase port permite seleccionar un puerto de una lista
        public Port()
        {
            InitializeComponent();
        }
        string port = ""; //nombre del puerto (identificador)
        public string GetPort
        {
            get
            {
                return port; //devuelve el port
            }
        }

        private void Port_Load(object sender, EventArgs e)//cargar los puertos disponibles
        {
            port_comboBox.Items.Add("");
            port_comboBox.Items.AddRange(SerialPort.GetPortNames());
        }

        private void acceptbutton_Click(object sender, EventArgs e)//evento del boton aceptar
        {
            if (!string.IsNullOrWhiteSpace(port_comboBox.Text))//establece el puerto y cierra la ventana con estado ok
            {
                port = port_comboBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Text = "Error. Seleccione un puerto valido.";
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e) //cancelar
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void update_button_Click(object sender, EventArgs e) //recargar puertos
        {
            port_comboBox.Items.Clear();
            port_comboBox.Items.Add("");
            port_comboBox.Items.AddRange(SerialPort.GetPortNames());
        }
    }
}
