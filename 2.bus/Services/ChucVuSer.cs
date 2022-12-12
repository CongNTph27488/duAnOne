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
    public class ChucVuSer : iChucVuSer
    {
        private iChucVuRepo cvRepo;
        public ChucVuSer()
        {
            cvRepo = new ChucVuRepo();
        }
        public string Add(ChucVuView obj)
        {
            if (obj == null) return "that bai";
            var cv = new ChucVu()
            {
                id = Guid.NewGuid(),
                ma = obj.ma,
                ten = obj.ten,
            };
            if (cvRepo.Add(cv)) return "thanh cong";
            return "that bai";
        }

        public string Delete(ChucVuView obj)
        {
            if (obj == null) return "that bai";
            var temp = cvRepo.GetAllCv().FirstOrDefault(c => c.id == obj.id);
            if (cvRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<ChucVuView> GetAllCv()
        {
            List<ChucVuView> lst = new List<ChucVuView>();
            lst = (from a in cvRepo.GetAllCv()
                   select new ChucVuView()
                   {
                       id = a.id,
                       ma = a.ma,
                       ten = a.ten,
                   }).ToList();
            return lst;
        }

        public List<ChucVuView> GetAllCv(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllCv();
            return GetAllCv().Where(c => c.ma.ToLower().StartsWith(input.ToLower()) || c.ten.ToLower().StartsWith(input.ToLower())).ToList();
        }

        public ChucVu GetById(Guid id)
        {
            return cvRepo.GetAllCv().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdByMa(string ma)
        {
            return cvRepo.GetAllCv().FirstOrDefault(c => c.ten == ma).id;
        }

        public Guid GetIdByName(string name)
        {
            return cvRepo.GetAllCv().FirstOrDefault(c => c.ten == name).id;
        }

        public string Update(ChucVuView obj)
        {
            if (obj == null) return "that bai";
            var temp = cvRepo.GetAllCv().FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            if (cvRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }
    }
}
