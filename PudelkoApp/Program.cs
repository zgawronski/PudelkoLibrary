using PudelkoLibrary;
using System;
using System.Collections.Generic;
using P = PudelkoLibrary.Pudelko;
using System.Runtime;


namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<P> pudelka = new List<P>();
            pudelka.Add(new P(1.5, 2.555, 0.7, UnitOfMeasure.meter));
            pudelka.Add(new P(666.99, 123.45, 678.910, UnitOfMeasure.centimeter));
            pudelka.Add(new P(369, 669, null, UnitOfMeasure.milimeter));
            pudelka.Add(new P(null, null, 270, UnitOfMeasure.milimeter));
            pudelka.Add(new P(0.33, null, 0.123456));
            pudelka.Add(new Pudelko(123, 456, 789, UnitOfMeasure.milimeter).Kompresuj());

            pudelka.Sort();

            pudelka.ForEach((pudelko) => { Console.WriteLine(pudelko.ToString()); });


            Console.ReadKey();
        }
    }
    public static class PudelkoExtra
    {
        public static P Kompresuj(this P pA)
        {
            double E = Convert.ToDouble(pA.Objetosc);
            double D = Math.Pow(E, (1 / 3));
            return new P(D, D, D);
        }
        //double D = Math.Cbrt(Convert.ToDouble(pA.Objetosc));
     
    }
    

}
