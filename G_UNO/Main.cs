using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G_UNO
{
    public partial class Main : Form
    {
        #region Inicializar
        string log = "";
        public Streamer streamer = new Streamer();
        public Main()
        {
            InitializeComponent();
        }
        #endregion
        #region Metodos
        void Actualizar()
        {
            if (!streamer.CheckPort())
            {
                portlbl.Text = "Puerto [  ]";
            }
            log = Log.Read();
            if(consolatbox.Text.Length < log.Length)
            {
                consolatbox.Text = log;
                consolatbox.SelectionStart = consolatbox.Text.Length;
                consolatbox.ScrollToCaret();
            }
        }
        void Stream(SerialRequest serialRequest)
        {
            if (!CheckPort())
            {
                Log.WriteLine("Error: Es necesario seleccionar un puerto serial valido");
                return;
            }
            if (serialRequest.Type == SerialRequest.TypeGCodeStream)
            {
                if (streaming)
                {
                    Log.WriteLine("Streaming de datos aun en proceso");
                    return;
                }
                else
                {
                    Log.WriteLine("Enviando codigos G");
                    streaming = true;
                    gunoserialPort.PortName = port;
                    if (!gunoserialPort.IsOpen)
                    {
                        gunoserialPort.Open();
                    }
                    foreach (string line in serialRequest.GCode)
                    {
                        gunoserialPort.WriteLine(line);
                    }
                    gunoserialPort.Close();
                    streaming = false;
                }
            }
            else if (serialRequest.Type == SerialRequest.TypeCancel)
            {
                if (streaming)
                {
                    Log.WriteLine("Cancelando Proceso");
                    //Cancelar
                }
                else
                {
                    Log.WriteLine("No hay nada que cancelar.");
                    return;
                }
            }
            else
            {
                if (streaming)
                {
                    Log.WriteLine("Streaming de datos aun en proceso");
                    return;
                }
                else
                {
                    switch (serialRequest.Type)
                    {
                        case SerialRequest.TypeUp:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeDown:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeLeft:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeRight:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeLaserON:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeLaserOFF:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeZero:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeHome:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        case SerialRequest.TypeGetInfo:
                            serialRequest.GCode.Clear();
                            serialRequest.GCode.Add("");
                            break;
                        default:
                            Log.WriteLine("No se reconoce el tipo de Serial Request");
                            break;
                    }
                }
            }
        }
        void LoadImg()
        {

        }
        void LoadGCode()
        {
            if (!streamer.CheckPort())
            {
                Log.WriteLine("No se ha seleccionado un puerto");
                return;
            }
            LoadGCode loadGCode = new LoadGCode();
            if (loadGCode.ShowDialog() == DialogResult.OK)
            {
                SerialRequest serialRequest = new SerialRequest(SerialRequest.TypeGCodeStream);
                serialRequest.GCode = loadGCode.GetGCode;
                Log.WriteLine(serialRequest.GCode.ToArray().ArrToString());
                Stream(serialRequest);
            }
        }
        void Salir()
        {
            this.Close();
        }
        void SelectPort()
        {
            Port portform = new Port();
            if (portform.ShowDialog() == DialogResult.OK)
            {
                streamer.Port = portform.GetPort;
                gunoserialPort.PortName = port;
                portlbl.Text = $"Puerto [ {port} ]";
                Log.WriteLine("Puerto seleccionado: " + port);
            }
        }
        void Cancel()
        {

        }
        void GoDOWN()
        {

        }
        void GoUP()
        {

        }
        void GoLEFT()
        {

        }
        void GoRIGHT()
        {

        }
        void GoHOME()
        {

        }
        void LaserON()
        {

        }
        void LaserOFF()
        {

        }
        void SetZeros()
        {

        }
        void AcercaDe()
        {
            About about = new About();
            about.ShowDialog();
        }
        #endregion
        #region Eventos
        private void gunotimer_Tick(object sender, EventArgs e)
        {
            Actualizar();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de G_UNO?", "Cerrar aplicación", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }
            else
            {
                if (gunoserialPort.IsOpen) gunoserialPort.Close();
            }
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            SelectPort();
        }
        private void gunoserialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //Log.WriteLine((sender as SerialPort).ReadExisting());'\n'
        }
        private void loadimg_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg();
        }
        private void loadgcode_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGCode();
        }
        private void update_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar();
        }
        private void salir_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void puertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPort();
        }
        private void cancelar_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        private void arribaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoUP();
        }
        private void abajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoDOWN();
        }
        private void izquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoLEFT();
        }
        private void derechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoRIGHT();
        }
        private void laserONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaserON();
        }
        private void laserOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaserOFF();
        }
        private void establecerPosicionACerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetZeros();
        }
        private void irAlOrigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoHOME();
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe();
        }
        private void update_toolStripButton_Click(object sender, EventArgs e)
        {
            Actualizar();
        }
        private void loadgcode_toolStripButton_Click(object sender, EventArgs e)
        {
            LoadGCode();
        }
        private void loadimg_toolStripButton_Click(object sender, EventArgs e)
        {
            LoadImg();
        }
        private void port_toolStripButton_Click(object sender, EventArgs e)
        {
            SelectPort();
        }
        private void cancel_toolStripButton_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        private void left_toolStripButton_Click(object sender, EventArgs e)
        {
            GoLEFT();
        }
        private void right_toolStripButton_Click(object sender, EventArgs e)
        {
            GoRIGHT();
        }
        private void up_toolStripButton_Click(object sender, EventArgs e)
        {
            GoUP();
        }
        private void down_toolStripButton_Click(object sender, EventArgs e)
        {
            GoDOWN();
        }
        private void laseroff_toolStripButton_Click(object sender, EventArgs e)
        {
            LaserOFF();
        }
        private void laseron_toolStripButton_Click(object sender, EventArgs e)
        {
            LaserON();
        }
        private void setzeros_toolStripButton_Click(object sender, EventArgs e)
        {
            SetZeros();
        }
        private void home_toolStripButton_Click(object sender, EventArgs e)
        {
            GoHOME();
        }
        #endregion
    }
}
