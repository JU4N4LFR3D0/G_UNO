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
            if (consolatbox.Text.Length < log.Length)
            {
                consolatbox.Text = log;
                consolatbox.SelectionStart = consolatbox.Text.Length;
                consolatbox.ScrollToCaret();
            }
            if (streamer.IsStreaming)
            {
                Cursor = Cursors.WaitCursor;
            }
            else
            {
                Cursor = Cursors.Default;
            }
            gunotoolStripProgressBar.Value = streamer.StreamProgress;
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
                streamer.StreamRequest(serialRequest);
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
                streamer.SetPort(portform.GetPort);
                portlbl.Text = $"Puerto [ {streamer.Port} ]";
                Log.WriteLine("Puerto seleccionado: " + streamer.Port);
            }
        }
        void Cancel()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeCancel));
        }
        void GoDOWN()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeDown));
        }
        void GoUP()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeUp));
        }
        void GoLEFT()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeLeft));
        }
        void GoRIGHT()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeRight));
        }
        void GoHOME()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeHome));
        }
        void LaserON()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeLaserON));
        }
        void LaserOFF()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeLaserOFF));
        }
        void SetZeros()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeZero));
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
                streamer.ClosePort();
            }
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            SelectPort();
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
