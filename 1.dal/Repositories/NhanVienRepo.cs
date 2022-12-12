using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.DAODbContext;

namespace _1.dal.Repositories
{
    public class NhanVienRepo : iNhanVienRepo
    {
        private DAOTeam06DbContext dbContext;
        public NhanVienRepo()
        {
            dbContext = new DAOTeam06DbContext();
        }
        public bool Add(NhanVien obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(NhanVien obj)
        {
            if (obj == null) return false;
            var temp = dbContext.nhanViens.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        public List<NhanVien> GetAllNv()
        {
            return dbContext.nhanViens.ToList();
        }

        public NhanVien GetById(Guid id)
        {
            return dbContext.nhanViens.FirstOrDefault(c => c.id == id);
        }

        public bool Update(NhanVien obj)
        {
            if (obj == null) return false;
            var temp = dbContext.nhanViens.FirstOrDefault(c => c.id == obj.id);
            temp.idCv = obj.idCv;
            temp.ma = obj.ma;
            temp.ho = obj.ho;
            temp.tenDem = obj.tenDem;
            temp.ten = obj.ten;
            temp.ngSinh = obj.ngSinh;
            temp.gioiTinh = obj.gioiTinh;
            temp.sdt = obj.sdt;
            temp.diaChi = obj.diaChi;
            temp.thanhPho = obj.thanhPho;
            temp.quocGia = obj.quocGia;
            temp.trangThai = obj.trangThai;
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
