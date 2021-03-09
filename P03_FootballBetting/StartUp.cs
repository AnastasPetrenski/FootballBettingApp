using Microsoft.Extensions.Caching.Memory;
using P03_FootballBetting.Data;
using System;
using System.Linq;

namespace P03_FootballBetting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();

            var users = context
                            .Users
                            .Select(u => new
                            {
                                u.Username,
                                u.Email,
                                Name = u.Name == null ? "No name" : u.Name,
                                Bets = u.Bets
                            });

            foreach (var item in users)
            {
                Console.WriteLine($"{item.Username} -> {item.Name} {item.Email}");
                foreach (var bet in item.Bets)
                {
                    Console.WriteLine($"{bet}");
                }
            }

            var colors = context.Colors.SelectMany(x => x.PrimaryKitTeams, (p, c) => new { p.Name, c.Initials});

            foreach (var color in colors)
            {
                
                    Console.WriteLine(color);
                
            }

        }
    }
}
