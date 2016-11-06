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
    public class DBController : IDBController
    {

        /// <summary>
        /// Retorna 1 atributo a partir dos seguintes dados:
        /// Tabela, Atributo, ChavePrimaria e Identificador
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="atributo"></param>
        /// <returns></returns>
        private DBCon dbcon = new DBCon();


        public List<DBUsuarios> getUsuarios([Optional] string _condicao)

        {

            Debug.WriteLine("Executado metodo getUsuarios com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }


            OracleCommand comandos = new OracleCommand("select usid,status,nome,email,telefone,datacadastro,senha from usuarios " + condicao, dbcon.getCon());
            OracleDataReader leitor = comandos.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBUsuarios> lista = new List<DBUsuarios>();
                while (leitor.Read())
                {
                    lista.Add(new DBUsuarios(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetString(2), leitor.GetString(3), leitor.GetString(4), leitor.GetDateTime(5), leitor.GetString(6)));
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
                return new List<DBUsuarios>();
            }
        }


        /// <summary>
        /// Retorna uma lista de anuncios
        /// Use o parametro condição para espeficiar a clausula where
        /// Exemplo: getAnuncios("usid=1") para retornar anuncios cujo usid é igual a 1
        /// </summary>
        /// <returns></returns>


        public List<DBAnuncio> getAnuncios([Optional] string _condicao)
        {
            Debug.WriteLine("Executado metodo getAnuncios com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }
            Debug.WriteLine("select aid, usid, cid, tipo, status, datacriacao, dataexpiracao, descricao, titulo from anuncio " + condicao);
            OracleCommand comandos = new OracleCommand("select aid, usid, cid, tipo, status, datacriacao, dataexpiracao, descricao, titulo from anuncio " + condicao, dbcon.getCon());
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
                return lista;
            }
            else
            {
                comandos.Dispose();
                leitor.Dispose();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<DBAnuncio>();
            }

        }


        public List<DBCandidatos> getCandidatos(string _condicao)
        {
            Debug.WriteLine("Executado metodo getCandidatos com o parâmetro: " + _condicao);
            OracleCommand comandos = new OracleCommand("select canid, usid, aid from candidatos " + _condicao, dbcon.getCon());
            OracleDataReader leitor = comandos.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBCandidatos> lista = new List<DBCandidatos>();
                while (leitor.Read())
                {
                    lista.Add(new DBCandidatos(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetInt32(2)));
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
                return new List<DBCandidatos>();
            }

        }


        public void addCandidato(int _usid, int _aid)
        {
            OracleCommand comandos = new OracleCommand("insert into candidatos (usid, aid) values(" + _usid + "," + _aid + ")");
            Debug.WriteLine("Executado metodo addCandidato insert into candidatos (usid, aid) values(" + _usid + "," + _aid + ")");
            OracleDataReader leitor = comandos.ExecuteReader();
        }
    }//End Classe
}//End Namespace

