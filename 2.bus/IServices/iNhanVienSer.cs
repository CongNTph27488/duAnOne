using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
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
        public List<string> lstThanhPho();
        public List<string> lstQuocGia();
    }
}
