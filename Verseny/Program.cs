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
        public static List<Versenyzo> versenyzok = new List<Versenyzo>();
        public static List<Versenyzo> idoszakElsök = new List<Versenyzo>();
        static void Main(string[] args)
        {
            string[] teljes = File.ReadAllLines("balkezesek.csv");

            int versenyzokDb = teljes.Count() - 1;
            Console.WriteLine($"Feladat 1: {versenyzokDb} db versenyzőről van adatunk.");


            
            versenyzokDb = versenyzokDb - 1;
            for (int i = 1; i < versenyzokDb; i++)
            {
                versenyzok.Add(new Versenyzo(teljes[i]));
            }
            
            Console.WriteLine("\nFeladat 2:");
            PalyaraLeptekEloszorEvben("1980.01.01", "1981.01.01");

            Console.WriteLine("\nFeladat 3 (ehhez adj meg egy nevet kérlek aki játszott a megadott időszakban):");
            string nev = Console.ReadLine();
            NevVizsgalat(nev);

            Console.WriteLine("\nFeladat 4 (Listázza a megadott időszakban az első alkalommal pályáralépett versenyzőket):");
            PalyaraLeptekEloszorIdoszakban();

            Console.WriteLine("\nFeladat 5 Legkorábbi pályáralépés ideje:");
            LegkorabbiPalyaralepes();

            Console.ReadLine();

        }


        public static DateTime LegkorabbiPalyaralepes() 
        {
            DateTime legkorabbi = DateTime.MaxValue;
            foreach (var item in versenyzok)
            {
                if (item.elso < legkorabbi )
                {
                    legkorabbi = item.elso;
                }
            }
            return legkorabbi;
        }
        public static void PalyaraLeptekEloszorEvben(string idöszakEleje, string idöszakvege) 
        {
            Console.WriteLine($"Első alkalommal volt pályán:");
            DateTime idöszakElejedatum = DateTime.Parse(idöszakEleje);
            DateTime idöszakvegedatum = DateTime.Parse(idöszakvege);
            foreach (var item in versenyzok)
            {
                if (item.elso > idöszakElejedatum && idöszakvegedatum > item.elso)
                {
                    idoszakElsök.Add(item);
                    Console.WriteLine(item.nev);
                }
            }
        }

        public static void NevVizsgalat(string nev) 
        {
            bool nemTalalt = true;
            foreach (var item in idoszakElsök)
            {
                if (item.nev == nev)
                {
                    double magassag = Math.Round(item.magassag * 2.57, 1);
                    Console.WriteLine(magassag);
                    nemTalalt = false;
                }
               
            }
            if (nemTalalt)
            {
                Console.WriteLine("Hibás adat");
            }
        }

        public static void PalyaraLeptekEloszorIdoszakban()
        {
            DateTime idöszakElejedatum;
            DateTime idöszakVegedatum;
            Console.WriteLine("Add meg listázandó versenyzők első pályára lépésének kezdődátumát");
            string idöszakEleje = Console.ReadLine();
            while (!DateTime.TryParse(idöszakEleje, out idöszakElejedatum))
            {
                Console.WriteLine("Hibás formátumban adtad meg a dátumot. próbáld újra");
                idöszakEleje = Console.ReadLine();
            }
            
            Console.WriteLine("Add meg listázandó versenyzők első pályára lépésének kezdődátumát");
            string idöszakVege = Console.ReadLine();
            while (!DateTime.TryParse(idöszakVege, out idöszakVegedatum) && idöszakVegedatum < idöszakElejedatum)
            {
                Console.WriteLine("Hibás formátumban adtad meg a dátumot vagy a vége dátum. próbáld újra");
                idöszakVege = Console.ReadLine();
            }
            
            
            Console.WriteLine($"Első alkalommal volt pályán az időszakban:");
            foreach (var item in versenyzok)
            {
                if (item.elso > idöszakElejedatum && idöszakVegedatum > item.elso)
                {
                    Console.WriteLine($"{item.ToString()}\n");
                }
            }
        }
    }
}
