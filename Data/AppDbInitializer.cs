using CinemaTickets.Data.Enums;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CinemaTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope =applicationBuilder.ApplicationServices.CreateScope())
            {
                var context= serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema One",
                            Logo = "Images\\Cinema\\CinemaOne.png",
                            Description = "Cinema One: destinație de distracție și un univers în care vei putea viziona filmele momentului."
                        },
                        new Cinema()
                        {
                            Name = "Cinema City",
                            Logo = "Images\\Cinema\\CinemaCity.png",
                            Description = "La Cinema City, te bucuri mereu de filme noi, in cele mai spectaculoase formate."
                        },
                        new Cinema()
                        {
                            Name = "Cinema Ateneu",
                            Logo = "Images\\Cinema\\CinemaAteneu.png",
                            Description = "La noi vezi ce la alții nu găsești."
                        },
                        new Cinema()
                        {
                            Name = "Cineplexx",
                            Logo = "Images\\Cinema\\Cineplexx.png",
                            Description = "Un loc magic pentru iubitorii de film."
                        },
                        new Cinema()
                        {
                            Name = "Cinema Victoria",
                            Logo = "Images\\Cinema\\Cineplexx.png",
                            Description = "O scenă nouă pentru film de artă, teatru independent, evenimente ale comunității."
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Ariana DeBose",
                            Bio = "Ariana DeBose este o actriță americană născută pe 25 ianuarie 1991 în Wilmington, Carolina de Nord, SUA.Este cunoscută pentru rolurile sale atât pe scenă cât și pe ecran, inclusiv în producția originală de pe Broadway a musicalului Hamilton (2015-2016)",
                            ProfilePictureURL = "Images\\Actor\\ArianaDeBose.png"

                        },
                        new Actor()
                        {
                            FullName = "Chris Pine",
                            Bio = "Chris Pine, născut pe 26 august 1980 la Los Angeles, California, SUA, este un actor american renumit pentru portretizarea personajelor inteligente și experimentate",
                            ProfilePictureURL = "Images\\Actor\\ChrisPine.png"
                        },
                        new Actor()
                        {
                            FullName = "Rick Hoffman",
                            Bio = "Richard Edward Hoffman este un actor american. Este cunoscut pentru rolul lui Jerry Best în sitcomul Fox The Bernie Mac Show",
                            ProfilePictureURL = "Images\\Actor\\RickHoffman.png"
                        },
                        new Actor()
                        {
                            FullName = "Tom Blyth",
                            Bio = "Tom Keir Blyth este un actor englez. Printre filmele sale se numără Scott și Sid, Benediction și The Hunger Games: The Ballad of Songbirds & Snakes.",
                            ProfilePictureURL = "Images\\Actor\\TomBlyth.png"
                        },
                        new Actor()
                        {
                            FullName = "Rachel Zegler",
                            Bio = "Rachel Anne Zegler este o actriță și cântăreață americană. Ea a devenit cunoscută odată cu debutul ei în film jucând pe María în adaptarea muzicală a lui Steven Spielberg West Side Story.",
                            ProfilePictureURL = "Images\\Actor\\RachelZegler.png"
                        },

                         new Actor()
                        {
                            FullName = "Joaquin Phoenix",
                            Bio = "Joaquín Rafael Phoenix, cunoscut în trecut ca Leaf Phoenix, este un actor, producător, regizor de videoclipuri, muzician și activist american.",
                            ProfilePictureURL = "Images\\Actor\\JoaquinPhoenix.png"
                        },
                         new Actor()
                         {
                            FullName = "Timothée Chalamet",
                            Bio = "Timothée Hal Chalamet este un actor american născut în New York, dintr-un tată francez și o mamă americancă. Cariera lui de actor s-a cristalizat în scurt-metraje, înainte de a apărea în serialul de televiziune Homeland.",
                            ProfilePictureURL = "Images\\Actor\\TimothéeChalamet.png"
                         },
                         
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Eli Roth",
                            Bio = "Eli Raphael Roth este un regizor, scenarist, producător și actor american. Ca regizor și producător, el este cel mai strâns asociat cu genul horror, și anume filmele splatter.",
                            ProfilePictureURL = "Images\\Producer\\EliRoth.png"

                        },
                        new Producer()
                        {
                            FullName = "Ridley Scott",
                            Bio = "Sir Ridley Scott KBE este un regizor de filme britanic considerat unul dintre cei influenți și mai renumiți regizori contemporani, cunoscut și recunoscut pentru stilul vizual deosebit.",
                            ProfilePictureURL = "Images\\Producer\\RidleyScott.png"
                        },
                        new Producer()
                        {
                            FullName = "Chris Buck",
                            Bio = "Chris Buck e un producator de filme animate din Kansas. Printre filmele produse se numara Tarzan, Frozen si Pocahontas.",
                            ProfilePictureURL = "Images\\Producer\\ChrisBuck.png"
                        },
                        new Producer()
                        {
                            FullName = "Francis Lawrence",
                            Bio = "Francis Lawrence este un regizor american și producător născut pe 26 martie 1971 la Viena, Austria, care și-a făcut un nume regizând videoclipuri muzicale și reclame.",
                            ProfilePictureURL = "Images\\Producer\\FrancisLawrence.png"
                        },
                       
                         new Producer()
                        {
                            FullName = "Paul King",
                            Bio = "Paul King este un scriitor și regizor britanic. Lucrează în televiziune, film și teatru și este specializat în comedie.",
                            ProfilePictureURL = "Images\\Producer\\PaulKing.png"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Wish",
                            Description = "Wish spune povestea tinerei Asha care, intr-o noapte instelata, isi pune o dorinta si primeste un raspuns mai ferm decat se astepta atunci cand o stea buclucasa coboara din cer pentru a i se alatura.",
                            Price = 39.50,
                            ImageURL = "https://cinemaone.ro/public/movies/582216964223291886wish%206080.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(500),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Vinerea neagră",
                            Description = "Dupa ce o revolta de Black Friday se sfarseste tragic, un misterios criminal inspirat de Ziua Recunostintei terorizeaza Plymouth, Massachusetts, orasul in care a aparut infama sarbatoare.",
                            Price = 29.50,
                            ImageURL = "https://cinemaone.ro/public/movies/319217006419835984thanksgiving%206080.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(50),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Jocurile Foamei",
                            Description = "https://cinemaone.ro/public/movies/188316965038207740the-hunger-games-the-ballad-of-songbirds-and-snakes-6080.jpg",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Napoleon",
                            Description = "Filmul expune modul crud in care generalul Napoleon pune mana pe tronul Frantei, intreaga lui cariera fiind analizata din unghiul lui Josephine, sotia si marea lui dragoste.",
                            Price = 39.50,
                            ImageURL = "https://cinemaone.ro/public/movies/423916981373554832Napoleon%202%206080.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Wonka",
                            Description = "Wonka spune povestea minunata prin care cel mai mare inventator, magician si producator de ciocolata a devenit indragitul personaj Willy Wonka, asa cum il cunoastem astazi.",
                            Price = 39.50,
                            ImageURL = "https://cinemaone.ro/public/movies/268716909650733697wonka%206080.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Fantasy
                        }
                      
                    });
                    
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 7
                        },
                        new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId=7
                        }
                        ,
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 8
                        },

                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 9
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 9
                        },

                        new Actor_Movie()
                        {
                            ActorId = 6,
                            MovieId = 10
                        },
                        //new Actor_Movie()
                        //{
                        //    ActorId = 7,
                        //    MovieId = 5
                        //}
                       


          
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
