using System;
using DAL_Project.Models;

namespace DAL_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int back = 1;
            do
            {
                using (var un = new UnitOfWork(new FilmsCollectionDBContext()))
                {
                    Console.WriteLine("Welcome to Films Collection!");
                    Console.WriteLine("Enter next numbers to use me:");
                    Console.WriteLine("1 - Filmmakers menu");
                    Console.WriteLine("2 - Films menu");
                    Console.WriteLine("3 - Your Favourite Films menu");
                    int temp = Int32.Parse(Console.ReadLine());

                    switch (temp)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("1 - Get information about filmmaker.");
                                Console.WriteLine("2 - Get list of filmmakers by genre.");
                                Console.WriteLine("3 - Get list of filmmakers by award.");
                                int t = Int32.Parse(Console.ReadLine());
                                switch (t)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Enter his/her full name:");
                                            string fullname = Console.ReadLine();
                                            var res = un.Filmmakers.GetInfoAboutFilmmaker(fullname);
                                            Console.WriteLine($"Firstname: {res.Firstname} \n Lastname: {res.Lastname} \n" +
                                                              $"Date of birth: {res.Dateofbirth} \n Country: {res.Country} \n" +
                                                              $"Awards: {res.Awards} \n Genre: {res.Genre} \n");
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Enter your preferred genre: ");
                                            string genre = Console.ReadLine();
                                            var res = un.Filmmakers.GetFilmmakerByGenre(genre);
                                            Console.WriteLine("Firstname\tLastname\tAwards\t");
                                            foreach (var el in res){
                                                
                                                Console.WriteLine($"{el.Firstname}\t{el.Lastname}\t{el.Awards}\t");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Enter his/her preferred award:");
                                            string award = Console.ReadLine();
                                            var res = un.Filmmakers.GetFilmmakerbyAward(award);
                                            Console.WriteLine("Firstname\tLastname\tGenre");
                                            foreach (var el in res)
                                            {
                                                Console.WriteLine($"{el.Firstname}\t{el.Lastname}\t{el.Genre}");
                                            }
                                            break;

                                        }
                                    default: Console.WriteLine("You have entered wrong number!"); break;
                                }
                                break;
                            }

                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("1 - Get all films directed by filmmaker.");
                                Console.WriteLine("2 - Get information about film.");
                                Console.WriteLine("3 - Get list of films by genre.");
                                Console.WriteLine("4 - Get best films rating.");
                                Console.WriteLine("5 - Get list of films by release date.");
                                int t = Int32.Parse(Console.ReadLine());

                                switch (t)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Enter his/her full name");
                                            Console.WriteLine("First name: ");
                                            string firstname = Console.ReadLine();
                                            Console.WriteLine("Last name: ");
                                            string lastname = Console.ReadLine();
                                            var res = un.Films.GetAllFilmsByFilmmaker(firstname,lastname);
                                            Console.WriteLine("Film name\t Genre\tImdb score");
                                            foreach (var el in res)
                                            {
                                                Console.WriteLine($"{el.Filmname}\t{el.Genre}\t{el.ImdbScore}");
                                            }
                                            break;
                                        }

                                    case 2:
                                        {
                                            Console.WriteLine("Enter film name: ");
                                            string filmname = Console.ReadLine();
                                            var res = un.Films.GetInfoAboutFilm(filmname);
                                            Console.WriteLine($"Film name: {res.Filmname} \n Genre: {res.Genre} \n Release date:" +
                                                              $"{res.Releasedate} \n Budget: {res.Budget} \n Imdb Score: {res.ImdbScore}\n");
                                            break;
                                        }

                                    case 3:
                                        {
                                            Console.WriteLine("Enter preferred genre: ");
                                            string genre = Console.ReadLine();
                                            var res = un.Films.GetAllFilmsByGenre(genre);
                                            Console.WriteLine("Film name\t Genre\tImdb score");
                                            foreach (var el in res)
                                            {
                                                Console.WriteLine($"{el.Filmname}\t{el.Genre}\t{el.ImdbScore}");
                                            }
                                            break;
                                        }

                                    case 4:
                                        {
                                            var res = un.Films.GetSortedByImdb();
                                            Console.WriteLine("Film name\t Genre\tImdb score");
                                            foreach (var el in res)
                                            {
                                                Console.WriteLine($"{el.Filmname}\t{el.Genre}\t{el.ImdbScore}");
                                            }
                                            break;

                                        }

                                    case 5:
                                        {
                                            string pattern = "MM-dd-yyyy";
                                            Console.WriteLine($"Date input pattern: {pattern}");
                                            Console.WriteLine();
                                            string release = Console.ReadLine();
                                            DateTime parsedDate = DateTime.ParseExact(release, pattern, System.Globalization.CultureInfo.InvariantCulture);
                                           
                                            var res = un.Films.GetAllFilmsByReleaseDate(parsedDate.Date);
                                            Console.WriteLine("Film name\t Genre\tImdb score");
                                            foreach (var el in res)
                                            {
                                                Console.WriteLine($"{el.Filmname}\t{el.Genre}\t{el.ImdbScore}");
                                            }
                                            break;
                                        }

                                    default: Console.WriteLine("You have entered wrong number!"); break;


                                }
                                break;
                            }

                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine("1 - Add film to your Favourites");
                                Console.WriteLine("2 - Remove film from your Favourites");
                                int t = Int32.Parse(Console.ReadLine());

                                switch (t)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Enter film name: ");
                                            string filmname = Console.ReadLine();
                                            un.FavouriteFilms.AddToFavFilms(filmname);
                                            Console.WriteLine("New film added successfully");
                                            break;

                                        }

                                    case 2:
                                        {
                                            Console.WriteLine("Enter film name: ");
                                            string filmname = Console.ReadLine();
                                            un.FavouriteFilms.RemoveFromFavFilms(filmname);
                                            Console.WriteLine("Film removed successfully");
                                            break;
                                        }
                                    default: Console.WriteLine("You have entered wrong number."); break;
                                }
                                break;
                            }

                        default: Console.WriteLine("You have entered wrong number"); break;
                    }

                    Console.WriteLine("If you want to exit press 1, to continue - 0");
                    back = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    un.Complete();
                }
            } while (back != 1);
        }
    }
}
