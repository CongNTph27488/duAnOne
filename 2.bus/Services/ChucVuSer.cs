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
    public class ChucVuSer : iChucVuSer
    {
        private iChucVuRepo iCvRepo;
        public ChucVuSer()
        {
            iCvRepo = new ChucVuRepo();
        }

        public string Add(ChucVuView obj)
        {
            if (obj == null) return "that bai";
            var cv = new ChucVu()
            {
                id = obj.id,
                ma = obj.ma,
                ten = obj.ten,
            };
            if (iCvRepo.Add(cv)) return "thanh cong";
            return "that bai";
        }

        public string Delete(ChucVuView obj)
        {
            if (obj == null) return "that bai";
            var temp = iCvRepo.GetAllCv().FirstOrDefault(c => c.id == obj.id);
            if (iCvRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<ChucVuView> GetAllCv()
        {
            List<ChucVuView> lst = new List<ChucVuView>();
            lst = (from a in iCvRepo.GetAllCv()
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
            return GetAllCv().Where(c=>c.ma.ToLower().StartsWith(input.ToLower())||c.ten.ToLower().StartsWith(input.ToLower())).ToList();   
        }

        public ChucVu GetById(Guid id)
        {
            return iCvRepo.GetAllCv().FirstOrDefault(c => c.id == id);
        }

        public Guid GetIdByName(string name)
        {
            return iCvRepo.GetAllCv().FirstOrDefault(c => c.ten == name).id;
        }

        public string Update(ChucVuView obj)
        {
            if (obj == null) return "that bai";
            var temp = iCvRepo.GetAllCv().FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            if (iCvRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }
    }
}
