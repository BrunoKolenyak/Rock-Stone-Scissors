using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Business;
using RockPaperScissors.Contexts;
using RockPaperScissors.Enums;
using RockPaperScissors.Models;
using RockPaperScissors.Repositories;

namespace RockPaperScissors.Controllers;

public class GameController : Controller
{
    private readonly ILogger<GameController> _logger;
    private readonly IGameRepository _repository;

    public GameController(ILogger<GameController> logger, IGameRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public IActionResult Index(GameTypeEnumeration gameType)
    {
        _repository.ClearResults();
        return View(new GameViewModel { GameType = gameType });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public PartialViewResult Result(RockPaperScissorsEnumeration playerOneChoice, RockPaperScissorsEnumeration playerTwoChoice)
    {
        string result = GameBusiness.CheckResultGame(playerOneChoice, playerTwoChoice);

        _repository.Save(result);

        var data = _repository.GetAllResults();

        int victoriesPlayer1 = data.Where(x => x.Win == "Player1").Count();
        int victoriesPlayer2 = data.Where(x => x.Win == "Player2").Count();
        int ties = data.Where(x => x.Tie == true).Count();

        var player1 = new PlayerViewModel(victoriesPlayer1, victoriesPlayer2, ties);
        var player2 = new PlayerViewModel(victoriesPlayer2, victoriesPlayer1, ties);

        var viewModel = new GameViewModel(player1, player2);

        return PartialView("_Result", viewModel );
    }
}

