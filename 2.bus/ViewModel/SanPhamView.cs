using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;

namespace _2.bus.ViewModel
{
    public class SanPhamView
    {
        public SanPham sp { get; set; }      
        public Guid idLsp { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public decimal giaBan { get; set; }

        public LoaiSanPham lsp { get; set; }
        public Guid id { get; set; }
        public string maLsp { get; set; }
        public string tenLsp { get; set; }

    }
}
