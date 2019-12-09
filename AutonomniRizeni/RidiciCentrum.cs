using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine(Vygenerovano);
        }
        public void ZjistiCestu(Pocasi DRUHTRASY)
        {
            DRUHTRASY.DruhCesty += DelejCestu;
        }
        public void DelejCestu(TrasaDruh Vygenerovano)
        {
            if (Vygenerovano == TrasaDruh.Tunel)
            {
                Rychlost += Rychlost / 2;
                Sviti = true;
                Console.WriteLine("Rychlost je " + Rychlost + " na trase " + Vygenerovano + " a světla " + Sviti);
                Rychlost = 50;
                STAVAJICICESTA = Vygenerovano;
            }
            else if (Vygenerovano == TrasaDruh.Most)
            {
                Rychlost -= Rychlost / 2;
                Sviti = false;
                Console.WriteLine("Rychlost je " + Rychlost + " na trase " + Vygenerovano + " a světla " + Sviti);
                Rychlost = 50;
                STAVAJICICESTA = Vygenerovano;
            }
            else if (Vygenerovano == TrasaDruh.Common && STAVAJICIPOCASI == TrasaStav.Slunecno)
            {
                Sviti = false;
                Console.WriteLine("Rychlost je " + Rychlost + " na trase " + Vygenerovano + " a světla " + Sviti);
                Rychlost = 50;
                STAVAJICICESTA = Vygenerovano;
            }
            else if (Vygenerovano == TrasaDruh.Common)
            {
                Rychlost = Rychlost;
                Sviti = false;
                Console.WriteLine("Rychlost je " + Rychlost + " na trase " + Vygenerovano + " a světla " + Sviti);
                Rychlost = 50;
                STAVAJICICESTA = Vygenerovano;
            }
        }
        public RidiciCentrum(AutonomniAuto elon) : base (elon.Rychlost, elon.DelkaTrasy, elon.trasaStav, elon.trasaDruh)
        {
        }
    }
}
