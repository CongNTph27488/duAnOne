using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.DaoDbContext;
using _1.dal.Table;

namespace _1.dal.iRepositories
{
    public interface iCuaHangRepo
    {
        public bool Add(CuaHang obj);
        public bool Update(CuaHang obj);    
        public bool Delete(CuaHang obj);
        public CuaHang GetById(Guid id);
        List<CuaHang> GetAllCh();
    }
}
