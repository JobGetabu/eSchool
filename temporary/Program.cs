using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temporary
{
    class Program
    {
        static int cyear= 2017;
        static int cteam = 3;

        static int yearAdm = 2010;
        static int teamAdm =2;
        static int count = 0;
        static void Main(string[] args)
        {
            for (int i = yearAdm; i <= cyear; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (count ==0)
                    {
                        j = teamAdm; 
                    }
                    if (cyear == i & cteam == j)
                    {
                        Console.WriteLine($"=>Period{count} Year {i} Term {j}");
                        break;

                    }
                    Console.WriteLine($"Period{count} Year {i} Term {j}");
                    count += 1;
                }
            }
            Console.ReadKey();
        }
    }
}
