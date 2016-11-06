using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace DAL
{
    public class DBCon
    {
        private OracleConnection conexao;


        ///<summary>Cria a conexão aberta com o banco de dados ao instanciar o objeto</summary>
        public DBCon()
        {
            conexao = new OracleConnection("Data Source=ovcentral.dyndns.org:443:xe;Persist Security Info=True;User ID=desfacafacil;Password=123*abc");
            conexao.Open();
        }
        /// <summary>
        /// Retorna a conexão aberta com o banco
        /// </summary>
        /// <returns></returns>
        public OracleConnection getCon()
        {
            return conexao;
        }
        /// <summary>
        /// Finaliza a conexão com o banco
        /// </summary>
        public void closeCon()
        {
            conexao.Close();
        }

        /*/// <summary>
        /// Retorna 1 atributo a partir dos seguintes dados:
        /// Tabela, Atributo, ChavePrimaria e Identificador
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="atributo"></param>
        /// <returns></returns>

        public string getAtributo(string atributo, string entidade, string chavePrimaria, object _id)
        {

            if (_id.GetType() == typeof(int) || _id.GetType() == typeof(string))
            {
                Debug.WriteLine("Executando query: " + "select " + atributo + " from " + entidade + " where " + chavePrimaria + "='" + _id + "'");
                return queryLinha("select " + atributo + " from " + entidade + " where " + chavePrimaria + "='" + _id + "'")[0];
            }
            else
            {
                Debug.WriteLine("Tipo de dados invalido informado no metodo \"getAtributo\"");
                return "";
            }
        }



        ///<summary>
        ///<para>Executa a query informada e retorna uma lista de strings como resultado</para>
        ///</summary>
        public List<string> queryLinha(string _query)
        {
            OracleCommand comandos = new OracleCommand(_query, conexao);
            Debug.WriteLine("Executando query: " + _query);
            OracleDataReader leitor = comandos.ExecuteReader();
            Debug.WriteLine(DateTime.Now + " -- Query executada: \"" + _query + "\"");
            if (leitor.HasRows)
            {
                List<string> lista = new List<string>();
                while (leitor.Read())
                {

                    for (int i = 0; i < leitor.FieldCount; i++)
                    {
                        lista.Add(leitor.GetValue(i).ToString());
                    }
                }
                return lista;
            }
            else
            {

                leitor.Dispose();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<string>(); //retorna um objeto vazio

            }
        }

        /// <summary>
        /// <para>Executa uma inserção no banco e returna o resultado da execução</para>
        /// </summary>
        public bool insert(string _query)
        {
            OracleCommand comandos = new OracleCommand(_query, conexao);
            try
            {
                comandos.ExecuteScalar();
            }
            catch (OracleException ex)
            {
                comandos = new OracleCommand("commit", conexao);
                Debug.WriteLine(ex);
                comandos.Dispose();
                return false;
            }
            Debug.WriteLine(DateTime.Now + " -- Inserção executada: \"" + _query + "\"");
            comandos.Dispose();
            return true;
        }


        public List<string> queryColuna(string _query)
        {
            OracleCommand comandos = new OracleCommand(_query, conexao);
            Debug.WriteLine("Executando query: " + _query);
            OracleDataReader leitor = comandos.ExecuteReader();
            Debug.WriteLine(DateTime.Now + " -- Query executada: \"" + _query + "\"");

            if (leitor.HasRows)
            {
                List<string> lista = new List<string>();
                while (leitor.Read())
                {
                    switch (leitor.GetFieldType(0).ToString())
                    {
                        case "System.String":
                            lista.Add(leitor.GetString(0));
                            Debug.WriteLine(DateTime.Now + " -- Tipo String adicionado a lista");
                            break;
                        case "System.Decimal":
                            lista.Add(leitor.GetDecimal(0).ToString());
                            Debug.WriteLine(DateTime.Now + " -- Tipo Numero adicionado a lista");
                            break;
                        case "System.DateTime":
                            lista.Add(leitor.GetDateTime(0).ToString());
                            Debug.WriteLine(DateTime.Now + " -- Tipo Data adicionado a lista");
                            break;
                    }

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
                return new List<string>(); //retorna um objeto vazio
            }

        }
        */
    }
}
