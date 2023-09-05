using System;

namespace 委托2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Calculate calculate = new Calculate();
            
            Console.WriteLine("请输入第一个数字");
            string a = Console.ReadLine();

            Console.WriteLine("请输入第二个数字");
            string b = Console.ReadLine();

            int A;
            int B;
            if (!(int.TryParse(a, out A)) || !(int.TryParse(b, out B)))
            {
                Console.WriteLine("输入错误的数字");
            }
            A = int.Parse(a);
            B = int.Parse(b);

            calculate.Invoke(A, B);
        }
    }
}