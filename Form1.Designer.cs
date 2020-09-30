namespace Cursor
{
    partial class Form1
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
            this.banggia = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_sell = new System.Windows.Forms.Button();
            this.bt_buy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banggia)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.banggia);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 547);
            this.panel1.TabIndex = 0;
            // 
            // banggia
            // 
            this.banggia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.banggia.Location = new System.Drawing.Point(5, 3);
            this.banggia.Name = "banggia";
            this.banggia.ReadOnly = true;
            this.banggia.Size = new System.Drawing.Size(1140, 542);
            this.banggia.TabIndex = 0;
            this.banggia.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.table_OnClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_cancel);
            this.panel2.Controls.Add(this.bt_sell);
            this.panel2.Controls.Add(this.bt_buy);
            this.panel2.Location = new System.Drawing.Point(352, 566);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 84);
            this.panel2.TabIndex = 1;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(286, 32);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 2;
            this.bt_cancel.Text = "Hủy";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_sell
            // 
            this.bt_sell.Location = new System.Drawing.Point(162, 32);
            this.bt_sell.Name = "bt_sell";
            this.bt_sell.Size = new System.Drawing.Size(75, 23);
            this.bt_sell.TabIndex = 1;
            this.bt_sell.Text = "Bán";
            this.bt_sell.UseVisualStyleBackColor = true;
            this.bt_sell.Click += new System.EventHandler(this.Open_SellForm);
            // 
            // bt_buy
            // 
            this.bt_buy.Location = new System.Drawing.Point(31, 32);
            this.bt_buy.Name = "bt_buy";
            this.bt_buy.Size = new System.Drawing.Size(75, 23);
            this.bt_buy.TabIndex = 0;
            this.bt_buy.Text = "Mua";
            this.bt_buy.UseVisualStyleBackColor = true;
            this.bt_buy.Click += new System.EventHandler(this.Open_TradeForm);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Bảng giá trực tuyến - N17DCCN155 - Cursor";
            this.Load += new System.EventHandler(this.BangGia_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.banggia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView banggia;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_sell;
        private System.Windows.Forms.Button bt_buy;
    }
}

