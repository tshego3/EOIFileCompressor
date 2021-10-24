using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOIFileExtractor
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static AppConfigModel appConfig = new AppConfigModel();

        static void Main(string[] args)
        {
            try
            {
                IntPtr hWnd = GetConsoleWindow();
                ShowWindow(hWnd, 0);

                foreach (string file in args)
                {
                    appConfig.DirectoryName = Path.GetDirectoryName(file);

                    var lines = File.ReadLines(file);
                    foreach (var line in lines)
                    {
                        appConfig.PrepReceivedFile = Encoding.ASCII.GetString(Convert.FromBase64String(line));

                        char[] delimiterChars = { '|' };
                        appConfig.PrepFileExtract = appConfig.PrepReceivedFile.Split(delimiterChars);
                        appConfig.FileName = Encoding.ASCII.GetString(Convert.FromBase64String(appConfig.PrepFileExtract[0]));
                        appConfig.FileBytes = Convert.FromBase64String(appConfig.PrepFileExtract[1]);

                        File.WriteAllBytes(appConfig.DirectoryName + "\\" + appConfig.FileName, appConfig.FileBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EOI File Compressor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
