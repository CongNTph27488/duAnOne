using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iCuaHangSer
    {
        public string Add(CuaHangView obj);
        public string Update(CuaHangView obj);
        public string Delete(CuaHangView obj);
        public List<CuaHangView> GetAllCh();
        public List<CuaHangView> GetAllCh(string input);
        public CuaHang GetById(Guid id);
        public Guid GetIdByName(string name);
    }
}
