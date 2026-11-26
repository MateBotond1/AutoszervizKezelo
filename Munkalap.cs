using System;
using System.Collections.Generic;
using System.Text;

namespace AutoszervizKezelo
{
    public class Munkalap
    {
        public string UgyfelNev {  get; set; }
        public string Kategoria { get; set; }
        public int Munkaora { get; set; }
        public int AlkatreszAr { get; set; }
        public bool Garancialis {  get; set; }

        public Munkalap(string sor)
        {
            string[] darabol = sor.Split(";");
            UgyfelNev = darabol[0];
            Kategoria = darabol[1];
            Munkaora = int.Parse(darabol[2]);
            AlkatreszAr = int.Parse(darabol[3]);
            Garancialis = bool.Parse(darabol[4]);
        }
        public int FizetendoOsszeg()
        {
            int kategoriaoradij = 0;
          
            if (Kategoria == "MOTOR") { kategoriaoradij = 15000; }
            else { kategoriaoradij = 12000; }
            if (Garancialis == true) { return 0; }
            else { return Munkaora * kategoriaoradij + AlkatreszAr; }
            
        }
        public override string ToString()
        {
            string allapot = "";
            if (Garancialis = true) { allapot = "Garancialis"; }
            else { allapot = "Fizetős"; }
            return $"{UgyfelNev} ({Kategoria}): {Munkaora} óra, alkatrész: {AlkatreszAr} Ft [{allapot}] - Fizetendő: {FizetendoOsszeg()} Ft";
        }
    }
    
}
