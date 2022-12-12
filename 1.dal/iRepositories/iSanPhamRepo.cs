using System;
using System.Collections.Generic;
using System.Text;
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
