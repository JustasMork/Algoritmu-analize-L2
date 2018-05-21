using System;

namespace L2
{
    class RecursiveTriangulation : Triangulation
    {

        public override double getMinPerimeter(int start, int end)
        {
            if (end < start + 2)
                return 0;

            double minPerimeter = Double.MaxValue;

            for (int i = start+1; i < end; i++)
            {
                double first = getMinPerimeter(start, i);
                double second = getMinPerimeter(i, end);
                double third = getPerimeter(start, i, end);

                double[] array = { minPerimeter, first + second + third };
                
                minPerimeter = getMinFromArray(array);
            }

            return minPerimeter;
        }
    }
}
