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

            for(int i=1; i<8; i += 2)
            {
                //polegry.WyswietlPlansze1(czlowiek.AktualnaPlansza());
                //czlowiek.Ustawianie(i);
                cpu.Losowanie_ustawienia(i);
                Console.Clear();
            }

            Console.WriteLine("Statki rozstawione, szykuj sie na bitwe!");
            Console.WriteLine("\n\nWcisnij enteraby kontynuowac...");
            Console.ReadLine();
            Console.Clear();


            while (czlowiek.IloscTrafien() < 20 || cpu.IloscTrafien()<20)
            {
                polegry.WyswietlPlansze1(czlowiek.AktualnaPlansza());
                polegry.WyswietlPlansze2(cpu.AktualnaPlansza());
                czlowiek.Ruch();
                
            }
        }
    }
}
