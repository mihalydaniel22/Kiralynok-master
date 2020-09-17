﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralynok
{
    class Tabla
    {
        private char[,] T = new char[8, 8];
        private char UresCella;

        public Tabla(char ch)
        {
            T = new char[8, 8];
            UresCella = ch;
            for (int i = 0; i < 8 ; i++)
            {
                for (int j = 0; j < 8 ; j++)
                {
                    T[i, j] = UresCella;
                }
            }

        }

        public void Elhelyez(int N)
        {
            //random osztaly értékkészklet [0, 7]
            //véletlen sor és oszlop kell
            //elhelyezzük a  "K"-t csak akkor HA!! üres --> "#"
            Random vel = new Random();
            for (int i = 0; i < N; i++)
            {
                bool igaz = true;
                while (igaz)
                {
                    int sor = vel.Next(0, 8);
                    int oszlop = vel.Next(0, 8);
                    if (T[sor, oszlop] == '#')
                    {
                        T[sor, oszlop] = 'K';
                        igaz = false;
                    }
                }
            }
        }
        public void Fajlbair()
        {

        }
        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{T[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public bool UresOszlop(int oszlop)
        {
            bool uresOszlop = true;
            for (int sor = 0; sor < T.GetLength(0); sor++)
            {
                if (T[sor,oszlop]=='K')
                {
                    uresOszlop = false;
                }
            }
            return uresOszlop;
        }
        public int UresOszlopokSzama()
        {
            int db = 0;
            for (int i = 0; i < T.GetLength(0); i++)
            {
                if (UresOszlop(i))
                {
                    db++;
                }
            }
            return db;


        }
        public bool UresSor(int sor)
        {
            return true;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");
            Tabla t = new Tabla('#');
            Console.WriteLine("Üres tábla :");
            t.Megjelenit();
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();
            Console.WriteLine("Üres oszlopok száma: " + t.UresOszlopokSzama());
            Console.ReadKey();
        }
    }
}
