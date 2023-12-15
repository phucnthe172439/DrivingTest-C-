using DrivingTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DrivingTest.Controllers
{
    public class AdminController : Controller
    {
        static int i;
        DriveTestDBContext db = new DriveTestDBContext();
        public IActionResult Index()
        {
            TempData["Username"] = TempData["Username"];
            TempData["Role"] = TempData["Role"];
            return View();
        }
        
        public IActionResult Add()
        {
            ViewBag.categories = db.Categories.ToList();
            

            return View();
        }
        [HttpPost]
        public IActionResult Add(Quiz quiz, int cateid)
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.cateidselected = cateid;
            if(cateid ==0)
            {

            }

            
            if (quiz.Answer.Equals("A"))
            {
                quiz.Answer = quiz.A;
            }
            else if (quiz.Answer.Equals("B"))
            {
                quiz.Answer = quiz.B;
            }
            else if (quiz.Answer.Equals("C"))
            {
                quiz.Answer = quiz.C;
            }
            else
            {
                quiz.Answer = quiz.D;
            }
            /*  if(quiz.IsZeroPoint.Equals(1)) //phan nay
              {
                  quiz.IsZeroPoint = 1;
              } else
              {
                  quiz.IsZeroPoint = 0;
              }*/
            i = 3;

            string inputImage = "/Images/" + i.ToString() + ".webp";
            var addQuiz = new Quiz()
            {
                Title = quiz.Title,
                Image = inputImage,
                Categoryid = cateid,
                A = quiz.A,
                B = quiz.B,
                C = quiz.C,
                D = quiz.D,
                IsZeroPoint = quiz.IsZeroPoint,
                Answer = quiz.Answer,
            };
            db.Quizzes.Add(addQuiz);
            db.SaveChanges();
            i++;
            return RedirectToAction("Index", "Admin"); 
        }
        public IActionResult Edit(string code )
        {
            Quiz q = db.Quizzes.Find(int.Parse(code));
            ViewBag.categories = db.Categories.ToList();
            return View(q);
        }
        [HttpPost]
        public IActionResult Edit(Quiz q)
        {
            ViewBag.categories = db.Categories.ToList();
            if (ModelState.IsValid)
            {
                Quiz q1 = db.Quizzes.FirstOrDefault(item => item.Id == q.Id);
                q1.Title = q.Title;
                q1.Image = q.Image;
                q1.A = q.A;
                q1.B = q.B;
                q1.C = q.C;
                q1.D = q.D;
                q1.IsZeroPoint = q.IsZeroPoint;
                q1.Answer = q.Answer;
                q1.Categoryid = q.Categoryid;
                db.Quizzes.Remove(q1);
                db.Quizzes.Add(q);
                db.SaveChanges();
                return RedirectToAction("ViewList", q);
            }
            else
            {
                return View(q);
            }
        }
        public IActionResult Delete(string code)
        {
            Quiz q = db.Quizzes.Find(int.Parse(code));
            db.Quizzes.Remove(q);
            db.SaveChanges();
            return RedirectToAction("ViewList");
        }
        public IActionResult ViewQuiz()
        {
            ViewBag.categories = db.Categories.ToList();
            List<Quiz> data = db.Quizzes.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult ViewQuiz(int cateid)
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.cateidselected = cateid;
            List<Quiz> data = db.Quizzes.ToList();
            if (cateid != 0)
            {
                data = db.Quizzes
                    .Where(p => p.Categoryid == cateid)
                    .ToList();
            }
            return View(data);
        }
        public IActionResult ViewList()
        {
            ViewBag.categories = db.Categories.ToList();
            List<Quiz> data = db.Quizzes.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult ViewList(int cateid)
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.cateidselected = cateid;
            List<Quiz> data = db.Quizzes.ToList();
            if (cateid != 0)
            {
                data = db.Quizzes
                    .Where(p => p.Categoryid == cateid)
                    .ToList();
            }
            return View(data);
        }
    }
}
