using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iHoaDonCtSer
    {
        public string Add(HoaDonCtView obj);
        public string Update(HoaDonCtView obj);
        public string Delete(HoaDonCtView obj);
        public List<HoaDonCtView> GetAllHdCt();
        public List<HoaDonCtView> GetAllHdCt(string input);
        public HoaDonCt GetById(Guid id);
        public Guid GetIdByName(string name);
    }
}
