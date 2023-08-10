using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 搭接接头坐标
{
    public partial class 计算搭接接头坐标点 : Form
    {
        public 计算搭接接头坐标点()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textA = textBox1.Text;
            string textB = textBox2.Text;
            string ab = @"^\(?-?\d+(\.\d+)?, ?-?\d+(\.\d+)?\)?$";

            if (!Regex.IsMatch(textA, ab) || !Regex.IsMatch(textB, ab))
            {
                MessageBox.Show("输入的点A或点B格式不正确，请输入正确的坐标", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] stringA = textA.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] stringB = textB.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

            float AX = float.Parse(stringA[0]);
            float AY = float.Parse(stringA[1]);
            float BX = float.Parse(stringB[0]);
            float BY = float.Parse(stringB[1]);

            string textAC = textBox3.Text;
            string textL = textBox4.Text;
            string textD = textBox5.Text;
            string M = @"^\d+?$";

            if (!Regex.IsMatch(textAC, M) || !Regex.IsMatch(textL, M) || !Regex.IsMatch(textD, M))
            {
                MessageBox.Show("输入的长度AC、L、d的格式不正确，请输入正确的数字", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float AC = float.Parse(textBox3.Text);
            float L = float.Parse(textBox4.Text);
            float d = float.Parse(textBox5.Text);


            float AB = (float)Math.Sqrt((BY - AY) * (BY - AY) + (BX - AX) * (BX - AX));
            PointF A = new PointF();
            PointF B = new PointF();
            PointF C = new PointF();
            PointF D = new PointF();
            PointF E = new PointF();
            PointF F = new PointF();
            PointF G = new PointF();

            A.X = AX; 
            A.Y = AY;
            B.X = BX; 
            B.Y = BY;

            C.Y = (B.Y - A.Y) * AC / AB;
            C.X = (B.X - A.X) * AC / AB;

            
            float DC = (float)Math.Sqrt((L/2) * (L/2) + (d/2) * (d/2));

            D.X = C.X - ((BX - AX) / AB) * DC;
            D.Y = C.Y - ((BY - AY) / AB) * DC ;

            F.X = ((BX - AX) / AB) * DC + C.X;
            F.Y = ((BY - AY) / AB) * DC + C.Y;

            float DF = (float)Math.Sqrt((F.Y - D.Y) * (F.Y - D.Y) + (F.X - D.X) * (F.X - D.X));

            
            float angle1 = (float)Math.Atan2(C.Y - D.Y, C.X - D.X);
            float angle2 = (float)Math.Atan2(d / 2, L / 2);
            E.X = (float)Math.Cos(angle1 + angle2) * L + D.X;
            E.Y = (float)Math.Sin(angle1 + angle2) * L + D.Y;

            G.X = F.X - (float)Math.Cos(angle1 + angle2) * L;
            G.Y = F.Y - (float)Math.Sin(angle1 + angle2) * L;

            string Dx = D.X.ToString("0.00");
            string Dy = D.Y.ToString("0.00");
            string Ex = E.X.ToString("0.00");
            string Ey = E.Y.ToString("0.00");
            string Fx = F.X.ToString("0.00");
            string Fy = F.Y.ToString("0.00");
            string Gx = G.X.ToString("0.00");
            string Gy = G.Y.ToString("0.00");

            textBox6.Text = Dx + ", " + Dy;
            textBox7.Text = Ex + ", " + Ey;
            textBox8.Text = Fx + ", " + Fy;
            textBox9.Text = Gx + ", " + Gy;
        }
    }
}
