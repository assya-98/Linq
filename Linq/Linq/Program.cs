using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        public class Personne
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            #region Avec LISTE
            var MaListe = new List<string> { "peche", "pomme", "poire", "orange", "banane", "ananas", "raisin" };

            #region len >5;

            // Mode Requete (1)

            /* var ResReq = from n in MaListe
                          where n.Length > 5
                          select n;

             Console.WriteLine();*/

            //Mode Methode (Requete 1)

            var Res = MaListe
                      .Where(n => n.Length > 5)
                      .ToList();


            for (int i = 0; i < Res.Count(); i++)
            {
                Console.WriteLine(Res[i]);
            }

            //Mode Requete (2)

            /*var ResReq2 = from n in MaListe
                          where n[0] == 'p'
                          select n;

            Console.WriteLine();*/

            // Mode Methode (Requete 2)

            var Res2 = MaListe
                       .Where(n => n[0] == 'p')
                       .ToList();

            //Autre façon de faire:

            /*for (int i = 0; i < Res2.Count(); i++)
            {
                Console.WriteLine(Res2[i]);
            }*/

            Console.WriteLine("*********");


            foreach (var fruit in Res2)
            {
                Console.WriteLine(fruit);

                
            }
            #endregion
            #endregion

            #region Avec des objets

            var Personnes = new List<Personne>
            {
                new Personne {Nom = "Durand", Prenom = "Jean", Age = 50},
                new Personne {Nom = "Dupond", Prenom = "Charles", Age = 25},
                new Personne {Nom = "Terrieur", Prenom = "Alain", Age = 34},
                new Personne {Nom = "Terrieur", Prenom = "Alex", Age = 16},
                new Personne {Nom = "Delachance", Prenom = "Jay", Age = 15},
            };

            var OrderByAge = Personnes.OrderBy(p => p.Age);

            var OrderByNom = Personnes.Where(p => p.Nom == "Terrieur")
                .OrderByDescending(p => p.Age);

            foreach (var Pers in OrderByNom)
            {
                Console.WriteLine($"{Pers.Nom}, {Pers.Prenom}, {Pers.Age}");

            }

            Console.WriteLine("*********");

            var Select3 = Personnes.First().Age;
            Console.WriteLine($"\n\n{Select3}");

            var Select4 = Personnes.First();
            Console.WriteLine($"\n\n{Select4.Nom}");

            #endregion


            #region Recherhe Mot

            // Recherche Mots dans un texte
            string text = @"Historically, the world of data and the world of objects" +
          @" have not been well integrated. Programmers work in C# or Visual Basic" +
          @" and also in SQL or XQuery. On the one side are concepts such as classes," +
          @" objects, fields, inheritance, and .NET APIs. On the other side" +
          @" are tables, columns, rows, nodes, and separate languages for dealing with" +
          @" them. Data types often require translation between the two worlds; there are" +
          @" different standard functions. Because the object world has no notion of query, a" +
          @" query can only be represented as a string without compile-time type checking or" +
          @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
          @" objects in memory is often tedious and error-prone.";

            string search = "data";

            string[] motsTab = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            #region AVEC REQ
            var searchQuery = from word in motsTab
                              where word.ToLower() == search
                              select word;

            Console.WriteLine($"Nombre d'occurences du mot '{search}' : {searchQuery.Count()}");
            #endregion

            #region AVEC MET
            var searchMet = motsTab.Where(word => word.ToLower() == search);
            Console.WriteLine($"Nombre d'occurences du mot '{search}' : {searchMet.Count()}");
            #endregion

            #endregion

        }
    }
}
