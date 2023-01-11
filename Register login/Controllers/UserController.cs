using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register_login.Models;

namespace Register_login.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        UsersDAL UserDAL;
        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
            UserDAL = new UsersDAL(this.configuration);
        }
        // GET: UserController
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        // GET: UserController/Details/5
        public ActionResult Register(Users us)
        {
            try
            {
                int res = UserDAL.UserrRegister(us);
                if (res==1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        // GET: UserController/Details/5
        public ActionResult Login(Users us)
        {
                Users u = UserDAL.UserLogin(us);
                if (u!=null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("UserLogin");

        }
        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
