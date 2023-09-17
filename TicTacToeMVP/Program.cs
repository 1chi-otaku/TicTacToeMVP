using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMVP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IModel model = new Model();
            IView view = new Form1();
            Presenter presenter = new Presenter(view, model);

            Application.Run(view as Form);
        }
    }
}
