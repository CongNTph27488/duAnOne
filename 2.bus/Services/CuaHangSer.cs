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
    public class CuaHangSer:iCuaHangSer
    {
        private iCuaHangRepo iChRepo;
        public CuaHangSer()
        {
            iChRepo = new CuaHangRepo();
        }

        public string Add(CuaHangView obj)
        {
            if (obj == null) return "that bai";
            var ch = new CuaHang()
            {
                id = obj.id,
                ma = obj.ma,
                ten = obj.ten,
            };
            if (iChRepo.Add(ch)) return "thanh cong";
            return "that bai";
        }

        public string Delete(CuaHangView obj)
        {
            if (obj == null) return "that bai";
            var temp=iChRepo.GetAllCh().FirstOrDefault(c=>c.id==obj.id);
            if (iChRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<CuaHangView> GetAllCh()
        {
            List<CuaHangView> lst = new List<CuaHangView>();
            lst = (from a in iChRepo.GetAllCh()
                   select new CuaHangView()
                   {
                       id = a.id,
                       ma = a.ma,
                       ten = a.ten,
                       diaChi = a.diaChi,
                       thanhPho = a.thanhPho,
                       quocGia = a.quocGia,
                   }).ToList();
            return lst;
        }

        public List<CuaHangView> GetAllCh(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllCh();
            return GetAllCh().Where(c => c.ma.ToLower().StartsWith(input.ToLower()) || c.ten.StartsWith(input.ToLower())).ToList();
        }

        public CuaHang GetById(Guid id)
        {
            return iChRepo.GetAllCh().FirstOrDefault(c=>c.id==id);
        }

        public Guid GetIdByName(string name)
        {
            return iChRepo.GetAllCh().FirstOrDefault(c => c.ten == name).id;
        }

        public string Update(CuaHangView obj)
        {
            if (obj == null) return "that bai";
            var temp = iChRepo.GetAllCh().FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.ten = obj.ten;
            if (iChRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }

        public List<string> GetAllCuahang()
        {
            return new List<string> { "Ch01", "Ch02" };
        }
    }
}
