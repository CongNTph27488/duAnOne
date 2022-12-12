using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;

namespace _2.bus.ViewModel
{
    public class LoaiSanPhamView
    {
        public LoaiSanPham lsp { get; set; }
        public Guid id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
    }
}
