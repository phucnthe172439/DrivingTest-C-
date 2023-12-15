using DrivingTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;
using static System.Formats.Asn1.AsnWriter;

namespace DrivingTest.Controllers
{
   
    public class ExamController : Controller
    {
        DriveTestDBContext db = new DriveTestDBContext();
        private readonly Random random;
        public ExamController()
        {
           
            random = new Random();
        }
        public IActionResult Index()
        {
            ViewBag.categories = db.Categories.ToList();
            List<Quiz> data = db.Quizzes.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult Index(int cateid)
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.cateidselected = cateid;
            List<Quiz> data = db.Quizzes.ToList();
            
            if(cateid != 0)
            {
                if(cateid ==1)
                {
                    TempData["cateName"] = "B1";
                } else if(cateid ==2)
                {
                    TempData["cateName"] = "A1";
                } else if(cateid ==3)
                {
                    TempData["cateName"] = "A2";
                } else if(cateid ==4)
                {
                    TempData["cateName"] = "B2";
                }
                data = db.Quizzes.Where(item => item.Categoryid == cateid).ToList();
            }
            TempData["cateid"] = cateid;
            return View();
        }
        
        public IActionResult TakeExam()
        {
           
           List<Quiz> data0 = db.Quizzes.ToList();
           List<Quiz> data1 = data0.Where(item => item.IsZeroPoint.Equals(false)).OrderBy(item => random.Next()).Take(24).ToList();
            List<Quiz> data2 = data0.Where(item => item.IsZeroPoint.Equals(true)).OrderBy(item => random.Next()).Take(1).ToList();
            List<Quiz> data3 = data1.Concat(data2).ToList();
            return View(data3);
           // PagedList<Quiz> data = new PagedList<Quiz>(data3, pageNumber, pageSize);

        }
        [HttpPost]
        public IActionResult CheckAnswers(List<string> userAnswers, List<Quiz> data)
        {
            // Retrieve correct answers for the questions
            List<Quiz> correctAnswers = data.ToList();

            // Calculate the score
            int score = CalculateScore(userAnswers, correctAnswers);

            // Return the score as JSON
            return Json(new { score });
        }

        private int CalculateScore(List<string> userAnswers, List<Quiz> correctAnswers)
        {
            int score = 0;

            for (int i = 0; i < userAnswers.Count; i++)
            {
                var item = correctAnswers[i];
                var selectedAnswer = userAnswers[i];

                if (string.Equals(selectedAnswer.ToLower(), item.AnswerChar.ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                }
            }

            return score;
        }



        public IActionResult showResult(int? score)
        {
            ViewBag.Score = score ?? 0;
            return View();
        }
        
        
    }
}
