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
    public class LoaiSpRepo : iLoaiSpRepo
    {
        private DAODbContext dbContext;
        public LoaiSpRepo()
        {
            dbContext = new DAODbContext();
        }
        bool iLoaiSpRepo.Add(LoaiSp obj)
        {
            if (obj == null) return false;
            obj.id=Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        bool iLoaiSpRepo.Delete(LoaiSp obj)
        {
            if(obj==null) return false;
            var temp = dbContext.loaiSps.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        List<LoaiSp> iLoaiSpRepo.GetAllLoaiSp()
        {
            return dbContext.loaiSps.ToList();
        }

        LoaiSp iLoaiSpRepo.GetById(Guid id)
        {
            return dbContext.loaiSps.FirstOrDefault(c => c.id == id);
        }

        bool iLoaiSpRepo.Update(LoaiSp obj)
        {
            if (obj == null) return false;
            var temp = dbContext.loaiSps.FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            dbContext.Update(temp);
            dbContext.SaveChanges();
            return true;
        }
    }
}
