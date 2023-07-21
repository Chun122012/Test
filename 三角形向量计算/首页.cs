using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 三角形向量计算
{
    public partial class 首页 : Form
    {
        public 首页()
        {
            InitializeComponent();
            this.SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // 计算PictureBox的大小和位置
            int leftMargin = 60; // 左外边距大小
            int rightMargin = 60; // 右外边距大小
            int topMargin = 200;
            int bottomMargin = 60; // 下外边距大小

            int width = this.ClientSize.Width - leftMargin - rightMargin; // 图片显示区域的宽度（窗口宽度减去左外边距和右外边距）
            int height = this.ClientSize.Height - topMargin - bottomMargin; // 图片显示区域的高度（窗口高度减去下外边距）

            Size imageSize = pictureBox1.Image.Size; // 图片的原始尺寸
            double aspectRatio = (double)imageSize.Width / imageSize.Height; // 图片的宽高比

            // 计算缩放后的宽度和高度
            int scaledWidth = width;
            int scaledHeight = (int)(width / aspectRatio);

            if (scaledHeight > height)
            {
                // 如果缩放后的高度大于图片显示区域的高度，则重新计算缩放后的宽度和高度
                scaledWidth = (int)(height * aspectRatio);
                scaledHeight = height;
            }

            int x = leftMargin + (width - scaledWidth) / 2; // 图片的左上角x坐标
            int y = (this.ClientSize.Height - scaledHeight) - bottomMargin; // 图片的左上角y坐标

            // 设置PictureBox的位置和尺寸
            pictureBox1.Location = new Point(x, y);
            pictureBox1.Size = new Size(scaledWidth, scaledHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;  // 将PictureBox控件的可见性设置为true，显示图片
            pictureBox1.Image = Image.FromFile("C:/Users/hasee/Desktop/图/示意图.jpg");  // 设置PictureBox控件的Image属性为要显示的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textM = textBox1.Text;
            string textN = textBox2.Text;
            string MN = @"^\d+?$";

            if (!Regex.IsMatch(textM, MN) || !Regex.IsMatch(textN, MN))
            {
                MessageBox.Show("输入的m或n格式不正确，请输入正确的坐标", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string textOA = textBox3.Text;
            string textOB = textBox4.Text;
            string E = @"^\(?-?\d+(\.\d+)?, ?-?\d+(\.\d+)?\)?$";

            if (!Regex.IsMatch(textOA, E) || !Regex.IsMatch(textOB, E))
            {
                MessageBox.Show("输入的e1或e2格式不正确，请输入正确的坐标", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] stringOA = textOA.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] stringOB = textOB.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

            int M = int.Parse(textBox1.Text);
            int N = int.Parse(textBox2.Text);
            float OAX = float.Parse(stringOA[0]);
            float OAY = float.Parse(stringOA[1]);
            float OBX = float.Parse(stringOB[0]);
            float OBY = float.Parse(stringOB[1]);

            

            PointF C = new PointF();
            PointF D = new PointF();

            Vector2 OA = new Vector2(OAX, OAY);
            Vector2 OB = new Vector2(OBX, OBY);

            PointF O  = new PointF();
            PointF A  = new PointF();
            PointF B  = new PointF();

            Vector2 OC = new Vector2();
            Vector2 OD = new Vector2();
            
            C.X = ((1 - M) * (OB.X + (M - 1) * OA.X) / M) / (1 - M);
            C.Y = ((1 - M) * (OB.Y + (M - 1) * OA.Y) / M) / (1 - M);

            O.X = (M * C.X - (M - 1) * OA.X - OB.X) / M;
            O.Y = (M * C.Y - (M - 1) * OA.Y - OB.Y) / M;

            A.X = OA.X + O.X;
            A.Y = OA.Y + O.Y;
            B.X = OB.X + O.X;
            B.Y = OB.Y + O.Y;

            D.X = ((N - 1) * B.X + A.X) / N;
            D.Y = ((N - 1) * B.Y + A.Y) / N;

            OC.X = C.X - O.X;
            OC.Y = C.Y - O.Y; 
            OD.X = D.X - O.X;
            OD.Y = D.Y - O.Y;

            label5.Text = "向量OC：" + $"{OC.X}, {OC.Y}";
            label6.Text = "向量OD：" + $"{OD.X}, {OD.Y}";
            

        }
    }
}
