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
    public class LoaiSanPhamSer : iLoaiSanPhamSer
    {
        private iLoaiSanPhamRepo lspRepo;
        public LoaiSanPhamSer()
        {
            lspRepo = new LoaiSanPhamRepo();
        }
        public string Add(LoaiSanPhamView obj)
        {
            if (obj == null) return "that bai";
            var lsp = new LoaiSanPham()
            {
                id = Guid.NewGuid(),
                ma = obj.ma,
                ten = obj.ten,
            };
            if (lspRepo.Add(lsp)) return "thanh cong";
            return "that bai";
        }

        public string Delete(LoaiSanPhamView obj)
        {
            if (obj == null) return "that bai";
            var temp = lspRepo.GetAllLoaiSp().FirstOrDefault(c => c.id == obj.id);
            if (lspRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<LoaiSanPhamView> GetAllLsp()
        {
            List<LoaiSanPhamView> lst = new List<LoaiSanPhamView>();
            lst = (from a in lspRepo.GetAllLoaiSp()
                   select new LoaiSanPhamView()
                   {
                       id = a.id,
                       ma = a.ma,
                       ten = a.ten,
                   }).ToList();
            return lst;
        }

        public List<LoaiSanPhamView> GetAllLsp(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllLsp();
            return GetAllLsp().Where(c => c.ma.ToLower().StartsWith(input.ToLower()) || c.ten.ToLower().StartsWith(input.ToLower())).ToList();
        }
        public Guid GetIdByMa(string ma)
        {
            return lspRepo.GetAllLoaiSp().FirstOrDefault(c => c.ten == ma).id;
        }

        public Guid GetIdbyName(string name)
        {
            return lspRepo.GetAllLoaiSp().FirstOrDefault(c => c.ten == name).id;
        }

        public string Update(LoaiSanPhamView obj)
        {
            if (obj == null) return "that bai";
            var temp = lspRepo.GetAllLoaiSp().FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            if (lspRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }

        LoaiSanPham iLoaiSanPhamSer.GetById(Guid id)
        {
            return lspRepo.GetAllLoaiSp().FirstOrDefault(c => c.id == id);
        }
    }
}
