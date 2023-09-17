using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMVP
{
    public interface IView
    {
        List<Button> Buttons { get; set; }
        Button Restart { get; set; }
        event EventHandler<EventArgs> RestartEvent;
        event EventHandler<ButtonClickEventArgs> ClickEvent;
        void ProcessCPUMove(int index);
        void RestartGame();
    }
}
