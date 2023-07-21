using System.Drawing;
using System.Numerics;
using System.Reflection;

namespace math
{
    public class Program 
    {
        public static void Main()
        {
            // 1
            Count.Text1(new PointF(1, 1), new PointF(4, 5), 2);
            
            // 2
            Count.Text2(new PointF(1, 1), 2);
            
            //3
            Count.Text3(new PointF(1, 1), new PointF(2, 2), 30, 4);
           
            //4
            Count.Text4(new Vector3(1, 1, 0), new Vector3(2, 1, 2), new Vector3(0, 0, 3));
            
            //5
            Count.Text5(new PointF(1, 1), new PointF(4, 6), new PointF(2, 4), new PointF(7, 5));
            
            //6
            Count.Text6(new PointF(1, 1), new PointF(4, 6), 4);

            //7
            Count.Text7(new PointF(1, 1), new PointF(2, 3), new PointF(0, 0), 2);

            //8
            Count.Text8(new PointF(5, 5), 5, new PointF(8, 9));
        }
    }
}
