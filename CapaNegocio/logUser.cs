using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class logUser
    {
        static DataBaseDataContext db = new DataBaseDataContext();
       
        #region Autentificaciones
        public static bool usLog(string log)
        {
            var auto = db.tblUsuario.Any(x => x.usCedula == log);
            return auto;
        }

        public static bool verificacion(string cedula, string clave)
        {
            var bol = db.tblUsuario.Any(x => x.usCedula == cedula & x.usClave == clave);
            return bol;
        }

        public static bool autentificarLog(string userlog, string clave)
        {
            var rs = db.tblUsuario.Any(x => x.usEstado == 'A' & x.usCedula.Equals(userlog) & x.usClave.Equals(clave));
            return rs;
        }

        public static tblUsuario autentificarxLoginlog(string ci, string clave)
        {
            var rs = db.tblUsuario.Single(x => x.usEstado == 'A' & x.usCedula.Equals(ci) & x.usClave.Equals(clave));
            return rs;
        }
        #endregion

        #region Obtencion de datos
        public object cargaUser()
        {
            var st = db.tblUsuario.Where(us => us.usEstado == 'A');
            return st;
        }

        public static bool cilogin(string ci)
        {
            var auto = db.tblUsuario.Any(usu => usu.usEstado == 'A' & usu.usCedula.Equals(ci));
            return auto;
        }
        public static tblUsuario inforci(string ci)
        {
            var auto = db.tblUsuario.Single(usu => usu.usCedula.Equals(ci));

            return auto;
        }

        public static tblUsuario obtenerxID(int key)
        {
            var usxID = db.tblUsuario.FirstOrDefault(us => us.idUsuario.Equals(key) && us.usEstado == 'A');
            return usxID;
        }
    

        public static List<tblUsuario> listarUsersxID(int tusu)
        {
            var rs = db.tblUsuario.Where(x => x.usEstado == 'A' & x.idTipUsu == tusu);
            return rs.ToList();
        }
        #endregion

        #region CRUD

        public static void save(tblUsuario user)
        {
            try
            {
                user.usEstado = 'A';
                db.tblUsuario.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void edit(tblUsuario us)
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Los datos no fueron Modificados <br/>" + ex.Message);
            }
        }

        public static void eliminarUser(tblUsuario us)
        {
            try
            {
                us.usEstado = 'I';
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no fueron Modificados <br/>" + ex.Message);


                throw;
            }
        }

        #endregion


    }
}
