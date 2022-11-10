using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iHoaDonRepo
    {
        public bool Add(HoaDon obj);
        public bool Update(HoaDon obj);
        public bool Delete(HoaDon obj);
        public HoaDon GetById(Guid id);
        List<HoaDon> GetAllHd();
    }
}
