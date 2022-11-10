using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;

namespace _2.bus.ViewModels
{
    public class CuaHangView
    {
        public CuaHang ch { get; set; }
        public Guid id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public string diaChi { get; set; }
        public string thanhPho { get; set; }
        public string quocGia { get; set; }
    }
}
