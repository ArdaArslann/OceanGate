using System;
using System.Windows.Forms;
using oceangate_r.DAL;

namespace oceangate_r
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Türkçe kültür ayarları (Console.OutputEncoding WinForms'ta çalışmaz)
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("tr-TR");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Veritabanını başlat (tablolar + seed data)
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

