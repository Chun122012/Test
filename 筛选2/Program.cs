
using System.Drawing;
using System.Numerics;

namespace 筛选2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("请输入直线起点坐标");
            string a = Console.ReadLine();

            Console.WriteLine("请输入直线的终点坐标");
            string b = Console.ReadLine();

            string[] A = a.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] B = b.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

            float Ax = float.Parse(A[0]);
            float Ay = float.Parse(A[1]);

            float Bx = float.Parse(B[0]);
            float By = float.Parse(B[1]);

            if (a == b)
            {
                Console.WriteLine("两点坐标相同，请重新输入");
                return;
            }
            Console.WriteLine("请输入随机坐标数量");
            string num = Console.ReadLine();

            Random random = new Random();

            List<Point> direction = new List<Point>();
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
                
                Vector2 line = new Vector2(Bx - Ax,By - Ay);
                Vector2 P = new Vector2(point[i].X - Ax, point[i].Y - Ay);

                if (Ax == Bx)
                {
                    if (Ay > By && point[i].Y < Ay)
                    {
                        direction.Add(point[i]);
                    }
                    else if (Ay < Bx && point[i].Y > Ay)
                    {
                        direction.Add(point[i]);
                    }
                }
                else if (Ay == By)
                {
                    if (Ax > Bx && point[i].X < Ax)
                    {
                        direction.Add(point[i]);
                    }
                    else if (Ax < Bx && point[i].Y > Ax)
                    {
                        direction.Add(point[i]);
                    }
                }
                else
                {
                    float k1 = (By - Ay) / (Bx - Ax);
                    float c1 = Ay / (k1 * Ax);
                    float k2 = -1/k1;
                    float c2 = Ay - k2 * Ax;

                    float Y = k2 * point[i].X + c2;
                    if (Y < point[i].Y)
                    {
                        direction.Add(point[i]);
                    }
                }
            }
            Console.WriteLine("direction:");
            for (int i = 0; i < direction.Count; i++)
            {
                Console.WriteLine(direction[i]);
            }
            
        }
    }
}