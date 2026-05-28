using System;
using System.Windows.Forms;
using oceangate_r.DAL;

namespace oceangate_r
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("tr-TR");

            Application.EnableVisualStyles();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => {
                System.IO.File.WriteAllText(@"c:\Users\Arda\source\repos\oceangate_r\crash.txt", e.Exception.ToString());
                MessageBox.Show("Hata: " + e.Exception.Message);
            };
            AppDomain.CurrentDomain.UnhandledException += (s, e) => {
                System.IO.File.WriteAllText(@"c:\Users\Arda\source\repos\oceangate_r\crash2.txt", e.ExceptionObject.ToString());
                MessageBox.Show("Hata: " + e.ExceptionObject.ToString());
            };
            Application.SetCompatibleTextRenderingDefault(false);

            // Veritabanını başlat (tablolar + mock data)
            try
            {
                DatabaseManager.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Veritabanı başlatılamadı:\n{ex.Message}\n\nUygulama kapatılacak.",
                    "Kritik Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Giriş formunu başlat
            Application.Run(new LoginForm());
        }
    }
}

