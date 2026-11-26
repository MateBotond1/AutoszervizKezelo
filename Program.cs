using AutoszervizKezelo;
List<Munkalap> Adatok=new List<Munkalap>();
foreach(string sor in File.ReadAllLines("munkalapok.txt").Skip(1))
{
    Adatok.Add(new Munkalap(sor));
}
