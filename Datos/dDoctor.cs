using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class dDoctor
    {
        Database db = new Database();
        public string Insertar(eDoctor obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert into Doctor(dni,nombre,especialidad,cargo,numcolegiado) values ('{0}','{1}','{2}','{3}',{4})", obj.DNI, obj.Nombre, obj.Especialidad, obj.Cargo, obj.NumColegiado);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto Doctor";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public string Modificar(eDoctor obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update Doctor set nombre='{0}', especialidad='{1}', cargo='{2}' where dni='{3}' or numcolegiado={4}", obj.Nombre, obj.Especialidad, obj.Cargo, obj.DNI, obj.NumColegiado);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modifico datos";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public string Eliminar(string dni, int numcoleg)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from Doctor where dni='{0}' or numcolegiado={1}", dni, numcoleg);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino Doctor";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        
        public List<eDoctor> ListarTodo()
        {
            try
            {
                List<eDoctor> aux = new List<eDoctor>();
                eDoctor doctor = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select dni,nombre,especialidad,cargo,numcolegiado from Doctor", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctor = new eDoctor();
                    doctor.DNI = (string)reader["dni"];
                    doctor.Nombre = (string)reader["nombre"];
                    doctor.Especialidad = (string)reader["especialidad"];
                    doctor.Cargo = (string)reader["cargo"];
                    doctor.NumColegiado = (int)reader["numcolegiado"];
                    aux.Add(doctor);
                }
                reader.Close();
                return aux;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            } 
        }
        public List<eDoctor> ListarEspecialidadCargo(string especialidad, string cargo)
        {
            try
            {
                List<eDoctor> aux = new List<eDoctor>();
                eDoctor doctor = null;
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select dni,nombre,especialidad,cargo,numcolegiado from Doctor where especialidad or cargo", especialidad, cargo);
                SqlCommand cmd = new SqlCommand(select,con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctor = new eDoctor();
                    doctor.DNI = (string)reader["dni"];
                    doctor.Nombre = (string)reader["nombre"];
                    doctor.Especialidad = (string)reader["especialidad"];
                    doctor.Cargo = (string)reader["cargo"];
                    doctor.NumColegiado = (int)reader["numcolegiado"];
                    aux.Add(doctor);
                }
                reader.Close();
                return aux;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

    }
}
