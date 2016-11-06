using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBEndereco
    {
        public DBEndereco(string eid, int usid, string pais, string estado, string cidade, string bairro, string rua, int numero, string cep)
        {
            this.eid = eid;
            this.usid = usid;
            this.pais = pais;
            this.estado = estado;
            this.cidade = cidade;
            this.bairro = bairro;
            this.rua = rua;
            this.numero = numero;
            this.cep = cep;
        }

        public string eid { get; set; }
        public int usid { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string cep { get; set; }
    }
}
