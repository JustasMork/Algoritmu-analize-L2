using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    abstract class Task1Logic
    {
        protected static int[] p = { 30, 2, 3, 4, 5, 6 };
        public abstract int runAlgorythm(int n, int k);

        protected int getSumOfElements(int n, int l)
        {
            int sum = 0;
            for (int i = l; i < n; i++)
                sum += p[i];
            return sum;
        }

        public void setPValue(string inputLine)
        {
            string[] inputs = inputLine.Split(',');
            List<int> numbers = new List<int>();
            for (int i = 0; i < inputs.Length; i++)
            {
                int number;
                bool canBeConverted = Int32.TryParse(inputs[i], out number);
                if (canBeConverted)
                    numbers.Add(number);
            }
            p = numbers.ToArray();
        }
    }
}
