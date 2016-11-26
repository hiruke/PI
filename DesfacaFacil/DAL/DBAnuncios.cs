using System;
using System.Collections.Generic;
using System.Linq;
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
            return dbcontroller.getCandidatos("aid=" + aid);
        }

        public DBUsuarios getUsuario()
        {

            DBController dbcontroller = new DBController();
            return dbcontroller.getUsuarios("usid=" + usid).Single();
        }


        public List<DBMensagens> getMensagens([Optional] string _condicao)

        {
            Debug.WriteLine("Executado metodo getAnuncios com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = " and " + _condicao;
            }

            OracleCommand comando = new OracleCommand("select mid,usidremetente,usiddestinatario,conteudo,aid,hora from mensagens where aid='" + aid + "'" + condicao, DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBMensagens> lista = new List<DBMensagens>();
                while (leitor.Read())
                {
                    lista.Add(new DBMensagens(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetInt32(2), leitor.GetString(3), leitor.GetInt32(4), leitor.GetDateTime(5)));
                }
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                return lista;
            }
            else
            {
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                Debug.WriteLine(this.dataexpiracao + " -- Retornada lista vazia");
                return new List<DBMensagens>();
            }
        }

        public void Alterar(int tipo, string titulo, string descricao, int categoria, int duracao)
        {

            string dataexpiracao = this.dataexpiracao.AddDays(duracao).Day + "/" + this.dataexpiracao.AddDays(duracao).Month + "/" + this.dataexpiracao.AddDays(duracao).Year + " " + this.dataexpiracao.AddDays(duracao).Hour + ":" + this.dataexpiracao.AddDays(duracao).Minute + ":" + this.dataexpiracao.AddDays(duracao).Second;

            OracleCommand comando = new OracleCommand("update anuncio set titulo='" + titulo + "',descricao='" + descricao + "',cid=" + categoria + ",dataexpiracao=to_date('" + dataexpiracao + "', 'DD/MM/YYYY hh24:mi:ss')where aid=" + aid, DBCon.getCon());
            Debug.WriteLine("Executado metodo AlterarAnuncio: update anuncio set titulo='" + titulo + "',descricao='" + descricao + "',cid=" + categoria + ",dataexpiracao=to_date('" + dataexpiracao + "', 'DD/MM/YYYY hh24:mi:ss') where aid=" + aid);
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando.Connection.Close();
            DBController dbcontroller = new DBController();
            dbcontroller.commit();

        }

        public string Fechar()
        {
            OracleCommand comando = new OracleCommand("update anuncio set status=" + 2 + " where aid=" + aid, DBCon.getCon());
            Debug.WriteLine("update anuncio set status=" + 2 + " where aid=" + aid);
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando.Connection.Close();
            DBController dbcontroller = new DBController();
            dbcontroller.commit();
            return "";
        }
    }
}
