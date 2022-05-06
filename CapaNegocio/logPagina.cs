using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class logPagina
    {
        static DataBaseDataContext db = new DataBaseDataContext();
        static public List<tblPagina> obtenerPag()
        {
            var st = db.tblPagina.Select(x => x);
            return st.ToList();
        }
        static public tblPagina obtenerPagxID(int key)
        {
            tblPagina pag = db.tblPagina.Single(r => r.idPagina == key);
            return pag;
        }

        static public List<tblGrupos> obtenerGrupo(int key)
        {
            var st = db.tblGrupos.Where(g => g.idPagina == key);
            return st.ToList();
        }
    }
}
