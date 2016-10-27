using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL
{
    public class DALAnuncios
    {
        static DBCon dbcon = new DBCon();


        /// <summary>
        /// Retorna a lista de todos os anuncios
        /// </summary>
        /// <returns></returns>
        public static List<string> getAnuncios()
        {
            return dbcon.queryColuna("select aid from anuncio");
        }


        /// <summary>
        /// Retorna os anuncios de um determinado usuário
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static List<string> getAnunciosByUsuario(object _id)
        {
            List<string> ids;
            if (_id.GetType() == typeof(int) || _id.GetType() == typeof(string))
            {

                ids = dbcon.queryColuna("select aid from anuncios where usid='" + _id + "'");
            }
            else
            {
                ids = null;
                Debug.WriteLine("Tipo invalido informado no metodo \"getAnunciosByUsuario\"");
            }
            return ids;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static string getTitulo(object _id)
        {
            return dbcon.getAtributo("titulo", "anuncio", "aid", _id);
        }
        public static string getDescricao(object _id)
        {
            return dbcon.getAtributo("descricao", "anuncio", "aid", _id);
        }
        public static string getDataCriacao(object _id)
        {
            return dbcon.getAtributo("datacriacao", "anuncio", "aid", _id);
        }
        public static string getDataExpiracao(object _id)
        {
            return dbcon.getAtributo("dataexpiracao", "anuncio", "aid", _id);
        }
        public static string getUSID(object _id)
        {
            return dbcon.getAtributo("usid", "anuncio", "aid", _id);
        }
    }
}

