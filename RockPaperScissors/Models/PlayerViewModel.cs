using System;
namespace RockPaperScissors.Models
{
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            NumberWins = 0;
            NumberLoss = 0;
            NumberTies = 0;
        }

        public PlayerViewModel(int win, int loss, int tie)
        {
            NumberWins = win;
            NumberLoss = loss;
            NumberTies = tie;
        }

        public int NumberWins { get; set; }
        public int NumberLoss { get; set; }
        public int NumberTies { get; set; }
    }
}

