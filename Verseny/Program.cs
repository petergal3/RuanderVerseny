using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verseny
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] teljes = File.ReadAllLines("balkezesek.csv");

            int versenyzokDb = teljes.Count() - 1;
            Console.WriteLine($"Feladat 1: {versenyzokDb} db versenyzőről van adatunk.");

            Console.ReadLine();

        }
    }
}
