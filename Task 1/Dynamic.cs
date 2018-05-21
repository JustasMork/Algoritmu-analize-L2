using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    class Dynamic: Task1Logic
    {
        protected int[,] recursionResultContainer;

        public override int runAlgorythm(int k, int n)
        {
            recursionResultContainer = new int[k,n];
            if (n == 0)
                return 0;
            else if (k == 1)
            {
                return getSumOfElements(n, 0);
            }
            else
            {
                int min = -1;
                for (int i = 1; i <= n; i++)
                {
                    int sum = getSumOfElements(n, i);
                    int recursionResult = recursionWithResultStoring(k - 1, n - 1);

                    if (sum > recursionResult)
                    {
                        if (min > sum || min == -1)
                            min = sum;
                    }
                    else
                    {
                        if (min > recursionResult || min == -1)
                            min = recursionResult;
                    }
                }
                return min;
            }
        }

        protected int recursionWithResultStoring(int k, int n)
        {
            if (recursionResultContainer[k,n] != 0)
                return recursionResultContainer[k,n];

            if (n == 0)
                return 0;
            else if (k == 1)
            {
                int result = getSumOfElements(n, 0);
                recursionResultContainer[k, n] = result;
                return result;
            }
            else
            {
                int min = -1;
                for (int i = 1; i <= n; i++)
                {
                    int sum = getSumOfElements(n, i);
                    int recursionResult = recursionWithResultStoring(k - 1, n - 1);

                    if (sum > recursionResult)
                    {
                        if (min > sum || min == -1)
                            min = sum;
                    }
                    else
                    {
                        if (min > recursionResult || min == -1)
                            min = recursionResult;
                    }
                }
                recursionResultContainer[k, n] = min;
                return min;
            }

        }
    }
}
