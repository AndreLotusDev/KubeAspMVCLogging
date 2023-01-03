using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TempMVC.Models;

namespace TempMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["words"] = RandomWords(3);

            return View();
        }

        private List<string> RandomWords(int quantity)
        {
            var wordList = System.IO.File.ReadLines(@"./RandomWords.txt").ToList();
            wordList = ShuffleAndTakeTen(wordList);

            var messageToSend = $"Words being listed: {string.Join(" ", wordList.Select(s => s))}";
            
            Console.WriteLine($"Produced by console: {messageToSend}");
            _logger.LogInformation($"Produced by serilog: {messageToSend}");

            return wordList.ToList();
        }

        private List<string> ShuffleAndTakeTen(List<string> words)
        {
            var shuffledWords = words.OrderBy(a => Guid.NewGuid()).Take(10).ToList();

            return shuffledWords;
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
}