//importar librerias
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_UNO
{
    public class Streamer //la clase streamer sirve para comunicar el programa con el arduino
    {
        #region Inicializar
        public List<string> Gcodes { get; set; } //lista de codigos g
        private bool Streaming { get; set; } //estado de transmitiendo
        public bool IsStreaming //devuelve si esta transmitiendo
        {
            get
            {
                return Streaming;
            }
        }
        private int GCodesSize = 0; //tamaño de los codigos
        public int StreamProgress //progreso de transmision de codigos g
        {
            get
            {
                if (!IsStreaming) return 0; //si no esta transmitiendo entonces 0
                if (GCodesSize <= 0) return 0; //si el tamaño de los codigos es 0 entonces 0
                double progress = GCodesSize - Gcodes.Count; //si nada de lo anterior entonces el progreso es igual al tamaño inicia menos el tamaño en ese momento
                progress /= GCodesSize; //dividido por el tamaño original
                progress *= 100.0; //multiplicado por 100 para el prorcentaje
                return progress >= 100 ? 100 : progress <= 0 ? 0 : (int)progress; //devuelve el valor entre 0 y 100
            }
        }
        public string Port { get; set; } //nombre del puerto
        SerialPort GUNO = new SerialPort(); //instancia de la clase SerialPort
        public Streamer() //constructor del streamer
        {
            Gcodes = new List<string>(); //instancia de la lista de codigos g
            GUNO.BaudRate = 9600; //puerto a 9600 baudios
            GUNO.DataReceived += GUNO_DataReceived; //se suscribe al evento de cuando se recibe informacion por el puerto serial
        }
        #endregion

        #region Metodos Prinicpales
        public void StreamRequest(SerialRequest serialRequest) //el metodo stream request gestiona las transmisiones al puerto serial, recibe una clase serial request
        {
            if (!CheckPort()) //Si no hay puerto seleccionado no deja continuar
            {
                Log.WriteLine("Error: Es necesario seleccionar un puerto serial valido");
                return;
            }
            if (serialRequest.Type == SerialRequest.TypeGCodeStream) //si el tipo de serial request es gcodestream
            {
                if (Streaming)//si ya esta transmitiendo entonces no deja continuar
                {
                    Log.WriteLine("Streaming de datos aun en proceso");
                    return;
                }
                else //si no
                {
                    Log.WriteLine("Enviando codigos G");
                    Streaming = true; //transmitiendo igual a verdadero
                    Gcodes.Clear(); //se limian los codigos existentes
                    Gcodes = serialRequest.GCode; //se cargan los nuevos codigos
                    GCodesSize = Gcodes.Count; //se guarda el tamaño original
                    Stream(); //se manda llamar a Stream
                }
            }
            else if (serialRequest.Type == SerialRequest.TypeCancel)//si es del tipo cancelar 
            {
                if (Streaming) //si esta transmitiendo cancela todo
                {
                    Log.WriteLine("Cancelando Proceso");
                    Gcodes.Clear();
                    Streaming = false;
                }
                else
                {
                    Log.WriteLine("No hay nada que cancelar.");
                    return;
                }
            }
            else //si es diferente a los anteriores
            {
                if (Streaming) //es necesario no estar transmitiendo
                {
                    Log.WriteLine("Streaming de datos aun en proceso");
                    return;
                }
                else
                {
                    //se identifica el tipo
                    switch (serialRequest.Type) 
                    {
                        case SerialRequest.TypeUp:
                            FastStream("M300 S99"); // se envia un codigo personalizado para cada tipo con el metodo FastStream
                            break;
                        case SerialRequest.TypeDown:
                            FastStream("M300 S97");
                            break;
                        case SerialRequest.TypeLeft:
                            FastStream("M300 S98");
                            break;
                        case SerialRequest.TypeRight:
                            FastStream("M300 S96");
                            break;
                        case SerialRequest.TypeSetON:
                            FastStream("M300 S30");
                            break;
                        case SerialRequest.TypeSetOFF:
                            FastStream("M300 S50");
                            break;
                        case SerialRequest.TypeZero:
                            FastStream("M300 S94");
                            break;
                        case SerialRequest.TypeHome:
                            FastStream("M300 S95");
                            break;
                        case SerialRequest.TypeGetInfo:
                            FastStream("M114");
                            break;
                        default:
                            Log.WriteLine("No se reconoce el tipo de Serial Request");
                            break;
                    }
                }
            }
        }
        private void Stream() //el metodo stream envia codigos por el puerto serial
        {
            //los codigos g son simples strings
            while (true)
            {
                if (Gcodes.Count <= 0) //si el numero de codigos g es 0 entonces cancela todo
                {
                    Streaming = false;
                    return;
                }
                if (string.IsNullOrWhiteSpace(Gcodes[0])) //elimina lineas en blanco
                {
                    Gcodes.RemoveAt(0);
                }
                else
                {
                    break; //si se encuentra una linea adecuada continua
                }

            }
            if (!Streaming) return;
            if (!CheckPort()) return;

            OpenPort();
            GUNO.WriteLine(Gcodes[0]); //se envia la primera linea disponible, el metodo de GUNO_DataReceived, se encarga de seguir llamando
            // hasta que se acaben las lineas
            Log.WriteLine(Gcodes[0]);
            if (Gcodes.Count > 0) Gcodes.RemoveAt(0); //se remueve la primiera linea de la lista
        }
        private void FastStream(string line) //el metodo FastStream recibe directamente una sola linea
        {
            if (!Streaming)
            {
                OpenPort();
                GUNO.WriteLine(line); //Envia esa linea
            }
        }
        private void GUNO_DataReceived(object sender, SerialDataReceivedEventArgs e) //el evento se dispara cuando el arduino devuelve informacion por el puerto
        {
            string receivedData = GUNO.ReadLine(); //se captura esa informacion
            if (receivedData.Trim().StartsWith("ok") || receivedData.Trim().StartsWith("error"))
            { //si esa informacion empieza con ok o error (significa que no se reconoce la linea pero puede continuar)
                Stream(); //se ejecuta el metodo Stream()
            }
            else
            {
                Log.WriteLine(receivedData, true);
            }
        }
        #endregion

        #region Metodos Secundarios
        public bool SetPort(string port) //Metodo para seleccionar puerto
        {
            if (GUNO.IsOpen) GUNO.Close();
            Port = port;
            if (CheckPort())
            {
                GUNO.PortName = port;
                GUNO.Open();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckPort() //Metodo para verificar puerto
        {
            if (string.IsNullOrWhiteSpace(Port))
            {
                return false;
            }
            if (SerialPort.GetPortNames().InArray(Port))
            {
                return true;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Port))
                {
                    Log.WriteLine("No se encuentra el puerto: " + Port);
                    Port = "";
                }
                return false;
            }
        }
        public void ClosePort() //Metodo para cerrar puerto
        {
            if (GUNO.IsOpen) GUNO.Close();
        }
        public void OpenPort() //metodo para abrir puerto
        {
            if (!GUNO.IsOpen) GUNO.Open();
        }
        #endregion
    }
}
