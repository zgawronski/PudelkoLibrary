using PudelkoLibrary;
using System;
using P = PudelkoLibrary.Pudelko;



namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            P p1 = new P(7.1, 8.2, 4.3, UnitOfMeasure.meter);

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p1.ToString("m"));
            Console.WriteLine(p1.ToString("cm"));
            Console.WriteLine(p1.ToString("mm"));

            Console.WriteLine($"Objetosc: {p1.Objetosc}");
            Console.WriteLine($"Pole: {p1.Pole}");




            Console.ReadKey();
        }
    }
}
