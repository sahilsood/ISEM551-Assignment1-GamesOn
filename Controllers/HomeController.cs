using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ISEM551_Assignment1_GamesOn.Models;

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
        // Sample data for top played games on Xbox
        var xboxTopGames = new List<GameViewModel>
        {
            new GameViewModel
            {
                Title = "Halo Infinite", Platform = "Xbox",
                ImageUrl = "https://seeklogo.com/images/H/halo-infinite-logo-FBA50491EE-seeklogo.com.png"
            },
            new GameViewModel
            {
                Title = "Forza Horizon 5", Platform = "Xbox",
                ImageUrl = "https://seeklogo.com/images/F/forza-horizon-logo-168F677383-seeklogo.com.png"
            },
            new GameViewModel
            {
                Title = "Minecraft", Platform = "Xbox",
                ImageUrl = "https://seeklogo.com/images/M/minecraft-logo-ECF7D3941A-seeklogo.com.png"
            },
        };

        // Sample data for top played games on PlayStation
        var playstationTopGames = new List<GameViewModel>
        {
            new GameViewModel
            {
                Title = "God of War", Platform = "PlayStation",
                ImageUrl = "https://seeklogo.com/images/G/god-of-war-4-logo-75E6099631-seeklogo.com.png"
            },
            new GameViewModel
            {
                Title = "The Last of Us Part II", Platform = "PlayStation",
                ImageUrl = "https://seeklogo.com/images/T/the-last-of-us-logo-BAEC7187B5-seeklogo.com.png"
            },
            new GameViewModel
            {
                Title = "Spider-Man: Miles Morales", Platform = "PlayStation",
                ImageUrl = "https://seeklogo.com/images/S/spider-man-logo-4EA649A533-seeklogo.com.png"
            },
        };

        var model = new HomeViewModel
        {
            XboxTopGames = xboxTopGames,
            PlayStationTopGames = playstationTopGames
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}