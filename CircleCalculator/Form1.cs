using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox1.Text, out float AX) || !float.TryParse(textBox4.Text, out float AY) ||
                !float.TryParse(textBox2.Text, out float BX) || !float.TryParse(textBox5.Text, out float BY) ||
                !float.TryParse(textBox3.Text, out float CX) || !float.TryParse(textBox6.Text, out float CY)
                )
            {
                MessageBox.Show("请输入正确的坐标！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //A、B、C三点坐标
            PointF pointA = new PointF(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text));
            PointF pointB = new PointF(Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text));
            PointF pointC = new PointF(Convert.ToSingle(textBox5.Text), Convert.ToSingle(textBox6.Text));

            //△ABC三条边的边长
            float c = (float)Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2));
            float b = (float)Math.Sqrt(Math.Pow(pointA.X - pointC.X, 2) + Math.Pow(pointA.Y - pointC.Y, 2));
            float a = (float)Math.Sqrt(Math.Pow(pointB.X - pointC.X, 2) + Math.Pow(pointB.Y - pointC.Y, 2));


            // 计算斜率a、c两边的斜率
            float k1 = (pointC.Y - pointB.Y) / (pointC.X - pointB.X);
            float k2 = (pointB.Y - pointA.Y) / (pointB.X - pointA.X);

            // 判断是否共线
            if (k1 == k2)
            {
                MessageBox.Show("输入的三个点共线，不能构成三角形");
                return;
            }

            //三角形半周长
            float s = (a + b + c) / 2;

            //三角形面积
            float area = (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            //三角形内切圆圆心坐标
            PointF pointIn = new PointF(
                (c * pointC.X + b * pointB.X + a * pointA.X) / (a + b + c), 
                (c * pointC.Y + b * pointB.Y + a * pointA.Y) / (a + b + c));

            //三角形内切圆半径
            float rIn = area / s;

            //三角形外切圆半径
            float rOut = a * b * c / (4 * area);

            //a、c两边的中点坐标
            PointF pointMidA = new PointF((pointC.X + pointB.X) / 2, (pointC.Y + pointB.Y) / 2);
            PointF pointMidC = new PointF((pointB.X + pointA.X) / 2, (pointB.Y + pointA.Y) / 2);

            //求出a、c的中垂线的斜率
            float ka = -1 / k1;
            float kc = -1 / k2;

            //三角形外切圆圆心坐标
            PointF pointOut = new PointF();
            pointOut.X = (pointMidC.Y - pointMidA.Y + k1 * pointMidA.X - k2 * pointMidC.X) / (k1 - k2);
            pointOut.Y = k1 * (pointOut.X - pointMidA.X) + pointMidA.Y;

            label11.Text = $"({pointIn.X:F2}, {pointIn.Y:F2})";
            label12.Text = $"{rIn:F2}";
            label13.Text = $"({pointOut.X:F2}, {pointOut.Y:F2})";
            label14.Text = $"{rOut:F2}";

            

        }

        private void CalculateIncircleAndCircumcircle(object point1X, object point1Y, object point2X, object point2Y, object point3X, object point3Y, out object incenterX, out object incenterY, out object incircleRadius, out object circumcenterX, out object circumcenterY, out object circumcircleRadius)
        {
            throw new NotImplementedException();
        }

        private bool IsTriangleValid(float aX, float aY, float bX, float bY, float cX, float cY)
        {
            throw new NotImplementedException();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
