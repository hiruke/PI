using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public class DBCandidatos
    {
        public int canid { get; set; }
        public int usid { get; set; }
        public int aid { get; set; }

        public DBCandidatos(int _canid, int _usid, int _aid)
        {
            canid = _canid;
            usid = _usid;
            aid = _aid;
        }

        public DBUsuarios getUsuario()
        {
            DBUsuarios usuario;
            DBCon dbcon = new DBCon();
            IDBController dbcontroller = new DBController();
            OracleCommand comando = new OracleCommand("select unique usid, status, nome, email, telefone, datacadastro, senha from usuarios where usid=" + usid, dbcon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                usuario = new DBUsuarios(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetString(2), leitor.GetString(3), leitor.GetString(4), leitor.GetDateTime(5), leitor.GetString(6));
                return usuario;
            }
            return null;
        }
    }

}

