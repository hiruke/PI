using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBCategorias
    {

        public int cid { get; set; }
        public string nome { get; set; }

        public DBCategorias(int cid, string nome)
        {
            this.cid = cid;
            this.nome = nome;
        }
    }
}
