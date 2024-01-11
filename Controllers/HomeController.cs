using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Business;
using Model;

namespace ISEM551_Assignment1_GamesOn.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var xboxTopGames1 = BusinessGameOn.GetTopPlayedGames("XBox");
        var playStationTopGames1 = BusinessGameOn.GetTopPlayedGames("PlayStation");

        var model = new HomeViewModel
        {
            XboxTopGames = xboxTopGames1,
            PlayStationTopGames = playStationTopGames1
        };
        return View(model);
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult GameAward()
    {
        var gameAwards = BusinessGameOn.GetGameAwardsList();
        var model = new GameAwardViewModel
        {
            Awards = gameAwards,
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}