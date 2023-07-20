using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace NormalCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断坐标输入是否正确
            string textA = textBox1.Text;
            string textB = textBox2.Text;
            string textC = textBox3.Text;
            string pattern = @"^\(?-?\d+(\.\d+)?, ?-?\d+(\.\d+)?, ?-?\d+(\.\d+)?\)?$";
            if (!Regex.IsMatch(textA, pattern) || !Regex.IsMatch(textB, pattern) || !Regex.IsMatch(textC, pattern))
            {
                MessageBox.Show("输入的坐标点格式不正确，请输入正确的坐标", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //字符串拆分
            string[] A = textA.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] B = textB.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] C = textC.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            if (!float.TryParse(A[0], out float AX) || !float.TryParse(A[1], out float AY) ||
                !float.TryParse(A[2], out float AZ) || !float.TryParse(B[0], out float BX) ||
                !float.TryParse(B[1], out float BY) || !float.TryParse(B[2], out float BZ) ||
                !float.TryParse(C[0], out float CX) || !float.TryParse(C[1], out float CY) ||
                !float.TryParse(C[2], out float CZ) 
                )
            {
                MessageBox.Show("输入的坐标点格式不正确，请输入正确的坐标", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //A、B、C三点的坐标
            Vector3 PointA = new Vector3(AX, AY, AZ);
            Vector3 PointB = new Vector3(BX, BY, BZ);
            Vector3 PointC = new Vector3(CX, CY, CZ);

            //AB、AC的向量
            Vector3 AB = PointB - PointA;
            Vector3 AC = PointC - PointA;

            //计算法向量
            Vector3 Normal = new Vector3();

            Normal.X = (BY - AY) * (CZ - AZ) - (CY - AY) * (BZ - AZ);
            Normal.Y = (BZ - AZ) * (CX - AX) - (CZ - AZ) * (BX - AX);
            Normal.Z = (BX - AX) * (CY - AY) - (CX - AX) * (BY - AY);

            //判断三点是否共线
            if (Normal == Vector3.Zero)
            {
                MessageBox.Show("输入的三个点共线");
                return;
            }


            textBox4.Text = $"{Normal.X}, {Normal.Y}, {Normal.Z}";  

        }
    }
}
