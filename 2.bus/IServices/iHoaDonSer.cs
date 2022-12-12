using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;
using _2.bus.ViewModel;

namespace _2.bus.IServices
{
    public interface iHoaDonSer
    {
        public string Add(HoaDonView obj);
        public string Update(HoaDonView obj);
        public string Delete(HoaDonView obj);
        public List<HoaDonView> GetAllHd();
        public List<HoaDonView> GetAllHd(string input);
        public HoaDon GetById(Guid id);
        public Guid GetIdByMa(string ma);
    }
}
