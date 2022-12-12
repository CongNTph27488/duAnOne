using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iChucVuRepo
    {
        public bool Add(ChucVu obj);
        public bool Update(ChucVu obj);
        public bool Delete(ChucVu obj);
        public ChucVu GetById(Guid id);
        List<ChucVu> GetAllCv();
    }
}
