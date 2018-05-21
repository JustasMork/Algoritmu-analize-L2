using System;

namespace L2
{
    class DynamicTriangulation : Triangulation
    {

        protected double[,] recursionResultContainer;

        public override double getMinPerimeter(int start, int end)
        {
            if (recursionResultContainer == null)
            {
                recursionResultContainer = new double[end+1, end+1];
                for (int i = 0; i <= end; i++)
                    for (int j = 0; j <= end; j++)
                        recursionResultContainer[i, j] = -1;
            }


            if (recursionResultContainer[start, end] != -1)
                return recursionResultContainer[start, end];

            if (end < start + 2)
            {
                recursionResultContainer[start, end] = 0;
                return 0;
            }
                

            double minPerimeter = Double.MaxValue;

            for (int i = start + 1; i < end; i++)
            {
                double first = getMinPerimeter(start, i);
                double second = getMinPerimeter(i, end);
                double third = getPerimeter(start, i, end);

                double[] array = { minPerimeter, first + second + third };

                minPerimeter = getMinFromArray(array);
            }
            recursionResultContainer[start, end] = minPerimeter;
            return minPerimeter;
        }
    }
}
