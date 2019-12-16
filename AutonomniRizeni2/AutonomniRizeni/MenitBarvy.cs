using System;
using System.Collections.Generic;
using System.Text;

namespace AutonomniRizeni
{
    class MenitBarvy
    {
        public event GetSomeArrowHandler ZmenKlavesu;
        public delegate void GetSomeArrowHandler();

        public void GetKlavesa(RidiciCentrum RC, Pocasi pocasi)
        {
            RC.ZjistiPocasi(pocasi);
            pocasi.GetPocasi();
        }
    }
}
