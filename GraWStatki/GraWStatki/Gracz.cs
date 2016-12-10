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
        public int[,] test_tab = new int[12, 12];
        public int Trafione = 0;
        public int x = 0;
        public int y = 0;

        public void Zerowanie_test_tab()
        {
            for (int i=0; i<13; i++)
            {
                for(int j=0; j<13; j++)
                {
                    test_tab[i, j] = 0;
                }
            }
        }

        public char[,] PlanszaCPU()
        {
            return planszaCPU;
        }
        public char[,] PlanszaCzlowieka()
        {
            return planszaCzlowieka;
        }
        public int[,] PlanszaTestowa()
        {
            return test_tab;
        }


        public int IloscTrafien()
        {
            return Trafione;
        }



    }
    class Osoba : Gracz
    {

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
                    planszaCPU[x, y] = 'X';
                    Console.Clear();
                    Console.WriteLine("Pudlo!\r\n");
                    Console.WriteLine(planszaCPU[x, y]);
                }

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Podawaj liczby tylko od 0 do 9");
            }
        }
        private void UstawPole(int x, int y) //funkcja ustawienia statku
        {
            planszaCzlowieka[x, y] = 'S';
        }
        public void Ustawianie(int dlugosc)
        {
            string kierunek;
            int wspolrzedna_x, wspolrzedna_y;
            Console.WriteLine("Ustawic pionowo/poziomo stateku o dlugosci: " + dlugosc);
            kierunek = Console.ReadLine();
            Console.WriteLine("Podaj wspolrzedne poczatku statku: x,y");
            wspolrzedna_x = Convert.ToInt32(Console.ReadLine());
            wspolrzedna_y = Convert.ToInt32(Console.ReadLine());
            if (kierunek == "pionowo" || kierunek == "Pionowo")
            {
                UstawPole(wspolrzedna_x, wspolrzedna_y);
                for (int i = 0; i < dlugosc; i++)
                {
                    UstawPole(wspolrzedna_x+i, wspolrzedna_y);
                }
            }
            if (kierunek == "poziomo" || kierunek == "Poziomo")
            {
                UstawPole(wspolrzedna_x, wspolrzedna_y);
                for (int i = 0; i < dlugosc; i++)
                {
                    UstawPole(wspolrzedna_x, wspolrzedna_y+i);
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
        public CPU()
        {

        }

        private void UstawStatekPionowo(int x, int y, int dlugosc) //funkcja ustawienia statku
        {
            for (int i=0; i < dlugosc; i++)
            {
                planszaCPU[x, y+i] = 'S';
            }

        }
        private void UstawStatekPoziomo(int x, int y, int dlugosc) //funkcja ustawienia statku
        {
            for (int j = 0; j < dlugosc; j++)
            {
                planszaCPU[x+j, y] = 'S';
            }
        }
        public void UstawCPU(int dlugosc)
        {
            int wyjdz = 0;
            int test_ok = 0;
            Random r = new Random();

            do
            {

                int x_cpu = r.Next(0, 8);
                int y_cpu = r.Next(0, 8);
                int kierunek = r.Next(0, 2);

                if (kierunek == 0)              //pionowo po y
                {
                    for (int i = 1; i <= dlugosc; i++)
                    {
                        try
                        {
                            if (test_tab[x_cpu+1, y_cpu + i] == 0 
                                && y_cpu + i < 8)
                            {
                                test_ok += 1;
                                //Console.WriteLine("test_ok= " + test_ok + " x= " + x_cpu + " y= " + y_cpu + " dla dlugosc= " + dlugosc + " test_tab= " + test_tab[x_cpu+1,y_cpu+1]);  test
                                if (test_ok == dlugosc)
                                {
                                    UstawStatekPionowo(x_cpu, y_cpu, dlugosc);
                                    mapa_miejsc(x_cpu + 1, y_cpu + 1, dlugosc, kierunek);
                                    test_ok = 0;
                                    wyjdz = 1;

                                }
                            }  //sprawdzamy czy jest wystarczajaco duzo miejsca, jesli tak to kladziemy tam statek i blokujemy pola
                            if(test_tab[x_cpu + 1, y_cpu + i] == 1)
                            { test_ok = 0; }
                        }
                        catch { }
                     }
                }

                if (kierunek == 1)              //poziomo po x
                {
                    for (int i = 1; i <= dlugosc; i++)
                    {
                        try
                        {
                            if (test_tab[x_cpu + i, y_cpu+1] == 0 && x_cpu + i < 8)
                            {
                                test_ok += 1;
                                Console.WriteLine("test_ok= " + test_ok + " x= " + x_cpu + " y= " + y_cpu + " dla dlugosc= " + dlugosc + " test_tab= " + test_tab[x_cpu, y_cpu] + " text_tab[x+i-1,y] " + test_tab[x_cpu + i, y_cpu]);
                                if (test_ok == dlugosc)
                                {
                                    UstawStatekPoziomo(x_cpu, y_cpu, dlugosc);
                                    mapa_miejsc(x_cpu + 1, y_cpu + 1, dlugosc, kierunek);
                                    test_ok = 0;
                                    wyjdz = 1;
                                }
                            }  //sprawdzamy czy jest wystarczajaco duzo miejsca, jesli tak to kladziemy tam statek
                            if (test_tab[x_cpu + i, y_cpu + 1] == 1)
                            {
                                test_ok = 0;
                            }
                        }
                        catch { }
                    }
                }
            } while (wyjdz != 1); //jesli tak to wychodzimy z petli




        }
        public void test()
        {
            Console.WriteLine("\nPole test");
            Console.WriteLine("X-> ¦ 0 1 2 3 4 5 6 7 8 9 ");
            Console.WriteLine("--------------------------\nY:");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("   " + (i-1).ToString() + "¦ ");
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(test_tab[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        public void mapa_miejsc(int x, int y, int dlugosc, int kierunek)
        {
            if (kierunek == 0)
            {
                for(int i=0; i<dlugosc; i++)
                {
                    test_tab[x      , y     +i]      = 1;
                    test_tab[x-1    , y     +i]      = 1;
                    test_tab[x+1    , y     +i]      = 1;
                    test_tab[x      , y-1   +i]      = 1;
                    test_tab[x      , y+1   +i]      = 1;
                }
            }

            if (kierunek == 1)
            {
                for (int i = 0; i < dlugosc; i++)
                {
                    test_tab[x+i , y] = 1;
                    test_tab[x-1+i , y] = 1;
                    test_tab[x+1+i , y] = 1;
                    test_tab[x+i , y - 1] = 1;
                    test_tab[x+i , y + 1] = 1;
                }
            }
        }

        }
    }

