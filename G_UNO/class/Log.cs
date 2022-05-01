using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G_UNO
{
    public static class Log //la clase log excribe y lee registros en archivos .txt (estatica)
    {
        public static void WriteLine(string message, bool writeDateTime = true) //el metodo writeline escribe una linea la final de un archivo .txt
        {
            try
            {
                string path = Application.UserAppDataPath + "/log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt"; //se crea un path en appdata con la fecha del dia
                if (!File.Exists(path))
                {
                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite); //si el archivo no existe se crea uno
                    file.Close();
                }
                using (StreamWriter sw = File.AppendText(path)) // se agerga la linea al archivo
                {
                    sw.WriteLine(message);
                    if (writeDateTime) sw.WriteLine("-----------------------" + DateTime.Now.ToString("dd/MM/yyyy HH:mm")); //si se indica al llamar al metodo, se escribe el momento (fecha y hora)
                }
            }
            catch (Exception)
            {
            }
        }
        public static string Read() //metodo para leer todo el archivo de registros.
        {
            try
            {
                string path = Application.UserAppDataPath + "/log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
                if (!File.Exists(path))
                {
                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    file.Close();
                }
                return File.ReadAllText(path);
            }
            catch (Exception)
            {
                return "Read error...";
            }
        }
    }
}