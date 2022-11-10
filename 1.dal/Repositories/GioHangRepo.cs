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
    public class GioHangRepo : iGioHangRepo
    {
        private DAODbContext dbContext;
        public GioHangRepo()
        {
            dbContext= new DAODbContext();  
        }
        bool iGioHangRepo.Add(GioHang obj)
        {
            if (obj == null) return false;
            obj.id=Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iGioHangRepo.Delete(GioHang obj)
        {
            if (obj == null) return false;
            var temp = dbContext.gioHangs.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(obj);
            dbContext.SaveChanges();
            return true;
        }

        List<GioHang> iGioHangRepo.GetAllGh()
        {
            return dbContext.gioHangs.ToList();
        }

        GioHang iGioHangRepo.GetById(Guid id)
        {
            return dbContext.gioHangs.FirstOrDefault(c => c.id == id);
        }

        bool iGioHangRepo.Update(GioHang obj)
        {
            if (obj == null) return false;
            var temp = dbContext.gioHangs.FirstOrDefault(c => c.id == obj.id);
            temp.idNv = obj.idNv;
            temp.ma = obj.ma;
            temp.ngTao = obj.ngTao;
            temp.ngThanhToan=obj.ngThanhToan;
            temp.tinhTrang = obj.tinhTrang; 
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
