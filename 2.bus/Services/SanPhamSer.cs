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
    public class SanPhamSer : iSanPhamSer
    {
        private iSanPhamRepo spRepo;
        private iLoaiSanPhamRepo lspRepo;
        public SanPhamSer()
        {
            spRepo = new SanPhamRepo();
            lspRepo = new LoaiSanPhamRepo();
        }
        public string Add(SanPhamView obj)
        {
            if (obj == null) return "that bai";
            var sp = new SanPham()
            {
                id = Guid.NewGuid(),
                idLsp = (Guid)obj.idLsp,
                ma = obj.ma,
                ten = obj.ten,
                giaBan = obj.giaBan,
            };
            if (spRepo.Add(sp)) return "thanh cong";
            return "that bai";
        }

        public string Delete(SanPhamView obj)
        {
            if (obj == null) return "that bai";
            var temp = spRepo.GetAllSp().FirstOrDefault(c => c.id == obj.id);
            if (spRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<SanPhamView> GetAllSp()
        {
            List<SanPhamView> lst = new List<SanPhamView>();
            lst = (from a in spRepo.GetAllSp()
                   join b in lspRepo.GetAllLoaiSp() on a.idLsp equals b.id
                   select new SanPhamView()
                   {
                       id = a.id,
                       idLsp = (Guid)b.id,
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
            return spRepo.GetAllSp().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdByMa(string ma)
        {
            return spRepo.GetAllSp().FirstOrDefault(c => c.ten == ma).id;
        }

        public Guid GetIdByName(string name)
        {
            return spRepo.GetAllSp().FirstOrDefault(c => c.ten == name).id;
        }

        public string Update(SanPhamView obj)
        {
            if (obj == null) return "that bai";
            var temp = spRepo.GetAllSp().FirstOrDefault(c => c.id == obj.id);
            temp.idLsp =(Guid)obj.idLsp;
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            temp.giaBan = obj.giaBan;
            if (spRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }
    }
}
