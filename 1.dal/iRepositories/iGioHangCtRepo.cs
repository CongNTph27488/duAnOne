using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iGioHangCtRepo
    {
        public bool Add(GioHangCt obj);
        public bool Update(GioHangCt obj);
        public bool Delete(GioHangCt obj);
        public GioHangCt GetById(Guid id);
        List<GioHangCt> GetAllGhCt();
    }
}
