using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMVP
{

    public partial class Form1 : Form, IView
    {
        public List<Button> Buttons { get; set; }
        public Button Restart { get; set; }

        public event EventHandler<EventArgs> RestartEvent;
        public event EventHandler<ButtonClickEventArgs> ClickEvent;

        public Form1()
        {
            InitializeComponent();
            Buttons = new List<Button>() { button1,button2, button3, button4, button5, button6,button7,button8,button9};
            Restart = button10;
           
        }
        private async void CalculateButtonClick(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                button.Text = "X";
                button.BackColor = Color.AliceBlue;
                button.Enabled = false;
                int index = Buttons.IndexOf(button);
                foreach (Button btn in Buttons)
                {
                    btn.Enabled = false;
                }

                await Task.Delay(1000);
                foreach (Button btn in Buttons)
                {
                    if(btn.Text == "?") { 
                        btn.Enabled= true;
                    }
                }
                if (index != -1)
                {
                    if(ClickEvent!= null)
                    {
                        ClickEvent?.Invoke(this, new ButtonClickEventArgs(index));
                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void RestartGame()
        {
            Buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
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

    }
    public class ButtonClickEventArgs : EventArgs
    {
        public int ButtonIndex { get; }

        public ButtonClickEventArgs(int buttonIndex)
        {
            ButtonIndex = buttonIndex;
        }
    }
}
