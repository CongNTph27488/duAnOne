using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iNhanVienRepo
    {
        public bool Add(NhanVien obj);
        public bool Update(NhanVien obj);
        public bool Delete(NhanVien obj);
        public NhanVien GetById(Guid id);
        List<NhanVien> GetAllNv();
    }
}
