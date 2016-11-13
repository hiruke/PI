using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DAL;

namespace DAL
{
    public interface IDBController
    {
        List<DBUsuarios> getUsuarios([Optional] string _condicao);
        List<DBAnuncios> getAnuncios([Optional] string _condicao);
        List<DBCandidatos> getCandidatos([Optional] string _condicao);
        void addCandidato(int _usid, int _aid);
        void addAnuncio(int usid, int cid, int tipo, int status, int duracao, string descricao, string titulo);
        List<DBCategorias> getCategorias([Optional] string _condicao);

    }
}
