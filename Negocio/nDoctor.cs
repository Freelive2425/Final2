using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nDoctor
    {
        private dDoctor Doctordatos = null;
        public nDoctor()
        {
            Doctordatos = new dDoctor();
        }
        public string InsertarDoctordatos(string dni, string nombre, string especialidad, string cargo, int numcol)
        {
            eDoctor doctor = new eDoctor()
            {
                DNI = dni,
                Nombre = nombre,
                Especialidad = especialidad,
                Cargo = cargo,
                NumColegiado = numcol
            };
            return Doctordatos.Insertar(doctor);
        }
        public string ModificarDoctordatos(string dni, string nombre, string especialidad, string cargo, int numcol)
        {
            eDoctor doctor = new eDoctor()
            {
                DNI = dni,
                Nombre = nombre,
                Especialidad = especialidad,
                Cargo = cargo,
                NumColegiado = numcol
            };
            return Doctordatos.Modificar(doctor);
        }
        public string EliminarDoctorDatos(string dni, int numcol)
        {
            return Doctordatos.Eliminar(dni, numcol);
        }
        public List<eDoctor> ListarDoctordatos()
        {
            return Doctordatos.ListarTodo();
        }
        public List<eDoctor> ListarDoctordatosRequerimientos(string especialidad, string cargo)
        {
            return Doctordatos.ListarEspecialidadCargo(especialidad, cargo);
        }
    }
}
