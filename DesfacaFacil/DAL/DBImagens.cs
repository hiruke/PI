using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBImagens
    {

        public int iid { get; set; }
        public int aid { get; set; }
        public string nome { get; set; }
        public string caminho { get; set; }

        public DBImagens(int iid, int aid, string nome, string caminho)
        {
            this.iid = iid;
            this.aid = aid;
            this.nome = nome;
            this.caminho = caminho;
        }


    }
}
