using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Data.Models.Enumerations;
using P03_FootballBetting.Web.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
