using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopService.Utilities
{
    public class Logger
    {
        private static string LOG_FILE = "shop.log";
        private static string sLogFormat;
        private static System.Windows.Forms.RichTextBox rtb;

        public Logger()
        {    
        }

        private static void CreateFile()
        {
            if (File.Exists(LOG_FILE))
            {
                File.Delete(LOG_FILE);
                FileStream fs = File.Create(LOG_FILE);
                fs.Close();
            }
            else
            {
                FileStream fs = File.Create(LOG_FILE);
                fs.Close();
            }
        }

        private static void CreateFile(int fileSizeLimit)
        {
            if (File.Exists(LOG_FILE))
            {
                FileInfo f = new FileInfo(LOG_FILE);
                if (f.Length >= fileSizeLimit)
                    File.Delete(LOG_FILE);
                else
                    return;
            }
            FileStream fs = File.Create(LOG_FILE);
            fs.Close();
        }

        public static void SetUpLogFile(string path)
        {
            LOG_FILE = path + "\\" + LOG_FILE;
            CreateFile();
            return;
        }

        public static void SetUpLogFile(string path, System.Windows.Forms.RichTextBox richtextbox)
        {
            LOG_FILE = path + "\\" + LOG_FILE;
            CreateFile();
            rtb = richtextbox;
            return;
        }

        public static void SetUpLogFile(string path, int fileSizeLimit)
        {
            LOG_FILE = path + "\\" + LOG_FILE;
            CreateFile(fileSizeLimit);
            return;
        }

        public static void LogBeforeStart()
        {
            writeLog("\n");
        }

        public static void LogInfo(String message)
        {
            // prefix data : dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string m = sLogFormat + "INFO : " + message;
            writeLog(m);
            if (rtb != null)
            {
                if (rtb.InvokeRequired)
                {
                    rtb.Invoke(new Action(() => rtb.AppendText(m + Environment.NewLine)));
                }
                else
                {
                    rtb.AppendText(m + Environment.NewLine);

                }
            }
        }

        public static void LogError(String message)
        {
            // prefix data : dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string m = sLogFormat + "ERR : " + message;
            writeLog(m);
        }

        public static void LogWarning(String message)
        {
            string m = sLogFormat + "WARN : " + message;
            writeLog(m);
        }
    
        private static void writeLog(String message)
        {
            TextWriter sw = null;
            try
            {
                sw = new StreamWriter(LOG_FILE, true);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
            finally
            {
                if (sw != null)
                    sw = null;
            }
        }
    }
}
