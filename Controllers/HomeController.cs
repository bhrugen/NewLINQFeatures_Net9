using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewLINQFeatures.Data;
using NewLINQFeatures.Models;
using System.Diagnostics;

namespace NewLINQFeatures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            //COUNT BY IN .NET 9
            var studentGenderCount = _db.Students.ToList()
                .GroupBy(u => u.Gender)
                .Select(c => new { Gender = c.Key, TotalCount = c.Count() });

            foreach (var genderCounter in studentGenderCount)
            {
                Console.WriteLine($"Gender: {genderCounter.Gender}, Count: {genderCounter.TotalCount}");
            }

            foreach (var genderCounterNew in _db.Students.ToList().CountBy(u=>u.Gender))
            {
                Console.WriteLine($"New Countby -- Gender: {genderCounterNew.Key}, Count: {genderCounterNew.Value}");
            }

            //AGGREGRATE BY IN .NET 9

            //OLD WAY
            var studentScoreTotal = _db.StudentScores.Include(u => u.Student)
                .GroupBy(s => s.Student.Name)
                .Select(u => new { Name = u.Key, TotalScore = u.Sum(u => u.Score) });

            foreach (var studentScore in studentScoreTotal)
            {
                Console.WriteLine($"Total Score for  {studentScore.Name} is {studentScore.TotalScore}");
            }


            //NEW WAY
            var studentScoreTotalNew = _db.StudentScores.Include(u => u.Student).ToList()
               .AggregateBy(s => s.Student.Name, seed: 0,
               (currentTotal, student) => currentTotal + student.Score);
               

            foreach (var studentScore in studentScoreTotalNew)
            {
                Console.WriteLine($"Total Score for  {studentScore.Key} is {studentScore.Value}");
            }


            return View();
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
