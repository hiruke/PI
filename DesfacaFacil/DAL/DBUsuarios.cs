using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{

    public class DBUsuarios
    {
        DBCon dbcon = new DBCon();
        public int usid { get; set; }
        public int status { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public DateTime dataCadastro { get; set; }
        public string senha { get; set; }
        private List<DBAnuncio> anuncios { get; set; }


        public DBUsuarios(int _usid, int _status, string _nome, string _email, string _telefone, DateTime _dataCadastro, string _senha)
        {
            nome = _nome;
            usid = _usid;
            status = _status;
            email = _email;
            telefone = _telefone;
            senha = _senha;
            dataCadastro = _dataCadastro;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DBAnuncio> listaAnuncios()
        {
            OracleCommand comandos = new OracleCommand("select aid, usid, cid, tipo, status, datacriacao, dataexpiracao, descricao, titulo from anuncio where usid="+usid, dbcon.getCon());
            OracleDataReader leitor = comandos.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBAnuncio> lista = new List<DBAnuncio>();
                while (leitor.Read())
                {
                    lista.Add(new DBAnuncio(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetInt32(2), leitor.GetInt32(3), leitor.GetInt32(4), leitor.GetDateTime(5), leitor.GetDateTime(6), leitor.GetString(7), leitor.GetString(8)));
                }
                comandos.Dispose();
                leitor.Dispose();

            }
            return new List<DBAnuncio>();
        }
    }
}
