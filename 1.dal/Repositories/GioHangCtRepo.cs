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
    public class GioHangCtRepo : iGioHangCtRepo
    {
        private DAODbContext dbContext;
        public GioHangCtRepo()
        {
            dbContext=new DAODbContext();
        }
        bool iGioHangCtRepo.Add(GioHangCt obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iGioHangCtRepo.Delete(GioHangCt obj)
        {
            if (obj == null) return false;
            var temp = dbContext.gioHangCts.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(obj);
            dbContext.SaveChanges();
            return true;
        }

        List<GioHangCt> iGioHangCtRepo.GetAllGhCt()
        {
            return dbContext.gioHangCts.ToList();
        }

        GioHangCt iGioHangCtRepo.GetById(Guid id)
        {
            return dbContext.gioHangCts.FirstOrDefault(c => c.id == id);
        }

        bool iGioHangCtRepo.Update(GioHangCt obj)
        {
            if (obj == null) return false;
            var temp = dbContext.gioHangCts.FirstOrDefault(c => c.id == obj.id);
            temp.idSp = obj.idSp;
            temp.idGh = obj.idGh;
            temp.thanhTien = obj.thanhTien;
            dbContext.Update(obj);            
            dbContext.SaveChanges();
            return true;
        }
    }
}
