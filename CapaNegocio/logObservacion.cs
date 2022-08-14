using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class logObservacion
    {
        private static DataBaseDataContext db = new DataBaseDataContext();
        static public List<tblObservacion> obtenerObservaciones(int key)
        {
            var cmd = db.tblObservacion.Where(r => r.idDato == key);
            return cmd.ToList();
        }


        static public bool actualizarObservaciones(tblObservacion objObservacion)
        {
            try
            {
                tblObservacion objactualiza = db.tblObservacion.Single(r => r.idObservacion == objObservacion.idObservacion);
                objactualiza.observacion = objObservacion.observacion;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
