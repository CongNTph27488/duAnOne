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
    public class HoaDonRepo : iHoaDonRepo
    {
        private DAODbContext dbContext;
        public HoaDonRepo()
        {
            dbContext = new DAODbContext();
        }
        bool iHoaDonRepo.Add(HoaDon obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iHoaDonRepo.Delete(HoaDon obj)
        {
            if (obj == null) return false;
            var temp = dbContext.hoaDons.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        List<HoaDon> iHoaDonRepo.GetAllHd()
        {
            return dbContext.hoaDons.ToList();  
        }

        HoaDon iHoaDonRepo.GetById(Guid id)
        {
            return dbContext.hoaDons.FirstOrDefault(c => c.id == id);
        }

        bool iHoaDonRepo.Update(HoaDon obj)
        {
            if (obj == null) return false;
            var temp = dbContext.hoaDons.FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ngTao = obj.ngTao;
            temp.ngThanhToan = obj.ngThanhToan;
            temp.idNv = obj.idNv;
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
