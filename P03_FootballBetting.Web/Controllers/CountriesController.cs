using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.ViewModels.Countries;
using System.Linq;

namespace P03_FootballBetting.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly FootballBettingContext context;
        private readonly IMapper mapper;

        public CountriesController(IMapper mapper, FootballBettingContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var country = this.mapper.Map<Country>(model);

            this.context.Countries.Add(country);
            this.context.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var countries = this.context.Countries
                .ProjectTo<AllCountriesViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(countries);
        }
    }
}
