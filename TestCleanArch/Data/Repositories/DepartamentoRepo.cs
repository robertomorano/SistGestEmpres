
using Data.DataBase;

using Microsoft.Data.SqlClient;
using Domain.Entities;
using Domain.Repositories;


namespace Data.Repositories
{
    public class DepartamentoRepo : ICRUDDepartamentoRepository
    {
        public List<Departamento> GetDepartamentos()
        {
            SqlConnection miConexion = new SqlConnection();
            List<Departamento> listadoDepartamentos = new List<Departamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Departamento oDepartamento;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new Departamento();
                        oDepartamento.Id = (int)miLector["IdDepartamento"];
                        oDepartamento.Name = (string)miLector["Nombre"];

                        listadoDepartamentos.Add(oDepartamento);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoDepartamentos;
        }

        public Departamento GetDepartamentoById(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Departamento oDepartamento = null;
            

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Departamentos WHERE IdDepartamento = @Id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Id", id);
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new Departamento();
                        oDepartamento.Id = (int)miLector["IdDepartamento"];
                        oDepartamento.Name = (string)miLector["Nombre"];

                        
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return oDepartamento;
        }

        public int CreateDepartamento(Departamento departamento)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int resultado = 0;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Nombre", departamento.Name);
                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return resultado;
        }

        public int DeleteDepartamento(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int resultado = 0;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Departamentos WHERE IdDepartamento = @Id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Id", id);
                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return resultado;
        }

        public int UpdateDepartamento(Departamento departamento)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int resultado = 0;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "UPDATE Departamentos SET Nombre = @Nombre WHERE IdDepartamento = @Id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Id", departamento.Id);
                miComando.Parameters.AddWithValue("@Nombre", departamento.Name);
                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return resultado;
        }

        public int CheckPersonasInDepartamento(int idDepartamento)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int contador = 0;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT COUNT(*) FROM Personas WHERE IdDepartamento = @IdDepartamento";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                contador = (int)miComando.ExecuteScalar();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return contador;
        }
    }
}