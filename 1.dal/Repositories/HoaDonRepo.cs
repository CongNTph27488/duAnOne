using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.DAODbContext;

namespace _1.dal.Repositories
{
    public class HoaDonRepo : iHoaDonRepo
    {
        private DAOTeam06DbContext dbContext;
        public HoaDonRepo()
        {
            dbContext = new DAOTeam06DbContext();
        }

        public bool Add(HoaDon obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDon obj)
        {
            if (obj == null) return false;
            var temp = dbContext.hoaDons.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        public List<HoaDon> GetAllHd()
        {
            return dbContext.hoaDons.ToList();
        }

        public HoaDon GetById(Guid id)
        {
            return dbContext.hoaDons.FirstOrDefault(c => c.id == id);
        }

        public bool Update(HoaDon obj)
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
