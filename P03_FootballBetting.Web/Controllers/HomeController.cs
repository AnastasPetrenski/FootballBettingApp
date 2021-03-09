using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.Common;
using P03_FootballBetting.Web.Models;
using P03_FootballBetting.Web.ViewModels.Homes;

namespace P03_FootballBetting.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly FootballBettingContext context;
        private readonly IMapper mapper;
       
        public HomeController(ILogger<HomeController> logger,
            FootballBettingContext context,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {        
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        public IActionResult Loged(RegisterConnectionViewModel model)
        {
            var user = this.context.Users.Where(x => x.Password == Sha512Generator.Sha512(model.Password) &&
                                                     x.Username == model.User).FirstOrDefault();

            if (user != null)
            {
                return this.View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.mapper.Map<User>(model);

                var check = context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (check == null)
                {
                    user.Password = Sha512Generator.Sha512(user.Password);
                    context.Users.Add(user);
                    context.SaveChanges();

                    //ViewBag.message = "User created";
                    return RedirectToAction("Index");
                }
            }

            return this.View();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var pass = Sha512Generator.Sha512(password);
                var data = context.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(pass)).ToList();
                //if (data.Count == 1)
                //{
                //    Session["FullName"] = data.FirstOrDefault().Username;
                //}

            }
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //create a string MD5 => Sha512
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}