using System;
using System.Collections.Generic;
using PudelkoLibrary;
using P = PudelkoLibrary.Pudelko;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            P p = new P(10.1, 20.2, 15.3);
            Console.WriteLine("Wymiary pudełka: " + p.A  + " x " + p.B + " x " + p.C);

            Console.ReadKey();
        }
    }
}
