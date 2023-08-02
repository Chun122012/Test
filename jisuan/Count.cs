using System.Drawing;
using System.Numerics;

namespace jisuan
{
    public class Count 
    {
       

        public static void Text1(PointF A, PointF B, float L)
        {

            if (A == B)
            {
                throw new Exception("坐标输入格式不正确，A、B坐标不能相同");
            }
            PointF C = new();
            float AB = (float)Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));

            Vector2 vectorAB = new Vector2((B.X - A.X), (B.Y - A.Y));

            Vector2 vectorBC = new Vector2();

            vectorBC = Vector2.Normalize(vectorAB) * L;

            C.X = vectorBC.X + B.X;
            C.Y = vectorBC.Y + B.Y;
            Console.WriteLine($"该点的坐标为：({C.X:F1}, {C.Y:F1})");
        }

        public static void Text2(PointF pointA, float offset)
        {
            PointF O = new(0, 0);
            PointF C = new();

            O.X = 0; O.Y = 0;
            float OA = (float)Math.Sqrt(Math.Pow((pointA.X - O.X), 2) + Math.Pow((pointA.Y - O.Y), 2));

            float angle;

            float cosAngle = (pointA.X * pointA.X + OA * OA - pointA.Y * pointA.Y) / (2 * pointA.X * OA);
            angle = (float)Math.Acos(cosAngle);

            C.X = pointA.X + offset * (float)Math.Cos(angle);
            C.Y = pointA.Y + offset * (float)Math.Sin(angle);
            Console.WriteLine($"该点的坐标为：({C.X:F1}, {C.Y:F1})");
        }

        public static void Text3(PointF A, PointF B, float R, float Rotation_A )
        {
            if (A == B)
            {
                throw new Exception("坐标输入格式不正确，A、B坐标不能相同");
            }
            PointF C = new();

            C.Y = (float)Math.Sin(Rotation_A * (float)Math.PI / 180) * R + A.Y;
            C.X = (float)Math.Cos(Rotation_A * (float)Math.PI / 180) * R + A.X;

            Console.WriteLine($"该点的坐标为：({C.X:F1}, {C.Y:F1})");
        }

        public static void Text4(Vector3 A, Vector3 B, Vector3 C)
        {
            if (A == B || A == C || B == C)
            {
                throw new Exception("坐标输入格式不正确，A、B、C坐标不能相同");
            }


            //AB、AC的向量
            Vector3 AB = B - A;
            Vector3 AC = C - A;

            //计算法向量
            Vector3 N = new Vector3();

            N.X = AB.Y * AC.Z - AC.Y * AB.Z;
            N.Y = AB.Z * AC.X - AC.Z * AB.X;
            N.Z = AB.X * AC.Y - AC.X * AB.Y;

            //判断三点是否共线
            if (N == Vector3.Zero)
            {
                throw new Exception("输入的A、B、C坐标共线");
            }

            float L = (float)Math.Sqrt(N.X * N.X + N.Y * N.Y + N.Z * N.Z);
            Vector3 n = N / L;

            Console.WriteLine($"单位法向量：({n.X:F1}, {n.Y:F1}, {n.Z:F1})");
        }

        public static void Text5(PointF A, PointF B, PointF C, PointF D)
        {
            if (A == B && C == D)
            {
                throw new Exception("坐标输入格式不正确，A、B或C、D坐标不能相同");
            }

            float k1 = (B.Y - A.Y) / (B.X - A.X);
            float k2 = (D.Y - C.Y) / (D.X - C.X);
            if (k1 == k2)
            {
                throw new Exception("AB与CD斜率相同，AB∥CD");
            }
            float x, y;
            x = (k1 * A.X - k2 * C.X - A.Y + C.Y) / (k1 - k2);
            y = k1 * (x - A.X) + A.Y;

            PointF E = new(x, y);
            Console.WriteLine($"该点的坐标为：({E.X:F1}, {E.Y:F1})");
        }

        public static void Text6(PointF O, PointF A, float R)
        {
            
            PointF M = new();
            PointF N = new();

            float AO = (float)Math.Sqrt((O.X - A.X) * (O.X - A.X) + (O.Y - A.Y) * (O.Y - A.Y));
            if (AO == R)
            {
                Console.WriteLine("点A在圆上，切点只有一个：({0:F1}, {1:F1}))", A.X, A.Y);
                return;
            }

            float AM = (float)Math.Sqrt((O.X - A.X) * (O.X - A.X) + (O.Y - A.Y) * (O.Y - A.Y) - R * R);
            float AN = AM;

            M.Y = R / AO * AM;
            N.Y = R / AO * AN;

            M.X = (float)Math.Sqrt(R * R - M.Y * M.Y);
            N.X = (float)Math.Sqrt(R * R - N.Y * N.Y);

            Console.WriteLine($"该点的坐标为：({{0:F1}}, {{1:F1}})、({{2:F1}}, {{3:F1}})", M.X, M.Y, N.X, N.Y);
        }


        public static void Text7(PointF O, PointF A, PointF B, float R)
        {
            float k = (A.Y - B.Y) / (A.X - B.X);
            float b = A.Y - k * A.X;

            float a = 1 + k * k;
            float b1 = 2 * k * (b - O.Y) - 2 * O.X;
            float c = O.X * O.X + (b - O.Y) * (b - O.Y) - R * R;


            if (b1 * b1 - 4 * a * c < 0)
            {
                Console.WriteLine("直线与圆没有交点");
            }
            else if (b1 * b1 - 4 * a * c == 0)
            {
                float X = -b1 / 2 * a;
                float Y = k * X + b;
                Console.WriteLine("直线与圆有一个交点，交点为：({0}, {1})", X, Y);
            }
            else
            {
                float X1 = (float)(-b1 + Math.Sqrt(b1 * b1 - 4 * a * c)) / (2 * a);
                float Y1 = k * X1 + b;
                float X2 = (float)(-b1 - Math.Sqrt(b1 * b1 - 4 * a * c)) / (2 * a);
                float Y2 = k * X2 + b;
                Console.WriteLine("直线与圆有两个交点，交点为：({0:F1}, {1:F1})、({2:F1}, {3:F1})", X1, Y1, X2, Y2);
            }
        }



        public static void Text8(PointF O,  PointF P, float R)
        {
            if ((P.X - O.X) * (P.X - O.X) + (P.Y - O.Y) * (P.Y - O.Y) != R * R)
            {
                Console.WriteLine("P点不是圆的切点，请重新输入");
                return;
            }

            PointF X = new();
            
            if(P.X - O.X == R && P.Y == O.Y)
            {
                Console.WriteLine("切点P的切线的方向角度数是：90");
                return;
            }
            else if(P.Y - O.Y == R && P.X == O.X)
            {
                Console.WriteLine("切点P的切线与X轴平行");
                return;
            }

            float k1 = (P.Y - O.Y) / (P.X - O.X);
            float k2 = -1 / k1;

            float b = P.Y - k2 * P.X;
            X.Y = 0;
            X.X = -b / k2;

            float angle;

            angle = (float)Math.Atan2(P.Y, P.X - X.X) * 180 / (float)Math.PI;

            Console.WriteLine("切点P的切线的方向角度数是：{0:F1}", angle);
        }
    }
}
