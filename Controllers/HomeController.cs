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

    public IActionResult AboutUs()
    {
        return View();
    }
    
    public IActionResult GameAward()
    {
        var gameAwardViewModel = new GameAwardViewModel
        {
            Awards = new List<AwardViewModel>
            {
                new() { Year = 2014, Game = "Dragon Age: Inquisition", Developer = "BioWare", Publisher = "Electronic Arts" },
                new() { Year = 2015, Game = "The Witcher 3: Wild Hunt", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
                new() { Year = 2016, Game = "Overwatch", Developer = "Blizzard Entertainment" },
                new() { Year = 2017, Game = "The Legend of Zelda: Breath of the Wild", Developer = "Nintendo EPD", Publisher = "Nintendo" },
                new() { Year = 2018, Game = "God of War", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
                new() { Year = 2019, Game = "Sekiro: Shadows Die Twice", Developer = "FromSoftware", Publisher = "Activision" },
                new() { Year = 2020, Game = "The Last of Us Part II", Developer = "Naughty Dog", Publisher = "Sony Interactive Entertainment" },
                new() { Year = 2021, Game = "It Takes Two", Developer = "Hazelight Studios", Publisher = "Electronic Arts" },
                new() { Year = 2022, Game = "Elden Ring", Developer = "FromSoftware", Publisher = "Bandai Namco Entertainment" },
                new() { Year = 2023, Game = "Alan Wake II", Developer = "Remedy Entertainment", Publisher = "Epic Games Publishing" }
            }
        };

        return View(gameAwardViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}