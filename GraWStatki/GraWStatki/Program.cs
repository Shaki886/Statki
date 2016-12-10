using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatki
{
    class Program
    {
        static void Main(string[] args)
        {
            Wyswietlanie polegry = new Wyswietlanie();
            Osoba czlowiek = new Osoba();
            CPU cpu = new CPU();
            Statki pionki = new Statki();

            for(int i=1; i<6; i+=2)
            {
                polegry.WyswietlPlansze1(czlowiek.PlanszaCzlowieka());
                czlowiek.Ustawianie(i);
                cpu.UstawCPU(i);
                Console.Clear();
            }

            //Console.WriteLine("Statki rozstawione, szykuj sie na bitwe!");
            //Console.WriteLine("\n\nWcisnij enteraby kontynuowac...");
            //Console.ReadLine();
            //Console.Clear();


            while (czlowiek.IloscTrafien() < 9 || cpu.IloscTrafien()<9)
            {
                polegry.WyswietlPlansze1(czlowiek.PlanszaCzlowieka());
                polegry.WyswietlPlansze2(cpu.PlanszaCPU());
                //cpu.test();
                //polegry.PlanszaTest(cpu.test_tab());
                czlowiek.Ruch();
                Console.ReadLine();
            }
        }
    }
}
