namespace 委托
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "张三";
            person.Age = 20;
            person.ShowInfo();
        }
    }
}