using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.DAODbContext;

namespace _1.dal.Repositories
{
    public class LoaiSanPhamRepo : iLoaiSanPhamRepo
    {
        private DAOTeam06DbContext dbContext;
        public LoaiSanPhamRepo()
        {
            dbContext = new DAOTeam06DbContext();
        }
        public bool Add(LoaiSanPham obj)
        {
            if (obj == null) return false;
            obj.id = Guid.NewGuid();
            dbContext.Add(obj);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(LoaiSanPham obj)
        {
            if (obj == null) return false;
            var temp = dbContext.loaiSps.FirstOrDefault(c => c.id == obj.id);
            dbContext.Remove(temp);
            dbContext.SaveChanges();
            return true;
        }

        public List<LoaiSanPham> GetAllLoaiSp()
        {
            return dbContext.loaiSps.ToList();
        }

        public LoaiSanPham GetById(Guid id)
        {
            return dbContext.loaiSps.FirstOrDefault(c => c.id == id);
        }

        public bool Update(LoaiSanPham obj)
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
