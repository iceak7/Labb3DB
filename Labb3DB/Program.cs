using Labb3DB.Models;
using System;
using System.Linq;

namespace Labb3DB
{
    class Program
    {
        static void Main(string[] args)
        {
            using SkolaDbContext context = new SkolaDbContext();

            bool continueLoop = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra?" +
               "\n1. Lista alla elever." +
               "\n2. Lista alla elever i en specifik klass." +
               "\n3. Lägga till ny personal." +
               "\n4. Avsluta programmet");

                string answer = Console.ReadLine();
                Console.Clear();


                switch (answer)
                {
                    case "1":

                        Console.WriteLine("Vad vill du sortera eleverna på?" +
                            "\n1. Förnamn." +
                            "\n2. Efternamn.");

                        string answer2 = Console.ReadLine();
                        Console.Clear();
                        if (answer2 == "1")
                        {
                            Console.WriteLine("Vill du sortera stigande eller fallande?" +
                                "\n1. Stigande." +
                                "\n2. Fallande.");

                            string answer3 = Console.ReadLine();

                            if (answer3 == "1")
                            {
                                var Elever = from Elev in context.Elever
                                             join klass in context.Klasser on Elev.KlassId equals klass.KlassId
                                             orderby Elev.Förnamn ascending
                                             select new { Förnamn = Elev.Förnamn, Efternamn = Elev.Efternamn, Klass = klass.KlassNamn, Personummer = Elev.Personnummer, Kön = Elev.Kön };

                                foreach (var i in Elever)
                                {
                                    Console.WriteLine($"Förnamn: {i.Förnamn} - Efternamn: {i.Efternamn} - Klass: {i.Klass} - Personnummer: {i.Personummer} - Kön: {i.Kön}");
                                }
                                Console.ReadKey();
                            }
                            else if (answer3 == "2")
                            {
                                var Elever = from Elev in context.Elever
                                             join klass in context.Klasser on Elev.KlassId equals klass.KlassId
                                             orderby Elev.Förnamn descending
                                             select new { Förnamn = Elev.Förnamn, Efternamn = Elev.Efternamn, Klass = klass.KlassNamn, Personummer = Elev.Personnummer, Kön = Elev.Kön };

                                foreach (var i in Elever)
                                {
                                    Console.WriteLine($"Förnamn: {i.Förnamn} - Efternamn: {i.Efternamn} - Klass: {i.Klass} - Personnummer: {i.Personummer} - Kön: {i.Kön}");
                                }
                                Console.ReadKey();
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (answer2 == "2")
                        {
                            Console.WriteLine("Vill du sortera stigande eller fallande?" +
                                "\n1. Stigande." +
                                "\n2. Fallande.");

                            string answer3 = Console.ReadLine();

                            if (answer3 == "1")
                            {
                                var Elever = from Elev in context.Elever
                                             join klass in context.Klasser on Elev.KlassId equals klass.KlassId
                                             orderby Elev.Efternamn ascending
                                             select new { Förnamn = Elev.Förnamn, Efternamn = Elev.Efternamn, Klass = klass.KlassNamn, Personummer = Elev.Personnummer, Kön = Elev.Kön };

                                foreach (var i in Elever)
                                {
                                    Console.WriteLine($"Förnamn: {i.Förnamn} - Efternamn: {i.Efternamn} - Klass: {i.Klass} - Personnummer: {i.Personummer} - Kön: {i.Kön}");
                                }
                                Console.ReadKey();
                            }
                            else if (answer3 == "2")
                            {
                                var Elever = from Elev in context.Elever
                                             join klass in context.Klasser on Elev.KlassId equals klass.KlassId
                                             orderby Elev.Efternamn descending
                                             select new { Förnamn = Elev.Förnamn, Efternamn = Elev.Efternamn, Klass = klass.KlassNamn, Personummer = Elev.Personnummer, Kön = Elev.Kön };

                                foreach (var i in Elever)
                                {
                                    Console.WriteLine($"Förnamn: {i.Förnamn} - Efternamn: {i.Efternamn} - Klass: {i.Klass} - Personnummer: {i.Personummer} - Kön: {i.Kön}");
                                }
                                Console.ReadKey();
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                        break;

                    case "2":
                        var Klasser = from Klass in context.Klasser
                                      select Klass;
                        foreach (var klass in Klasser)
                        {
                            Console.WriteLine(klass.KlassNamn);
                        }

                        Console.WriteLine("\nSkriv vilken klass du vill visa eleverna ifrån.");

                        string classAnswer = Console.ReadLine();

                        var elever = from elev in context.Elever
                                     where elev.Klass.KlassNamn == classAnswer
                                     select elev;

                        foreach (var i in elever)
                        {
                            Console.WriteLine($"Förnamn: {i.Förnamn} - Efternamn: {i.Efternamn} - Personnummer: {i.Personnummer} - Kön: {i.Kön}");
                        }
                        Console.ReadKey();

                        break;
                    case "3":
                        Personal NyPersonal = new Personal();

                        Console.Clear();
                        Console.WriteLine("\nVilket förnamn har den nyanställda?");
                        NyPersonal.Förnamn = Console.ReadLine();

                        Console.WriteLine("\nVilket efternamn har den nyanstälda?");
                        NyPersonal.Efternamn = Console.ReadLine();

                        Console.WriteLine("\nVilket befattning har den nyanställda?");
                        NyPersonal.Befattning = Console.ReadLine();

                        Console.WriteLine("\nVilket ID ska den nyanställda få?");
                        NyPersonal.PersonalId = int.Parse(Console.ReadLine());

                        context.Personal.Add(NyPersonal);
                        context.SaveChanges();

                        break;
                    case "4":
                        continueLoop = false;
                        break;
                    default:
                        break;
                }

            } while (continueLoop); 
        }
    }
}
