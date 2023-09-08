
using System.Drawing;
using System.Numerics;

namespace 两圆位置关系
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个圆的圆心坐标");
            string a = Console.ReadLine();

            Console.WriteLine("请输入第二个圆的圆心坐标");
            string b = Console.ReadLine();

            string[] A = a.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] B = b.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

            float Ax = float.Parse(A[0]);
            float Ay = float.Parse(A[1]);

            float Bx = float.Parse(B[0]);
            float By = float.Parse(B[1]);

            Console.WriteLine("请输入第一个圆的半径");
            string AR = Console.ReadLine();
            Console.WriteLine("请输入第二个圆的半径");
            string BR = Console.ReadLine();

            float Ar = float.Parse(AR);
            float Br = float.Parse(BR);

            if (a == b && AR == BR)
            {
                Console.WriteLine("两圆重合相同");
                return;
            }

            float AB = (float)Math.Sqrt((Bx - Ax) * (Bx - Ax) + (By - Ay) * (By - Ay));

            if (Ar + Br < AB)
            {
                Console.WriteLine("两圆相离");
            }

            else if (Ar + Br == AB)
            {
                Console.WriteLine("两圆外切");
            }
            else if ((Ar - Br == AB && Ar > Br) || (Br - Ar == AB && Ar < Br))
            {
                Console.WriteLine("两圆内切");
            }

            else if(Ar + Br > AB && AB > Ar - Br && Ar >= Br)
            {
                Console.WriteLine("两圆相交");

                float angle1 = (float)Math.Asin((By - Ay) / AB);
                float angle2 = (float)Math.Acos((Ar * Ar - Br * Br + AB * AB) / (2 * Ar * AB));

                float X1 = Ax + Ar * (float)Math.Cos(angle1 + angle2);
                float Y1 = Ay + Ar * (float)Math.Sin(angle1 + angle2);
                float X2 = Ax + Ar * (float)Math.Cos(angle1 - angle2);
                float Y2 = Ay + Ar * (float)Math.Sin(angle1 - angle2);

                Console.WriteLine("两圆的交点为：({0:F2}, {1:F2})、({2:f2}, {3:F2})", X1, Y1, X2, Y2);

                float angle3 = (float)Math.Acos((float)Math.Abs(Ax - Bx) / AB);
                float angle4 = (float)Math.Acos((float)Math.Abs(X1 - Bx) / Br);

                float angleB = angle3 + angle4;

                float angle5 = (float)Math.Acos((float)Math.Abs(Ay - By) / AB);
                float angle6 = (float)Math.Acos((float)Math.Abs(Y1 - Ay) / Ar);

                float angleA = angle5 + angle6;

                float h = (float)Math.Sqrt( ((float)Math.Abs(X1 - X2) * (float)Math.Abs(X1 - X2)) + ((float)Math.Abs(Y1 - Y2) * (float)Math.Abs(Y1 - Y2)) ) / 2;

                float S1 = (angleA / 2) * Ar * Ar;
                float S2 = (angleB / 2) * Br * Br;

                float total = (S1 * 2) + (S2 * 2) - 2 * (AB * h * 1 / 2);
                Console.WriteLine("两圆的公共面积为为：{0:F2}" , total);
            }
            else if (Ar + Br > AB && AB > Br - Ar && Ar <= Br)
            {
                Console.WriteLine("两圆相交");

                float angle1 = (float)Math.Asin((By - Ay) / AB);
                float angle2 = (float)Math.Acos((Br * Br - Ar * Ar + AB * AB) / (2 * Ar * AB));

                float X1 = Ax + Ar * (float)Math.Cos(angle1 + angle2);
                float Y1 = Ay + Ar * (float)Math.Sin(angle1 + angle2);
                float X2 = Ax + Ar * (float)Math.Cos(angle1 - angle2);
                float Y2 = Ay + Ar * (float)Math.Sin(angle1 - angle2);

                Console.WriteLine("两圆的交点为：({0}, {1})、({2}, {3})", X1, Y1, X2, Y2);

                float angle3 = (float)Math.Acos((float)Math.Abs(Ax - Bx) / AB);
                float angle4 = (float)Math.Acos((float)Math.Abs(X1 - Bx) / Br);

                float angleB = angle3 + angle4;

                float angle5 = (float)Math.Acos((float)Math.Abs(Ay - By) / AB);
                float angle6 = (float)Math.Acos((float)Math.Abs(Y1 - Ay) / Ar);

                float angleA = angle5 + angle6;

                float h = (float)Math.Sqrt(((float)Math.Abs(X1 - X2) * (float)Math.Abs(X1 - X2)) + ((float)Math.Abs(Y1 - Y2) * (float)Math.Abs(Y1 - Y2))) / 2;

                float S1 = (angleA / 2) * Ar * Ar;
                float S2 = (angleB / 2) * Br * Br;

                float total = (S1 * 2) + (S2 * 2) - 2 * (AB * h * 1 / 2);
                Console.WriteLine("两圆的公共面积为为：{0:F2}", total);
            }

            else if ((AB + Br < Ar && Ar > Br) || (AB + Ar < Br && Ar < Br))
            {
                Console.WriteLine("两圆内含");
            }

            

            


            
        }
    }
}