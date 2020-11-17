using System;
using System.Globalization;


namespace PudelkoLibrary
{
    public interface IFormattable
    {
        string Unit(UnitOfMeasure unit);
    }
    
    
    public class Pudelko : IFormattable
    {

        public string Unit(UnitOfMeasure unit)
        {
            unit = UnitOfMeasure.meter;

            
        }

        public double A
        {
            get;
            set;
            
        }
        public double B
        {
            get;
            set;
        }
        public double C
        {
            get;
            set;
        }
        
        
        public Pudelko()
        {

        }
        public Pudelko(double a, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (unit == UnitOfMeasure.meter)
                A = 1;
            this.A = a;
            
           
        }
        public Pudelko(double a, double b)
        {
            this.A = a;
            this.B = b;
            
        }


        public Pudelko(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            
        }
        
        public Pudelko(double a, double b, double c, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            
            if (unit == UnitOfMeasure.meter)
                A = 1;
            if (unit == UnitOfMeasure.centimeter)
                A = (1 / 100);
            if (unit == UnitOfMeasure.milimeter)
                A = (1 / 1000);
            this.A = a;
            this.B = b;
            this.C = c;
            

            
            

            
            if (A > 10 || A < 0 || B > 10 || B < 0 || C > 10 || C < 0)
                throw new ArgumentOutOfRangeException("podaj prawidłowe wymiary");
           
        }
        //public static double Unit(UnitOfMeasure unit) 
        //{

        //    switch (unit)
        //    {
        //        case UnitOfMeasure.meter:
        //            return 1;
        //        case UnitOfMeasure.centimeter:
        //            return 0.01;
        //       case UnitOfMeasure.milimeter:
        //            return 0.001;
        //        default:
        //            return 1;
        //    }
        //}
        


    }
}
