using System;
using System.Collections.Generic;
using System.Text;

namespace AutonomniRizeni
{
    public class RidiciCentrum : AutonomniAuto
    {
        public event DruhTrasy Trasa;
        public delegate void DruhTrasy(AutonomniAuto a);

        public void ZjistiTrasu()
        {
            if (trasaDruh == TrasaDruh.Tunel)
            {
                Rychlost += Rychlost/2;
                Sviti = true;
            }
            else if (trasaDruh == TrasaDruh.Most)
            {
                Rychlost += Rychlost / 2;
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
            Console.WriteLine(Vygenerovano);
        }
        public void ZjistiCestu(Pocasi DRUHTRASY)
        {
            DRUHTRASY.DruhCesty += DelejCestu;
        }
        public void DelejCestu(TrasaDruh Vygenerovano)
        {
            Console.WriteLine(Vygenerovano);
        }
        public RidiciCentrum(AutonomniAuto elon) : base (elon.Rychlost, elon.DelkaTrasy, elon.trasaStav, elon.trasaDruh)
        {
        }
    }
}
