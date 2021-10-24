using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EOIFileCompressor
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
                    appConfig.FileName = Path.GetFileName(file);

                    appConfig.DirectoryName = Path.GetDirectoryName(file);

                    appConfig.FileBytes = File.ReadAllBytes(file);

                    appConfig.Base64FileName = Convert.ToBase64String(Encoding.ASCII.GetBytes(appConfig.FileName));

                    appConfig.Base64FileBytes = Convert.ToBase64String(appConfig.FileBytes);

                    appConfig.PrepFileCompress = appConfig.Base64FileName + "|" + appConfig.Base64FileBytes;

                    using (StreamWriter writer = new StreamWriter(appConfig.DirectoryName + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "_EOI-File.txt", true))
                    {
                        writer.WriteLine(Convert.ToBase64String(Encoding.ASCII.GetBytes(appConfig.PrepFileCompress)));
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
