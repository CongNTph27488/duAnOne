using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iLoaiSpSer
    {
        public string Add(LoaiSpView obj);
        public string Update(LoaiSpView obj);
        public string Delete(LoaiSpView obj);
        public List<LoaiSpView> GetAllLsp();
        public List<LoaiSpView> GetAllLsp(string input);
        public LoaiSp GetById(Guid id);
        public Guid GetIdbyName(string name);
    }
}
