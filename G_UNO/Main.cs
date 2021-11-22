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
        int log_size = 0;
        public Streamer streamer = new Streamer();
        public Timer guno_timer = new Timer();
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
            if (log_size < log.Length)
            {
                log_size = log.Length;
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
        void GetInfo()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeGetInfo));
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
        private void Main_Load(object sender, EventArgs e)
        {
            guno_timer.Interval = 500;
            guno_timer.Tick += gunotimer_Tick;
            guno_timer.Start();
        }
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
        private void setONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaserON();
        }
        private void setOFFToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void setoff_toolStripButton_Click(object sender, EventArgs e)
        {
            LaserOFF();
        }
        private void seton_toolStripButton_Click(object sender, EventArgs e)
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
        private void info_toolStripButton_Click(object sender, EventArgs e)
        {
            GetInfo();
        }
        private void info_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetInfo();
        }
        #endregion
    }
}
