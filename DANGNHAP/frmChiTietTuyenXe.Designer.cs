namespace DANGNHAP
{
    partial class frmChiTietTuyenXe
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
            this.btn_tieude = new System.Windows.Forms.Button();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.cobTenTuyenXe = new System.Windows.Forms.ComboBox();
            this.lbl_tentuyen = new System.Windows.Forms.Label();
            this.cobMaTuyenXe = new System.Windows.Forms.ComboBox();
            this.lbl_dsthoidiemkhoihanh = new System.Windows.Forms.Label();
            this.txtGKH = new System.Windows.Forms.TextBox();
            this.lbl_giokhoihanh = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lbl_ngay = new System.Windows.Forms.Label();
            this.cobMTD = new System.Windows.Forms.ComboBox();
            this.lbl_mathoidiem = new System.Windows.Forms.Label();
            this.cobMSTX = new System.Windows.Forms.ComboBox();
            this.lbl_masotuyen = new System.Windows.Forms.Label();
            this.btn_Thoát = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtwChiTiet = new System.Windows.Forms.DataGridView();
            this.lbl_thoidiem = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_matuyenxe = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtwChiTiet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tieude
            // 
            this.btn_tieude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tieude.BackColor = System.Drawing.Color.Green;
            this.btn_tieude.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tieude.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_tieude.Location = new System.Drawing.Point(8, -2);
            this.btn_tieude.Margin = new System.Windows.Forms.Padding(4);
            this.btn_tieude.Name = "btn_tieude";
            this.btn_tieude.Size = new System.Drawing.Size(1069, 78);
            this.btn_tieude.TabIndex = 3;
            this.btn_tieude.Text = "CHI TIẾT TUYẾN XE";
            this.btn_tieude.UseVisualStyleBackColor = false;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThi.Location = new System.Drawing.Point(763, 17);
            this.btnHienThi.Margin = new System.Windows.Forms.Padding(4);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(281, 43);
            this.btnHienThi.TabIndex = 4;
            this.btnHienThi.Text = "Lọc danh sách theo mã tuyến";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // cobTenTuyenXe
            // 
            this.cobTenTuyenXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobTenTuyenXe.FormattingEnabled = true;
            this.cobTenTuyenXe.Location = new System.Drawing.Point(440, 17);
            this.cobTenTuyenXe.Margin = new System.Windows.Forms.Padding(4);
            this.cobTenTuyenXe.Name = "cobTenTuyenXe";
            this.cobTenTuyenXe.Size = new System.Drawing.Size(265, 30);
            this.cobTenTuyenXe.TabIndex = 3;
            // 
            // lbl_tentuyen
            // 
            this.lbl_tentuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_tentuyen.AutoSize = true;
            this.lbl_tentuyen.Location = new System.Drawing.Point(341, 21);
            this.lbl_tentuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tentuyen.Name = "lbl_tentuyen";
            this.lbl_tentuyen.Size = new System.Drawing.Size(86, 22);
            this.lbl_tentuyen.TabIndex = 2;
            this.lbl_tentuyen.Text = "Tên tuyến";
            // 
            // cobMaTuyenXe
            // 
            this.cobMaTuyenXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobMaTuyenXe.FormattingEnabled = true;
            this.cobMaTuyenXe.Location = new System.Drawing.Point(156, 17);
            this.cobMaTuyenXe.Margin = new System.Windows.Forms.Padding(4);
            this.cobMaTuyenXe.Name = "cobMaTuyenXe";
            this.cobMaTuyenXe.Size = new System.Drawing.Size(160, 30);
            this.cobMaTuyenXe.TabIndex = 1;
            // 
            // lbl_dsthoidiemkhoihanh
            // 
            this.lbl_dsthoidiemkhoihanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_dsthoidiemkhoihanh.AutoSize = true;
            this.lbl_dsthoidiemkhoihanh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_dsthoidiemkhoihanh.Location = new System.Drawing.Point(360, 0);
            this.lbl_dsthoidiemkhoihanh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_dsthoidiemkhoihanh.Name = "lbl_dsthoidiemkhoihanh";
            this.lbl_dsthoidiemkhoihanh.Size = new System.Drawing.Size(252, 22);
            this.lbl_dsthoidiemkhoihanh.TabIndex = 0;
            this.lbl_dsthoidiemkhoihanh.Text = "Danh sách thời điểm khởi hành";
            // 
            // txtGKH
            // 
            this.txtGKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGKH.Enabled = false;
            this.txtGKH.Location = new System.Drawing.Point(151, 204);
            this.txtGKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtGKH.Name = "txtGKH";
            this.txtGKH.Size = new System.Drawing.Size(265, 30);
            this.txtGKH.TabIndex = 8;
            // 
            // lbl_giokhoihanh
            // 
            this.lbl_giokhoihanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_giokhoihanh.AutoSize = true;
            this.lbl_giokhoihanh.Location = new System.Drawing.Point(20, 207);
            this.lbl_giokhoihanh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_giokhoihanh.Name = "lbl_giokhoihanh";
            this.lbl_giokhoihanh.Size = new System.Drawing.Size(122, 22);
            this.lbl_giokhoihanh.TabIndex = 7;
            this.lbl_giokhoihanh.Text = "Giờ khởi hành";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgay.Enabled = false;
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(151, 147);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(265, 30);
            this.dtpNgay.TabIndex = 6;
            // 
            // lbl_ngay
            // 
            this.lbl_ngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ngay.AutoSize = true;
            this.lbl_ngay.Location = new System.Drawing.Point(20, 156);
            this.lbl_ngay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ngay.Name = "lbl_ngay";
            this.lbl_ngay.Size = new System.Drawing.Size(51, 22);
            this.lbl_ngay.TabIndex = 5;
            this.lbl_ngay.Text = "Ngày";
            // 
            // cobMTD
            // 
            this.cobMTD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cobMTD.Enabled = false;
            this.cobMTD.FormattingEnabled = true;
            this.cobMTD.Location = new System.Drawing.Point(151, 95);
            this.cobMTD.Margin = new System.Windows.Forms.Padding(4);
            this.cobMTD.Name = "cobMTD";
            this.cobMTD.Size = new System.Drawing.Size(265, 30);
            this.cobMTD.TabIndex = 4;
            // 
            // lbl_mathoidiem
            // 
            this.lbl_mathoidiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_mathoidiem.AutoSize = true;
            this.lbl_mathoidiem.Location = new System.Drawing.Point(20, 103);
            this.lbl_mathoidiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_mathoidiem.Name = "lbl_mathoidiem";
            this.lbl_mathoidiem.Size = new System.Drawing.Size(116, 22);
            this.lbl_mathoidiem.TabIndex = 3;
            this.lbl_mathoidiem.Text = "Mã thời điểm";
            // 
            // cobMSTX
            // 
            this.cobMSTX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cobMSTX.Enabled = false;
            this.cobMSTX.FormattingEnabled = true;
            this.cobMSTX.Location = new System.Drawing.Point(151, 43);
            this.cobMSTX.Margin = new System.Windows.Forms.Padding(4);
            this.cobMSTX.Name = "cobMSTX";
            this.cobMSTX.Size = new System.Drawing.Size(265, 30);
            this.cobMSTX.TabIndex = 2;
            // 
            // lbl_masotuyen
            // 
            this.lbl_masotuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_masotuyen.AutoSize = true;
            this.lbl_masotuyen.Location = new System.Drawing.Point(20, 46);
            this.lbl_masotuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_masotuyen.Name = "lbl_masotuyen";
            this.lbl_masotuyen.Size = new System.Drawing.Size(105, 22);
            this.lbl_masotuyen.TabIndex = 1;
            this.lbl_masotuyen.Text = "Mã số tuyến";
            // 
            // btn_Thoát
            // 
            this.btn_Thoát.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Thoát.BackColor = System.Drawing.Color.Blue;
            this.btn_Thoát.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoát.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Thoát.Location = new System.Drawing.Point(848, 315);
            this.btn_Thoát.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Thoát.Name = "btn_Thoát";
            this.btn_Thoát.Size = new System.Drawing.Size(132, 64);
            this.btn_Thoát.TabIndex = 4;
            this.btn_Thoát.Text = "Thoát";
            this.btn_Thoát.UseVisualStyleBackColor = false;
            this.btn_Thoát.Click += new System.EventHandler(this.btn_Thoát_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xoa.BackColor = System.Drawing.Color.Blue;
            this.btn_xoa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_xoa.Location = new System.Drawing.Point(676, 315);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(132, 64);
            this.btn_xoa.TabIndex = 3;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtGKH);
            this.panel2.Controls.Add(this.lbl_giokhoihanh);
            this.panel2.Controls.Add(this.dtpNgay);
            this.panel2.Controls.Add(this.lbl_ngay);
            this.panel2.Controls.Add(this.cobMTD);
            this.panel2.Controls.Add(this.lbl_mathoidiem);
            this.panel2.Controls.Add(this.cobMSTX);
            this.panel2.Controls.Add(this.lbl_masotuyen);
            this.panel2.Location = new System.Drawing.Point(563, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 269);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.dtwChiTiet);
            this.groupBox1.Controls.Add(this.lbl_thoidiem);
            this.groupBox1.Controls.Add(this.btn_Thoát);
            this.groupBox1.Controls.Add(this.btn_xoa);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.lbl_dsthoidiemkhoihanh);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 71);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1048, 400);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dtwChiTiet
            // 
            this.dtwChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtwChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtwChiTiet.Location = new System.Drawing.Point(7, 39);
            this.dtwChiTiet.Name = "dtwChiTiet";
            this.dtwChiTiet.RowTemplate.Height = 24;
            this.dtwChiTiet.Size = new System.Drawing.Size(549, 306);
            this.dtwChiTiet.TabIndex = 10;
            this.dtwChiTiet.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtwChiTiet_CellMouseClick);
            // 
            // lbl_thoidiem
            // 
            this.lbl_thoidiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_thoidiem.AutoSize = true;
            this.lbl_thoidiem.BackColor = System.Drawing.Color.White;
            this.lbl_thoidiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_thoidiem.Location = new System.Drawing.Point(746, 27);
            this.lbl_thoidiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_thoidiem.Name = "lbl_thoidiem";
            this.lbl_thoidiem.Size = new System.Drawing.Size(94, 24);
            this.lbl_thoidiem.TabIndex = 9;
            this.lbl_thoidiem.Text = "Thời điểm";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnHienThi);
            this.panel1.Controls.Add(this.cobTenTuyenXe);
            this.panel1.Controls.Add(this.lbl_tentuyen);
            this.panel1.Controls.Add(this.cobMaTuyenXe);
            this.panel1.Controls.Add(this.lbl_matuyenxe);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 481);
            this.panel1.TabIndex = 2;
            // 
            // lbl_matuyenxe
            // 
            this.lbl_matuyenxe.AutoSize = true;
            this.lbl_matuyenxe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_matuyenxe.Location = new System.Drawing.Point(17, 21);
            this.lbl_matuyenxe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_matuyenxe.Name = "lbl_matuyenxe";
            this.lbl_matuyenxe.Size = new System.Drawing.Size(107, 24);
            this.lbl_matuyenxe.TabIndex = 0;
            this.lbl_matuyenxe.Text = "Mã tuyến xe";
            // 
            // frmChiTietTuyenXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 559);
            this.Controls.Add(this.btn_tieude);
            this.Controls.Add(this.panel1);
            this.Name = "frmChiTietTuyenXe";
            this.Text = "frmChiTietTuyenXe";
            this.Load += new System.EventHandler(this.frmChiTietTuyenXe_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtwChiTiet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tieude;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.ComboBox cobTenTuyenXe;
        private System.Windows.Forms.Label lbl_tentuyen;
        private System.Windows.Forms.ComboBox cobMaTuyenXe;
        private System.Windows.Forms.Label lbl_dsthoidiemkhoihanh;
        private System.Windows.Forms.TextBox txtGKH;
        private System.Windows.Forms.Label lbl_giokhoihanh;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lbl_ngay;
        private System.Windows.Forms.ComboBox cobMTD;
        private System.Windows.Forms.Label lbl_mathoidiem;
        private System.Windows.Forms.ComboBox cobMSTX;
        private System.Windows.Forms.Label lbl_masotuyen;
        private System.Windows.Forms.Button btn_Thoát;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_matuyenxe;
        private System.Windows.Forms.Label lbl_thoidiem;
        private System.Windows.Forms.DataGridView dtwChiTiet;
    }
}