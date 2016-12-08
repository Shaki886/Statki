using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatki
{
    class Wyswietlanie
    {
        public void WyswietlPlansze1(char[,] plansza)
        {

            Console.WriteLine("Pole gracza");
            Console.WriteLine("Y-> ¦ 0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("--------------------------\nX:");
            for (int i = 0; i <= 9; i++)
            {
                Console.Write("   " + (i).ToString() + "¦ ");
                for (int j = 0; j <= 9; j++)
                {
                    Console.Write(plansza[i,j] + " ");
                }
                Console.WriteLine();
            }

        }
        public void WyswietlPlansze2(char[,] plansza)
        {
            Console.WriteLine("Pole komputera");
            Console.WriteLine("Y-> ¦ 0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("--------------------------\nX:");
            for (int i = 0; i <= 9; i++)
            {
                Console.Write("   " + (i).ToString() + "¦ ");
                for (int j = 0; j <= 9; j++)
                {
                    Console.Write(plansza[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }
}
