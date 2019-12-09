using System;
using System.Threading;
using System.IO;

namespace AutonomniRizeni
{
    class Program
    {
        static void Main(string[] args)
        {
            Random nc = new Random();
            Pocasi CyberPocasi = new Pocasi();
            AutonomniAuto CyberTruck = new AutonomniAuto(50, 90, TrasaStav.Slunecno, TrasaDruh.Common);
            RidiciCentrum RC = new RidiciCentrum(CyberTruck);
            RC.ZjistiPocasi(CyberPocasi);
            CyberPocasi.GetPocasi();
        }
    }
}
