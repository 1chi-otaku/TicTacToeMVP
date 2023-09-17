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
        public event EventHandler<ButtonClickEventArgs> CPUMoveEvent; 
        public Presenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ClickEvent += new EventHandler<ButtonClickEventArgs>(PlayerClickButton);
            _view.RestartEvent += new EventHandler<EventArgs>(Update);

        }
        private void PlayerClickButton(object sender, ButtonClickEventArgs e)
        {
            if (!_model.MakePlayerMove(e.ButtonIndex))
            {
                int cpuMoveIndex = _model.MakeCPUMove();
                _view.ProcessCPUMove(cpuMoveIndex);
            }
            else
            {
                _view.RestartGame();
                _model.Reset();
            }
            
        }
        private void Update(object sender, EventArgs e)
        {
            _model.Reset();

        }


    }
}
