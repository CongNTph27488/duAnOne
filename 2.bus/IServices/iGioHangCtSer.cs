using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iGioHangCtSer
    {
        public string Add(GioHangCtView obj);
        public string Update(GioHangCtView obj);
        public string Delete(GioHangCtView obj);
        public List<GioHangCtView> GetAllGhCt();
        public List<GioHangCtView> GetAllGhCt(string input);
        public GioHangCt GetById(Guid id);
        public Guid GetIdByName(string name);
    }
}
