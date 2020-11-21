using PudelkoLibrary;
using System;
using P = PudelkoLibrary.Pudelko;



namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            P p = new P(7000.1, 8.2, 4.3, UnitOfMeasure.meter);

            Console.WriteLine(p.ToString());
            Console.WriteLine(p.ToString("m"));
            Console.WriteLine(p.ToString("cm"));
            Console.WriteLine(p.ToString("mm"));

            Console.WriteLine($"Objetosc: {p.Objetosc}");
            Console.WriteLine($"Pole: {p.Pole}");

            Console.ReadKey();
        }
    }
}
