using System;

namespace L2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select test (1 - Task 1 Recursive, 2 - Task 1 Dynamic, 3 - Task 2 Recursive, 4 - Task 2 Dynamic)");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Recursive recursive = new Recursive();
                    testTask1(recursive);
                    break;
                case "2":
                    Dynamic dynamic = new Dynamic();
                    testTask1(dynamic);
                    break;
                case "3":
                    RecursiveTriangulation recursiveTriangulation = new RecursiveTriangulation();
                    testTask2(recursiveTriangulation);
                    break;
                case "4":
                    DynamicTriangulation dynamicTriangulation = new DynamicTriangulation();
                    testTask2(dynamicTriangulation);
                    break;
                default:
                    Console.WriteLine("Unknown method selected");
                    break;
            }
        }

        private static void testTask1(Task1Logic logicObj)
        {
            int k, n;
            
            Console.WriteLine("Enter k value:");
            string input = Console.ReadLine();

            bool canBeConverted = Int32.TryParse(input.Trim(), out k);
            if (!canBeConverted)
            {
                Console.WriteLine("Input cannot be converted to int");
                return;
            }

            Console.WriteLine("Enter n value:");
            input = Console.ReadLine();
            canBeConverted = Int32.TryParse(input.Trim(), out n);
            if (!canBeConverted)
            {
                Console.WriteLine("Input cannot be converted to int");
                return;
            }

            Console.WriteLine("Do you want to set p values? (y/n)");
            input = Console.ReadLine();
            if (input.Trim().ToLower() == "y")
            {
                Console.WriteLine("Enter your p values (1,2,3,4,...) and press Enter");
                input = Console.ReadLine();
                logicObj.setPValue(input);
            }
            Console.WriteLine("Result:");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(logicObj.runAlgorythm(k, n));
            watch.Stop();
            Console.WriteLine("\n Elapsed time:{0}", watch.Elapsed);
        }

        private static void testTask2(Triangulation triangulation)
        {
            int n;

            Console.WriteLine("Do you want to set point values? (y/n)");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "y")
            {
                bool firstTime = true;
                Console.WriteLine("Enter your point values 'x y' or X to exit");
                while (input.Trim().ToLower() != "x")
                {
                    if (!firstTime)
                    {
                        string[] splited = input.Split(' ');
                        Point point = new Point(int.Parse(splited[0]), int.Parse(splited[1]));
                        triangulation.addPoint(point);
                    }
                    else
                        firstTime = false;
                    input = Console.ReadLine(); 
                }

                Console.WriteLine("Min perimeter {0}", triangulation.getMinPerimeter(0, triangulation.getNumPoints() - 1));
            } else {

                Console.WriteLine("Enter number of points in polygon (min 3):");
                input = Console.ReadLine();

                bool canBeConverted = Int32.TryParse(input.Trim(), out n);
                if (!canBeConverted)
                {
                    Console.WriteLine("Input cannot be converted to int");
                    return;
                }
                var watch = System.Diagnostics.Stopwatch.StartNew();
                triangulation.GeneratePolygon(n);
                watch.Stop();
                Console.WriteLine("Min perimeter {0}", triangulation.getMinPerimeter(0, n - 1));
                Console.WriteLine("\nPolygon points: {0}\n Time: {1}", n, watch.Elapsed);
            }
        }

    }
}
