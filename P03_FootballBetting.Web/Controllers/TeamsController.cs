using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.ViewModels.Teams;
using System.Linq;

namespace P03_FootballBetting.Web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly FootballBettingContext context;
        private readonly IMapper mapper;

        public TeamsController(FootballBettingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateTeamViewModel()
            {
                Colors = this.context
                             .Colors
                             .ProjectTo<CreateColorsViewModel>(mapper.ConfigurationProvider)
                             .ToList(),
                Towns = this.context
                            .Towns
                            .ProjectTo<CreateTownsViewModel>(mapper.ConfigurationProvider)
                            .ToList()
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateTeamInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var team = this.mapper.Map<Team>(model);

            this.context.Teams.Add(team);
            this.context.SaveChanges();

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var teams = this.context.Teams
                .ProjectTo<AllTeamsViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(teams);
        }
    }
}
