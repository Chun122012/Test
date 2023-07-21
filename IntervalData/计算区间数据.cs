using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using IntervalData;


namespace IntervalData
{
    public partial class 计算区间数据 : Form
    {
        public 计算区间数据()
        {
            InitializeComponent();

            //初始化表格
            //根据Header和所有单元格的内容自动调整行的高度
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //设置内容对齐方式
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 设置所有列的自动调整模式为None
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 计算列宽度平均值
            int averageWidth = dataGridView1.Width / dataGridView1.Columns.Count;
            // 设置每一列的宽度
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                // 设置列宽度为平均宽度
                column.Width = averageWidth;
            }

            //添加事件
            dataGridView1.KeyDown += DataGridView1_KeyDown;
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
        }

        //点击回车添加新行
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //添加新的一行
                string[] data = { "", "", "" };

                dataGridView1.Rows.Add(data);
            }
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // 判断是否右击了单元格
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // 确保右击的是有效单元格
                {
                    dataGridView1.ClearSelection(); // 取消选中所有单元格
                    dataGridView1.Rows[e.RowIndex].Selected = true; // 选中右击的行

                    if (dataGridView1.Rows[e.RowIndex].Selected) // 只操作选中的行
                    {
                        if (MessageBox.Show("是否删除选中行？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            // 删除当前选中的行
                            dataGridView1.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }

        }

        //点击按钮输出文件
        private void button1_Click(object sender, EventArgs e)
        {
            //确定长度值
            int length = 0;
            try
            {
                length = int.Parse(textBox1.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("区间格式错误！");
            }
            //生成区间
            List<Interval> intervals = new List<Interval>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    string prefix, start, end;
                    prefix = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    start = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    end = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    //格式校验
                    if (prefix == "")
                    {
                        if (intervals[intervals.Count - 1].Start < int.Parse(dataGridView1.Rows[i - 1].Cells[1].Value.ToString()))
                        {
                            throw new Exception("起点不能小于上个区间的终点");
                        }
                        return;
                    }
                    else if (!Regex.IsMatch(prefix, "^[A-Z]{1}$"))
                    {
                        throw new Exception("前缀名称输入不正确");
                    }
                    else if (start == null || end == null || start.Length == 0 || end.Length == 0)
                    {
                        throw new Exception("起点、终点数据不能为空");
                    }

                    Interval interval = new Interval(prefix,int.Parse(start),int.Parse(end));
                    if (i > 0 && interval.Start < int.Parse(dataGridView1.Rows[i - 1].Cells[2].Value.ToString()))
                    {
                        throw new Exception("前后区间应连贯");
                    }
                    intervals.Add(interval);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //生成字符串组
            List<string> IntervalData = new List<string>();
            //字符串的添加
            int x = 0;

            for (int j = 0; j < intervals.Count; j++)
            {
                int loselength = 0;
                //若为尾部区间
                if (j == (intervals.Count - 1))
                {
                    string s = IntervalData[IntervalData.Count - 1];
                    if (s.Count(c => c == ',') == 2)
                    {
                        s += intervals[j].Prefix + "," + x + "-无";
                    }
                    else
                    {
                        s = s.Substring(0, s.Length - 1);
                        int location = s.IndexOf(',');
                        location = s.IndexOf(',', location + 1);
                        s = s.Insert(location + 1, intervals[j].Prefix + "," + x + "-");
                    }
                    IntervalData[IntervalData.Count - 1] = s;

                    int count2 = (intervals[j].End - x) / length;
                    for (int i = 0; i < count2; i++)
                    {
                        string d1 = intervals[j].Prefix + "," + x + "," + intervals[j].Prefix + "," + (x + length) + "-无";
                        x += length;
                        IntervalData.Add(d1);
                    }
                    string end = intervals[j].Prefix + "," + x + "," + intervals[j].Prefix + "," + intervals[j].End + "-无";
                    IntervalData.Add(end);

                }
                else if (intervals[j].End < x)
                {
                    //跨过当前区间
                    IntervalData[IntervalData.Count - 1] += intervals[j].Prefix + "," + intervals[j].Start + "," + intervals[j].Prefix + "," + intervals[j].End + ",";
                }
                    //不跨过当前区间
                else
                {
                    if (j == 0)
                    {
                        int count = (intervals[j].End - x) / length;
                        for (int i = 0; i < count; i++)
                        {
                            string d1 = intervals[j].Prefix + "," + x + "," + intervals[j].Prefix + "," + (x + length) + "-无";
                            x += length;
                            IntervalData.Add(d1);
                        }
                        //计算剩余长度
                        loselength = intervals[j].End - x;
                        string d2 = intervals[j].Prefix + "," + x + ",";
                        //计算新的结束点
                        x = intervals[j + 1].Start + length - loselength;
                        //添加语句前半部分
                        IntervalData.Add(d2);
                    }
                    else
                    {
                        //字符串拼接后半句
                        string s = IntervalData[IntervalData.Count - 1];
                        if (s.Count(c => c == ',') == 2)
                        {
                            s += intervals[j].Prefix + "," + x + "-无";
                        }
                        else
                        {
                            s = s.Substring(0, s.Length - 1);
                            int location = s.IndexOf(',');
                            location = s.IndexOf(',', location + 1);
                            s = s.Insert(location + 1, intervals[j].Prefix + "," + x + "-");
                        }
                        IntervalData[IntervalData.Count - 1] = s;

                        int count = (intervals[j].End - x) / length;
                        for (int i = 0; i < count; i++)
                        {
                            string d1 = intervals[j].Prefix  + "," + x + "," + intervals[j].Prefix + "," + (x + length) + "-无";
                            x += length;
                            IntervalData.Add(d1);
                        }
                        loselength = intervals[j].End - x;
                        string d2 = intervals[j].Prefix + "," + x + ",";
                        x = intervals[j + 1].Start + length - loselength;
                        IntervalData.Add(d2);
                    }

                }

            }

            //输出文件
            string filePath = @"D:\区间数据.txt"; // 文件路径
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                foreach (string s in IntervalData)
                {
                    streamWriter.WriteLine(s);
                }
            }
            MessageBox.Show("输出文件成功");
        }

    }
}