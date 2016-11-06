using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBCandidatos
    {
        public int canid { get; set; }
        public int usid { get; set; }
        public int aid { get; set; }

        public DBCandidatos(int _canid, int _usid, int _aid)
        {
            canid = _canid;
            usid = _usid;
            aid = _aid;
        }

    }
}

