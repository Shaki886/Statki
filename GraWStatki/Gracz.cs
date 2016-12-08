using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatki
{
    class Gracz
    {
        public char[,] planszaCzlowieka = new char[10, 10];
        public char[,] planszaCPU = new char[10, 10];
        public int Trafione = 0;
        public int x = 0;
        public int y = 0;

        public int IloscTrafien()
        {
            return Trafione;
        }



    }
    class Osoba : Gracz
    {
        public char[,] AktualnaPlansza()
        {
            return planszaCzlowieka;
        }
        public void Ruch()
        {
            Console.WriteLine("Podaj wspolrzedna X:");
            string napis = Console.ReadLine();
            int liczba;
            if (int.TryParse(napis, out liczba))
            {
                x = liczba;
            }
            else
            {
                Console.WriteLine("Podales zla wartosc");
            }

            Console.WriteLine("Podaj wspolrzedna Y");
            napis = Console.ReadLine();
            if (int.TryParse(napis, out liczba))
            {
                y = liczba;
            }
            else
            {
                Console.WriteLine("Podales zla wartosc");
            }

            try
            {
                if (planszaCPU[x, y].Equals('S'))
                {
                    planszaCPU[x, y] = 'Z';
                    Console.Clear();
                    Console.WriteLine("Zatopiony!\r\n");
                    Trafione += 1;
                }
                else
                {
                    planszaCPU[x, y] = 'P';
                    Console.Clear();
                    Console.WriteLine("Pudlo!\r\n");
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Podawaj liczby tylko od 0 do 9");
            }
        }
        private void Ustaw(int j, int w) //funkcja ustawienia statku
        {
            planszaCzlowieka[j, w] = 'S';
        }
        public void Ustawianie(int dlugosc)
        {
            string jak;
            int wspolrzedna_x, wspolrzedna_y;
            Console.WriteLine("pion/poziom dla statku dlugosci " + dlugosc);
            jak = Console.ReadLine();
            Console.WriteLine("Podaj wspolrzedne poczatku statku: x,y");
            wspolrzedna_x = Convert.ToInt32(Console.ReadLine());
            wspolrzedna_y = Convert.ToInt32(Console.ReadLine());
            if (jak == "pion" || jak == "Pion")
            {
                Ustaw(wspolrzedna_x, wspolrzedna_y);
                for (int i = 0; i < dlugosc; i++)
                {
                    Ustaw(wspolrzedna_x + i, wspolrzedna_y);
                }
            }
            if (jak == "poziom" || jak == "Poziom")
            {
                Ustaw(wspolrzedna_x, wspolrzedna_y);
                for (int i = 0; i < dlugosc; i++)
                {
                    Ustaw(wspolrzedna_x, wspolrzedna_y + i);
                }
            }
            else
            {
                Console.WriteLine("Podales bledne koordynacje");
            }

        }
    }
    class CPU:Gracz
    {
        private void Ustaw(int j, int w) //funkcja ustawienia statku
        {
            planszaCPU[j, w] = 'S';
        }
        public char[,] AktualnaPlansza()
        {
            return planszaCPU;
        }

        public void Losowanie_ustawienia(int dlugosc)
        {
            int wspolrzedneok = 0;
            do
            {
                Random r = new Random();

                int x_cpu = r.Next(0, 10);
                int y_cpu = r.Next(0, 10);
                int jak = r.Next(0, 2);
                int zderzenieok=0;
                try
                {
                    if (planszaCPU[x_cpu, y_cpu] != 'S' &&
                        planszaCPU[x_cpu + 1, y_cpu] != 'S' &&
                        planszaCPU[x_cpu, y_cpu - 1] != 'S' &&
                        planszaCPU[x_cpu + 1, y_cpu + 1] != 'S' &&
                        planszaCPU[x_cpu - 1, y_cpu - 1] != 'S')
                    {
                        if (jak == 0)
                        {
                        for (int i = 0; i < dlugosc; i++)
                        {
                            if(planszaCPU[x_cpu+i,y_cpu] != 'S')
                                {
                                    zderzenieok +=1
                                }   
                        }
                    }
                
                
                { 

                {
                    Ustaw(x_cpu, y_cpu);
                        for (int i = 0; i < dlugosc; i++) //ustawienie kolejnych pól
                        {
                            Ustaw(x_cpu + i, y_cpu);
                        }
                    wspolrzedneok = 1;
                }
                if (planszaCPU[x_cpu, y_cpu] != 'S' && jak == 1 && y_cpu + dlugosc < 10)
                {
                    Ustaw(x_cpu, y_cpu);
                        for (int i = 0; i < dlugosc; i++)
                        {
                            Ustaw(x_cpu, y_cpu + i);
                        }
                wspolrzedneok = 1;
                }
            } while (wspolrzedneok != 1);
        }
    }
}
