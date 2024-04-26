using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace POS_build
{
    public partial class FrmSell : MetroForm
    {
        SqlConnection connection = new SqlConnection(Helper.Common.ConnString);
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table = new DataTable();

        public FrmSell()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection(Helper.Common.ConnString);
            SqlCommand cmd_db = new SqlCommand("SELECT * FROM sales_tb;", con);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd_db;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //텍스트 박스 초기화
            textBox1.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM sales_tb WHERE CONCAT(name, price, count, total) like '%" + valueToSearch + "%'";
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "고유번호";
            dataGridView1.Columns[1].HeaderText = "상품명";
            dataGridView1.Columns[2].HeaderText = "가격";
            dataGridView1.Columns[3].HeaderText = "개수";
            dataGridView1.Columns[4].HeaderText = "합계";
            dataGridView1.Columns[5].HeaderText = "식별번호";
        }

        private void FrmSell_Load(object sender, EventArgs e)
        {
            searchData("");
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("검색 정보를 입력해주세요");
            }
            else
            {
                string valueToSearch = textBox1.Text.ToString();
                searchData(valueToSearch);
                //텍스트 박스 초기화
                textBox1.Text = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selData = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = selData.Cells[0].Value.ToString();
                textBox3.Text = selData.Cells[1].Value.ToString();
                textBox4.Text = selData.Cells[2].Value.ToString();
                textBox5.Text = selData.Cells[3].Value.ToString();
                textBox6.Text = selData.Cells[4].Value.ToString();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("항목을 정확히 입력해주세요");
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            decimal price = decimal.Parse(textBox4.Text);
            decimal count = decimal.Parse(textBox5.Text);
            decimal total = price * count;

            textBox6.Text = total.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();


                    var query = @"UPDATE [dbo].[sales_tb]
                                    SET [name] = @name
                                        ,[price] = @price
                                        ,[count] = @count
                                        ,[total] = @total
                                    WHERE no = @no";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmName = new SqlParameter("@name", textBox3.Text);
                    cmd.Parameters.Add(prmName);
                    SqlParameter prmPrice = new SqlParameter("@price", textBox4.Text);
                    cmd.Parameters.Add(prmPrice);
                    SqlParameter prmCount = new SqlParameter("@count", textBox5.Text);
                    cmd.Parameters.Add(prmCount);
                    SqlParameter prmTotal = new SqlParameter("@total", textBox6.Text);
                    cmd.Parameters.Add(prmTotal);
                    SqlParameter prmNo = new SqlParameter("@no", textBox2.Text);
                    cmd.Parameters.Add(prmNo);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this 메시지박스의 부모창이 누구냐, FrmLoginUser
                        MessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            LoadData();
            
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = "DELETE FROM [dbo].[sales_tb] WHERE no = @no";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmNo = new SqlParameter("@no", textBox2.Text);
                cmd.Parameters.Add(prmNo);

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MetroMessageBox.Show(this, "삭제성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this, "삭제실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            LoadData();
        }
    }
}
