using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.ViewModels.Colors;
using System.Linq;

namespace P03_FootballBetting.Web.Controllers
{
    public class ColorsController : Controller
    {
        private readonly FootballBettingContext context;
        private readonly IMapper mapper;

        public ColorsController(FootballBettingContext footballBettingContext, IMapper mapper)
        {
            this.context = footballBettingContext;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateColorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

                var color = this.mapper.Map<Color>(model);

            //return entity with id=1 color=blue
            //var test = this.context.Find<Color>(color.ColorId); not found <== Null
            var test = this.context.Find<Color>(1002);

            this.context.Colors.Add(color);

            this.context.SaveChanges();
            //var test = this.context.Find<Color>(color.ColorId); the Id=1002

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var colors = this.context.Colors
                .ProjectTo<AllColorsViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(colors);
        }
    }
}
