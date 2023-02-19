using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWorldOfComputerTechnology
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyApplicationContext.Open(new Authorization());
            Application.Run();
        }
        public static int formCount;
        public class MyApplicationContext : ApplicationContext
        {
            static public void Open(Form form)
            {

                form.Closed += OnFormClosed;
                formCount++;
                form.Show();
                form.Focus();
            }

            static public void OnFormClosed(object sender, EventArgs e)
            {
                formCount--;
                if (formCount <= 0)
                {
                    Application.Exit();
                }
            }
        }
    }
}
