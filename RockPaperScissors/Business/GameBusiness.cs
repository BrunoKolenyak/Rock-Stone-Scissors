using System;
using RockPaperScissors.Enums;

namespace RockPaperScissors.Business
{
	public static class GameBusiness
	{
		public static string CheckResultGame(RockPaperScissorsEnumeration playerOneChoice, RockPaperScissorsEnumeration playerTwoChoice)
		{
			if (playerOneChoice == playerTwoChoice)
			{
				return "Tie";
			}
			else if ((playerOneChoice == RockPaperScissorsEnumeration.rock && playerTwoChoice == RockPaperScissorsEnumeration.scissors) ||
                     (playerOneChoice == RockPaperScissorsEnumeration.scissors && playerTwoChoice == RockPaperScissorsEnumeration.paper) ||
                     (playerOneChoice == RockPaperScissorsEnumeration.paper && playerTwoChoice == RockPaperScissorsEnumeration.rock))
			{
				return "Player1";
			}
			else
			{
				return "Player2";
			}
		}
	}
}

