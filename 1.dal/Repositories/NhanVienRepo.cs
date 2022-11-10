using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;
using _1.dal.iRepositories;

namespace _1.dal.Repositories
{
    public class NhanVienRepo : iNhanVienRepo
    {
        private DAODbContext dbContext;
        public NhanVienRepo()
        {
            dbContext = new DAODbContext();
        }
        bool iNhanVienRepo.Add(NhanVien obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iNhanVienRepo.Delete(NhanVien obj)
        {
            if(obj == null) return false;
            var temp = dbContext.nhanViens.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        List<NhanVien> iNhanVienRepo.GetAllNv()
        {
            return dbContext.nhanViens.ToList();
        }

        NhanVien iNhanVienRepo.GetById(Guid id)
        {
            return dbContext.nhanViens.FirstOrDefault(c=>c.id==id);
        }

        bool iNhanVienRepo.Update(NhanVien obj)
        {
            if (obj == null) return false;
            var temp = dbContext.nhanViens.FirstOrDefault(c => c.id == obj.id);
            temp.idCh = obj.idCh;
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
