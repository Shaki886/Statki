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
            Gracz nowy = new Gracz();
            Statki pionki = new Statki();

            for(int i=1; i<2; i+=2)
            {
                polegry.WyswietlPlansze1(nowy.PlanszaCzlowieka());
                nowy.Ustawianie(i);
                nowy.UstawCPU(i);
                Console.Clear();
            }

            //Console.WriteLine("Statki rozstawione, szykuj sie na bitwe!");
            //Console.WriteLine("\n\nWcisnij enteraby kontynuowac...");
            //Console.ReadLine();
            //Console.Clear();


            while (nowy.IloscTrafien() < 1 || nowy.IloscTrafien()<1)
            {
                polegry.WyswietlPlansze1(nowy.PlanszaCzlowieka());
                polegry.WyswietlPlansze2(nowy.PlanszaCPU());
                //cpu.test();
                //polegry.PlanszaTest(cpu.test_tab());
                nowy.RuchOsoby();
                Console.WriteLine(nowy.IloscTrafien());
                Console.ReadLine();
            }
        }
    }
}
