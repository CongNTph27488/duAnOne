using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;
using _2.bus.ViewModel;

namespace _2.bus.IServices
{
    public interface iLoaiSanPhamSer
    {
        public string Add(LoaiSanPhamView obj);
        public string Update(LoaiSanPhamView obj);
        public string Delete(LoaiSanPhamView obj);
        public List<LoaiSanPhamView> GetAllLsp();
        public List<LoaiSanPhamView> GetAllLsp(string input);
        public LoaiSanPham GetById(Guid id);
        public Guid GetIdbyName(string name);
        public Guid GetIdByMa(string ma);
    }
}
