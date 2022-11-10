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
    public class CuaHangRepo:iCuaHangRepo
    {
        private DAODbContext dbContext;
        public CuaHangRepo()
        {
            dbContext = new DAODbContext();
        }

        bool iCuaHangRepo.Add(CuaHang obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iCuaHangRepo.Delete(CuaHang obj)
        {
            if (obj == null) return false;
            var temp = dbContext.cuaHangs.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        List<CuaHang> iCuaHangRepo.GetAllCh()
        {
            return dbContext.cuaHangs.ToList();
        }

        CuaHang iCuaHangRepo.GetById(Guid id)
        {
           
            return dbContext.cuaHangs.FirstOrDefault(c=>c.id == id);
        }

        bool iCuaHangRepo.Update(CuaHang obj)
        {
            if (obj == null) return false;
            var temp = dbContext.cuaHangs.FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            temp.diaChi = obj.diaChi;
            temp.thanhPho = obj.thanhPho;
            temp.quocGia = obj.quocGia;
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
