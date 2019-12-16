using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutonomniRizeni
{
    public class RidiciCentrum : AutonomniAuto
    {
        public TrasaStav STAVAJICIPOCASI;
        public TrasaDruh STAVAJICICESTA;
        public void ZjistiTrasu()
        {
            if (trasaDruh == TrasaDruh.Tunel)
            {
                Rychlost += Rychlost/2;
                Sviti = true;
            }
            else if (trasaDruh == TrasaDruh.Most)
            {
                Rychlost -= Rychlost / 2;
                Sviti = false;
            }
            else
            {
                Rychlost = Rychlost;
                Sviti = false;
            }
        }
        public void ZjistiPocasi(Pocasi P)
        {
            P.DruhPocasi += Delej;
            P.DruhCesty += DelejCestu;
        }
        public void Delej(TrasaStav Vygenerovano)
        {
            STAVAJICIPOCASI = Vygenerovano;
        }
        public void ZjistiCestu(Pocasi DRUHTRASY)
        {
            DRUHTRASY.DruhCesty += DelejCestu;
        }
        public void DelejCestu(TrasaDruh Vygenerovano)
        {
            string TypSilnice = "";
            string TypPocasi = "";
            switch (Vygenerovano)
            {
                case TrasaDruh.Tunel:
                    TypSilnice = "v tunelu";
                    break;
                case TrasaDruh.Most:
                    TypSilnice = "po mostě";
                    break;
                case TrasaDruh.Common:
                    TypSilnice = "po obyčejné silnici";
                    break;
            }
            switch (STAVAJICIPOCASI)
            {
                case TrasaStav.Prsi:
                    TypPocasi = "prší";
                    break;
                case TrasaStav.Mrholi:
                    TypPocasi = "mrholí";
                    break;
                case TrasaStav.Mlha:
                    TypPocasi = "je mlha";
                    break;
                case TrasaStav.Snih:
                    TypPocasi = "sněží";
                    break;
                case TrasaStav.Slunecno:
                    TypPocasi = "svítí slunce";
                    break;
            }
            if (Vygenerovano == TrasaDruh.Tunel)
            {
                Rychlost += Rychlost / 2;
                Sviti = true;
                Console.WriteLine($"Vozidlo jede rychlostí {Rychlost} km * h^(-1), jede {TypSilnice}, {TypPocasi} a světla mu {(Sviti == true ? "svítí" : "nesvítí")}.");
                Rychlost = 50;
                STAVAJICICESTA = Vygenerovano;
            }
            else if (Vygenerovano == TrasaDruh.Most)
            {
                if (STAVAJICIPOCASI == TrasaStav.Slunecno)
                {
                    Rychlost -= Rychlost / 2;
                    Sviti = false;
                    Console.WriteLine($"Vozidlo jede rychlostí {Rychlost} km * h^(-1), jede {TypSilnice}, {TypPocasi} a světla mu {(Sviti == true ? "svítí" : "nesvítí")}.");
                    Rychlost = 50;
                    STAVAJICICESTA = Vygenerovano;
                }
                else if (STAVAJICIPOCASI == (TrasaStav.Mlha | TrasaStav.Mrholi | TrasaStav.Prsi))
                {
                    Rychlost -= Rychlost / 3;
                    Sviti = true;
                    Console.WriteLine($"Vozidlo jede rychlostí {Rychlost} km * h^(-1), jede {TypSilnice}, {TypPocasi} a světla mu {(Sviti == true ? "svítí" : "nesvítí")}.");
                    Rychlost = 50;
                    STAVAJICICESTA = Vygenerovano;
                }
                else
                {
                    Rychlost -= Rychlost / 4;
                    Sviti = true;
                    Console.WriteLine($"Vozidlo jede rychlostí {Rychlost} km * h^(-1), jede {TypSilnice}, {TypPocasi} a světla mu {(Sviti == true ? "svítí" : "nesvítí")}.");
                    Rychlost = 50;
                    STAVAJICICESTA = Vygenerovano;
                }
            }
            else if (Vygenerovano == TrasaDruh.Common)
            {
                if (STAVAJICIPOCASI == TrasaStav.Slunecno)
                {
                    Sviti = false;
                    Console.WriteLine($"Vozidlo jede rychlostí {Rychlost} km * h^(-1), jede {TypSilnice}, {TypPocasi} a světla mu {(Sviti == true ? "svítí" : "nesvítí")}.");
                    Rychlost = 50;
                    STAVAJICICESTA = Vygenerovano;
                }
                else if (STAVAJICIPOCASI == (TrasaStav.Mlha | TrasaStav.Mrholi | TrasaStav.Prsi))
                {
                    Rychlost -= Rychlost / 2;
                    Sviti = true;
                    Console.WriteLine($"Vozidlo jede rychlostí {Rychlost} km * h^(-1), jede {TypSilnice}, {TypPocasi} a světla mu {(Sviti == true ? "svítí" : "nesvítí")}.");
                    Rychlost = 50;
                    STAVAJICICESTA = Vygenerovano;
                }
                else
                {
                    Rychlost -= Rychlost / 3;
                    Sviti = true;
                    Console.WriteLine($"Vozidlo jede rychlostí {Rychlost} km * h^(-1), jede {TypSilnice}, {TypPocasi} a světla mu {(Sviti == true ? "svítí" : "nesvítí")}.");
                    Rychlost = 50;
                    STAVAJICICESTA = Vygenerovano;
                }
            }
            File.WriteAllText(@"Z:\svarta.txt", $"{File.ReadAllText(@"Z:\svarta.txt")}\n{STAVAJICICESTA.ToString()}");
        }
        public RidiciCentrum(AutonomniAuto elon) : base (elon.Rychlost, elon.DelkaTrasy, elon.trasaStav, elon.trasaDruh, elon.BarvaVozidla)
        {
            Console.ForegroundColor = BarvaVozidla;
        }
        public RidiciCentrum(AutonomniAuto[] elon, int PORADIVPOLI) : base(elon[PORADIVPOLI - 1].Rychlost, elon[PORADIVPOLI - 1].DelkaTrasy, elon[PORADIVPOLI - 1].trasaStav, elon[PORADIVPOLI - 1].trasaDruh, elon[PORADIVPOLI - 1].BarvaVozidla)
        {
            Console.ForegroundColor = BarvaVozidla;
        }
    }
}
