using AutoMapper;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Data.Models.Enumerations;
using P03_FootballBetting.Web.ViewModels.Colors;
using P03_FootballBetting.Web.ViewModels.Countries;
using P03_FootballBetting.Web.ViewModels.Games;
using P03_FootballBetting.Web.ViewModels.Players;
using P03_FootballBetting.Web.ViewModels.Positions;
using P03_FootballBetting.Web.ViewModels.Teams;
using P03_FootballBetting.Web.ViewModels.Towns;
using P03_FootballBetting.Web.ViewModels.Users;
using P03_FootballBetting.Web.Common;
using System;
using System.Security.Cryptography;
using System.Text;
using P03_FootballBetting.Web.ViewModels.Homes;

namespace P03_FootballBetting.Web.MappingConfigurations
{
    public class FootballBettingProfile : Profile
    {
        public FootballBettingProfile()
        {
            //CreateUser
            this.CreateMap<CreateUserViewModel, User>()
                .ForMember(x => x.Balance, y => y.MapFrom(s => s.Balance))
                .ForMember(x => x.Password, y => y.MapFrom(s => Sha512Generator.Sha512(s.Password)));

            //DisplayAllUserInfo
            this.CreateMap<User, AllUsersViewModel>()
                .ForMember(x => x.UserId, y => y.MapFrom(s => s.UserId));

            //Positions
            this.CreateMap<Position, CreatePositionViewModel>();

            this.CreateMap<Position, AllPositionsViewModel>();
                       

            //Countries
            this.CreateMap<CreateCountryViewModel, Country>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Country, AllCountriesViewModel>()
                .ForMember(x => x.CountryName, y => y.MapFrom(s => s.Name));

            //Towns
            this.CreateMap<Country, CreateTownViewModel>()
                .ForMember(x => x.CountryId, y => y.MapFrom(s => s.CountryId))
                .ForMember(x => x.CountryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateTownInputModel, Town>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.TownName));

            this.CreateMap<Town, AllTownsViewModel>()
                .ForMember(x => x.Country, y => y.MapFrom(s => s.Country.Name))
                .ForMember(x => x.TownName, y => y.MapFrom(s => s.Name));

            //Colors
            this.CreateMap<CreateColorViewModel, Color>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Color, AllColorsViewModel>()
                .ForMember(x => x.ColorId, y => y.MapFrom(s => s.ColorId))
                .ForMember(x => x.ColorName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.PrimaryTeamsColorCount, y => y.MapFrom(s => s.PrimaryKitTeams.Count))
                .ForMember(x => x.SecondaryTeamsColorCount, y => y.MapFrom(s => s.SecondaryKitTeams.Count));

            //Teams
            this.CreateMap<Color, CreateColorsViewModel>()
                .ForMember(x => x.ColorName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.ColorId, y => y.MapFrom(s => s.ColorId));

            this.CreateMap<Town, CreateTownsViewModel>()
                .ForMember(x => x.TownName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.TownId, y => y.MapFrom(s => s.TownId));
            //TODO:Check mapping
            this.CreateMap<CreateTeamInputModel, Team>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.PrimaryKitColorId, y => y.MapFrom(s => s.PrimaryKitColorId))
                .ForMember(x => x.SecondryKitColorId, y => y.MapFrom(s => s.SecondaryKitColorId))
                .ForMember(x => x.TownId, y => y.MapFrom(s => s.TownId));


            this.CreateMap<Team, AllTeamsViewModel>()
                .ForMember(x => x.PrimaryKitColor, y => y.MapFrom(s => s.PrimaryKitColor.Name))
                .ForMember(x => x.SecondaryKitColor, y => y.MapFrom(s => s.SecondaryKitColor.Name))
                .ForMember(x => x.Town, y => y.MapFrom(s => s.Town.Name))
                .ForMember(x => x.Country, y => y.MapFrom(s => s.Town.Country.Name));

            //Players
            this.CreateMap<Position, CreatePositionsViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.PositionId))
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<Team, CreateTeamsViewModel>()
                .ForMember(x => x.TeamId, y => y.MapFrom(s => s.TeamId))
                .ForMember(x => x.TeamName, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreatePlayerInputModel, Player>()
                .ForMember(x => x.TeamId, y => y.MapFrom(s => s.TeamId))
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.PositionId));
                //.ForMember(x => x.IsInjured, y => y.MapFrom(s => Injury.No));

            this.CreateMap<Player, AllPlayersViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name))
                .ForMember(x => x.Team, y => y.MapFrom(s => s.Team.Name));

            //Games
            this.CreateMap<Team, CreateHomeTeamViewModel>();

            this.CreateMap<Team, CreateAwayTeamViewModel>();

            this.CreateMap<CreateGameInputModel, Game>()
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime))
                .ForMember(x => x.AwayTeamId, y => y.MapFrom(s => s.AwayTeamId))
                .ForMember(x => x.HomeTeamId, y => y.MapFrom(s => s.HomeTeamId));

            this.CreateMap<Game, AllGamesViewModel>()
                .ForMember(x => x.HomeTeam, y => y.MapFrom(s => s.HomeTeam.Name))
                .ForMember(x => x.AwayTeam, y => y.MapFrom(s => s.AwayTeam.Name))
                .ForMember(x => x.DataTime, y => y.MapFrom(s => s.DateTime));

            //HomeLoginRegister
            this.CreateMap<RegisterUserViewModel, User>();
        }

    }
}
