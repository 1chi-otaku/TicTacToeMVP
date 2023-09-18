using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMVP
{
    public class Presenter
    {
        private readonly IView _view;
        private readonly IModel _model;
        public Presenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ClickEvent += new EventHandler<ButtonClickEventArgs>(PlayerClickButton);
            _view.RestartEvent += new EventHandler<EventArgs>(Update);
            _view.HardModeChanged += new EventHandler<bool>(HardModeChanged);
        }
        private void PlayerClickButton(object sender, ButtonClickEventArgs e)
        {
            if(e.ButtonIndex != -2)
            {
                _model.MakePlayerMove(e.ButtonIndex);
                if (_model.WinCheck())
                {
                    _view.ShowWinMessage("X Won!");
                    _model.Reset();
                    _view.RestartGame();
                    return;
                }
            }
            else
            {
                _view.PlayerGoesFirst = true;
            }

            int cpuMoveIndex = _model.MakeCPUMove();
            _view.ProcessCPUMove(cpuMoveIndex);

            if (_model.WinCheck())
            {
                _view.ShowWinMessage("O Won!");
                _model.Reset();
                _view.RestartGame();
            }

            if (_model.TieCheck())
            {
                _view.ShowWinMessage("Tie!");
                _model.Reset();
                _view.RestartGame();
            }
        }
        private void Update(object sender, EventArgs e)
        {
            _model.Reset();
        }
        private void HardModeChanged(object sender, bool value)
        {
            _model.HardModeEnabled = value;
        }
    }
}
