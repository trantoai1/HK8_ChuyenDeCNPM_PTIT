using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursor
{
    public partial class Form1 : Form
    {
        private Dictionary<string, CoPhieu> list;
        public Form1()
        {
            InitializeComponent();
            try
            {
                SqlClientPermission dd = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                dd.Demand();
                this.list = new Dictionary<string, CoPhieu>();
                con = new SqlConnection(m_Connectstring);
               // frm_Current = new CancelCP();
            }
            catch (Exception)
            {

            }
             
        }
       
        private bool open = true;
        private void ResetNewDay()
        {
            int count = CheckDay();
            if (count > 0)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE dbo.LENHDAT SET TRANGTHAILENH=N'Chưa khớp' WHERE TRANGTHAILENH IN (N'Chờ khớp',N'Khớp lệnh 1 phần') AND DATEDIFF(DAY,NGAYDAT,@Ngay)=@count", con);
                cmd.Parameters.AddWithValue("@Ngay", DateTime.Today);
                cmd.Parameters.AddWithValue("@count", count);
                try
                {

                    if (cmd.ExecuteNonQuery()==1)
                    {
                        //Test("Cập nhật thành công");
                    }

                   
                }
                catch (SqlException)
                {
                    Test("Thất bại");
                }
                catch (NullReferenceException)
                {

                }
                finally
                {
                                        con.Close();
                }
            }    
        }

        private SetTrade frm_Trade;
        private CancelCP frm_Current;
        public string m_Connectstring = Connect.strConnect;
        public delegate void NewDemo();
        public event NewDemo OnNewDemo;
        SqlConnection con;

       

        private void BangGia_Load(object sender, EventArgs e)
        {
            
            SqlDependency.Stop(m_Connectstring);
            SqlDependency.Start(m_Connectstring);
            OnNewDemo = new NewDemo(Form1_OnNewDemo);
            
            LoadData();
        }

        private void Form1_OnNewDemo()
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)
            {
                NewDemo te = new NewDemo(Form1_OnNewDemo);
                i.BeginInvoke(te, null);
                return;
            }
            LoadData();
        }

        //Ham Lay Du lieu tu database

        void LoadData()
        {
            if(open)
            {
                ResetNewDay();
               
            }    
            Load_MaCK();
            Load_DuMua();
            Load_DuBan();
            
            Load_Khop();
           






            DataTable dt = new DataTable();
           
            //dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            dt.Columns.Add("Mã CP", typeof(string));
            
            dt.Columns.Add("Giá mua 2", typeof(string));

            dt.Columns.Add("SL mua 2", typeof(string));

            dt.Columns.Add("Giá mua 1", typeof(string));
            dt.Columns.Add("SL mua 1", typeof(string));
            //======================
            dt.Columns.Add("Giá Khớp", typeof(string));
            dt.Columns.Add("Số lượng", typeof(string));
            //======================
            dt.Columns.Add("Giá bán 1", typeof(string));
            dt.Columns.Add("SL bán 1", typeof(string));
            dt.Columns.Add("Giá bán 2", typeof(string));
            dt.Columns.Add("SL bán 2", typeof(string));
            
            foreach (CoPhieu s in list.Values)
            {
                DataRow dr = dt.NewRow();
                dr[0] = s.MaCK;
               
                bool display = false;
                try
                {
                    if (s.Dumua[0].Gia > 0)
                    {
                        dr[3]= s.Dumua[0].Gia;
                        

                        dr[4]= s.Dumua[0].Soluong;
                        if (s.Dumua[1].Gia > 0)
                        {
                            dr[1] = s.Dumua[1].Gia;

                            dr[2] = s.Dumua[1].Soluong;
                        }

                        display = true;
                    }
                    
                    if (s.Duban[0].Gia > 0)
                    {
                        dr[7] = s.Duban[0].Gia;

                        dr[8] = s.Duban[0].Soluong;
                        if (s.Duban[1].Gia > 0)
                        {
                            dr[9] = s.Duban[1].Gia;

                            dr[10] = s.Duban[1].Soluong;
                        }
                        display = true;

                    }
                    if (s.Khop.Gia > 0)
                    {
                        dr[5] = s.Khop.Gia;
                        dr[6] = s.Khop.Soluong;
                        display = true;
                    }    
                    if (display)
                        dt.Rows.Add(dr);
                    
                    
                }
                catch(NullReferenceException)
                {
                   
                }

                
            }
            
            banggia.DataSource = dt;
            if(!open)
            try
            {
                foreach (DataGridViewRow Myrow in banggia.Rows)
                {            //Here 2 cell is target value and 1 cell is Volume
                    foreach (CoPhieu x in this.list.Values)
                    {
                        if (Myrow.Cells[0].Value.Equals(x.MaCK))
                        {
                            Myrow.Cells[1].Style.ForeColor = x.Dumua[1].C_gia.F;
                            Myrow.Cells[1].Style.BackColor = x.Dumua[1].C_gia.B;
                            Myrow.Cells[2].Style.ForeColor = x.Dumua[1].C_sl.F;
                            Myrow.Cells[2].Style.BackColor = x.Dumua[1].C_sl.B;

                            Myrow.Cells[3].Style.ForeColor = x.Dumua[0].C_gia.F;
                            Myrow.Cells[3].Style.BackColor = x.Dumua[0].C_gia.B;
                            Myrow.Cells[4].Style.ForeColor = x.Dumua[0].C_sl.F;
                            Myrow.Cells[4].Style.BackColor = x.Dumua[0].C_sl.B;

                            Myrow.Cells[5].Style.ForeColor = x.Khop.C_gia.F;
                            Myrow.Cells[5].Style.BackColor = x.Khop.C_gia.B;
                            Myrow.Cells[6].Style.ForeColor = x.Khop.C_sl.F;
                            Myrow.Cells[6].Style.BackColor = x.Khop.C_sl.B;
                                
                            Myrow.Cells[7].Style.ForeColor = x.Duban[0].C_gia.F;
                            Myrow.Cells[7].Style.BackColor = x.Duban[0].C_gia.B;
                            Myrow.Cells[8].Style.ForeColor = x.Duban[0].C_sl.F;
                            Myrow.Cells[8].Style.BackColor = x.Duban[0].C_sl.B;

                            Myrow.Cells[9].Style.ForeColor = x.Duban[1].C_gia.F;
                            Myrow.Cells[9].Style.BackColor = x.Duban[1].C_gia.B;
                            Myrow.Cells[10].Style.ForeColor = x.Duban[1].C_sl.F;
                            Myrow.Cells[10].Style.BackColor = x.Duban[1].C_sl.B;
                            break;
                        }
                    }
                }
            }
            catch(Exception)
            {

            }
            
                    open = false;
                
        }
        private Int32 CheckDay()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) DATEDIFF(DAY,(SELECT MAX(NGAYDAT) FROM dbo.LENHDAT), @Ngay) FROM dbo.LENHDAT", con);
            cmd.Parameters.AddWithValue("@Ngay", DateTime.Today);
            try
            {

                SqlDataReader rs = cmd.ExecuteReader();


                if (rs.Read())
                {
                  
                        
                      return rs.GetInt32(0);
                    
                }
                rs.Close();

            }
            catch (SqlException)
            {

            }
            catch (NullReferenceException)
            {
                
            }
            finally
            {
               
                cmd.Dispose();
                con.Close();
            }
            return 0;
        }
        private void Test(string s)
        {
            MessageBox.Show(this, s, "Thông báo", MessageBoxButtons.YesNoCancel);
        }
        private void Load_Khop()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //Neu select * thi khong dc nhe
            //SELECT * FROM TheoDoi nhu the nay khong dc phai select field
            //va from thi truoc table phai co dbo.

            foreach (CoPhieu x in list.Values)
            {
                SqlCommand cmd = new SqlCommand("SELECT  LK.GIAKHOP,LK.SOLUONGKHOP   from dbo.LENHKHOP LK,dbo.LENHDAT LD  Where LD.MACP = @macp and LK.NGAYKHOP >=@Ngay  AND LK.IDLENHDAT=LD.ID order by LK.NGAYKHOP DESC", con);
                cmd.Parameters.AddWithValue("@macp", x.MaCK);
                cmd.Parameters.AddWithValue("@Ngay", DateTime.Today);
                //cmd.Parameters.AddWithValue("@loaigd", "B");
                double giatam =  x.Khop.Gia;
                int sltam =  x.Khop.Soluong;
                x.Khop.C_gia.MacDinh();
                x.Khop.C_sl.MacDinh();
                x.Khop.Gia = 0;
                x.Khop.Soluong = 0;
                // SqlDependency de = new SqlDependency(cmd);
                //de.OnChange += new OnChangeEventHandler(de_OnChange);//tab\'
                try
                {

                    SqlDataReader rs = cmd.ExecuteReader();

                    
                    if (rs.Read())
                    {
                        
                            x.Khop.Gia = rs.GetDouble(0);
                            x.Khop.Soluong = rs.GetInt32(1);
                        if (giatam < x.Khop.Gia)
                            x.Khop.C_gia.Tang();
                        else if (giatam > x.Khop.Gia)
                            x.Khop.C_gia.Giam();
                        else
                            x.Khop.C_gia.MacDinh();

                        if (sltam < x.Khop.Soluong)
                            x.Khop.C_sl.Tang();
                        else if (sltam > x.Khop.Soluong)
                            x.Khop.C_sl.Giam();
                        else
                            x.Khop.C_sl.MacDinh();
                    }

                    rs.Close();
                }
                catch (SqlException )
                {

                }
                catch(NullReferenceException )
                {

                }


            }

            con.Close();
        }
        internal static List<LenhGD> current = new List<LenhGD>();
        internal static List<LenhGD> Current { get => current; set => current = value; }
        private void Load_DuBan()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //Neu select * thi khong dc nhe
            //SELECT * FROM TheoDoi nhu the nay khong dc phai select field
            //va from thi truoc table phai co dbo.

            foreach (CoPhieu x in list.Values)
            {
                SqlCommand cmd = new SqlCommand("EXEC SP_DU @macp,@Ngay,@loaigd", con);
                cmd.Parameters.AddWithValue("@macp", x.MaCK);

                cmd.Parameters.AddWithValue("@Ngay", DateTime.Today);
                cmd.Parameters.AddWithValue("@loaigd", "B");
                double []giatam = { x.Duban[0].Gia, x.Duban[1].Gia };
                int []sltam = { x.Duban[0].Soluong, x.Duban[1].Soluong };
                x.Duban[0].Gia = 0;
                x.Duban[0].Soluong = 0;
                x.Duban[1].Gia = 0;
                x.Duban[1].Soluong = 0;
                x.Duban[0].C_gia.MacDinh();
                x.Duban[0].C_sl.MacDinh();
                x.Duban[1].C_gia.MacDinh();
                x.Duban[1].C_sl.MacDinh();
                //Console.WriteLine(DateTime.Parse(DateTime.Now.ToString("yyyyMMdd")));
                //SqlDependency de = new SqlDependency(cmd);
                //de.OnChange += new OnChangeEventHandler(de_OnChange1);//tab\'
                try
                {

                    SqlDataReader rs = cmd.ExecuteReader();

                    int i = 0;
                    while (rs.Read() && i < 2)
                    {
                        x.Duban[i].C_gia.MacDinh();
                        x.Duban[i].C_sl.MacDinh();
                        x.Duban[i].Gia = rs.GetDouble(1);
                        x.Duban[i].Soluong = rs.GetInt32(2);
                        if (giatam[i] < x.Duban[i].Gia)
                            x.Duban[i].C_gia.Tang();
                        else if (giatam[i] > x.Duban[i].Gia)
                            x.Duban[i].C_gia.Giam();
                        else
                            x.Duban[i].C_gia.MacDinh();

                        if (sltam[i] < x.Duban[i].Soluong)
                            x.Duban[i].C_sl.Tang();
                        else if (sltam[i] > x.Duban[i].Soluong)
                            x.Duban[i].C_sl.Giam();
                        else
                            x.Duban[i].C_sl.MacDinh();

                        i++;
                        
                    }

                    rs.Close();
                }
                catch (SqlException )
                {

                }


            }

            con.Close();
        }
        private void Load_Current()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //Neu select * thi khong dc nhe
            //SELECT * FROM TheoDoi nhu the nay khong dc phai select field
            //va from thi truoc table phai co dbo.
            foreach (LenhGD s in Form1.current)
            {
                SqlCommand cmd = new SqlCommand("SELECT ID,SOLUONG,TRANGTHAILENH from dbo.LENHDAT WHERE MACP=@macp AND DATEDIFF(MINUTE,NGAYDAT,@Ngay)<2 AND LOAIGD=@loaigd AND GIADAT=@gia", con);

                Console.WriteLine(s.Macp + " " + s.Time + " " + s.Gia);
                cmd.Parameters.AddWithValue("@macp", s.Macp);
                cmd.Parameters.AddWithValue("@Ngay", s.Time);
                cmd.Parameters.AddWithValue("@loaigd", s.Loaigd);
                cmd.Parameters.AddWithValue("@gia", s.Gia);
                
                try
                {
                    SqlDataReader rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        s.Id = rs.GetInt32(0);
                        s.Sl = rs.GetInt32(1);
                        s.Trangthai = rs.GetString(2);
                        Console.WriteLine(rs.GetInt32(0) + " " + rs.GetInt32(1) + " " + rs.GetString(2));
                    }
                    
                    rs.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //cmd.Parameters.AddWithValue("@Ngay", "20200331");
            con.Close();
        }
        private void Load_DuMua()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //Neu select * thi khong dc nhe
            //SELECT * FROM TheoDoi nhu the nay khong dc phai select field
            //va from thi truoc table phai co dbo.
            
            foreach (CoPhieu x in list.Values)
            {
                SqlCommand cmd = new SqlCommand("EXEC SP_DU @macp,@Ngay,@loaigd", con);
                cmd.Parameters.AddWithValue("@macp", x.MaCK);
                cmd.Parameters.AddWithValue("@Ngay", DateTime.Today);
                cmd.Parameters.AddWithValue("@loaigd", "M");
                double[] giatam = { x.Dumua[0].Gia, x.Dumua[1].Gia };
                int[] sltam = { x.Dumua[0].Soluong, x.Dumua[1].Soluong };
                x.Dumua[0].Gia = 0;
                x.Dumua[0].Soluong = 0;
                x.Dumua[1].Gia = 0;
                x.Dumua[1].Soluong = 0;
                x.Dumua[0].C_gia.MacDinh();
                x.Dumua[0].C_sl.MacDinh();
                x.Dumua[1].C_gia.MacDinh();
                x.Dumua[1].C_sl.MacDinh();
                //SqlDependency de = new SqlDependency(cmd);
                //de.OnChange += new OnChangeEventHandler(de_OnChange0);//tab\'
                try
                {

                    SqlDataReader rs = cmd.ExecuteReader();
                    
                    int i = 0;
                    while (rs.Read()&& i<2)
                    {
                       
                        x.Dumua[i].Gia = rs.GetDouble(1);
                        x.Dumua[i].Soluong = rs.GetInt32(2);
                        if (giatam[i] < x.Dumua[i].Gia)
                            x.Dumua[i].C_gia.Tang();
                        else if (giatam[i] > x.Dumua[i].Gia)
                            x.Dumua[i].C_gia.Giam();
                        else
                            x.Dumua[i].C_gia.MacDinh();

                        if (sltam[i] < x.Dumua[i].Soluong)
                            x.Dumua[i].C_sl.Tang();
                        else if (sltam[i] > x.Dumua[i].Soluong)
                            x.Dumua[i].C_sl.Giam();
                        else
                            x.Dumua[i].C_sl.MacDinh();
                        i++;
                    }

                    rs.Close();
                }
                catch (SqlException )
                {

                }
               
                
            }

            con.Close();


        }

        private void Load_MaCK()
        {
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //Neu select * thi khong dc nhe
            //SELECT * FROM TheoDoi nhu the nay khong dc phai select field
            //va from thi truoc table phai co dbo.
            SqlCommand cmd = new SqlCommand("SELECT MACP from dbo.LENHDAT", con);

            //cmd.Parameters.AddWithValue("@Ngay", "20200331");
            SqlDependency de = new SqlDependency(cmd);
            de.OnChange += new OnChangeEventHandler(de_OnChange);//tab\'
            try
            {
               // list.Clear();
                SqlDataReader rs = cmd.ExecuteReader();
                while (rs.Read())
                {
                    if(!list.ContainsKey(rs.GetString(0).Trim()))
                    list.Add(rs.GetString(0).Trim(), new CoPhieu(rs.GetString(0).Trim()));
                }
                rs.Close();
                con.Close();
            }
            catch(SqlException )
            {

            }

               
        }

        private void de_OnChange(object sender, SqlNotificationEventArgs e)
        {
           
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= de_OnChange;
            if (OnNewDemo != null)
            {
                OnNewDemo();
            }
        }

        private void Open_TradeForm(object sender, EventArgs e)
        {
            
            try
            {
                if (frm_Trade!=null)
                    frm_Trade.Visible = false;
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                frm_Trade = new SetTrade();
                frm_Trade.rb_buy.Checked = true;
                //frm_Trade.rb_sell.Checked = false;
                frm_Trade.Show();
            }
        }

        private void Open_SellForm(object sender, EventArgs e)
        {
            
            try
            {
                if (frm_Trade!=null)
                    frm_Trade.Visible = false;
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                frm_Trade = new SetTrade();
                //frm_Trade.rb_buy.Checked = true;
                frm_Trade.rb_sell.Checked = true;
                frm_Trade.Show();
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (frm_Current!=null)
                    frm_Current.Visible = false;
            }
            catch (NullReferenceException)
            {

            }
            frm_Current = new CancelCP();
            Load_Current();
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
                if (s.Loaigd.ToString().Equals("M"))
                    dr[2] = "Mua";
                else
                    dr[2] = "Bán";
                dr[3] = s.Time;//.ToString("dd-MM-yyyy");
                dr[4] = s.Gia;
                dr[5] = s.Sl;
                if (s.Id == 0)
                    dr[6] = "Khớp hết";
                else
                    dr[6] = s.Trangthai;
                dt2.Rows.Add(dr);
            }
            frm_Current.table_cancel.Rows.Clear();
            frm_Current.table_cancel.Refresh();
            frm_Current.table_cancel.DataSource = dt2;
            frm_Current.Show();
        }

        private void table_OnClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //frm_Current.Hide();
            if (e.ColumnIndex == 0)
            {
                try
                {
                    if (frm_Trade!=null)
                        frm_Trade.Visible = false;
                }
                catch (NullReferenceException)
                {

                }
                finally
                {
                    frm_Trade = new SetTrade();
                    frm_Trade.rb_buy.Checked = true;
                    //frm_Trade.rb_sell.Checked = true;
                    frm_Trade.Show();
                    frm_Trade.txt_macp.Text = banggia.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() ;
                    frm_Trade.txt_macp.ReadOnly = true;
                }
            }
            else if(e.ColumnIndex > 0 && e.ColumnIndex <=4)
            {
                try
                {
                    if (frm_Trade != null)
                        frm_Trade.Visible = false;
                }
                catch (NullReferenceException)
                {

                }
                finally
                {
                    frm_Trade = new SetTrade();
                    //frm_Trade.rb_buy.Checked = true;
                    frm_Trade.rb_sell.Checked = true;
                    frm_Trade.Show();
                    frm_Trade.txt_macp.Text = banggia.Rows[e.RowIndex].Cells[0].Value.ToString();
                    frm_Trade.txt_macp.ReadOnly = true;
                    if(e.ColumnIndex >2)
                    {
                        frm_Trade.txt_gia.Text = banggia.Rows[e.RowIndex].Cells[3].Value.ToString();
                        frm_Trade.txt_sl.Text = banggia.Rows[e.RowIndex].Cells[4].Value.ToString();
                    }
                    else
                    {
                        frm_Trade.txt_gia.Text = banggia.Rows[e.RowIndex].Cells[1].Value.ToString();
                        frm_Trade.txt_sl.Text = banggia.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }    
                    
                }
            }
            else if (e.ColumnIndex >= 7 && e.ColumnIndex <= 10)
            {
                try
                {
                    if (frm_Trade != null)
                        frm_Trade.Visible = false;
                }
                catch (NullReferenceException)
                {

                }
                finally
                {
                    frm_Trade = new SetTrade();
                    frm_Trade.rb_buy.Checked = true;
                    //frm_Trade.rb_sell. = true;
                    frm_Trade.Show();
                    frm_Trade.txt_macp.Text = banggia.Rows[e.RowIndex].Cells[0].Value.ToString();
                    frm_Trade.txt_macp.ReadOnly = true;
                    if (e.ColumnIndex > 8)
                    {
                        frm_Trade.txt_gia.Text = banggia.Rows[e.RowIndex].Cells[9].Value.ToString();
                        frm_Trade.txt_sl.Text = banggia.Rows[e.RowIndex].Cells[10].Value.ToString();
                    }
                    else
                    {
                        frm_Trade.txt_gia.Text = banggia.Rows[e.RowIndex].Cells[7].Value.ToString();
                        frm_Trade.txt_sl.Text = banggia.Rows[e.RowIndex].Cells[8].Value.ToString();
                    }

                }
            }
        }
    }
}
