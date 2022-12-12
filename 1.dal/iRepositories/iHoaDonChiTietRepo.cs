using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iHoaDonChiTietRepo
    {
        public bool Add(HoaDonChiTiet obj);
        public bool Update(HoaDonChiTiet obj);
        public bool Delete(HoaDonChiTiet obj);
        public HoaDonChiTiet GetById(Guid id);
        List<HoaDonChiTiet> GetAllHdCt();
    }
}
