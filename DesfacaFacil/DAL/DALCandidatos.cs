using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCandidatos
    {
        static DBCon dbcon = new DBCon();
        public static List<string> GetCandidatosByAnuncio(int _id)
        {
            return dbcon.queryColuna("select canid from candidatos where canid=" + _id);
        }


    }
}
