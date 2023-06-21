using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo01
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Console.WriteLine("请输入一个大于一的整数");
            string y = Console.ReadLine();
            for (int i = 2; i <= int.Parse(y); i++)
            {
                bool z = true;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        z = false;
                        break;
                    }
                }

                if (z)
                {
                    x++;
                }

            }
            Console.WriteLine("其中有{0}个质数", x);
        }
    }
}
