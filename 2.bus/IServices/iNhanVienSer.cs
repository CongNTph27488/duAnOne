using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;
using _2.bus.ViewModel;

namespace _2.bus.IServices
{
    public interface iNhanVienSer
    {
        public string Add(NhanVienView obj);
        public string Update(NhanVienView obj);
        public string Delete(NhanVienView obj);
        public List<NhanVienView> GetAllNv();
        public List<NhanVienView> GetAllNv(string input);
        public NhanVien GetById(Guid id);
        public Guid getIdByName(string name);
        public Guid GetIdByMa(string ma);
    }
}
