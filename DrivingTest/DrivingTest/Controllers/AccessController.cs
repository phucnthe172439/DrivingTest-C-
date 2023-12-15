using DrivingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrivingTest.Controllers
{
    public class AccessController : Controller
    {
        
        DriveTestDBContext db = new DriveTestDBContext();
        
        public IActionResult Index()
        {
            List<User> data = db.Users.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult Index(string userName, string passWord)
        {
            if(ModelState.IsValid)
            {
                var data = db.Users.FirstOrDefault(item => item.Username.Equals(userName) && item.Password.Equals(passWord));
                if(data != null)
                {
                    TempData["Username"] = userName;
                    if (userName.Equals("phucnthe172439"))
                    {
                        TempData["role"] = 1;
                    }else
                    {
                        TempData["role"] = 0;
                    }
                    
                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    ViewBag.Message = "Wrong username or password!!!";
                    return View();
                }
            } else
            {
                ViewBag.Message = "Please enter username and password";
                return View();
            }
            
        }
        
        public IActionResult Register(string userName, string password1, string password2, User u) 
        {
            if (ModelState.IsValid)
            {
                if (password2.Equals(password1))
                {
                    db.Users.Add(u);
                    db.SaveChanges();
                    ViewBag.Message = "Create account successfully!!!";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Password is not the same!!!";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Please enter username and password";
                return View();
            }
        }
    }
}
