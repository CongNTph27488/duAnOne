using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iLoaiSanPhamRepo
    {
        public bool Add(LoaiSanPham obj);
        public bool Update(LoaiSanPham obj);
        public bool Delete(LoaiSanPham obj);
        public LoaiSanPham GetById(Guid id);
        List<LoaiSanPham> GetAllLoaiSp();
    }
}
