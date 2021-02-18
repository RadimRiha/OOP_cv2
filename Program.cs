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
        static public char Symbol = 'i';    //imaginary symbol

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
            return string.Format("{0:F2}{1}{2:F2}{3}", Real, Imag>=0?"+":"", Imag, Symbol);
        }
        public Complex Conjugate()
        {
            return new Complex(Real, -Imag);
        }
        public double Modulus()
        {
            return Math.Sqrt(Real*Real + Imag*Imag);
        }
        public double Argument()
        {
            if (Real > 0) return Math.Atan2(Imag, Real);                                //1.,4. quadrant
            else if (Real < 0 && Imag >= 0) return Math.PI + Math.Atan2(Imag, Real);    //2. quadrant
            else if (Real < 0 && Imag < 0) return Math.Atan2(Imag, Real) - Math.PI;     //3. quadrant
            else if (Imag != 0) return Math.Sign(Imag) * Math.PI/2;                     //Real = 0
            else return double.NaN;                                                     //Real = 0, Imag = 0
        }
    }

    public class TestComplex
    {
        public static void Test(Complex actual, Complex expected, string testName)
        {
            if(actual == expected) Console.WriteLine("{0}: OK", testName);
            else Console.WriteLine("{0}: Error, Expected value: {1} Actual value: {2}", testName, expected, actual);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(10,3); //complex numbers for testing operators
            Complex c2 = new Complex(7,4);

            Console.WriteLine("--- test start ---");
            TestComplex.Test(c1 + c2, new Complex(17, 7), "add");
            TestComplex.Test(c1 - c2, new Complex(3, -1), "subtract");
            TestComplex.Test(c1 * c2, new Complex(58, 61), "multiply");
            TestComplex.Test(c1 / c2, new Complex(82/65.0, -19/65.0), "divide");
            TestComplex.Test(-c1, new Complex(-10, -3), "unary-");
            TestComplex.Test(c1.Conjugate(), new Complex(10, -3), "conjugate");
            Console.WriteLine("result of == operator: {0}", c1 == new Complex(10, 3));
            Console.WriteLine("result of != operator: {0}", c1 != new Complex(10, 3));
        }
    }
}
