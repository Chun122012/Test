using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 坐标计算
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textA = textBox1.Text;
            string textO = textBox2.Text;
            string textB = textBox3.Text;
            string aob = @"^\(?-?\d+(\.\d+)?, ?-?\d+(\.\d+)?\)?$";

            if (!Regex.IsMatch(textA, aob) || !Regex.IsMatch(textO, aob) || !Regex.IsMatch(textB, aob))
            {
                MessageBox.Show("输入的点坐标格式不正确，请输入正确的坐标", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] stringA = textA.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] stringO = textO.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] stringB = textB.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

            float Ax = float.Parse(stringA[0]);
            float Ay = float.Parse(stringA[1]);
            float Ox = float.Parse(stringO[0]);
            float Oy = float.Parse(stringO[1]);
            float Bx = float.Parse(stringB[0]);
            float By = float.Parse(stringB[1]);

            if (Ax == Ox && Ax == Bx || Ay == Oy && Ay == By)
            {
                {
                    MessageBox.Show("A、B、O三点共线", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string textOY = textBox4.Text;
            string textCD = textBox5.Text;
            string textFY = textBox6.Text;
            string textGY = textBox7.Text;
            string num = @"^\d+?$";

            if (!Regex.IsMatch(textOY, num) || !Regex.IsMatch(textCD, num) || !Regex.IsMatch(textFY, num) || !Regex.IsMatch(textGY, num))
            {
                MessageBox.Show("输入的长度格式不正确，请输入正确的数字", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float OY = float.Parse(textBox4.Text);
            float CD = float.Parse(textBox5.Text);
            float FY = float.Parse(textBox6.Text);
            float GY = float.Parse(textBox7.Text);

            PointF A = new PointF(Ax,Ay);
            PointF O = new PointF(Ox,Oy);
            PointF B = new PointF(Bx,By);
            PointF E = new PointF();
            PointF F = new PointF();
            PointF G = new PointF();
            PointF H = new PointF();
            PointF M = new PointF();
            PointF N = new PointF();
            PointF Y = new PointF();
            float angle;
            if(A.X == O.X)
            {
                angle = 90 * (float)Math.PI / 180;
            }else
            {
                angle = (float)Math.Atan((Ay - Oy) / (Ax - Ox));
            }
            float angle1 = angle;
            float angle2 = (float)Math.Atan((By - Oy) / (Bx - Ox));

            float angleAOB = angle1 - angle2;
            float angleEOY = angleAOB / 2;

            float OM = FY / (float)Math.Tan(angleEOY);
            float EF = OY - OM;
            float OE = (float)Math.Sqrt(OM * OM + FY * FY);

            float OA = (float)Math.Sqrt((Ay - Oy) * (Ay - Oy) + (Ax - Ox) * (Ax - Ox));
            Vector2 oa = new Vector2(A.X - O.X, A.Y - O.Y);
            Vector2 oe = new Vector2();

            oe = oa / OA * OE;
            E.X = oe.X + O.X;
            E.Y = oe.Y + O.Y;

            float angle4 = (float)Math.PI / 180 * 90 - angleEOY;
            M.X = (float)Math.Cos(angle4) * OM;
            M.Y = (float)Math.Sin(angle4) * OM;

            float k1 = (M.Y - O.Y) / (M.X - O.X);

            Y.Y = (float)Math.Sin(angle4) * OY;
            Y.X = (float)Math.Cos(angle4) * OY;

            
            float ON = GY / (float)Math.Tan(angleEOY);
            float HG = OY - ON;
            float OH = (float)Math.Sqrt(ON * ON + GY * GY);

            N.X = (float)Math.Cos(angle4) * ON;
            N.Y = (float)Math.Sin(angle4) * ON;

            float OB = (float)Math.Sqrt((By - Oy) * (By - Oy) + (Bx - Ox) * (Bx - Ox));
            Vector2 ob = new Vector2(B.X - O.X, B.Y - O.Y);
            Vector2 oh = new Vector2();

            oh = ob / OB * OH;
            H.X = oh.X + O.X;
            H.Y = oh.Y + O.Y;


            Vector2 my = new Vector2(Y.X - M.X, Y.Y - M.Y);
            F.X = my.X + E.X;
            F.Y = my.Y + E.Y;

            Vector2 ny = new Vector2(Y.X - N.X, Y.Y - N.Y);
            G.X = ny.X + H.X;
            G.Y = ny.Y + H.Y;

            string Hx = H.X.ToString("0.00");
            string Hy = H.Y.ToString("0.00");
            string Ex = E.X.ToString("0.00");
            string Ey = E.Y.ToString("0.00");
            string Fx = F.X.ToString("0.00");
            string Fy = F.Y.ToString("0.00");
            string Gx = G.X.ToString("0.00");
            string Gy = G.Y.ToString("0.00");

            listBox1.Items.Add("E:(" + Ex + ", " + Ey + ")");
            listBox1.Items.Add("F:(" + Fx + ", " + Fy + ")");
            listBox1.Items.Add("G:(" + Gx + ", " + Gy + ")");
            listBox1.Items.Add("H:(" + Hx + ", " + Hy + ")");
        }
    }
}
