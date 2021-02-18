using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv2
{
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
            Console.WriteLine("For complex number {0}:", c1.ToString());
            Console.WriteLine("modulus: {0:F2}", c1.Modulus());
            Console.WriteLine("argument: {0:F2} rad", c1.Argument());
            Console.WriteLine("--- test done ---");
        }
    }
}
