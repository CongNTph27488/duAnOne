using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.Repositories;
using _2.bus.IServices;
using _2.bus.ViewModel;

namespace _2.bus.Services
{
    public class HoaDonChiTietSer : iHoaDonChiTietSer
    {
        private iHoaDonChiTietRepo hdCtRepo;
        private iHoaDonRepo hdRepo;
        private iSanPhamRepo spRepo;
        public HoaDonChiTietSer()
        {
            hdCtRepo = new HoaDonChiTietRepo();
            hdRepo = new HoaDonRepo();
            spRepo = new SanPhamRepo();
        }

        public string Add(HoaDonChiTietView obj)
        {
            if (obj == null) return "that bai";
            var hdCt = new HoaDonChiTiet()
            {
                id=Guid.NewGuid(),
                idHd=(Guid)obj.idHd,
                idSp=(Guid)obj.idSp,
                soLuong=obj.soLuong,
                thanhTien=obj.thanhTien,
            };
            if (hdCtRepo.Add(hdCt)) return "thanh cong";
            return "that bai";
        }

        public string Delete(HoaDonChiTietView obj)
        {
            if (obj == null) return "that bai";
            var temp = hdCtRepo.GetAllHdCt().FirstOrDefault(c => c.id == obj.id);
            if (hdCtRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<HoaDonChiTietView> GetAllHdCt()
        {
            List<HoaDonChiTietView> lst = new List<HoaDonChiTietView>();
            lst = (from a in hdCtRepo.GetAllHdCt()
                   join b in hdRepo.GetAllHd() on a.idHd equals b.id
                   join c in spRepo.GetAllSp() on a.idSp equals c.id
                   select new HoaDonChiTietView()
                   {
                       id= a.id,
                       soLuong=a.soLuong,
                       thanhTien=a.thanhTien,

                       idHd=b.id,
                       maHd=b.ma,
                       ngTaoHd=b.ngTao,
                       ngThanhToanHd=b.ngThanhToan,

                       idSp=c.id,
                       maSp=c.ma,
                       tenSp=c.ten,
                       giaBan=c.giaBan,
                   }).ToList();
            return lst;
        }

        public List<HoaDonChiTietView> GetAllHdCt(string input)
        {
            throw new NotImplementedException();
        }

        public string Update(HoaDonChiTietView obj)
        {
            if(obj == null) return "that bai";
            var temp = hdCtRepo.GetAllHdCt().FirstOrDefault(c => c.id == obj.id);
            temp.idHd = (Guid)obj.idHd;
            temp.idSp = (Guid)obj.idSp;
            temp.soLuong = obj.soLuong;
            temp.thanhTien = obj.thanhTien;
            if (hdCtRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }

        HoaDonChiTiet iHoaDonChiTietSer.GetById(Guid id)
        {
            return hdCtRepo.GetAllHdCt().FirstOrDefault(c => c.id == id);
        }
    }
}
