//Importacion de las librerias
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
        string log = ""; //variable para los registros
        int log_size = 1; //tamaño de los registros
        public Streamer streamer = new Streamer(); //instancia de la clase streamer
        public Timer guno_timer = new Timer(); //instancia de un temporizador
        public Main()
        {
            InitializeComponent(); //inicializando la interfaz grafica
        }
        #endregion
        #region Metodos
        void Actualizar() // el metodo actualizar se ejecuta cada vez que se dispara el temporizador
        {
            try
            {
                if (!streamer.CheckPort()) //Si no esta conectado el puerto
                {
                    portlbl.Text = "Puerto [  ]"; //el label se deja con puerto vacio
                }
                log = Log.Read(); // se guarda el registro con la clase statica Log
                if (log_size < log.Length) //si el log esta desactualizado 
                {
                    consolatbox.AppendText(log.Substring(log_size, log.Length-log_size)); //le agrega el registro faltante al RichTextBox
                    log_size = log.Length; //actualiza el tamaño del log
                    consolatbox.SelectionStart = consolatbox.Text.Length; //coloca el cursor al final
                    consolatbox.ScrollToCaret(); //posiciona el richtextbox al final.
                }
                if (streamer.IsStreaming)
                {
                    Cursor = Cursors.WaitCursor;//si el streaming esta ocupado establece el cursor en cargando
                }
                else
                {
                    Cursor = Cursors.Default; //si no, entonces en default
                }
                gunotoolStripProgressBar.Value = streamer.StreamProgress;  //establece la barra de progreso segun los codigos g que quedan
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message); //en caso de error
            }
        }
        void LoadGCode()
        {
            if (!streamer.CheckPort()) //si no se a seleccionado un puerto no deja continuar
            {
                Log.WriteLine("No se ha seleccionado un puerto");
                return;
            }
            LoadGCode loadGCode = new LoadGCode(); //instancia de la forma para cargar el codigo g
            if (loadGCode.ShowDialog() == DialogResult.OK) //si todo salio bien
            {
                SerialRequest serialRequest = new SerialRequest(SerialRequest.TypeGCodeStream); //se hace una instancia de serial request
                serialRequest.GCode = loadGCode.GetGCode; //se le carga el codigo g seleccionado
                Log.WriteLine(serialRequest.GCode.ToArray().ArrToString()); //se imprime el codigo g seleccionado en consola
                streamer.StreamRequest(serialRequest); //y se hace la llamada para imprimir
            }
        }
        void Salir()
        {
            this.Close(); //para salir
        }
        void SelectPort()
        {
            Port portform = new Port(); //para seleccionar puerto se crea una instancia de la interfaz
            if (portform.ShowDialog() == DialogResult.OK)//si todo salio bien
            {
                streamer.SetPort(portform.GetPort); //se guarda el puerto
                portlbl.Text = $"Puerto [ {streamer.Port} ]"; //se actualiza el label de la interfaz
                Log.WriteLine("Puerto seleccionado: " + streamer.Port);//se imprime en consola
            }
        }
        void Cancel()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeCancel)); //cancelar operacion
        }
        void GoDOWN()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeDown)); //decirle al actuador que vaya en direccion -y
        }
        void GoUP()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeUp)); //decirle al actuador que vaya en direccion +y
        }
        void GoLEFT()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeLeft)); //decirle al actuador que vaya en direccion -x
        }
        void GoRIGHT()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeRight)); //decirle al actuador que vaya en direccion +x
        }
        void GoHOME()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeHome)); ////decirle al actuador que vaya hacia home
        }
        void GetInfo()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeGetInfo)); //obtener posicion del actuador
        }
        void SetON()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeSetON));//encender actuador
        }
        void SetOFF()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeSetOFF)); //apagar aactuador
        }
        void SetZeros()
        {
            streamer.StreamRequest(new SerialRequest(SerialRequest.TypeZero)); //establecer el origen
        }
        void AcercaDe()
        {
            About about = new About();
            about.ShowDialog();
        }
        #endregion
        #region Eventos
        //los eventos se disparan cuando se hace un click o hay algun suceso durante la vida del programa
        private void Main_Load(object sender, EventArgs e) //el load se manda llamar cuando se carga por primera vez la interfaz
        {
            guno_timer.Interval = 500; //el timer se establece a 500ms de intervalo
            guno_timer.Tick += gunotimer_Tick; //se inidica que metodo se llama en cada intervalo
            guno_timer.Start(); //se inicia el timer
        }
        private void gunotimer_Tick(object sender, EventArgs e)
        {
            Actualizar(); //con cada intervalo del timer se llama a actualizar
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //antes de cerrar la aplicacion se pregunta si esta seguro
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
            SelectPort(); //una vez se muestra la ventana prinicpal se manda a llamar para seleccionar puerto
        }
        private void loadgcode_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGCode(); //boton de cargar codigo g
        }
        private void update_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar(); //boton de acutalizar
        }
        private void salir_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salir(); //boton de salir
        }
        private void puertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPort(); //boton de puerto
        }
        private void cancelar_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancel(); //boton de cancelar
        }
        private void arribaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoUP(); //boton de arriba
        }
        private void abajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoDOWN(); //boton de abajo
        }
        private void izquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoLEFT(); //boton de izquierda
        }
        private void derechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoRIGHT(); //boton de derecha
        }
        private void setONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetON(); //boton de encender
        }
        private void setOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetOFF(); //boton de apagar
        }
        private void establecerPosicionACerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetZeros(); //boton de origen
        }
        private void irAlOrigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoHOME(); //boton de home
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe(); //boton de acerca de
        }
        private void update_toolStripButton_Click(object sender, EventArgs e)
        {
            Actualizar(); //boton de actualizar
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
            SetOFF();
        }
        private void seton_toolStripButton_Click(object sender, EventArgs e)
        {
            SetON();
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
