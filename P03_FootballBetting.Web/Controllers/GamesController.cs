using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Data.Models.Enumerations;
using P03_FootballBetting.Web.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P03_FootballBetting.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly IMapper mapper;
        private readonly FootballBettingContext context;

        public GamesController(FootballBettingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var teams = new CreateGameViewModel()
            {
                HomeTeams = this.context.Teams
                                .ProjectTo<CreateHomeTeamViewModel>(mapper.ConfigurationProvider)
                                .ToList(),
                AwayTeams = this.context.Teams
                                .ProjectTo<CreateAwayTeamViewModel>(mapper.ConfigurationProvider)
                                .ToList(),
                Predict = Enum.GetValues(typeof(Prediction)).Cast<Prediction>().ToList(),

            };

            return this.View(teams);
        }

        [HttpPost]
        public IActionResult Create(CreateGameInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var game = this.mapper.Map<Game>(model);

            this.context.Games.Add(game);
            this.context.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var games = this.context.Games
                            .ProjectTo<AllGamesViewModel>(mapper.ConfigurationProvider)
                            .ToList();

            return this.View(games);
        }

        [HttpPost]
        public IActionResult All(IEnumerable<AllGamesViewModel> games)
        {
            return this.View(games);
        }

        public IActionResult Search()
        {
            var countries = new SelectList(context.Countries.Select(x => x.Name).ToList());

            return this.View(countries);
        }

        public async Task<IActionResult> DoSearch(string country, string team)
        {
            var teams = new List<string>();

            if (!string.IsNullOrEmpty(country))
            {
                teams = context.Teams
                               .Where(t => t.Town.Country.Name == country)
                               .Select(t => t.Name)
                               .ToList();

            }

            if (teams.Any(x => x == team))
            {
                teams = teams.Where(x => x == team).ToList();
            }

            var games = await this.context.Games
                            .Where(x => teams.Contains(x.HomeTeam.Name) || teams.Contains(x.AwayTeam.Name))
                            .ProjectTo<AllGamesViewModel>(mapper.ConfigurationProvider)
                            .ToListAsync();

            if (!string.IsNullOrEmpty(team))
            {
                games = await this.context.Games
                                  .Where(x => x.HomeTeam.Name == team || x.AwayTeam.Name == team)
                                  .ProjectTo<AllGamesViewModel>(mapper.ConfigurationProvider)
                                  .ToListAsync();
            }

            if (games.Count == 0)
            {
                games = await this.context.Games
                     .ProjectTo<AllGamesViewModel>(mapper.ConfigurationProvider)
                            .ToListAsync();
            }

            return this.View(games);
        }
    }
}
