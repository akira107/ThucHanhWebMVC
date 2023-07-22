using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Models;

namespace ThucHanhWebMVC.Controllers
{
    public class AccessController : Controller
    {
        QlbanValiContext db = new QlbanValiContext();
        [HttpGet]
        public IActionResult Login()
        {
           if(HttpContext.Session.GetString("UserName")== null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if(HttpContext.Session.GetString("Username") == null)
            {
                var u = db.TUsers.Where(x => x.Username.Equals(user.Username)/*&& x.LoaiUser.Equals(user.LoaiUser)*/ && x.Password.Equals(user.Password)).FirstOrDefault();
                if(u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    if (u.LoaiUser == 1)
                    {
                        return RedirectToAction("Index", "HomeAdmin", new {area = "Admin"});

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Access");
        }
        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]

        //public IActionResult Register(TUser user)
        //{
        //    QlbanValiContext userContext = new QlbanValiContext();
        //    try
        //    {
        //        var userData = new TUser()
        //        {
        //            Username = user.Username,
        //            Password = user.Password
        //        };
        //        userContext.TUsers.Add(userData);
        //        userContext.SaveChanges();
        //        ViewBag.Status = 1;
        //    }
        //    catch
        //    {
        //        ViewBag.Status = 0;
        //    }
        //    return View();
        //}


    }
}
