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
    public class GioHangSer:iGioHangSer
    {
        private iGioHangRepo iGhRepo;
        private iNhanVienRepo iNvRepo;
        public GioHangSer()
        {
            iGhRepo = new GioHangRepo();
            iNvRepo = new NhanVienRepo();
        }

        public string Add(GioHangView obj)
        {
            if (obj == null) return "that bai";
            var gh = new GioHang()
            {
                id = obj.id,
                idNv = obj.idNv,
                ma = obj.ma,
                ngTao = obj.ngTao,
                ngThanhToan = obj.ngThanhToan,
                tinhTrang = obj.tinhTrang,
            };
            if (iGhRepo.Add(gh)) return "thanh cong";
            return "that bai";
        }

        public string Delete(GioHangView obj)
        {
            if (obj == null) return "that bai";
            var temp = iGhRepo.GetAllGh().FirstOrDefault(c => c.id == obj.id);
            if (iGhRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<GioHangView> GetAllGh()
        {
            List<GioHangView> lst = new List<GioHangView>();
            lst = (from a in iGhRepo.GetAllGh()
                   join b in iNvRepo.GetAllNv() on a.idNv equals b.id
                   select new GioHangView()
                   {
                       id = a.id,
                       idNv = b.id,
                       ma = a.ma,
                       ngTao = a.ngTao,
                       ngThanhToan = a.ngThanhToan,
                   }).ToList();
            return lst;
        }

        public List<GioHangView> GetAllGh(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllGh();
            return GetAllGh().Where(c => c.ma.ToLower().StartsWith(input.ToLower())).ToList();
        }

        public GioHang GetById(Guid id)
        {
            return iGhRepo.GetAllGh().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public string Update(GioHangView obj)
        {
            if (obj == null) return "that bai";
            var temp = iGhRepo.GetAllGh().FirstOrDefault(c => c.id == obj.id);
            temp.idNv = obj.idNv;
            temp.ma = obj.ma;
            temp.ngTao = obj.ngTao;
            temp.ngThanhToan = obj.ngThanhToan;
            if (iGhRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }        
    }
}
