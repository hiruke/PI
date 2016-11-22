using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace DAL
{
    public static class DBCon
    {
        static private OracleConnection conexao;

        static public OracleConnection getCon()
        {
            conexao = new OracleConnection("Data Source=ovcentral.dyndns.org:443:xe;Persist Security Info=True;User ID=desfacafacil;Password=123*abc");

            if (conexao.State != System.Data.ConnectionState.Open)
            {
                conexao.Open();
            }
            return conexao;
        }
        /// <summary>
        /// Finaliza a conexão com o banco
        /// </summary>
        static public void closeCon()
        {
            conexao.Close();
        }
    }
}
