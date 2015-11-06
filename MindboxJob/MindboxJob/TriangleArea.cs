using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxJob
{
    public class TriangleArea
    {
        /// <summary>
        /// Calculate tirangle area (for whole numbers)
        /// </summary>
        /// <param name="side1">Width first side</param>
        /// <param name="side2">Width second side</param>
        /// <returns>Triangle area</returns>
        public int GetTriangleArea(int side1, int side2)
        {
            return CalcArea(side1, side2);
        }

        /// <summary>
        /// Calculate tirangle area (for real numbers)
        /// </summary>
        /// <param name="side1">Width first side</param>
        /// <param name="side2">Width second side</param>
        /// <returns>Triangle area</returns>
        public decimal GetTriangleArea(decimal side1, decimal side2)
        {
            return CalcArea(side1, side2);
        }

        private dynamic CalcArea(dynamic side1, dynamic side2)
        {
            if (side1 == 0 || side2 == 0)
                return 0;

            return (side1 * side2) / 2;
        }
    }
}
