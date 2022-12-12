using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.DAODbContext;

namespace _1.dal.Repositories
{
    public class HoaDonChiTietRepo : iHoaDonChiTietRepo
    {
        private DAOTeam06DbContext dbContext;
        public HoaDonChiTietRepo()
        {
            dbContext = new DAOTeam06DbContext();
        }
        public bool Add(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var temp = dbContext.hoaDonCts.FirstOrDefault(h => h.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        public List<HoaDonChiTiet> GetAllHdCt()
        {
            return dbContext.hoaDonCts.ToList();
        }

        public HoaDonChiTiet GetById(Guid id)
        {
            return dbContext.hoaDonCts.FirstOrDefault(h => h.id == id);
        }

        public bool Update(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var temp = dbContext.hoaDonCts.FirstOrDefault(h => h.id == obj.id);
            temp.idSp = obj.idSp;
            temp.idHd = obj.idHd;
            temp.soLuong = obj.soLuong;
            temp.thanhTien = obj.thanhTien;
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
