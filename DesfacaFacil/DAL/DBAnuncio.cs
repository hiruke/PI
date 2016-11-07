using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL
{

    public class DBAnuncio
    {
        public int aid { get; set; }
        public int usid { get; set; }
        public int cid { get; set; }
        public int tipo { get; set; }
        public int status { get; set; }
        public DateTime datacriacao { get; set; }
        public DateTime dataexpiracao { get; set; }
        public string descricao { get; set; }
        public string titulo { get; set; }
        public List<DBCandidatos> candidatos = new List<DBCandidatos>();
        public List<DBImagens> imagens = new List<DBImagens>();

        public DBAnuncio(int aid, int usid, int cid, int tipo, int status, DateTime datacriacao, DateTime dataexpiracao, string descricao, string titulo)
        {
            this.aid = aid;
            this.usid = usid;
            this.cid = cid;
            this.tipo = tipo;
            this.status = status;
            this.datacriacao = datacriacao;
            this.dataexpiracao = dataexpiracao;
            this.descricao = descricao;
            this.titulo = titulo;
        }

        public List<DBCandidatos> getCandidatos()
        {
            DBController dbcontroller = new DBController();
            return dbcontroller.getCandidatos("where aid="+aid);
        }

        /*public bool addCandidato(DBCandidatos candidato)
        {
            DBController dbcontroler = new DBController();
            dbcontroller.addCandidato(candidato);
        }*/

    }
}

