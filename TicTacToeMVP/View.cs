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
        bool PlayerGoesFirst { get; set; }
        bool HardMode { get; set; }
        event EventHandler<EventArgs> RestartEvent;
        event EventHandler<ButtonClickEventArgs> ClickEvent;
        event EventHandler<bool> HardModeChanged;
        void ProcessCPUMove(int index);
        void RestartGame();
        void ShowWinMessage(string message);
    }
}
