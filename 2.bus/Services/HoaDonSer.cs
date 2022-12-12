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
    public class HoaDonSer : iHoaDonSer
    {
        private iHoaDonRepo hdRepo;
        private iNhanVienRepo nvRepo;
        public HoaDonSer()
        {
            hdRepo = new HoaDonRepo();
            nvRepo = new NhanVienRepo();
        }
        public string Add(HoaDonView obj)
        {
            if (obj == null) return "that bai";
            var hd = new HoaDon()
            {
                id = obj.id,
                idNv = (Guid)obj.idNv,
                ma = obj.ma,
                ngTao = obj.ngTao,
                ngThanhToan = obj.ngThanhToan,
            };
            if (hdRepo.Add(hd)) return "thanh cong";
            return "that bai";
        }

        public string Delete(HoaDonView obj)
        {
            if (obj == null) return "that bai";
            var temp = hdRepo.GetAllHd().FirstOrDefault(c => c.id == obj.id);
            if (hdRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<HoaDonView> GetAllHd()
        {
            List<HoaDonView> lst = new List<HoaDonView>();
            lst = (from a in hdRepo.GetAllHd()
                   join b in nvRepo.GetAllNv() on a.idNv equals b.id
                   select new HoaDonView()
                   {
                       id = a.id,
                       idNv = (Guid)b.id,
                       ma = a.ma,
                       ngTao = a.ngTao,
                       ngThanhToan = a.ngThanhToan,
                   }).ToList();
            return lst;
        }

        public List<HoaDonView> GetAllHd(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllHd();
            return GetAllHd().Where(c => c.ma.ToLower().StartsWith(input.ToLower())).ToList();
        }

        public HoaDon GetById(Guid id)
        {
            return hdRepo.GetAllHd().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdByMa(string ma)
        {
            return hdRepo.GetAllHd().FirstOrDefault(c => c.ma == ma).id;
        }

        public string Update(HoaDonView obj)
        {
            if (obj == null) return "that bai";
            var temp = hdRepo.GetAllHd().FirstOrDefault(c => c.id == obj.id);
            temp.idNv = (Guid)obj.idNv;
            temp.ma = obj.ma;
            temp.ngTao = obj.ngTao;
            temp.ngThanhToan = obj.ngThanhToan;
            if (hdRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }
    }
}
