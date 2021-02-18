using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv2
{
    public class Complex
    {
        public double Real;
        public double Imag;
        public const double Epsilon = 1E-6; //maximum error for == and != operators
        static private char symbol = 'i';    //imaginary symbol

        //constructor
        public Complex(double real, double imag)
        {
            Real = real;
            Imag = imag;
        }

        //operators
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imag + b.Imag);
        }
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imag - b.Imag);
        }
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Real * b.Real - a.Imag * b.Imag, a.Imag * b.Real + a.Real * b.Imag);
        }
        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex((a.Real * b.Real + a.Imag * b.Imag) / (b.Real * b.Real + b.Imag * b.Imag),
                               (a.Imag * b.Real - a.Real * b.Imag) / (b.Real * b.Real + b.Imag * b.Imag));
        }
        public static bool operator ==(Complex a, Complex b)
        {
            return (Math.Abs(a.Real - b.Real) < Epsilon && Math.Abs(a.Imag - b.Imag) < Epsilon);
        }
        public static bool operator !=(Complex a, Complex b)
        {
            return !(a == b);
        }
        public static Complex operator -(Complex a)
        {
            return new Complex(-a.Real, -a.Imag);
        }
        public override string ToString()
        {
            return string.Format("{0:F2}{1}{2:F2}{3}", Real, Imag >= 0 ? "+" : "", Imag, symbol);
        }
        public Complex Conjugate()
        {
            return new Complex(Real, -Imag);
        }
        public double Modulus()
        {
            return Math.Sqrt(Real * Real + Imag * Imag);
        }
        public double Argument()
        {
            return Math.Atan2(Imag, Real);
        }
    }
}
