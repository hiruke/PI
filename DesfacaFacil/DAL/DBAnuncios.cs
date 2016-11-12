using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System.Runtime.InteropServices;

namespace DAL
{


    public class DBAnuncios

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


        public DBAnuncios(int aid, int usid, int cid, int tipo, int status, DateTime datacriacao, DateTime dataexpiracao, string descricao, string titulo)
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
            candidatos = dbcontroller.getCandidatos("aid=" + aid);
            return candidatos;
        }


        public List<DBMensagens> getMensagens([Optional] string _condicao)

        {
            Debug.WriteLine("Executado metodo getAnuncios com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }

            OracleCommand comandos = new OracleCommand("select mid,usidremetente,usiddestinatario,conteudo,aid,hora from mensagens " + condicao, DBCon.getCon());
            OracleDataReader leitor = comandos.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBMensagens> lista = new List<DBMensagens>();
                while (leitor.Read())
                {
                    lista.Add(new DBMensagens(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetInt32(2), leitor.GetString(3), leitor.GetInt32(4), leitor.GetDateTime(5)));
                }
                comandos.Dispose();
                leitor.Dispose();
                return lista;
            }
            else
            {
                comandos.Dispose();
                leitor.Dispose();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<DBMensagens>();
            }
        }
    }
}
