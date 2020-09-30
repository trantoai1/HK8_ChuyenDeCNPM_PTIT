namespace Cursor
{
    partial class SetTrade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_confirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_sell = new System.Windows.Forms.RadioButton();
            this.rb_buy = new System.Windows.Forms.RadioButton();
            this.txt_gia = new System.Windows.Forms.TextBox();
            this.txt_sl = new System.Windows.Forms.TextBox();
            this.txt_macp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.bt_confirm);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txt_gia);
            this.panel1.Controls.Add(this.txt_sl);
            this.panel1.Controls.Add(this.txt_macp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 357);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "đ";
            // 
            // bt_confirm
            // 
            this.bt_confirm.Location = new System.Drawing.Point(165, 282);
            this.bt_confirm.Name = "bt_confirm";
            this.bt_confirm.Size = new System.Drawing.Size(79, 28);
            this.bt_confirm.TabIndex = 6;
            this.bt_confirm.Text = "Xác nhận";
            this.bt_confirm.UseVisualStyleBackColor = true;
            this.bt_confirm.Click += new System.EventHandler(this.bt_confirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_sell);
            this.groupBox1.Controls.Add(this.rb_buy);
            this.groupBox1.Location = new System.Drawing.Point(134, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 61);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // rb_sell
            // 
            this.rb_sell.AutoSize = true;
            this.rb_sell.Location = new System.Drawing.Point(87, 19);
            this.rb_sell.Name = "rb_sell";
            this.rb_sell.Size = new System.Drawing.Size(44, 17);
            this.rb_sell.TabIndex = 0;
            this.rb_sell.TabStop = true;
            this.rb_sell.Text = "Bán";
            this.rb_sell.UseVisualStyleBackColor = true;
            // 
            // rb_buy
            // 
            this.rb_buy.AutoSize = true;
            this.rb_buy.Checked = true;
            this.rb_buy.Location = new System.Drawing.Point(19, 19);
            this.rb_buy.Name = "rb_buy";
            this.rb_buy.Size = new System.Drawing.Size(46, 17);
            this.rb_buy.TabIndex = 0;
            this.rb_buy.TabStop = true;
            this.rb_buy.Text = "Mua";
            this.rb_buy.UseVisualStyleBackColor = true;
            // 
            // txt_gia
            // 
            this.txt_gia.Location = new System.Drawing.Point(134, 126);
            this.txt_gia.Name = "txt_gia";
            this.txt_gia.Size = new System.Drawing.Size(149, 20);
            this.txt_gia.TabIndex = 4;
            this.txt_gia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress_Double);
            // 
            // txt_sl
            // 
            this.txt_sl.Location = new System.Drawing.Point(134, 80);
            this.txt_sl.Name = "txt_sl";
            this.txt_sl.Size = new System.Drawing.Size(149, 20);
            this.txt_sl.TabIndex = 3;
            this.txt_sl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress_Int);
            // 
            // txt_macp
            // 
            this.txt_macp.Location = new System.Drawing.Point(134, 38);
            this.txt_macp.Name = "txt_macp";
            this.txt_macp.Size = new System.Drawing.Size(149, 20);
            this.txt_macp.TabIndex = 2;
            this.txt_macp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress_Char);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đơn giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã cổ phiếu";
            // 
            // SetTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 366);
            this.Controls.Add(this.panel1);
            this.Name = "SetTrade";
            this.Text = "Đặt lệnh";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_confirm;
        public System.Windows.Forms.RadioButton rb_sell;
        public System.Windows.Forms.RadioButton rb_buy;
        public System.Windows.Forms.TextBox txt_gia;
        public System.Windows.Forms.TextBox txt_sl;
        public System.Windows.Forms.TextBox txt_macp;
        private System.Windows.Forms.Label label4;
    }
}