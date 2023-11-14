using System;
using Datos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NPaciente
    {
        private DPaciente dPaciente=new DPaciente();
        public NPaciente() { } //CONSTRUCTOR

        public String Registrar(PACIENTE paciente)
        {
            return dPaciente.Registrar(paciente);
        }

        public String Modificar(PACIENTE paciente)
        {
            return dPaciente.Modificar(paciente);
        }

        public String Eliminar(int codigoid)
        {
            return dPaciente.Eliminar(codigoid);
        }

        public double ObtenerPromedioEdadRRHH()
        {
            return dPaciente.ObtenerPromedioEdadRRHH();
        }
        /// AUXILIAR DE LISTAR

        public List<PACIENTE> ListarTodo()
        {
            return dPaciente.ListarTodo();
        }

        public List<PACIENTE> ListarXAreadeMarketing()
        {
            return dPaciente.ListarXAreadeMarketing();
        }

        public List<PACIENTE> ListarTodoBuscarPorCodigo(String codigo)
        {
            return dPaciente.ListarTodoBuscarPorCodigo(codigo);
        }
        public int CantidadPacientesConPesoMayorA100()
        {
            return dPaciente.CantidadPacientesConPesoMayorA100();
        }
        public List<PACIENTE> ListaOrdenadaxEdad()
        {
            return dPaciente.ListaOrdenadaxEdad();
        }
    }
}
