using System;
using System.Windows.Forms;

namespace P5RFieldTexUtility
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new P5RFieldTexUtilityForm());
        }
    }
}
