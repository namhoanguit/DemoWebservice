using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Services.Protocols;
using System.Data;

namespace WebServiceQLSV
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public SqlConnection con = new SqlConnection("Data Source=HOANGNAM-PC;Initial Catalog=QuanLySinhVien;Integrated Security=True");


        [WebMethod]
       public void myClose()
        { con.Close();  }

        [WebMethod]
        public void myconnect()
        { con.Open(); }


        ////////////////=========== SINH VIEN=======================

        [WebMethod]
        public DataTable taobang (string QLSV)
        {
            con.Open();
                string s;
            DataTable bang = new DataTable(QLSV);
            s = "SELECT MASV,HOSV,TENSV,MAKHOA,NGAYSINH,GIOITINH"+  QLSV;
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(bang);
            return bang;
        }

        [WebMethod]
        public void SinhVien_Them(string masv,string hosv,string tensv,DateTime ngaysinh ,bool gioitinh , string makhoa)
        {
            con.Open();
            string s = "INSERT INTO SINHVIEN(MASV,HOSV,TENSV,NGAYSINH,MAKHOA)" +
                "VALUES('" + masv + "','" + hosv + "','" + tensv + "','" + ngaysinh.ToShortDateString() + "','" + gioitinh + "','" + makhoa + "')";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void SinhVien_Xoa(string masv)
        {   
             con.Open();
             string s = "DELETE FROM SINHVIEN WHERE MASV ='" + masv + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }
        [WebMethod]
        public void  SinhVien_Sua(string masv,string hosv,string tensv,DateTime ngaysinh ,bool gioitinh , string makhoa)
        {
            con.Open();
            string s = "UPDATE  SINHVIEN SET HOTEN '"+ hosv +"' ,TENSV ='"+tensv+"' ,"+"NGAYSINH='" +ngaysinh.ToShortDateString()+"',GIOITINH='"+gioitinh+"',"+
                "MAKHOA ='"+makhoa+"' WHERE MASV ='"+masv+"'";
    
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }
        ////////////////=========== KHOA=======================

        [WebMethod]
        public DataTable TaoBangKhoa(String QLSV)
        {
            con.Open();
            string s;
            DataTable bangkhoa = new DataTable(QLSV);
            s = "SELECT MAKHOA ,TENKHOA " + QLSV;
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(bangkhoa);
            return bangkhoa;
        }

        [WebMethod]
        public void Khoa_Them(string makhoa , string tenkhoa)
        {
            con.Open();
            string s = "INSERT INTO KHOA(MAKHOA,TENKHOA) VALUES ('"+makhoa+"' , '"+tenkhoa+"')";
            SqlCommand scm = new SqlCommand();
            scm.ExecuteNonQuery();
        }
        [WebMethod]
        public void Khoa_Sua(string makhoa , string tenkhoa)
        {
            con.Open();
            string s = "UPDATE KHOA SET  TENKHOA ='" +tenkhoa + "' WHERE MAKHOA ='" + makhoa + "'";
            SqlCommand scm = new SqlCommand();
            scm.ExecuteNonQuery();
        }

        [WebMethod]
        public void Khoa_Xoa(string makhoa)
        {
            con.Open();
            string s = "DELETE FROM KHOA WHERE MAKHOA ='" + makhoa + "'";
            SqlCommand scm = new SqlCommand();
            scm.ExecuteNonQuery();
        }


        ////////////////=========== MON HOC =======================
        [WebMethod]
        public DataTable TaoBangMonHoc(String QLSV)
        {
            con.Open();
            string s;
            DataTable bangmonhoc = new DataTable(QLSV);
            s = "SELECT * FORM MONHOC " + QLSV;
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(bangmonhoc);
            return bangmonhoc;
        }

        public void MonHoc_Them(string mamonhoc,string tenmonhoc,int sotiet)
        {
            con.Open();
            string s = "INSERT INTO MONHOC(MAMH,TENMH,SOTIET)" +
                "VALUES('" + mamonhoc + "','" + tenmonhoc + "','" + sotiet + "')";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void MonHoc_Sua(string mamonhoc, string tenmonhoc, int sotiet)
        {
            con.Open();
            string s = "UPDATE MONHOC SET  TENMH ='" +tenmonhoc + "',SOTIET='"+sotiet+"' WHERE MAMH ='" + mamonhoc + "'";
            SqlCommand scm = new SqlCommand(s,con);
            scm.ExecuteNonQuery();
        }


        [WebMethod]
        public void MonHoc_Xoa(string mamonhoc)
        {
            con.Open();
            string s = "DELETE FROM MONHOC WHERE  MAMH ='" + mamonhoc + "'";
            SqlCommand scm = new SqlCommand(s,con);
            scm.ExecuteNonQuery();
        }

        ////////////////=========== KET QUA =======================
        [WebMethod]
        public DataTable TaoBangKQ(string QLSV)
        {
            con.Open();
            string s;
            DataTable TaoBangKQ = new DataTable(QLSV);
            s = " SELECT * FROM " + QLSV;

            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(TaoBangKQ);
            return TaoBangKQ;
        }

        [WebMethod]
        public void KetQua_Them(string masinhvien , string mamonhoc , int lanthi, int diem)
        {
            con.Open();
            string s = "INSERT INTO KETQUA(MASV,MANH,LANTHI,DIEM)" +
                "VALUES('" + masinhvien + "','" + mamonhoc + "','" + lanthi + "','"+diem+"')";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void KetQua_Sua(string masinhvien, string mamonhoc, int lanthi, int diem)
        {
            con.Open();
            string s = "UPDATE KETQUA SET  MAMH ='" + mamonhoc + "',LANTHI='" + lanthi + "',DIEM='" + diem + "' WHERE MASV ='"+masinhvien+"')";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void KetQua_Xoa(string masinhvien, string mamonhoc, int lanthi, int diem)
        {
            con.Open();
            string s = "DELETE FROM KETQUA WHERE MASV '" + masinhvien + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }


        ////////////////===========THONG KE MONHOC =======================
        [WebMethod]
        public DataTable TaoBangTKMonHoc(string mamonhoc)
        {
            con.Open();
            string s;
            DataTable dt = new DataTable(mamonhoc);
            s = "SELECT SINHVIEN.MASV,HOSV,TENSV,NGAYSINH,LANTHI,DIEM" +
                "FROM SINHVIEN,KETQUA WHERE SINHVIEN.MASV = KETQUA.MASV AND (KETQUA.MAMH ='" + mamonhoc + "')";
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(dt);
            return dt;
        }

            [WebMethod]
        public DataTable MONHOC_TimTheoMaMH(string mamonhoc)
        {
            con.Open();
            string s = "SELECT * FROM MONHOC WHERE MAMH ='" + mamonhoc + "'";
            DataTable dt = new DataTable(mamonhoc);
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(dt);
            return dt;
        }


        ////////////////===========THONG KE KHOA =======================

        [WebMethod]
        public DataTable TaoBangTKKhoa(string makhoa)
        {
            con.Open();
            string s;
            DataTable dt = new DataTable(makhoa);
            s = "SELECT MASV,HOSV,TENSV,NGAYSINH FROM SINHVIEN ,KHOA" +
                "WHERE SINHVIEN.MAKHOA = KHOA.MAKHOA AND (KHOA.MAKHOA ='" + makhoa+ "')";
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(dt);
            return dt;
        }


           [WebMethod]
        public DataTable Khoa_TimTheoMaKhoa(string mamonhoc)
        {
            con.Open();
            string s = "SELECT * FROM KHOA FROM MAKHOA ='" + mamonhoc + "'";
            DataTable dt = new DataTable(mamonhoc);
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(dt);
            return dt;
        }

        ////////////////===========THONG KE LAN THI =======================
           [WebMethod]
        public DataTable TaoBangTKLanThi(string lanthi)
        {
            con.Open();
            string s;
            DataTable dt = new DataTable(lanthi);
            s = "SELECT SV.MASV ,HOSV,TENSV,MH.MAMH,MH.TENMH,DIEM " +
                "FROM (SINHVIEN SV INNER JOIN KETQUA KQ ON SV.MASV = KQ.MASV)" +
                "INNER JOIN MONHOC MH ON MH.MAMH = KQ.MAMH" +
                "WHERE LANTHI '" + lanthi + "' ORDER BY SV.MASV ASC , KQ.DIEM DESC";
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(dt);
            return dt;
        }


           [WebMethod]
           public DataTable KetQua_TimTheoLanThi(string lanthi)
           {
               con.Open();
               string s = "SELECT * FROM KETQUA WHERE LANTHI ='"+lanthi+"'";
               DataTable dt = new DataTable(lanthi);
               SqlDataAdapter ds = new SqlDataAdapter(s, con);
               ds.Fill(dt);
               return dt;
           }


        ////////////////===========TIM KIEM THONG TIN SINH VIEN =======================
        [WebMethod]
        public DataTable TimKiem_ThongTinSV(string masinhvien)
           {
               con.Open();
               string s = "select hosv+tensv as 'hoten',ngaysinh," +
               "(case gioitinh when 'true' then N'Nam' else N'Nu' end ) as N'gioitinh',makhoa " +
               "from SinhVien where masv='" + masinhvien + "'";
               DataTable dt = new DataTable(masinhvien);
               SqlDataAdapter ds = new SqlDataAdapter(s, con);
               ds.Fill(dt);
            return dt;
           }

        [WebMethod]
        public DataTable TimKiem_ThongTinSVGridView(string masinhvien)
        {
            con.Open();
            string s = "select monhoc.mamh,tenmh,diem,lanthi" +
                "from sinhvien,ketqua,monhoc where ketqua.mamh = monhoc.mamh" +
                "and ketqua.masv = sinhvien.masv and sinhvien.masv ='" + masinhvien + "'";
            DataTable dt = new DataTable(masinhvien);
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(dt);
            return dt;
        }


        ////////////////===========TIM KIEM KET QUA HOC TAP =======================
        [WebMethod]
        public DataTable TimKiem_DiemTrungBinh(string masinhvien)
        {
            con.Open();
            string s = "select avg(diem) as diem from ketqua where masv='"+masinhvien+"'";
            DataTable dt = new DataTable(masinhvien);
            SqlDataAdapter ds = new SqlDataAdapter(s, con);
            ds.Fill(dt);
            return dt;
        }

    }
}