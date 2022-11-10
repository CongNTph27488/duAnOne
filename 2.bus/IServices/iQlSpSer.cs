using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _2.bus.iServices
{
    public interface iQlSpSer
    {
        public string Add(QlSpView obj);
        public string Update(QlSpView obj);
        public string Delete(QlSpView obj);
        List<QlSpView> GetAllQlSp();
    }
}
