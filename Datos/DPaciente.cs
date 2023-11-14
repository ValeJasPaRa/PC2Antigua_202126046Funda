using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DPaciente
    {
        public DPaciente() { }

        public String Registrar(PACIENTE paciente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.PACIENTE.Add(paciente);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(PACIENTE paciente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    PACIENTE pacienteTemp = context.PACIENTE.Find(paciente.codigo);
                    pacienteTemp.nombre = paciente.nombre;
                    pacienteTemp.edad = paciente.edad;
                    pacienteTemp.peso = paciente.peso;
                    pacienteTemp.area = paciente.area;
                    context.SaveChanges();
                }
                return "Modificado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Eliminar(int codigoid)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    PACIENTE pacienteTemp = context.PACIENTE.Find(codigoid);
                    context.PACIENTE.Remove(pacienteTemp);
                    context.SaveChanges();
                }
                return "Eliminaado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public double ObtenerPromedioEdadRRHH()
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    var pacientesRRHH = context.PACIENTE.Where(a => a.area.Equals("RRHH")).ToList();
                    //verificación
                    if (pacientesRRHH.Any())
                    {               
                        double promedioEdad = pacientesRRHH.Average(p => p.edad);
                        return promedioEdad;
                    }
                    else
                    {
                        Console.WriteLine("No hay pacientes en el área de RRHH.");
                        return 0; 
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                return 0; 
            }
        }
        /// AUXILIAR DE LISTAR
        
        public List<PACIENTE> ListarTodo()
        {
            List<PACIENTE> pacientes = new List<PACIENTE>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    pacientes = context.PACIENTE.ToList();
                }
                return pacientes;
            }
            catch (Exception ex)
            {
                return pacientes;
            }
        }

        public List<PACIENTE> ListarXAreadeMarketing()
        {
            List<PACIENTE> pacientes = new List<PACIENTE>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    pacientes = context.PACIENTE.Where(a => a.area.Equals("Marketing")).ToList();
                }
                return pacientes;
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                return pacientes;
            }
        }

        public List<PACIENTE> ListarTodoBuscarPorCodigo(String codigo)
        {
            List<PACIENTE> pacientes = new List<PACIENTE>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    pacientes = context.PACIENTE.Where(a => a.codigo.Equals(codigo)).ToList();
                }
                return pacientes;
            }
            catch (Exception ex)
            {
                return pacientes;
            }
        }
        public int CantidadPacientesConPesoMayorA100()
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    
                    int cantidadPacientes = context.PACIENTE.Count(p => p.peso > 100);
                    return cantidadPacientes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0; 
            }
        }

        public List<PACIENTE> ListaOrdenadaxEdad()
        {
            List<PACIENTE> pacientes = new List<PACIENTE>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    pacientes = context.PACIENTE.OrderBy(a => a.edad).ToList();
                }
                return pacientes;
            }
            catch (Exception ex)
            {
                return pacientes;
            }
        }

    }
}
