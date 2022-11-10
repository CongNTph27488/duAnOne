using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iQlNvSer
    {
        public string Add(QlNvView obj);
        public string Update(QlNvView obj);
        public string Delete(QlNvView obj);
        List<QlNvView> GetAllQlNv();
        List<string> TrangThai();
        string Add(NhanVienView nhanVienView);
    }
}
