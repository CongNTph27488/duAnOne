using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.DAODbContext   ;

namespace _1.dal.Repositories
{
    public class ChucVuRepo : iChucVuRepo
    {
        private DAOTeam06DbContext dbContext;
        public ChucVuRepo()
        {
            dbContext = new DAOTeam06DbContext();
        }
        public bool Add(ChucVu obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(ChucVu obj)
        {
            if (obj == null) return false;
            var temp = dbContext.chucVus.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        public List<ChucVu> GetAllCv()
        {
            return dbContext.chucVus.ToList();
        }

        public ChucVu GetById(Guid id)
        {
            return dbContext.chucVus.FirstOrDefault(c => c.id == id);
        }

        public bool Update(ChucVu obj)
        {
            if (obj == null) return false;
            var temp = dbContext.chucVus.FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
