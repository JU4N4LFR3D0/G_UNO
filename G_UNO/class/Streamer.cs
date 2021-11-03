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
        public List<string> Gcodes { get; set; }
        public bool Streaming { get; set; }
        public string Port { get; set; }
        SerialPort GUNO

        public Streamer()
        {
            Gcodes = new List<string>();
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
    }
}
