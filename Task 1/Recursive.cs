using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    class Recursive: Task1Logic
    {
        public override int runAlgorythm(int k, int n)
        {
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
                    int recursionResult = runAlgorythm(k - 1, n - 1);

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


    }
}
