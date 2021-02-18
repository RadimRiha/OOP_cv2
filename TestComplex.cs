using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv2
{
    public class TestComplex
    {
        public static void Test(Complex actual, Complex expected, string testName)
        {
            if (actual == expected) Console.WriteLine("{0}: OK", testName);
            else Console.WriteLine("{0}: Error, Expected value: {1} Actual value: {2}", testName, expected, actual);
        }
    }
}
