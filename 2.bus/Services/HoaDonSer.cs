using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _1.dal.iRepositories;
using _1.dal.Repositories;
using _2.bus.ViewModels;
using _2.bus.iServices;

namespace _2.bus.Services
{
    public class HoaDonSer:iHoaDonSer
    {
        private iHoaDonRepo iHdRepo;
        private iNhanVienRepo iNvRepo;
        public HoaDonSer()
        {
            iHdRepo = new HoaDonRepo();
            iNvRepo = new NhanVienRepo();
        }

        public string Add(HoaDonView obj)
        {
            if (obj == null) return "that bai";
            var hd = new HoaDon()
            {
                id = obj.id,
                idNv = obj.idNv,
                ma = obj.ma,
                ngTao = obj.ngTao,
                ngThanhToan = obj.ngThanhToan,
            };
            if (iHdRepo.Add(hd)) return "thanh cong";
            return "that bai";
        }

        public string Delete(HoaDonView obj)
        {
            if (obj == null) return "that bai";
            var temp = iHdRepo.GetAllHd().FirstOrDefault(c => c.id == obj.id);
            if (iHdRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<HoaDonView> GetAllHd()
        {
            List<HoaDonView> lst = new List<HoaDonView>();
            lst = (from a in iHdRepo.GetAllHd()
                   join b in iNvRepo.GetAllNv() on a.idNv equals b.id
                   select new HoaDonView()
                   {
                       id = a.id,
                       idNv = b.id,
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
            return iHdRepo.GetAllHd().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public string Update(HoaDonView obj)
        {
            if (obj == null) return "that bai";
            var temp = iHdRepo.GetAllHd().FirstOrDefault(c => c.id == obj.id);
            temp.idNv = obj.idNv;
            temp.ma = obj.ma;
            temp.ngTao = obj.ngTao;
            temp.ngThanhToan = obj.ngThanhToan;
            if (iHdRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }
    }
}
