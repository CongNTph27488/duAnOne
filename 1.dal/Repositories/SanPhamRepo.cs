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
    public class SanPhamRepo : iSanPhamRepo
    {
        private DAODbContext dbContext;
        public SanPhamRepo()
        {
            dbContext = new DAODbContext(); 
        }
        bool iSanPhamRepo.Add(SanPham obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }
        bool iSanPhamRepo.Delete(SanPham obj)
        {
            if (obj == null) return false;
            var temp = dbContext.sanPhams.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }
        List<SanPham> iSanPhamRepo.GetAllSp()
        {
            return dbContext.sanPhams.ToList();
        }
        SanPham iSanPhamRepo.GetByIt(Guid id)
        {
            return dbContext.sanPhams.FirstOrDefault(c => c.id == id);
        }
        bool iSanPhamRepo.Update(SanPham obj)
        {
            if (obj == null) return false;
            var temp = dbContext.sanPhams.FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            temp.giaBan = obj.giaBan;
            temp.idLsp = obj.idLsp;
            dbContext.Update(temp);           
            dbContext.SaveChanges();
            return true;
        }
    }
}
