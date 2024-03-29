﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AngleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                
                PointF pointA = new PointF(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox4.Text));
                PointF pointB = new PointF(Convert.ToSingle(textBox2.Text), Convert.ToSingle(textBox5.Text));
                PointF pointC = new PointF(Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox6.Text));

                float AB = (float)Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2));
                float AC = (float)Math.Sqrt(Math.Pow(pointA.X - pointC.X, 2) + Math.Pow(pointA.Y - pointC.Y, 2));
                float BC = (float)Math.Sqrt(Math.Pow(pointB.X - pointC.X, 2) + Math.Pow(pointB.Y - pointC.Y, 2));

                float cosA = (AC * AC + AB * AB - BC * BC) / (2 * AC * AB);
                float cosB = (BC * BC + AB * AB - AC * AC) / (2 * BC * AB);
                float cosC = (BC * BC + AC * AC - AB * AB) / (2 * BC * AC);

                float A = (float)Math.Acos(cosA) * 180 / (float)Math.PI;
                float B = (float)Math.Acos(cosB) * 180 / (float)Math.PI;
                float C = (float)Math.Acos(cosC) * 180 / (float)Math.PI;

               
                label10.Text = A.ToString("0.00"+"°");
                label11.Text = B.ToString("0.00"+"°");
                label12.Text = C.ToString("0.00"+"°");


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
