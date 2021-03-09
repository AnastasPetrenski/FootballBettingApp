using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.ViewModels.Players;

namespace P03_FootballBetting.Web.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FootballBettingContext context;
        private readonly IMapper mapper;

        public PlayersController(FootballBettingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public IActionResult Create()
        {
            var viewModel = new CreatePlayerViewModel()
            {
                Positions = this.context.Positions
                                .ProjectTo<CreatePositionsViewModel>(mapper.ConfigurationProvider)
                                .ToList(),
                Teams = this.context.Teams
                            .ProjectTo<CreateTeamsViewModel>(mapper.ConfigurationProvider)
                            .ToList()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePlayerInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var player = this.mapper.Map<Player>(model);

            this.context.Players.Add(player);
            this.context.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var players = this.context.Players
                              .ProjectTo<AllPlayersViewModel>(mapper.ConfigurationProvider)
                              .ToArray();

            return this.View(players);
        }
    }
}
