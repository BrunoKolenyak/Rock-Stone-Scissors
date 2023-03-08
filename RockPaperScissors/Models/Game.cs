using System;
namespace RockPaperScissors.Models
{
	public class Game
	{
		public Game(bool tie, string? win)
		{
			Tie = tie;
			Win = win;
		}

		public Game(bool tie)
		{
			Tie = tie;
		}

		public int Id { get; private set; }
		public bool Tie { get; private set; }
		public string? Win { get; private set; }
	}
}

