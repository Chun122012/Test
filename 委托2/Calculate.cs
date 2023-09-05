using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 委托2
{
    internal class Calculate
    {
        public void Invoke(int A, int B)
        {
            int add = MathOperation.Add(A, B);
            Console.WriteLine("结果1：" + add);

            int multiply = MathOperation.Multiply(A, B);
            Console.WriteLine("结果2：" + multiply);
        }
    }
}
