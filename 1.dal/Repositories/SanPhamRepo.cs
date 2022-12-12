using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.DAODbContext;


namespace _1.dal.Repositories
{
    public class SanPhamRepo:iSanPhamRepo
    {
        private DAOTeam06DbContext dbContext;
        public SanPhamRepo()
        {
            dbContext = new DAOTeam06DbContext();
        }

        public bool Add(SanPham obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(SanPham obj)
        {
            if (obj == null) return false;
            var temp = dbContext.sanPhams.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        public List<SanPham> GetAllSp()
        {
            return dbContext.sanPhams.ToList();
        }

        public SanPham GetByIt(Guid id)
        {
            return dbContext.sanPhams.FirstOrDefault(c => c.id == id);
        }

        public bool Update(SanPham obj)
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
