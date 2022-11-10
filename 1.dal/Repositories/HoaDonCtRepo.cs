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
    public class HoaDonCtRepo : iHoaDonCtRepo
    {
        private DAODbContext dbContext;
        public HoaDonCtRepo()
        {
            dbContext=new DAODbContext();
        }
        bool iHoaDonCtRepo.Add(HoaDonCt obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iHoaDonCtRepo.Delete(HoaDonCt obj)
        {
            if (obj == null) return false;
            var temp=dbContext.hoaDonCts.FirstOrDefault(h => h.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        List<HoaDonCt> iHoaDonCtRepo.GetAllHdCt()
        {
            return dbContext.hoaDonCts.ToList();
        }

        HoaDonCt iHoaDonCtRepo.GetById(Guid id)
        {
            return dbContext.hoaDonCts.FirstOrDefault(h => h.id == id);
        }

        bool iHoaDonCtRepo.Update(HoaDonCt obj)
        {
            if (obj == null) return false;
            var temp = dbContext.hoaDonCts.FirstOrDefault(h => h.id == obj.id);
            temp.idSp = obj.idSp;
            temp.idHd = obj.idHd;
            temp.soLuong = obj.soLuong; 
            temp.thanhTien=obj.thanhTien;
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
