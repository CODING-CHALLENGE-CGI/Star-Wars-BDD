﻿using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Persistance.Models;

namespace Persistance.Seed
{
    public static class StarWarsSeedData
    {
        public static void EnsureSeedData(this StarWarsContext db)
        {

            // episodes
            var newhope = new Episode { Id = 4, Title = "NEWHOPE" };
            var empire = new Episode { Id = 5, Title = "EMPIRE" };
            var jedi = new Episode { Id = 6, Title = "JEDI" };
            var episodes = new List<Episode>
            {
                newhope,
                empire,
                jedi,
            };
            if (!db.Episodes.Any())
            {
                db.Episodes.AddRange(episodes);
                db.SaveChanges();
            }

            // planets
            var tatooine = new Planet { Id = 1, Name = "Tatooine" };
            var alderaan = new Planet { Id = 2, Name = "Alderaan" };
            var planets = new List<Planet>
            {
                tatooine,
                alderaan
            };
            if (!db.Planets.Any())
            {
                db.Planets.AddRange(planets);
                db.SaveChanges();
            }

            // humans
            var luke = new Human
            {
                Id = 1000,
                Name = "Luke Skywalker",
                CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope },
                    new CharacterEpisode { Episode = empire },
                    new CharacterEpisode { Episode = jedi }
                },
                HomePlanet = tatooine
            };
            var vader = new Human
            {
                Id = 1001,
                Name = "Darth Vader",
                CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope },
                    new CharacterEpisode { Episode = empire },
                    new CharacterEpisode { Episode = jedi }
                },
                HomePlanet = tatooine
            };
            var han = new Human
            {
                Id = 1002,
                Name = "Han Solo",
                CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope },
                    new CharacterEpisode { Episode = empire },
                    new CharacterEpisode { Episode = jedi }
                },
                HomePlanet = tatooine
            };
            var leia = new Human
            {
                Id = 1003,
                Name = "Leia Organa",
                CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope },
                    new CharacterEpisode { Episode = empire },
                    new CharacterEpisode { Episode = jedi }
                },
                HomePlanet = alderaan
            };
            var tarkin = new Human
            {
                Id = 1004,
                Name = "Wilhuff Tarkin",
                CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope }
                },
            };
            

            var humans = new List<Human>
            {
                luke,
                vader,
                han,
                leia,
                tarkin
            };

            for (int i = 10000; i < 150000; i++)
            {
                humans.Add(new Human
                {
                    Id = i,
                    Name = "Unknown jedis",
                    CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope }
                },
                    HomePlanet = new Planet { Id = i, Name = "Unknown Planet" }
            });
            }
            if (!db.Humans.Any())
            {
                db.Humans.AddRange(humans);
                db.SaveChanges();
            }

            



            // droids
            var threepio = new Droid
            {
                Id = 2000,
                Name = "C-3PO",
                CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope },
                    new CharacterEpisode { Episode = empire },
                    new CharacterEpisode { Episode = jedi }
                },
                PrimaryFunction = "Protocol"
            };
            var artoo = new Droid
            {
                Id = 2001,
                Name = "R2-D2",
                CharacterEpisodes = new List<CharacterEpisode>
                {
                    new CharacterEpisode { Episode = newhope },
                    new CharacterEpisode { Episode = empire },
                    new CharacterEpisode { Episode = jedi }
                },
                PrimaryFunction = "Astromech"
            };
            var droids = new List<Droid>
            {
                threepio,
                artoo
            };
            if (!db.Droids.Any())
            {
                db.Droids.AddRange(droids);
                db.SaveChanges();
            }

            // update character's friends
            luke.CharacterFriends = new List<CharacterFriend>
            {
                new CharacterFriend { Friend = han },
                new CharacterFriend { Friend = leia },
                new CharacterFriend { Friend = threepio },
                new CharacterFriend { Friend = artoo }
            };
            vader.CharacterFriends = new List<CharacterFriend>
            {
                new CharacterFriend { Friend = tarkin }
            };
            han.CharacterFriends = new List<CharacterFriend>
            {
                new CharacterFriend { Friend = luke },
                new CharacterFriend { Friend = leia },
                new CharacterFriend { Friend = artoo }
            };
            leia.CharacterFriends = new List<CharacterFriend>
            {
                new CharacterFriend { Friend = luke },
                new CharacterFriend { Friend = han },
                new CharacterFriend { Friend = threepio },
                new CharacterFriend { Friend = artoo }
            };
            tarkin.CharacterFriends = new List<CharacterFriend>
            {
                new CharacterFriend { Friend = vader }
            };
            threepio.CharacterFriends = new List<CharacterFriend>
            {
                new CharacterFriend { Friend = luke },
                new CharacterFriend { Friend = han },
                new CharacterFriend { Friend = leia },
                new CharacterFriend { Friend = artoo }
            };
            artoo.CharacterFriends = new List<CharacterFriend>
            {
                new CharacterFriend { Friend = luke },
                new CharacterFriend { Friend = han },
                new CharacterFriend { Friend = leia }
            };
            var characters = new List<Character>
            {
                luke,
                vader,
                han,
                leia,
                tarkin,
                threepio,
                artoo
            };
            if (!db.CharacterFriends.Any())
            {
                db.Characters.UpdateRange(characters);
                db.SaveChanges();
            }

            // update episode's heroes
            newhope.Hero = artoo;
            empire.Hero = luke;
            jedi.Hero = artoo;
            db.SaveChanges();
        }
    }
}
