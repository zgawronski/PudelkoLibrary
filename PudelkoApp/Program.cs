using PudelkoLibrary;
using System;



namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Pudelko p = new Pudelko(7.1, 8.2, 4.3, UnitOfMeasure.meter);

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
