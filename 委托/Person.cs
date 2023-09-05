using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    public class Person : IShowInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine("我叫" + Name + ",今年" + Age + "岁");
        }
    }

    public interface IShowInfo
    {
        public void ShowInfo();
    }
}
