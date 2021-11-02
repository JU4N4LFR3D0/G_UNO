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
        public Port()
        {
            InitializeComponent();
        }
        string port = "";
        public string GetPort
        {
            get
            {
                return port;
            }
        }

        private void Port_Load(object sender, EventArgs e)
        {
            port_comboBox.Items.Add("");
            port_comboBox.Items.AddRange(SerialPort.GetPortNames());
        }

        private void acceptbutton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(port_comboBox.Text))
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

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
