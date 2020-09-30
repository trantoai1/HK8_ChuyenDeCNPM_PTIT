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

namespace Cursor
{
    public partial class CancelCP : Form
    {
        public CancelCP()
        {
            InitializeComponent();
            
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(table_cancel.Rows.Count <=1)
            {
                MessageBox.Show(this, "Bạn chưa đặt lệnh", "Nhắc nhở", MessageBoxButtons.OK);
                this.Visible = false;
                return;
            }
            else
            {
                int curR = table_cancel.CurrentCell.RowIndex;
                int curC = table_cancel.CurrentCell.ColumnIndex;
                //MessageBox.Show(this, curR +" "+ curC, "Nhắc nhở", MessageBoxButtons.OK);
                if (table_cancel[6, curR].Value.Equals("Khớp hết") || table_cancel[0, curR].Value.Equals("0"))
                {
                    MessageBox.Show(this, "Lệnh đã khớp hết không thể hủy", "Nhắc nhở", MessageBoxButtons.OK);
                    //this.Visible = false;
                    return;
                }
                if (table_cancel[6, curR].Value.Equals("Đã hủy") )
                {
                    MessageBox.Show(this, "Lệnh này đã hủy rồi", "Nhắc nhở", MessageBoxButtons.OK);
                    //this.Visible = false;
                    return;
                }
                else if(table_cancel[6, curR].Value.Equals("Chờ khớp")|| table_cancel[6, curR].Value.Equals("Khớp lệnh 1 phần") )
                {
                    string ID = table_cancel[0, curR].Value.ToString();
                    HuyLenhDat(ID);
                }    
            }    
        }

        private void HuyLenhDat(string iD)
        {
            try
            {
                string m_Connectstring = Connect.strConnect;
                SqlConnection con = new SqlConnection(m_Connectstring);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.LENHDAT SET TRANGTHAILENH=N'Đã hủy' WHERE ID=@id", con);
                cmd.Parameters.AddWithValue("@id",iD);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.Visible = false;
                    MessageBox.Show(this, "Hủy thành công lệnh " + iD, "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(this, "Hủy thất bại " + iD, "Lỗi", MessageBoxButtons.OK);
                }    
            }
            catch(SqlException e)
            {
                MessageBox.Show(this, e.Message , "Lỗi", MessageBoxButtons.OK);
            }
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(string));

            dt2.Columns.Add("Mã CP", typeof(string));

            dt2.Columns.Add("Loại GD", typeof(string));

            dt2.Columns.Add("Thời gian", typeof(string));
            dt2.Columns.Add("Giá", typeof(string));
            //======================
            dt2.Columns.Add("Số lượng", typeof(string));
            dt2.Columns.Add("Trạng thái", typeof(string));
            foreach (LenhGD s in Form1.current)
            {
                DataRow dr = dt2.NewRow();
                dr[0] = s.Id;
                dr[1] = s.Macp;
                if (s.Loaigd.Equals("M"))
                    dr[2] = "Mua";
                else
                    dr[2] = "Bán";
                dr[3] = s.Time.ToString("dd-MM-yyyy");
                dr[4] = s.Gia;
                dr[5] = s.Sl;
                if (s.Id == 0)
                    dr[6] = "Khớp hết";
                else
                    dr[6] = s.Trangthai;
                dt2.Rows.Add(dr);
            }
            table_cancel.DataSource = dt2;
            table_cancel.Show();
        }
    }
}
