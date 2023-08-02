using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using jisuan;

namespace jiSuan
{
    public class Count
    {
        public static void Main()
        {
            // 1
            jisuan.Count.Text1(new PointF(1, 1), new PointF(4, 5), 2);

            // 2
            jisuan.Count.Text2(new PointF(1, 1), 2);

            //3
            jisuan.Count.Text3(new PointF(0, 0), new PointF(10, 0), 10, 45);

            //4
            jisuan.Count.Text4(new Vector3(1, 1, 0), new Vector3(2, 1, 2), new Vector3(0, 0, 3));

            //5
            jisuan.Count.Text5(new PointF(1, 1), new PointF(4, 6), new PointF(2, 4), new PointF(7, 5));

            //6
            jisuan.Count.Text6(new PointF(0, 0), new PointF(10, 0), 10);

            //7
            jisuan.Count.Text7(new PointF(0, 0), new PointF(10, 0), new PointF(0, 0), 5);

            //8
            jisuan.Count.Text8(new PointF(0, 0), new PointF(2, 0), 2);
        }
    }
}