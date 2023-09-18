using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMVP
{

    public partial class Form1 : Form, IView
    {
        public List<Button> Buttons { get; set; }
        public Button Restart { get; set; }
        public bool PlayerGoesFirst
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public bool HardMode
        {
            get { return checkBox2.Checked; }
            set
            {
                checkBox2.Checked = value;
                HardModeChanged?.Invoke(this, value);
            }
        }
        public event EventHandler<EventArgs> RestartEvent;
        public event EventHandler<ButtonClickEventArgs> ClickEvent;
        public event EventHandler<bool> HardModeChanged;

        public Form1()
        {
            InitializeComponent();
            Buttons = new List<Button>() { button1,button2, button3, button4, button5, button6,button7,button8,button9};
            Restart = button10;
            PlayerGoesFirst = true;
            HardMode = true;  
        }
        private async void CalculateButtonClick(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int index = -2;
                if (PlayerGoesFirst)
                {
                    button.Text = "X";
                    button.BackColor = Color.AliceBlue;
                    button.Enabled = false;

                    foreach (Button btn in Buttons)
                    {
                        btn.Enabled = false;
                    }
                    await Task.Delay(1000);
                    foreach (Button btn in Buttons)
                    {
                        if (btn.Text == "?")
                        {
                            btn.Enabled = true;
                        }
                    }
                    index = Buttons.IndexOf(button);
                }
                if (index != -1)
                {
                    ClickEvent?.Invoke(this, new ButtonClickEventArgs(index));
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        
        public void RestartGame()
        {
            Buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            PlayerGoesFirst = checkBox1.Checked;
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].Enabled = true;
                Buttons[i].BackColor = Color.White;
                Buttons[i].Text = "?";
            }
        }
        private void RestartButtonClicked(object sender, EventArgs e)
        {
            RestartGame();
            RestartEvent?.Invoke(sender, EventArgs.Empty);
        }

        public void ProcessCPUMove(int index)
        {
            Buttons[index].Text = "O";
            Buttons[index].BackColor = Color.IndianRed;
            Buttons[index].Enabled = false;
        }

        public void ShowWinMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            HardMode= checkBox2.Checked;
        }
    }
    public class ButtonClickEventArgs : EventArgs //Класс для передачи дополнительной информации о событии клика на кнопке.
    {
        public int ButtonIndex { get; }

        public ButtonClickEventArgs(int buttonIndex)
        {
            ButtonIndex = buttonIndex;
        }
    }
}
