using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;
using _2.bus.ViewModel;

namespace _2.bus.IServices
{
    public interface iHoaDonChiTietSer
    {
        public string Add(HoaDonChiTietView obj);
        public string Update(HoaDonChiTietView obj);
        public string Delete(HoaDonChiTietView obj);
        public List<HoaDonChiTietView> GetAllHdCt();
        public List<HoaDonChiTietView> GetAllHdCt(string input);
        public HoaDonChiTiet GetById(Guid id);
    }
}
