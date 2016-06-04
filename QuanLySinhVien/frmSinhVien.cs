using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien.WebServiceDemo.Service1 bien;
        public frmSinhVien()
        {
            bien = new WebServiceDemo.Service1();
            InitializeComponent();
       }
        public void LoadDuLieu()
        {
            dataGridView1.DataSource = bien.taobang("SINHVIEN");
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySinhVienDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.quanLySinhVienDataSet.SINHVIEN);
            LoadDuLieu();
            txtMaSV.Enabled = false;
            txtHoSv.Enabled = false;
            txtTenSv.Enabled = false;
            txtGioiTinh.Enabled = false;
            dateNgaySinh.Enabled = false;
            txtMaKhoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int flag;
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            txtMaSV.Enabled = true;
            txtHoSv.Enabled = true;
            txtTenSv.Enabled = true;
            txtGioiTinh.Enabled = true;
            dateNgaySinh.Enabled = true;
            txtMaKhoa.Enabled = true;

            txtMaSV.ResetText();
            txtMaKhoa.ResetText();
            txtGioiTinh.ResetText();
            txtHoSv.ResetText();
            txtTenSv.ResetText();
            dateNgaySinh.ResetText();

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnSua.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtMaSV.Enabled = false;
            txtHoSv.Enabled = true;
            txtTenSv.Enabled = true;
            txtGioiTinh.Enabled = true;
            dateNgaySinh.Enabled = true;
            txtMaKhoa.Enabled = true;

            txtMaSV.ResetText();
            txtMaKhoa.ResetText();
            txtGioiTinh.ResetText();
            txtHoSv.ResetText();
            txtTenSv.ResetText();
            dateNgaySinh.ResetText();

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnSua.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                bien.SinhVien_Xoa(txtMaSV.Text);
                LoadDuLieu();


                txtMaSV.ResetText();
                txtMaKhoa.ResetText();
                txtGioiTinh.ResetText();
                txtHoSv.ResetText();
                txtTenSv.ResetText();
                dateNgaySinh.ResetText();
                txtMaSV.Focus();

            }
            catch(Exception)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu xóa");
            }
            bien.myClose();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtMaSV.Enabled = false;
            txtHoSv.Enabled = false;
            txtTenSv.Enabled = false;
            txtGioiTinh.Enabled = false;
            dateNgaySinh.Enabled = false;

            if(flag==0)
            {
                try
                { 
                    bool gioitinh;
                    if(txtGioiTinh.Text=="Nam")
                    {
                        gioitinh = true;
                    }
                    else{gioitinh = false;}

                    DateTime NgaySing = dateNgaySinh.Value;
                    bien.SinhVien_Them(txtMaSV.Text,txtHoSv.Text,txtTenSv.Text,NgaySing,gioitinh,txtMaKhoa.Text);
                    LoadDuLieu();
                        txtMaSV.ResetText();
                    txtMaKhoa.ResetText();
                    txtGioiTinh.ResetText();
                    txtHoSv.ResetText();
                    txtTenSv.ResetText();
                    dateNgaySinh.ResetText();
                    txtMaSV.Focus();

                    btnLuu.Enabled =false;
                    btnHuy.Enabled =false;

                    btnSua.Enabled =true;
                    btnThem.Enabled =true;
                    btnXoa.Enabled =true;
                }

                catch(Exception)
                {
                    MessageBox.Show("Mã sinh viên đã có , vui lòng nhập lại",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                bien.myClose();
            }
            else if(flag==1)
            {

                DataTable dt = new DataTable();
                bool gioitinh;
                if (txtGioiTinh.Text == "Nam")
                {
                    gioitinh = true;
                }
                else { gioitinh = false; }

                DateTime NgaySing = dateNgaySinh.Value;
                bien.SinhVien_Sua(txtMaSV.Text, txtHoSv.Text, txtTenSv.Text, NgaySing, gioitinh, txtMaKhoa.Text);
                LoadDuLieu();
                txtMaSV.ResetText();
                txtMaKhoa.ResetText();
                txtGioiTinh.ResetText();
                txtHoSv.ResetText();
                txtTenSv.ResetText();
                dateNgaySinh.ResetText();
                txtMaSV.Focus();

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                LoadDuLieu();
                bien.myClose();
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaSV.ResetText();
            txtMaKhoa.ResetText();
            txtGioiTinh.ResetText();
            txtHoSv.ResetText();
            txtTenSv.ResetText();
            dateNgaySinh.ResetText();
            txtMaSV.Focus();

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            btnSua.Enabled = true ;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
