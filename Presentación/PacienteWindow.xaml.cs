using System;
using Datos;
using Negocios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentación
{
    /// <summary>
    /// Lógica de interacción para PacienteWindow.xaml
    /// </summary>
    public partial class PacienteWindow : Window
    {
        public PacienteWindow()
        {
            InitializeComponent();
            MostrarPacientes(nPaciente.ListarTodo());
        }

        NPaciente nPaciente = new NPaciente();
        PACIENTE pacienteElegido = null;

        //exclusivo para el datagrid
        private void MostrarPacientes(List<PACIENTE> pacientes)
        {
            dgPaciente.ItemsSource = new List<PACIENTE>();
            dgPaciente.ItemsSource = pacientes;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (txtNombre.Text == "" || txtEdad.Text == "" || txtArea.Text == "" || txtPeso.Text == "")
            {
                MessageBox.Show("Ingresar todos los campos, campos vacíos");
                return;
            }

            // Creando el objeto
            PACIENTE paciente = new PACIENTE
            {
                nombre = txtNombre.Text,
                edad = int.Parse(txtEdad.Text),
                area = txtArea.Text,
                peso = Decimal.Parse(txtPeso.Text),
            };

            // Registro
            String mensaje = nPaciente.Registrar(paciente);
            MessageBox.Show(mensaje);

            //Se muestra en el DataGrid
            MostrarPacientes(nPaciente.ListarTodo());
        }

        private void txtSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pacienteElegido = dgPaciente.SelectedItem as PACIENTE; // pasa como tipo, obj variable al seleccionar
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (txtNombre.Text == "" || txtEdad.Text == "" || txtArea.Text == "" || txtPeso.Text == "")
            {
                MessageBox.Show("Ingresar todos los campos, campos vacíos");
                return;
            }

            // Validación de selección
            if (pacienteElegido == null)
            {
                MessageBox.Show("Seleccione un PACIENTE");
                return;
            }

            // Creando el objeto
            PACIENTE paciente = new PACIENTE
            {
                codigo = pacienteElegido.codigo,
                nombre = txtNombre.Text,
                edad = int.Parse(txtEdad.Text),
                area = txtArea.Text,
                peso = Decimal.Parse(txtPeso.Text),
            };


            // Registrar el objeto
            String mensaje = nPaciente.Modificar(paciente);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarPacientes(nPaciente.ListarTodo());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //validación
            if (pacienteElegido == null)
            {
                MessageBox.Show("Seleccione un paciente de la lista");
                return;
            }

            // Eliminando
            String mensaje = nPaciente.Eliminar(pacienteElegido.codigo);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarPacientes(nPaciente.ListarTodo());
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            nPaciente.ListarTodo();
        }

        private void btnPromedioPacientesRRHH_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show( "Proemdio de Pacientes en el area de RRHH :"+ nPaciente.ObtenerPromedioEdadRRHH().ToString());
        }

        private void btnPesomayor100_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("La cantidad de pacientes con un peso > a 100 es: " + nPaciente.CantidadPacientesConPesoMayorA100().ToString());

        }

        private void btnListarxAreaMkt_Click(object sender, RoutedEventArgs e)
        {
            MostrarPacientes(nPaciente.ListarXAreadeMarketing());
        }

        private void btnOrdenarporEdad_Click(object sender, RoutedEventArgs e)
        {
            MostrarPacientes(nPaciente.ListaOrdenadaxEdad());
        }
    }
}
