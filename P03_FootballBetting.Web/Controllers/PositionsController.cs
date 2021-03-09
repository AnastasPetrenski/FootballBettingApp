using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Web.ViewModels.Positions;

namespace P03_FootballBetting.Web.Controllers
{
    public class PositionsController : Controller
    {
        private readonly FootballBettingContext context;
        private readonly IMapper mapper;

        public PositionsController(FootballBettingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            try
            {
                //if (!ModelState.IsValid || position.Name == null)
                //{
                //    return RedirectToAction("Error", "Home");
                //}

                this.context.Positions.Add(position);
                this.context.SaveChanges();

                return this.RedirectToAction("All");
            }
            catch (Exception)
            {
                return this.RedirectToAction("Create");
            }          
        }

        [HttpGet]
        public IActionResult All()
        {
            List<AllPositionsViewModel> positions = this.context
                .Positions
                .ProjectTo<AllPositionsViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(positions);
        }
    }
}
