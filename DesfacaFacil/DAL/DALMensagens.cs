using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL
{
    public class DALMensagens
    {
        static DBCon dbcon = new DBCon();
        ///<summary>
        ///<para>Retorna as IDs de todas as mensagens de um anuncio</para>
        ///</summary>
        public static List<string> GetMensagensByAnuncio(int anuncio)
        {
            return dbcon.queryColuna("select mid from mensagens");
        }


        ///<summary>
        ///<para>Retorna as IDs de todas as mensagens de um determinado remetente</para>
        ///</summary>
        public static List<string> GetMensagensByRemetente(object _id)
        {
            if (_id.GetType() == typeof(int) || _id.GetType() == typeof(string))
            {

                return dbcon.queryColuna("select mid from mensagens where usidremetente='" + _id + "'");
            }
            else
            {
                Debug.WriteLine(DateTime.Now + " -- Tipo invalido informado no metodo \"GetMensagensByUsuario\"");
                return new List<string>();
            }

        }

        ///<summary>
        ///<para>Retorna as IDs de todas as mensagens de um determinado destinatario</para>
        ///</summary>
        public static List<string> GetMensagensByDestinario(object _id)
        {
            if (_id.GetType() == typeof(int) || _id.GetType() == typeof(string))
            {

                return dbcon.queryColuna("select mid from mensagens where usidremetente='" + _id + "'");
            }
            else
            {
                Debug.WriteLine(DateTime.Now + " -- Tipo invalido informado no metodo \"GetMensagensByUsuario\"");
                return new List<string>();
            }

        }

    }
}
