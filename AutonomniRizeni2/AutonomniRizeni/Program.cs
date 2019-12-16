using System;
using System.Threading;
using System.IO;

namespace AutonomniRizeni
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("svarta.txt")) File.Create("svarta.txt");
            Pocasi CyberPocasi = new Pocasi();
            AutonomniAuto[] Vicero = new AutonomniAuto[] {
                new AutonomniAuto(110, 90, TrasaStav.Snih, TrasaDruh.Tunel, ConsoleColor.Red),
                new AutonomniAuto(50, 90, TrasaStav.Mlha, TrasaDruh.Common, ConsoleColor.Yellow),
                new AutonomniAuto(50, 90, TrasaStav.Slunecno, TrasaDruh.Common, ConsoleColor.Magenta) };
            //RidiciCentrum[] Kuba = new RidiciCentrum[Vicero.Length];
            //Kuba[0] = new RidiciCentrum(Vicero[0]);
            //Kuba[0].ZjistiPocasi(CyberPocasi);
            //CyberPocasi.GetPocasi();

            int ID = 0;
            ConsoleKeyInfo pocasi = Console.ReadKey();

            if (pocasi.Key == ConsoleKey.UpArrow)
            {
                ID += 1;
                RidiciCentrum Kuba = new RidiciCentrum(Vicero, ID);
                Kuba.ZjistiPocasi(CyberPocasi);
                CyberPocasi.GetPocasi();
            }
        }
    }
}
