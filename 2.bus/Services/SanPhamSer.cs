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
    public class SanPhamSer : iSanPhamSer
    {
        private iSanPhamRepo iSpRepo;
        private iLoaiSpRepo iLspRepo;
        public SanPhamSer()
        {
            iSpRepo = new SanPhamRepo();
            iLspRepo = new LoaiSpRepo();
        }

        public string Add(SanPhamView obj)
        {
            if (obj == null) return "that bai";
            var sp = new SanPham()
            {
                id = obj.id,
                idLsp = obj.idLsp,
                ma = obj.ma,
                ten = obj.ten,
                giaBan = obj.giaBan,
            };
            if (iSpRepo.Add(sp)) return "thanh cong";
            return "that bai";
        }

        public string Delete(SanPhamView obj)
        {
            if (obj == null) return "that bai";
            var temp = iSpRepo.GetAllSp().FirstOrDefault(c => c.id == obj.id);
            if (iSpRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<SanPhamView> GetAllSp()
        {
            List<SanPhamView> lst = new List<SanPhamView>();
            lst = (from a in iSpRepo.GetAllSp()
                   join b in iLspRepo.GetAllLoaiSp() on a.idLsp equals b.id
                   select new SanPhamView()
                   {
                       id = a.id,
                       idLsp = b.id,
                       ma = a.ma,
                       ten = a.ten,
                       giaBan = a.giaBan,
                   }).ToList();
            return lst;
        }

        public List<SanPhamView> GetAllSp(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllSp();
            return GetAllSp().Where(c => c.ma.ToLower().StartsWith(input.ToLower()) || c.ten.ToLower().StartsWith(input.ToLower())).ToList();
        }

        public SanPham GetById(Guid id)
        {
            return iSpRepo.GetAllSp().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdByName(string name)
        {
            return iSpRepo.GetAllSp().FirstOrDefault(c => c.ten == name).id;
        }

        public string Update(SanPhamView obj)
        {
            if (obj == null) return "that bai";
            var temp = iSpRepo.GetAllSp().FirstOrDefault(c => c.id == obj.id);
            temp.idLsp=obj.idLsp;
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            temp.giaBan = obj.giaBan;
            if (iSpRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }
    }
}
