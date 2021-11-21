using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_UNO
{
    public class Streamer
    {
        #region Inicializar
        public List<string> Gcodes { get; set; }
        private bool Streaming { get; set; }
        public bool IsStreaming
        {
            get
            {
                return Streaming;
            }
        }
        private int GCodesSize = 0;
        public int StreamProgress
        {
            get
            {
                if (!Streaming) return 0;
                double progress = ((GCodesSize - Gcodes.Count) / GCodesSize) * 100;
                return progress >= 100 ? 100 : progress <= 0 ? 0 : (int)progress;
            }
        }
        public string Port { get; set; }
        SerialPort GUNO = new SerialPort();
        public Streamer()
        {
            Gcodes = new List<string>();
            GUNO.BaudRate = 9600;
            GUNO.DataReceived += GUNO_DataReceived;
        }
        #endregion


        #region Metodos Prinicpales
        public void StreamRequest(SerialRequest serialRequest)
        {
            if (!CheckPort())
            {
                Log.WriteLine("Error: Es necesario seleccionar un puerto serial valido");
                return;
            }
            if (serialRequest.Type == SerialRequest.TypeGCodeStream)
            {
                if (Streaming)
                {
                    Log.WriteLine("Streaming de datos aun en proceso");
                    return;
                }
                else
                {
                    Log.WriteLine("Enviando codigos G");
                    Streaming = true;
                    Gcodes.Clear();
                    Gcodes = serialRequest.GCode;
                    GCodesSize = Gcodes.Count;
                    Stream();
                }
            }
            else if (serialRequest.Type == SerialRequest.TypeCancel)
            {
                if (Streaming)
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
            else
            {
                if (Streaming)
                {
                    Log.WriteLine("Streaming de datos aun en proceso");
                    return;
                }
                else
                {
                    switch (serialRequest.Type)
                    {
                        case SerialRequest.TypeUp:
                            FastStream("M300 S99");
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
                        case SerialRequest.TypeLaserON:
                            FastStream("M300 S30");
                            break;
                        case SerialRequest.TypeLaserOFF:
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
        private void Stream()
        {
            while (true)
            {
                if (Gcodes.Count <= 0)
                {
                    Streaming = false;
                    return;
                }
                if (string.IsNullOrWhiteSpace(Gcodes[0]))
                {
                    Gcodes.RemoveAt(0);
                }
                else
                {
                    break;
                }

            }
            if (!Streaming) return;
            if (!CheckPort()) return;

            OpenPort();
            GUNO.WriteLine(Gcodes[0]);
            Log.WriteLine(Gcodes[0]);
            if (Gcodes.Count > 0) Gcodes.RemoveAt(0);
        }
        private void FastStream(string line)
        {
            if (!Streaming)
            {
                OpenPort();
                GUNO.WriteLine(line);
            }
        }
        private void GUNO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = GUNO.ReadLine();
            if (receivedData.Trim().StartsWith("ok") || receivedData.Trim().StartsWith("error"))
            {
                Stream();
            }
            else
            {
                Log.WriteLine(receivedData, true);
            }
        }
        #endregion


        #region Metodos Secundarios
        public bool SetPort(string port)
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
        public bool CheckPort()
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
        public void ClosePort()
        {
            if (GUNO.IsOpen) GUNO.Close();
        }
        public void OpenPort()
        {
            if (!GUNO.IsOpen) GUNO.Open();
        }
        #endregion

    }
}
