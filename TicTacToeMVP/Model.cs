using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TicTacToeMVP
{
    public interface IModel
    {
        bool HardModeEnabled { get; set; }
        bool MakePlayerMove(int index);
        int MakeCPUMove();
        bool WinCheck();
        bool TieCheck();
        void Reset();
    }

    public class Model : IModel
    {
        public string[] Board { get; } = new string[9];
        public bool HardModeEnabled { get; set; } = true;

        public int MakeCPUMove()
        {
            if (HardModeEnabled)
            {
                if (Board[4] == null)
                {
                    Board[4] = "O";
                    return 4;
                }
            }

            List<int> availableIndices = GetAvailableIndices();
            if (availableIndices.Count > 0)
            {
                Random random = new Random();
                int randomIndex = availableIndices[random.Next(availableIndices.Count)];
                Board[randomIndex] = "O";
                return randomIndex;
            }
            return -1;
        }

        public bool MakePlayerMove(int index)
        {
            Board[index] = "X";
            return true;
        }

        public void Reset()
        {
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = null;
            }
        }

        public bool TieCheck()
        {
            foreach (var item in Board)
            {
                if (item == null)
                {
                    return false;
                }
            }
            return true;
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
                return true;
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
