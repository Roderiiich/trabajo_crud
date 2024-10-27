using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosDAL
{
    public class AlumnosDAL
    {
        //ACA VAN  METODOS
        //DE INSERTAR
        //ELIMINAR
        //LISTAR
        //LISTAR-UNO
        //MODIFICAR

        private string connectionString = "Server=your_server;Database=Trabajo2_db;Trusted_Connection=True;"; // Reemplaza con tu cadena de conexión

        public void InsertarAlumno(AlumnosBOL alumno)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = @"INSERT INTO Alumnos (IDAlumno, Nombre, ApellidoPAt, ApellidoMat, Email, N_Matricula) 
                             VALUES (@IDAlumno, @Nombre, @ApellidoPAt, @ApellidoMat, @Email, @N_Matricula);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDAlumno", alumno.IDAlumno);
                    command.Parameters.AddWithValue("@Nombre", alumno.Nombre ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ApellidoPAt", alumno.ApellidoPAt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ApellidoMat", alumno.ApellidoMat ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", alumno.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@N_Matricula", alumno.N_Matricula ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
                

               

                
            }
        }

        public int EliminarAlumno(int id)
        {
            int res = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = @"delete from alumnos where id=@IDAlumno;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDAlumno", id);
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }

            }
            return res;

        }



    }
}
