using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = "Data Source= LAPTOP-PUU85PCD\\SQLEXPRESS;Initial Catalog=NeptunoDB; User ID=USER02; Password=12345;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Actualizar_Empleado", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idEmpleado", int.Parse(txtIdEmpleados.Text));
                command.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Cargo", txtCargo.Text);
                command.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
                command.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(txtFechaNacimiento.Text));
                command.Parameters.AddWithValue("@FechaContratacion", DateTime.Parse(txtFechaContratacion.Text));
                command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                command.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                command.Parameters.AddWithValue("@Region", txtRegion.Text);
                command.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                command.Parameters.AddWithValue("@Pais", txtPais.Text);
                command.Parameters.AddWithValue("@TelDomicilio", txtTelDomicilio.Text);
                command.Parameters.AddWithValue("@Extension", txtExtension.Text);
                command.Parameters.AddWithValue("@Notas", txtNotas.Text);
                command.Parameters.AddWithValue("@Jefe", int.Parse(txtJefe.Text));
                command.Parameters.AddWithValue("@SueldoBasico", decimal.Parse(txtSueldoBasico.Text));


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con el ID proporcionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                }
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Eliminar_Empleado", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idEmpleado", int.Parse(txtIdEmpleados.Text));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Empleado eliminado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún Empleado con el ID proporcionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar Empleado: " + ex.Message);
                }
            }
        }
    }
  
}