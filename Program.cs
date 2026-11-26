using AutoszervizKezelo;

List<Munkalap> Adatok = new List<Munkalap>();
foreach (string sor in File.ReadAllLines("munkalapok.txt").Skip(1))
{
    Adatok.Add(new Munkalap(sor));
}

Console.WriteLine("Rögzített munkalapok:");
foreach (Munkalap aktualis in Adatok)
{
    Console.WriteLine(aktualis);
}

int osszes = Adatok.Sum(x => x.FizetendoOsszeg());
int legrovidebbjavitas = Adatok.Min(x => x.Munkaora);
int leghosszabbjavitas = Adatok.Max(x => x.Munkaora);
double atlagjavitas = Adatok.Average(x => x.Munkaora);
Munkalap legjobbugyfel = Adatok.MaxBy(x => x.FizetendoOsszeg())!;
int fizetosMunkalapok = Adatok.Count(x => x.Garancialis == false); 

Console.WriteLine("\nAlapvető statisztikák:");
Console.WriteLine($"Szerviz teljes bevétele: {osszes} Ft");
Console.WriteLine($"Legrövidebb javítás: {legrovidebbjavitas} óra, leghosszabb javítás: {leghosszabbjavitas} óra");
Console.WriteLine($"Átlagos munkaidő: {atlagjavitas:F1} óra");
Console.WriteLine($"Legtöbbet fizető ügyfél: {legjobbugyfel.UgyfelNev} ({legjobbugyfel.FizetendoOsszeg()} Ft)"); 
Console.WriteLine($"Fizetős munkalapok száma: {fizetosMunkalapok} db");

Console.WriteLine("\nMOTOR kategóriájú munkalapok:");
List<Munkalap> szurt = Adatok.Where(x => x.Kategoria == "MOTOR").ToList();
foreach (Munkalap valogatott in szurt)
{
    Console.WriteLine($"{valogatott.UgyfelNev} ({valogatott.Munkaora} óra)");
}

bool elerte = Adatok.Any(x => x.FizetendoOsszeg() > 150000);
bool mind = Adatok.All(x => x.AlkatreszAr >= 10000);

Console.WriteLine("\nDöntések:");
Console.WriteLine($"Volt 150 000 Ft feletti javítás: {(elerte ? "Igen" : "Nem")}");
Console.WriteLine($"Minden munkalapon legalább 10 000 Ft az alkatrészár: {(mind ? "Igen" : "Nem")}");

List<Munkalap> legjobbharom = Adatok.OrderByDescending(x => x.FizetendoOsszeg()).Take(3).ToList();

Console.WriteLine("\nTop 3 legmagasabb végösszegű munkalap:");
for (int i = 0; i < legjobbharom.Count; i++)
{
    Console.WriteLine($"{i + 1}. {legjobbharom[i].UgyfelNev} - {legjobbharom[i].FizetendoOsszeg()} Ft");
}