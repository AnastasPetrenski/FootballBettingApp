using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.ViewModels.Towns;
using System.Linq;

namespace P03_FootballBetting.Web.Controllers
{
    public class TownsController : Controller
    {
        private readonly FootballBettingContext context;
        private readonly IMapper mapper;

        public TownsController(FootballBettingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var countries = this.context.Countries
                .ProjectTo<CreateTownViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(countries);
        }

        [HttpPost]
        public IActionResult Create(CreateTownInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var town = this.mapper.Map<Town>(model);

            this.context.Towns.Add(town);
            this.context.SaveChanges();

            return this.RedirectToAction("All", "Towns");
        }

        public IActionResult All()
        {
            var towns = this.context.Towns
                .ProjectTo<AllTownsViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(towns);
        }
    }
}
