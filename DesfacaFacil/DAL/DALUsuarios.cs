using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL
{

    public class DALUsuarios
    {
        static DBCon dbcon = new DBCon();
        ///<summary>
        ///<para>Retorna o ID do usuario a partir do email informado</para>
        ///</summary>
        public static string GetIDByEmail(string email)
        {
            string id;
            id = dbcon.queryColuna("select usid from usuarios where email='" + email + "'")[0];
            return id;
        }


        ///<summary>
        ///<para>Retorna a nome do usuario a partir do ID informado</para>
        ///Requer como parametro uma string ou numero que representa a ID
        ///</summary>
        public static string GetNomeByID(object _id)
        {
            string id;

            if (_id.GetType() == typeof(int) || _id.GetType() == typeof(string))
            {

                id = dbcon.queryColuna("select nome from usuarios where usid='" + _id + "'")[0];
            }
            else
            {
                id = null;
                Debug.WriteLine("Tipo invalido informado no metodo \"NomeByID\"");
            }
            return id;
        }


        ///<summary>
        ///<para>Retorna os endereço do usuario contento:</para>
        ///0 - eid, 1 - pais, 2 - estado, 3 - cidade, 4 - bairro, 5 - rua, 6 - numero, 7 - cep
        ///</summary>
        public static List<string> GetEnderecoByID(object _id)
        {
            if (_id.GetType() == typeof(int) || _id.GetType() == typeof(string))
            {
                List<string> endereco = dbcon.queryLinha("select eid,pais,estado,cidade,bairro,rua,numero,cep from endereco where usid='" + _id + "'");

                return endereco;
            }
            else
            {
                Debug.WriteLine("Tipo invalido informado no metodo \"NomeByID\"");
            }
            return new List<string>();
        }
        public static string getNome(object _id)
        {
            return dbcon.getAtributo("nome", "usuarios", "usid", _id);
        }
        public static string getStatus(object _id)
        {
            return dbcon.getAtributo("status", "usuarios", "usid", _id);
        }
        public static string getDataEmail(object _id)
        {
            return dbcon.getAtributo("email", "usuarios", "usid", _id);
        }
        public static string getDataTelefone(object _id)
        {
            return dbcon.getAtributo("telefone", "usuarios", "usid", _id);
        }
        public static string getDatacadastro(object _id)
        {
            return dbcon.getAtributo("datacadastro", "usuarios", "usid", _id);
        }
        public static string getSenha(object _id)
        {
            return dbcon.getAtributo("senha", "usuarios", "usid", _id);
        }
    }
}
