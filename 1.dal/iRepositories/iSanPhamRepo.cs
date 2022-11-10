using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iSanPhamRepo
    {
        public bool Add(SanPham obj);
        public bool Update(SanPham obj);
        public bool Delete(SanPham obj);
        public SanPham GetByIt(Guid id);
        List<SanPham> GetAllSp();
    }
}
