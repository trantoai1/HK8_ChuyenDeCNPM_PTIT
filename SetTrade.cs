using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursor
{
    public partial class SetTrade : Form
    {
        public SetTrade()
        {
            InitializeComponent();
        }

        private void bt_confirm_Click(object sender, EventArgs e)
        {
            if(txt_macp.Text.Equals("") )
            {
                MessageBox.Show(this, "Mã cổ phiếu không thể trống", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if(!Regex.IsMatch(txt_macp.Text.ToUpper(), "^[A-Z]+"))
            {
                MessageBox.Show(this, "Mã cổ phiếu bắt đầu bằng chữ", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if (txt_macp.Text.Trim().Length>7)
            {
                MessageBox.Show(this, "Mã cổ phiếu tối đa 7 ký tự", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (txt_sl.Text.Equals(""))
            {
                MessageBox.Show(this, "Nhập số lượng", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (txt_gia.Text.Equals(""))
            {
                MessageBox.Show(this, "Nhập giá", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            
            string loai = "";
            if (rb_buy.Checked)
                loai = "M";
            else
                loai = "B";
            try
            {
                
                LenhGD gd = new LenhGD(txt_macp.Text.ToUpper().Trim(),Char.Parse(loai), DateTime.Now,Double.Parse(txt_gia.Text),Int32.Parse(txt_sl.Text));
                Form1.current.Add(gd);
                string m_Connectstring = Connect.strConnect;
                SqlConnection con = new SqlConnection(m_Connectstring);
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC dbo.SP_KHOPLENH_LO @macp,@Ngay,@loaigd,@sl,@gia", con);
                cmd.Parameters.AddWithValue("@macp", gd.Macp);
                cmd.Parameters.AddWithValue("@Ngay",gd.Time);
                cmd.Parameters.AddWithValue("@loaigd", gd.Loaigd);
                cmd.Parameters.AddWithValue("@sl", gd.Sl);
                cmd.Parameters.AddWithValue("@gia",gd.Gia);
                if(cmd.ExecuteNonQuery()==1)
                {
                    this.Visible = false;
                    MessageBox.Show(this, "Đặt thành công", "Thông báo", MessageBoxButtons.OK);
                }    
            }
            catch(SqlException e1)
            {
                Test(e1.Message);
            }
            catch (Exception e1)
            {
                Test(e1.Message);
            }
        }
        private void Test(string s)
        {
            MessageBox.Show(this, s, "Thông báo", MessageBoxButtons.OK);
        }
        private void textBox1_KeyPress_Double(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox1_KeyPress_Int(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

            // only allow one decimal point
            
        }
        private void textBox1_KeyPress_Char(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                
                e.Handled = true;
            }

            // only allow one decimal point

        }
    }
}
