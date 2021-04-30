using System;
using System.Collections.Generic;
using System.Text;

namespace EnVrac
{
    class ConsoleDeTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Création de la base de données...");
            clsBDDSingleton _bdd = clsBDDSingleton.Instance;
            Console.WriteLine("Base de données créée !");
        }
    }
}
