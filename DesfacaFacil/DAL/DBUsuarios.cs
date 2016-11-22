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
        public int usid { get; set; }
        public int status { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public DateTime dataCadastro { get; set; }
        public string senha { get; set; }
        private List<DBAnuncios> anuncios { get; set; }


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
        public List<DBAnuncios> listaAnuncios()
        {
            OracleCommand comando = new OracleCommand("select aid, usid, cid, tipo, status,z datacriacao, dataexpiracao, descricao, titulo from anuncio where usid=" + usid, DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBAnuncios> lista = new List<DBAnuncios>();
                while (leitor.Read())
                {
                    lista.Add(new DBAnuncios(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetInt32(2), leitor.GetInt32(3), leitor.GetInt32(4), leitor.GetDateTime(5), leitor.GetDateTime(6), leitor.GetString(7), leitor.GetString(8)));
                }
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();

            }
            comando.Dispose();
            leitor.Dispose();
            comando.Connection.Close();
            return new List<DBAnuncios>();
        }
    }
}
