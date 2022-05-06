using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class logDatos
    {
        //Instanciamos la base
       private static DataBaseDataContext db = new DataBaseDataContext();

        public static List<tblDatos> listarDatos()
        {
            var st = db.tblDatos.Where(dat => dat.datEstado == 'A');
            return st.ToList();
        }

        public static List<tblDatos> listarDatosxID(int key)
        {
            var st = db.tblDatos.Where(dat => dat.datEstado == 'A' & dat.idUsuario==key);
            return st.ToList();
        }

        static public tblDatos obtenerDatos(int key)
        {
           tblDatos dat = db.tblDatos.Single(r => r.idDato == key);
            return dat;
        }

        

        static public tblDatos obtenerDat()
        {
            tblDatos dat = (tblDatos)db.tblDatos.Where(r => r.datEstado == 'A');
            return dat;
        }

        static public Array obtenerImg(int key)
        {
            var img = from i in db.tblDatos where i.idDato==key select i.datArte.ToArray();
            return img.ToArray();
        }
        public object cargarDatos()
        {
            var st = from s in db.tblDatos select s;
            return st;
        }

        public  static void registrarDatos(tblDatos objDatos)
        {
           
            try
            {
                
                objDatos.datEstado = 'A';
                db.tblDatos.InsertOnSubmit(objDatos);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Datos no guardados: " + ex.Message);
            }
        }

        static public void actualizaDatos1(tblDatos objDatos)
        {
            try
            {
                tblDatos objactualiza = db.tblDatos.Single(r => r.idDato == objDatos.idDato);
                objactualiza.datContInteresado = objDatos.datContInteresado;
                objactualiza.datCantInteresado = objDatos.datCantInteresado;
                objactualiza.datContramensaje = objDatos.datContramensaje;
                objactualiza.datCantRecibidos = objDatos.datCantRecibidos;
                objactualiza.datLlamadaFinal = objDatos.datLlamadaFinal;
                objactualiza.datCita = objDatos.datCita;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Datos no modificados: " + ex.Message);
            }
        }

        static public void actualizaDatos(tblDatos objDatos)
        {
            try
            {
                tblDatos objactualiza = db.tblDatos.Single(r => r.idDato == objDatos.idDato);
                objactualiza.idUsuario = objDatos.idUsuario;
                objactualiza.idPagina = objDatos.idPagina;
                objactualiza.idGrupo = objDatos.idGrupo;
                objactualiza.datPerfil = objDatos.datPerfil;
                objactualiza.datPropiedad = objDatos.datPropiedad;
                objactualiza.datTipo = objDatos.datTipo;
                objactualiza.datArte = objDatos.datArte;
                objactualiza.datFechaHoraPub = objDatos.datFechaHoraPub;
                objactualiza.datSitio = objDatos.datSitio;
                objactualiza.datGrupoPost = objDatos.datGrupoPost;
                

                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Datos no modificados: " + ex.Message);
            }
            
        }

        static public void eliminarDatos(tblDatos dat)
        {
            try
            {
                dat.datEstado = 'I';
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Datos no eliminados: " + ex.Message);
            }
            
        }

    }
}
