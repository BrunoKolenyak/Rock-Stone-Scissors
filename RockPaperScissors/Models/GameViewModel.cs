using RockPaperScissors.Enums;

namespace RockPaperScissors.Models;

public class GameViewModel
{
    public GameViewModel()
    {
        Player1 = new PlayerViewModel();
        Player2 = new PlayerViewModel();
    }

    public GameViewModel(PlayerViewModel player1, PlayerViewModel player2)
    {
        Player1 = player1;
        Player2 = player2;
    }

    public GameTypeEnumeration GameType { get; set; }
    public PlayerViewModel? Player1 { get; set; }
    public PlayerViewModel? Player2 { get; set; }
}

