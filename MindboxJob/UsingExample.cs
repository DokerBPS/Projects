using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindboxJob;

namespace MindboxJob.UsingExample
{
    class UsingExample
    {
        public void CalcArea()
        {
            TriangleArea calcArea = new TriangleArea();
            decimal sideDec1 = 25.6M, sideDec2 = 15.6M;
            int sideInt1 = 3, sideInt2 = 4;

            var resultDecimal = calcArea.GetTriangleArea(sideDec1, sideDec2);
            var resultInt = calcArea.GetTriangleArea(sideInt1, sideInt2);

            Console.WriteLine("Result decimal: " + resultDecimal);
            Console.WriteLine("Result int: " + resultInt);
            Console.ReadLine();
        }
    }
}
