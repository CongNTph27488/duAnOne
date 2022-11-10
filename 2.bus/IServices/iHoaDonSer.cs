using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iHoaDonSer
    {
        public string Add(HoaDonView obj);
        public string Update(HoaDonView obj);
        public string Delete(HoaDonView obj);
        public List<HoaDonView> GetAllHd();
        public List<HoaDonView> GetAllHd(string input);
        public HoaDon GetById(Guid id);
        public Guid GetIdByName(string name);
    }
}
