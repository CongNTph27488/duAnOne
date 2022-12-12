using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;
using _2.bus.ViewModel;

namespace _2.bus.IServices
{
    public interface iSanPhamSer
    {
        public string Add(SanPhamView obj);
        public string Update(SanPhamView obj);
        public string Delete(SanPhamView obj);
        public List<SanPhamView> GetAllSp();
        public List<SanPhamView> GetAllSp(string input);
        public SanPham GetById(Guid id);
        public Guid GetIdByName(string name);
        public Guid GetIdByMa(string ma);
    }
}
