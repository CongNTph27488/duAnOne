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
    public class NhanVienSer : iNhanVienSer
    {
        private iNhanVienRepo iNvRepo;
        private iCuaHangRepo iChRepo;
        private iChucVuRepo iCvRepo;
        public NhanVienSer()
        {
            iNvRepo = new NhanVienRepo();
            iChRepo = new CuaHangRepo();
            iCvRepo = new ChucVuRepo();
        }

        public string Add(NhanVienView obj)
        {
            if (obj == null) return "that bai";
            var nv = new NhanVien()
            {
                id = obj.id,
                ma = obj.ma,
                idCh = obj.idCh,
                idCv = obj.idCv,
                ho = obj.ho,
                tenDem = obj.tenDem,
                ten = obj.ten,
                ngSinh = obj.ngSinh,
                gioiTinh = obj.gioiTinh,
                sdt = obj.sdt,
                diaChi = obj.diaChi,
                thanhPho = obj.thanhPho,
                quocGia = obj.quocGia,
                trangThai = obj.trangThai,
            };
            if (iNvRepo.Add(nv)) return "thanh cong";
            return "that bai";
        }

        public string Delete(NhanVienView obj)
        {
            if (obj == null) return "that bai";
            var temp = iNvRepo.GetAllNv().FirstOrDefault(c => c.id == obj.id);
            if (iNvRepo.Delete(temp)) return "thanh cong";
            return "that bai";
        }

        public List<NhanVienView> GetAllNv()
        {
            List<NhanVienView> lst = new List<NhanVienView>();
            lst = (from a in iNvRepo.GetAllNv()
                   join b in iChRepo.GetAllCh() on a.idCh equals b.id
                   join c in iCvRepo.GetAllCv() on a.idCv equals c.id
                   select new NhanVienView()
                   {
                       id = a.id,
                       ma = a.ma,
                       idCh = b.id,
                       idCv = c.id,
                       ho = a.ho,
                       tenDem = a.tenDem,
                       ten = a.ten,
                       ngSinh = a.ngSinh,
                       gioiTinh = a.gioiTinh,
                       sdt = a.sdt,
                       diaChi = a.diaChi,
                       thanhPho = a.thanhPho,
                       quocGia = a.quocGia,
                       trangThai = a.trangThai,
                   }).ToList();
            return lst;
        }

        public List<NhanVienView> GetAllNv(string input)
        {
            if (string.IsNullOrEmpty(input)) return GetAllNv();
            return GetAllNv().Where(c => c.ma.ToLower().StartsWith(input.ToLower()) || c.ten.ToLower().StartsWith(input.ToLower())).ToList();
        }

        public NhanVien GetById(Guid id)
        {
            return iNvRepo.GetAllNv().FirstOrDefault(c => c.id == id);
        }

        public Guid getIdByName(string name)
        {
            return iNvRepo.GetAllNv().FirstOrDefault(c => c.ten == name).id;
        }

        public List<string> lstQuocGia()
        {
            return new List<string> { "vietnam", "thailan" };
        }

        public List<string> lstThanhPho()
        {
            return new List<string> { "hanoi", "thaibinh" };
        }

        public string Update(NhanVienView obj)
        {
            if (obj == null) return "that bai";
            var temp = iNvRepo.GetAllNv().FirstOrDefault(c => c.id == obj.id);
            temp.ma = obj.ma;
            temp.idCh = obj.idCh;
            temp.idCv = obj.idCv;
            temp.ho = obj.ho;
            temp.tenDem = obj.tenDem;
            temp.ten = obj.ten;
            temp.ngSinh = obj.ngSinh;
            temp.gioiTinh = obj.gioiTinh;
            temp.sdt = obj.sdt;
            temp.diaChi = obj.diaChi;
            temp.thanhPho = obj.thanhPho;
            temp.quocGia = obj.quocGia;
            temp.trangThai = obj.trangThai;
            if (iNvRepo.Update(temp)) return "thanh cong";
            return "that bai";
        }

        
    }
}
