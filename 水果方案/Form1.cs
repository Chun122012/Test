using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 水果方案
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            string text3 = textBox3.Text;
            string text4 = textBox4.Text;
            string text5 = textBox5.Text;
            string num = @"^\d+?$";

            if (!Regex.IsMatch(text1, num) || !Regex.IsMatch(text2, num) || !Regex.IsMatch(text3, num) || 
                !Regex.IsMatch(text4, num) || !Regex.IsMatch(text5, num))
            {
                MessageBox.Show("输入的价格不正确，请输入正确的价格", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int Price = int.Parse(text1);
            int Apple = int.Parse(text2);
            int Watermelon = int.Parse(text3);
            int Cherries = int.Parse(text4);
            int Durian = int.Parse(text5);

            
            List<string> fruit = new List<string>();
            int count = 0;

            for (int a = 0; a <= Price / Apple; a++)
            {
                for (int w = 0; w <= Price / Watermelon; w++)
                {
                    for (int c = 0; c <= Price / Cherries; c++)
                    {
                        for (int d = 0; d <= Price / Durian; d++)
                        {
                            if (Apple * a + Watermelon * w + Cherries * c + Durian * d == 0)
                            {
                                break;
                            }
                            else if (
                                Price / (Apple * a + Watermelon * w + Cherries * c + Durian * d) == 1 && 
                                Price % (Apple * a + Watermelon * w + Cherries * c + Durian * d) < 10
                                )
                            {
                                fruit.Add("苹果数量：" + a + " ，西瓜数量：" + w + " ，车厘子数量：" + c + " ，榴莲数量：" + d);
                                count++;
                            }
                        }
                    }
                }
            }

            listBox1.Items.Add("一共" + count + "种方案");
            
            for (int i = 0; i < fruit.Count; i++)
            {
                listBox1.Items.Add(fruit[i]);
            }
            listBox1.Visible = true;
        }
    }
}
