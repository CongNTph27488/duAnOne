using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iHoaDonCtRepo
    {
        public bool Add(HoaDonCt obj);
        public bool Update(HoaDonCt obj);
        public bool Delete(HoaDonCt obj);
        public HoaDonCt GetById(Guid id);
        List<HoaDonCt> GetAllHdCt();
    }
}
