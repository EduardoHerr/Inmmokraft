using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class logGrupo
    {
        static DataBaseDataContext db = new DataBaseDataContext();
        static public tblGrupos obtenerDatos(int key)
        {
            tblGrupos dat = db.tblGrupos.Single(r => r.idGrupo == key);
            return dat;
        }


    }
}
