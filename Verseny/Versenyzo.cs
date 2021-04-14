using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verseny
{
    class Versenyzo
    {
        public string nev { get; set; }
        public DateTime elso { get; set; }
        public DateTime utolso { get; set; }
        public int suly { get; set; }
        public int magassag { get; set; }

        public Versenyzo(string adatok) 
        {
            string[] adatokDarabolt = adatok.Split(';');
            this.nev = adatokDarabolt[0];
            this.elso = Convert.ToDateTime(adatokDarabolt[1]);
            this.utolso = Convert.ToDateTime(adatokDarabolt[2]);
            this.suly = Convert.ToInt32(adatokDarabolt[3]);
            this.magassag = Convert.ToInt32(adatokDarabolt[4]);
        }

        public override string ToString()
        {
            return $"Név: {nev}, első: {elso}, utolsó: {utolso}, súly: {suly}, magasság: {magassag}";
        }

    }
}
