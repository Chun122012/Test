using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IntervalData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Forml_Load;
        }

        private void Forml_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("前缀名称", typeof(string));
            dt.Columns.Add("起点", typeof(int));
            dt.Columns.Add("终点", typeof(int));

            dt.Rows.Add("K", 0, 1300);
            //dt.Rows.Add("A", 1400, 1480);
            //dt.Rows.Add("B", 1480, 1500);
            //dt.Rows.Add("C", 1500, 3000);
            //dt.Rows.Add("D", 3000, 3050);
            //dt.Rows.Add("E", 3050, 3800);
            //dt.Rows.Add("F", 3950, 4500);

            // 绑定数据到DataGridView
            dataGridView1.DataSource = dt;
            // 在窗口加载事件中注册DataGridView的KeyPress事件
            dataGridView1.KeyDown += DataGridView1_KeyDown;
            // 在窗口加载事件中注册DataGridView的CellMouseDown事件
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 填满整个 DataGridView 并自动调整列宽
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells; // 根据已显示的单元格内容自动调整行高


        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // 判断按下的键是否是回车键
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;  // 处理回车键事件，防止触发默认的换行行为

                int rowCount = dataGridView1.Rows.Count;
                int colCount = dataGridView1.Columns.Count;
                bool isValid = true;

                for (int col = 0; col < colCount; col++)
                {
                    if (col == 0)
                    {
                        // 第一列不能为空
                        if (dataGridView1.Rows[rowCount - 1].Cells[col].Value == null
                            || string.IsNullOrEmpty(dataGridView1.Rows[rowCount - 1].Cells[col].Value.ToString()))
                        {
                            isValid = false;
                            MessageBox.Show("第一列不能为空");
                            break;
                        }
                    }
                    else
                    {
                        // 第二列和第三列必须是数字
                        if (dataGridView1.Rows[rowCount - 1].Cells[col].Value != null
                            && !double.TryParse(dataGridView1.Rows[rowCount - 1].Cells[col].Value.ToString(), out double value))
                        {
                            isValid = false;
                            MessageBox.Show("第二列和第三列必须是数字");
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    // 获取当前数据表格绑定的数据源
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    // 添加新的一行
                    DataRow newRow = dt.NewRow();
                    dt.Rows.Add(newRow);
                    // 设置新行为当前行
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];

                    // 设置编辑模式
                    dataGridView1.BeginEdit(true);
                }
            }
        }
        
        //private void DataGridView1_KeyDown(object sender, KeyPressEventArgs e)
        //{
        //    // 判断按下的键是否是回车键
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        e.Handled = true;  // 处理回车键事件，防止触发默认的换行行为

        //        // 获取当前数据表格绑定的数据源
        //        DataTable dt = (DataTable)dataGridView1.DataSource;
        //        // 添加新的一行
        //        DataRow newRow = dt.NewRow();
        //        dt.Rows.Add(newRow);
        //        // 设置新行为当前行
        //        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];

        //        // 设置编辑模式
        //        dataGridView1.BeginEdit(true);
        //    }
        //}


        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // 判断是否右击了单元格
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // 确保右击的是有效单元格
                {
                    dataGridView1.ClearSelection(); // 取消选中所有单元格
                    dataGridView1.Rows[e.RowIndex].Selected = true; // 选中右击的行
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
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
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!int.TryParse(textBox1.Text, out int Interval))
            {
                MessageBox.Show("请输入正确的区间", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<List<string>> values = new List<List<string>>(); // 创建一个集合储存单元格的值

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                List<string> rowValues = new List<string>(); // 创建一个集合储存一行的单元格值

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    DataGridViewCell cell = row.Cells[j]; // 获取当前行的当前列单元格
                    string value = cell.Value?.ToString() ?? ""; // 获取单元格的值并转换为字符串

                    // 将单元格的值添加到行值集合中
                    rowValues.Add(value);
                }

                // 将一行的值集合添加到总集合中
                values.Add(rowValues);
            }
            if (Interval >= Convert.ToInt32(values[2]))
            {
                for(int i = Interval;i >= Convert.ToInt32(values[2]); i += Interval)
                {
                    Console.WriteLine(values[0] + "," + 0 + "," + values[0] + "," +Interval);

                }
            }
            
            







        }
    }
}
