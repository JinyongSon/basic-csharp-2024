using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace POS_build
{
    public partial class FrmMain : MetroForm
    {
        DataTable table = new DataTable();
        
        public FrmMain()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Helper.Common.ConnString);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                label6.Text = "Connected";
                label6.ForeColor = Color.Black;
            }
            else
            {
                label6.Text = "DisConnected";
                label6.ForeColor = Color.Red;
            }

            RefreshData();
        }

        private void RefreshData()
        {
            table.Columns.Add("상품명", typeof(string));
            table.Columns.Add("가격", typeof(string));
            table.Columns.Add("개수", typeof(string));
            table.Columns.Add("합계", typeof(string));

            dataGridView1.DataSource = table;
            numericUpDown1.Value = 1;
        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("상품명을 입력해주세요");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("가격을 입력해주세요");
                return;
            }
            else
            {
                // 합계를 구하기 위해 품목명과 가격을 정의하고 total로 합침
                decimal price = decimal.Parse(textBox2.Text);
                decimal count = numericUpDown1.Value;
                decimal total = price * count;

                // text박스내의 정보를 표에 삽입
                table.Rows.Add(textBox1.Text, textBox2.Text, numericUpDown1.Value, total);
                dataGridView1.DataSource = table;

                // text박스의 정보 초기화
                textBox1.Clear();
                textBox2.Clear();
                numericUpDown1.Value = 1;

                // 합계
                decimal all = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    all += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                }
                textBox3.Text = all.ToString();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // 행 지우기
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }

            // 합계창에 수정된 값 넣기
            decimal all = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                all += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
            }

            textBox3.Text = all.ToString();
        }

        private void BtnCal_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                // 각 행의 정보를 반복문으로 불러옴
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    String Name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    String Price = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    String Count = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    String Total = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    // INSERT INTO 쿼리문으로 받아온 정보를 DB에 전송
                    var sql = string.Format("INSERT INTO sales_tb(name,price,count,total,c_num) " +
                                                             "VALUES  ('{0}',{1},{2},{3},{4})"
                                                                , @Name, @Price, @Count, @Total, @i);

                    var sql_count = string.Format("update item_tb set i_count = i_count - {0} where i_name = '{1}'", @Count, @Name);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        SqlCommand c_command = new SqlCommand(sql_count, conn);
                        c_command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            MessageBox.Show("계산되었습니다.");

            // 그리드뷰 초기화
            int rowCount = dataGridView1.Rows.Count;
            for (int n = 0; n < rowCount; n++)
            {
                if (dataGridView1.Rows[0].IsNewRow == false)
                    dataGridView1.Rows.RemoveAt(0);
            }

            // 함계창 초기화
            textBox3.Text = "0";
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            FrmSell dlg = new FrmSell();
            dlg.ShowDialog();
        }

        private void BtnInven_Click(object sender, EventArgs e)
        {
            FrmInven dlg = new FrmInven();
            dlg.ShowDialog();

        }
    }
}
