using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.ViewModels.Users;

namespace P03_FootballBetting.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly FootballBettingContext context;
        private readonly IMapper mapper; 

        public UsersController(FootballBettingContext footballBettingContext, IMapper mapper)
        {
            this.context = footballBettingContext;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Error");
            }
            //User user = new User()
            //{
            //    Username = this.footballBettingContext.Users.FirstOrDefault(x => x.Username == model.Username) == null ? model.Username : throw new InvalidOperationException("User exist"),
            //    //Username = model.Username,
            //    Password = model.Password,
            //    Email = model.Email,
            //    Name = model.Name,
            //    Balance = 0m
            //};
            User user = this.mapper.Map<User>(model);

            this.context.Users.Add(user);
            //this.footballBettingContext.SaveChangesAsync(); <= dont show changes ??? white monitor
            this.context.SaveChanges();

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult All()
        {
            //List<User> users = footballBettingContext.Users.ToList();

            List<AllUsersViewModel> users = this.context
                .Users
                .ProjectTo<AllUsersViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(users);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            User user = context.Users.FirstOrDefault(u => u.UserId == ID);

            return this.View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            this.context.Update(user);

            this.context.SaveChanges();

            return this.View(user);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            User user = context.Users.FirstOrDefault(u => u.UserId == id);

            return this.View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = this.context.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return this.View("Error");
            }

            return this.View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            this.context.Users.Remove(user);

            this.context.SaveChanges();

            return this.View(user);

            //return this.RedirectToAction("All")
        }
    }
}
