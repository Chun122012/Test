
using System.Drawing;

namespace 筛选1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("请输入直线的起点坐标");
            string a = Console.ReadLine();

            Console.WriteLine("请输入直线的终点坐标");
            string b = Console.ReadLine();

            string[] A = a.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] B = b.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

            double Ax = double.Parse(A[0]);
            double Ay = double.Parse(A[1]);

            double Bx = double.Parse(B[0]);
            double By = double.Parse(B[1]);

            if (a == b)
            {
                Console.WriteLine("两点坐标相同，请重新输入");
                return;
            }
            Console.WriteLine("请输入随机坐标数量");
            string num = Console.ReadLine();

            Random random = new Random();

            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();
            List<Point> point = new List<Point>();

            for (int i = 0; i < int.Parse(num); i++)
            {
                int x = random.Next(-100, 100);
                int y = random.Next(-100, 100);
                point.Add(new Point(x, y));
            }

            
            for (int i = 0; i < point.Count; i++)
            {
                if (Ax == Bx)
                {
                    if (point[i].X > Ax)
                    {
                        left.Add(point[i]);
                    }
                    else if (point[i].X < Ax)
                    {
                        right.Add(point[i]);
                    }
                }
                else if (Ay == By)
                {
                    if (point[i].Y > Ay)
                    {
                        left.Add(point[i]);
                    }
                    else if (point[i].Y < Ay)
                    {
                        right.Add(point[i]);
                    }
                }
                else
                {
                    double k = (By - Ay) / (Bx - Ax);
                    double c = Ay / (k * Ax);

                    if (k > 0)
                    {
                        if (point[i].Y > k * point[i].X + c)
                        {
                            left.Add(point[i]);
                        }
                        else if (point[i].Y < k * point[i].X + c)
                        {
                            right.Add(point[i]);
                        }
                    }
                    else if (k < 0)
                    {
                        if (point[i].Y > k * point[i].X + c)
                        {
                            right.Add(point[i]);
                        }
                        else if (point[i].Y < k * point[i].X + c)
                        {
                            left.Add(point[i]);
                        }
                    }
                }
            }
            Console.WriteLine("left:");
            for (int i = 0; i < left.Count; i++)
            {
                Console.WriteLine(left[i]);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("right:");
            for (int i = 0; i < right.Count; i++)
            {
                Console.WriteLine(right[i]);
            }
        }
    }
}