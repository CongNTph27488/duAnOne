using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iGioHangRepo
    {
        public bool Add(GioHang obj);
        public bool Update(GioHang obj);
        public bool Delete(GioHang obj);
        public GioHang GetById(Guid id);
        List<GioHang> GetAllGh();
    }
}
