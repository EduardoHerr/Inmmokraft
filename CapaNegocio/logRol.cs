using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class logRol
    {
        private static DataBaseDataContext db = new DataBaseDataContext();

        public static List<tblTipoUsuario> obtenerRol()
        {
            var st = db.tblTipoUsuario.Where(rol => rol.tusuEstado == 'A');

            return st.ToList();
        }

    }
}
