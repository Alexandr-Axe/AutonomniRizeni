using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutonomniRizeni
{
    public class Pocasi
    {
        //Prší 30-50
        //Mrholí 5-10
        //Mlha 10-30
        //Slunečno 50-100
        //Sněží 0-5
        public event PocasiHandler DruhPocasi;
        public delegate void PocasiHandler(TrasaStav Vygenerovano);
        public event TrasaHandler DruhCesty;
        public delegate void TrasaHandler(TrasaDruh Vygenerovano);
        public void GetPocasi()
        {
            while (true)
            {
                Random NC = new Random();
                int Vygenerovano = NC.Next(0, 101);
                Thread.Sleep(500);
                if (Vygenerovano >= 50) DruhPocasi(TrasaStav.Slunecno);
                else if (Vygenerovano >= 30 && Vygenerovano < 50) DruhPocasi(TrasaStav.Prsi);
                else if (Vygenerovano >= 10 && Vygenerovano < 30) DruhPocasi(TrasaStav.Mlha);
                else if (Vygenerovano >= 5 && Vygenerovano < 10) DruhPocasi(TrasaStav.Mrholi);
                else if (Vygenerovano >= 0 && Vygenerovano < 5) DruhPocasi(TrasaStav.Snih);
                Random RC = new Random();
                int Vygenerovan = RC.Next(0, 101);
                if (Vygenerovan >= 50) DruhCesty(TrasaDruh.Common);
                else if (Vygenerovan >= 25 && Vygenerovan < 50) DruhCesty(TrasaDruh.Most);
                else DruhCesty(TrasaDruh.Tunel);
            }
        }



       
        //public void GetTrasa()
        //{
        //    while (true)
        //    {
        //        Random RC = new Random();
        //        int Vygenerovano = RC.Next(0, 101);
        //        Thread.Sleep(1000);
        //        if (Vygenerovano >= 50) DruhCesty(TrasaDruh.Common);
        //        else if (Vygenerovano >= 25 && Vygenerovano < 50) DruhCesty(TrasaDruh.Most);
        //        else DruhCesty(TrasaDruh.Tunel);
        //    }
        //}
    }
}
