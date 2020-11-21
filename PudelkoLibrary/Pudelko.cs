using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace PudelkoLibrary
{
        public enum UnitOfMeasure
        {
            meter, centimeter, milimeter
        }

   
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {
        private double a, b, c;
       
        public double A
        {
            get
            {              
                return GetRoundedNumber(a);

            }
        }
        public double B
        {
            get
            {
                return GetRoundedNumber(b);
            }
        }

        public double C
        {
            get
            {
                 return GetRoundedNumber(c);
            }
        }

        public string Objetosc => $"{Math.Round((A * B * C), 9)} m3";

        public string Pole => $"{Math.Round(2 * A * B + 2 * A * C + 2 * B * C, 6)} m2";

       
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    case 2:
                        return c;
                    default:
                        throw new ArgumentOutOfRangeException("Błąd");

                }
               
            }
        }
        public Pudelko()
        {
            
            a = 0.1;
            b = 0.1;
            c = 0.1;
        }

        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {

            switch (unit)
            {
                case UnitOfMeasure.meter:
                    if (a is null)
                        a = 0.1;
                    if (b is null)
                        b = 0.1;
                    if (c is null)
                        c = 0.1;
                    break;
                case UnitOfMeasure.centimeter:
                    if (a is null)
                        a = 10;
                    if (b is null)
                        b = 10;
                    if (c is null)
                        c = 10;
                    a = a / 100;
                    b = b / 100;
                    c = c / 100;

                    break;
                case UnitOfMeasure.milimeter:
                    if (a is null)
                        a = 100;
                    if (b is null)
                        b = 100;
                    if (c is null)
                        c = 100;
                    a = a / 1000;
                    b = b / 1000;
                    c = c / 1000;
                    break;
                default:
                    break;
            }
            var tempA = Math.Truncate((double)a * 1000);
            var tempB = Math.Truncate((double)b * 1000);
            var tempC = Math.Truncate((double)c * 1000);

            //try
            //{
                if (tempA > 10000 || tempA <= 0 || tempB > 10000 || tempB <= 0 || tempC > 10000 || tempC <= 0)
                    throw new ArgumentOutOfRangeException("Podano błędne wymiary!");
            //}
            /* catch(Exception)
            {
                Console.WriteLine();
            }*/

            this.a = (double)a;
            this.b = (double)b;
            this.c = (double)c;
        }
        

        public override int GetHashCode()
        {
            return a.GetHashCode() + b.GetHashCode() + c.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return Equals((Pudelko)obj);
        }

        public bool Equals(Pudelko other)
        {
            if (other is null)
            {
                return false;
            }

            List<double> numbers = new List<double>()
            {
                A, B, C
            };
            if (numbers.Contains(other.A)) numbers.Remove(other.A);
            if (numbers.Contains(other.B)) numbers.Remove(other.B);
            if (numbers.Contains(other.C)) numbers.Remove(other.C);

            if (numbers.Count == 0) return true;

            return false;
        }

        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => !(p1 == p2);
        public static explicit operator double[](Pudelko p) => new double[] { p.A, p.B, p.C };
        public static implicit operator Pudelko(ValueTuple<int, int, int> v) => new Pudelko(v.Item1, v.Item2, v.Item3, UnitOfMeasure.milimeter);

        public static Pudelko operator +(Pudelko pudelko1, Pudelko pudelko2)
        {
            double[] doublePudelko1 = (double[])pudelko1, doublePudelko2 = (double[])pudelko2;

            Array.Sort(doublePudelko1);
            Array.Sort(doublePudelko2);

            return new Pudelko(
                doublePudelko1[0] + doublePudelko2[0],
                doublePudelko1[1] + doublePudelko2[1],
                doublePudelko1[2] + doublePudelko2[2]
            );
        }

        public override string ToString()
        {
            return $"{A.ToString("F3")} m \u00D7 {B.ToString("F3")} m \u00D7 {C.ToString("F3")} m";
        }

        

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (format is null)
                format = "m";
            switch (format)
            {
                case "m":
                    return ToString();
                case "cm":
                    return $"{(A * 100).ToString("F1")} cm \u00D7 {(B * 100).ToString("F1")} cm \u00D7 {(C * 100).ToString("F1")} cm";
                case "mm":
                    return $"{A * 1000} mm \u00D7 {B * 1000} mm \u00D7 {C * 1000} mm";
                default:
                    throw new FormatException("Niepoprawny format!");
            }
        }

        private static double GetRoundedNumber(double number)
        {
            number *= 1000;
            number = (int)number;
            number /= 1000;
            return number;
        }
        public static UnitOfMeasure ParseUnitMeasure(string unit)
        {

            switch (unit)
            {
                case "m":
                    return UnitOfMeasure.meter;
                case "cm":
                    return UnitOfMeasure.centimeter;
                case "mm":
                    return UnitOfMeasure.milimeter;
                default:
                    throw new FormatException("Niepoprawny format!");
            }
        }

        public IEnumerator GetEnumerator()
        {
            yield return a;
            yield return b;
            yield return c;
        }
    }
   
}

