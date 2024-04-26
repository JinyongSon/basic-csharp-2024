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
    public partial class FrmInven : MetroForm
    {
        SqlConnection connection = new SqlConnection(Helper.Common.ConnString);
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table = new DataTable();

        public FrmInven()
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
            SqlCommand cmd_db = new SqlCommand("SELECT * FROM item_tb;", con);

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

            var answer = MessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = "DELETE FROM [dbo].[item_tb] WHERE no = @no";

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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conDataBase = new SqlConnection(Helper.Common.ConnString))
                {
                    conDataBase.Open();
                    var query = @"INSERT INTO [dbo].[item_tb]
                                            ([i_name]
                                            ,[i_price]
                                            ,[i_count])
                                        VALUES
                                            (@i_name
                                            ,@i_price
                                            ,@i_count)";    

                    SqlCommand cmd = new SqlCommand (query, conDataBase);

                    SqlParameter prmIname = new SqlParameter("@i_name", textBox3.Text);
                    cmd.Parameters.Add(prmIname);
                    SqlParameter prmIprice = new SqlParameter("@i_price", textBox4.Text);
                    cmd.Parameters.Add(prmIprice); 
                    SqlParameter prmCount = new SqlParameter("@i_count", textBox5.Text);
                    cmd.Parameters.Add(prmCount);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this 메시지박스의 부모창이 누구냐, FrmLoginUser
                        MetroMessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"오류  : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
    }
}
