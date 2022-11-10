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
    public class ChucVuRepo:iChucVuRepo
    {
        private DAODbContext dbContext;
        public ChucVuRepo()
        {
            dbContext = new DAODbContext();
        }

        bool iChucVuRepo.Add(ChucVu obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iChucVuRepo.Delete(ChucVu obj)
        {
            if (obj == null) return false;
            var temp = dbContext.chucVus.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        List<ChucVu> iChucVuRepo.GetAllCv()
        {
            return dbContext.chucVus.ToList();
        }

        ChucVu iChucVuRepo.GetById(Guid id)
        {
            return dbContext.chucVus.FirstOrDefault(c => c.id == id);
        }

        bool iChucVuRepo.Update(ChucVu obj)
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
