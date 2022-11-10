using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
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
    }
}
