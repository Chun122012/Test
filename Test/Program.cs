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
            int z;
            if (int.TryParse(y, out z))
            {
                for (int i = 2; i <= z; i++)
                {
                    bool a = true;
                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            a = false;
                            break;
                        }
                    }

                    if (a)
                    {
                        x++;
                    }

                }
                Console.WriteLine("其中有{0}个质数", x);
            }
            else
            {
                Console.WriteLine("输入的格式不正确！");
                Console.ReadKey();
            }
        }
    }
}
