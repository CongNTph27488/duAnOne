﻿using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;
using _2.bus.ViewModel;

namespace _2.bus.IServices
{
    public interface iChucVuSer
    {
        public string Add(ChucVuView obj);
        public string Update(ChucVuView obj);
        public string Delete(ChucVuView obj);
        public List<ChucVuView> GetAllCv();
        public List<ChucVuView> GetAllCv(string input);
        public ChucVu GetById(Guid id);
        public Guid GetIdByName(string name);
        public Guid GetIdByMa(string ma);
    }
}
