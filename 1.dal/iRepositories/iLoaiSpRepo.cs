using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iLoaiSpRepo
    {
        public bool Add(LoaiSp obj);
        public bool Update(LoaiSp obj);
        public bool Delete(LoaiSp obj);
        public LoaiSp GetById(Guid id);
        List<LoaiSp> GetAllLoaiSp();
    }
}
