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
    public class LoaiSpSer:iLoaiSpSer
    {
        private iLoaiSpRepo iLspRepo;
        public LoaiSpSer()
        {
            iLspRepo = new LoaiSpRepo();
        }

        public string Add(LoaiSpView obj)
        {
            if (obj == null) return "that bai";
            var lsp = new LoaiSp()
            {
                id = obj.id,
                ma = obj.ma,
                ten = obj.ten,
            };
            if (iLspRepo.Add(lsp)) return "thanh cong";
            return "that bai";
        }

        public string Delete(LoaiSpView obj)
        {
            if (obj == null) return "that bai";
            var temp = iLspRepo.GetAllLoaiSp().FirstOrDefault(c => c.id == obj.id);
            if (iLspRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<LoaiSpView> GetAllLsp()
        {
            List<LoaiSpView> lst = new List<LoaiSpView>();
            lst = (from a in iLspRepo.GetAllLoaiSp()
                   select new LoaiSpView()
                   {
                       id = a.id,
                       ma = a.ma,
                       ten = a.ten,
                   }).ToList();
            return lst;
        }

        public List<LoaiSpView> GetAllLsp(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllLsp();
            return GetAllLsp().Where(c => c.ma.ToLower().StartsWith(input.ToLower()) || c.ten.ToLower().StartsWith(input.ToLower())).ToList();
        }

        public LoaiSp GetById(Guid id)
        {
            return iLspRepo.GetAllLoaiSp().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdbyName(string name)
        {
            return iLspRepo.GetAllLoaiSp().FirstOrDefault(c => c.ten == name).id;
        }

        public string Update(LoaiSpView obj)
        {
            if (obj == null) return "that bai";
            var temp = iLspRepo.GetAllLoaiSp().FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            if (iLspRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }
    }
}
