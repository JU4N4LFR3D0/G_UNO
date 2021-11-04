using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G_UNO
{
    public static class Log
    {
        public static void WriteLine(string message, bool writeDateTime = true)
        {
            string path = Application.UserAppDataPath + "/log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
            if (!File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                file.Close();
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(message);
                if(writeDateTime) sw.WriteLine("-----------------------" + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            }
        }
        public static string Read()
        {
            string path = Application.UserAppDataPath + "/log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
            if (!File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                file.Close();
            }
            return File.ReadAllText(path);
        }
    }
}