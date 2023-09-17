using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMVP
{
    public interface IModel
    {
        string current_turn { get; set; }
        bool is_game_finished { get; set; }
        bool MakePlayerMove(int index);
        int MakeCPUMove();
        bool WinCheck();
        void Reset();
    }

    public class Model : IModel
    {
        public string current_turn { get; set; }
        public bool is_game_finished { get; set; }
        public string[] Board { get; } = new string[9];
        public int MakeCPUMove()
        {
            List<int> availableIndices = GetAvailableIndices();
            if (availableIndices.Count > 0)
            {
                Random random = new Random();
                int randomIndex = availableIndices[random.Next(availableIndices.Count)];
                Board[randomIndex] = "O";
                if (WinCheck())
                {
                    MessageBox.Show("O Won!");
                    return -1;
                }
                return randomIndex;
            }
            return -1;
        }

        public bool MakePlayerMove(int index)
        {
            Board[index] = "X";
            if (WinCheck())
            {
                MessageBox.Show("X Won!");
                return true;
            }
            return false;
        }

        public void Reset()
        {
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = null;
            }
        }

        public bool WinCheck()
        {
            if (Board[0] == "X" && Board[1] == "X" && Board[2] == "X"
               || Board[3] == "X" && Board[4] == "X" && Board[5] == "X"
               || Board[6] == "X" && Board[8] == "X" && Board[7] == "X"
               || Board[0] == "X" && Board[3] == "X" && Board[6] == "X"
               || Board[1] == "X" && Board[4] == "X" && Board[7] == "X"
               || Board[2] == "X" && Board[5] == "X" && Board[8] == "X"
               || Board[0] == "X" && Board[4] == "X" && Board[8] == "X"
               || Board[2] == "X" && Board[4] == "X" && Board[6] == "X")
            {
                Reset();
                return true;
            }

            else if (Board[0] == "O" && Board[1] == "O" && Board[2] == "O"
            || Board[3] == "O" && Board[4] == "O" && Board[5] == "O"
            || Board[6] == "O" && Board[8] == "O" && Board[7] == "O"
            || Board[0] == "O" && Board[3] == "O" && Board[6] == "O"
            || Board[1] == "O" && Board[4] == "O" && Board[7] == "O"
            || Board[2] == "O" && Board[5] == "O" && Board[8] == "O"
            || Board[0] == "O" && Board[4] == "O" && Board[8] == "O"
            || Board[2] == "O" && Board[4] == "O" && Board[6] == "O")
            {
                Reset();
                return true;
            }
            else
            {
                List<int> a = GetAvailableIndices();
                if(a.Count == 0) {
                    Reset();
                    MessageBox.Show("Tie!");
                }
            }
            return false;
        }

        private List<int> GetAvailableIndices()
        {
            List<int> availableIndices = new List<int>();
            for (int i = 0; i < Board.Length; i++)
            {
                if (string.IsNullOrEmpty(Board[i]))
                {
                    availableIndices.Add(i);
                }
            }
            return availableIndices;
        }
    }
}
