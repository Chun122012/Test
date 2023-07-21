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
            
            float AX = float.Parse(A[0]);
            float AY = float.Parse(A[1]);
            float AZ = float.Parse(A[2]);
            float BX = float.Parse(B[0]);
            float BY = float.Parse(B[1]);
            float BZ = float.Parse(B[2]);
            float CX = float.Parse(C[0]);
            float CY = float.Parse(C[1]);
            float CZ = float.Parse(C[2]);

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
