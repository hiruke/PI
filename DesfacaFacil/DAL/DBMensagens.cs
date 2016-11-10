using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL
{
    public class DBMensagens
    {

        public int mid { get; set; }
        public int usidremetente { get; set; }
        public int usiddestinatario { get; set; }
        public string conteudo { get; set; }
        public int aid { get; set; }
        public DateTime hora { get; set; }
        public DBMensagens(int mid, int usidremetente, int usiddestinatario, string conteudo, int aid, DateTime hora)
        {
            this.mid = mid;
            this.usidremetente = usidremetente;
            this.usiddestinatario = usiddestinatario;
            this.conteudo = conteudo;
            this.aid = aid;
            this.hora = hora;
        }
    }
}
