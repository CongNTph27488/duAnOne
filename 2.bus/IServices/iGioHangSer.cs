using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iGioHangSer
    {
        public string Add(GioHangView obj);
        public string Update(GioHangView obj);
        public string Delete(GioHangView obj);
        public List<GioHangView> GetAllGh();
        public List<GioHangView> GetAllGh(string input);
        public GioHang GetById(Guid id);
        public Guid GetIdByName(string name);
    }
}
