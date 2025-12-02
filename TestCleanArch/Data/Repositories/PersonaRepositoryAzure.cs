using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Data.DataBase;


namespace Data.Repositories
{
    public class PersonaRepositoryAzure : ICRUDPeopleRepository
    {
        
        
        /// <summary>
        /// Retrieves a list of people from the database.
        /// </summary>
        /// <remarks>This method executes a SQL query to fetch all records from the "Personas" table and
        /// maps the results to a list of <see cref="Person"/> objects. Each record is converted into a <see
        /// cref="Person"/> instance, with null checks applied to optional fields such as "FechaNacimiento",
        /// "Direccion", "Telefono", and "Foto".</remarks>
        /// <returns>A <see cref="List{T}"/> of <see cref="Person"/> objects representing the people retrieved from the database.
        /// If no records are found, an empty list is returned.</returns>
        public List<Person> GetPeopleList()
        {
            SqlConnection miConexion = new SqlConnection();
            List<Person> listadoPersonas = new List<Person>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Person oPerson;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPerson = new Person();
                        oPerson.Id = (int)miLector["ID"];
                        oPerson.Name = (string)miLector["Nombre"];
                        oPerson.Surname = (string)miLector["Apellidos"];
                        //oPerson.Age = (int)miLector["Edad"];

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPerson.fechaNac = (DateTime)miLector["FechaNacimiento"];
                        }

                        if (miLector["Direccion"] != System.DBNull.Value)
                        {
                            oPerson.direccion = (string)miLector["Direccion"];
                        }

                        if (miLector["Telefono"] != System.DBNull.Value)
                        {
                            oPerson.telefono = (string)miLector["Telefono"];
                        }

                        oPerson.Departamento = (int)miLector["IDDepartamento"];

                        if (miLector["Foto"] != System.DBNull.Value)
                        {
                            oPerson.Foto = (string)miLector["Foto"];
                        }

                        listadoPersonas.Add(oPerson);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                //throw exSql;
            }

            return listadoPersonas;
        }

        public Person GetPersonById(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Person oPersona = null;
            

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Personas WHERE ID = @Id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Id", id);
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new Person();
                        oPersona.Id = (int)miLector["ID"];
                        oPersona.Name = (string)miLector["Nombre"];
                        oPersona.Surname = (string)miLector["Apellidos"];
                        //oPersona.Age = (int)miLector["Edad"];

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.fechaNac = (DateTime)miLector["FechaNacimiento"];
                        }

                        if (miLector["Direccion"] != System.DBNull.Value)
                        {
                            oPersona.direccion = (string)miLector["Direccion"];
                        }

                        if (miLector["Telefono"] != System.DBNull.Value)
                        {
                            oPersona.telefono = (string)miLector["Telefono"];
                        }

                        oPersona.Departamento = (int)miLector["IDDepartamento"];

                        if (miLector["Foto"] != System.DBNull.Value)
                        {
                            oPersona.Foto = (string)miLector["Foto"];
                        }

                        
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                //throw exSql;
            }

            return oPersona;
        }

        public int CreatePerson(Person persona)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int resultado = 0;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = @"INSERT INTO Personas (Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento, Foto) 
                                         VALUES (@Nombre, @Apellidos, @FechaNacimiento, @Direccion, @Telefono, @IdDepartamento, @Foto)";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Nombre", persona.Name);
                miComando.Parameters.AddWithValue("@Apellidos", persona.Surname);
                

                if (persona.fechaNac != DateTime.MinValue)
                {
                    miComando.Parameters.AddWithValue("@FechaNacimiento", persona.fechaNac);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@FechaNacimiento", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(persona.direccion))
                {
                    miComando.Parameters.AddWithValue("@Direccion", persona.direccion);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@Direccion", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(persona.telefono))
                {
                    miComando.Parameters.AddWithValue("@Telefono", persona.telefono);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                }

                miComando.Parameters.AddWithValue("@IdDepartamento", persona.Departamento);

                if (!string.IsNullOrEmpty(persona.Foto))
                {
                    miComando.Parameters.AddWithValue("@Foto", persona.Foto);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@Foto", DBNull.Value);
                }

                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                //throw exSql;
            }

            return resultado;
        }

        public int DeletePerson(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int resultado = 0;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Personas WHERE ID = @Id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Id", id);
                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
               // throw exSql;
            }

            return resultado;
        }

        public int UpdatePerson(Person persona)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int resultado = 0;

            miConexion.ConnectionString = Connection.GetConnectionString();

            try
            {
                miConexion.Open();
                miComando.CommandText = @"UPDATE Personas 
                                         SET Nombre = @Nombre, 
                                             Apellidos = @Apellidos, 
                                              
                                             FechaNacimiento = @FechaNacimiento, 
                                             Direccion = @Direccion, 
                                             Telefono = @Telefono, 
                                             IDDepartamento = @IdDepartamento, 
                                             Foto = @Foto 
                                         WHERE ID = @Id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@Id", persona.Id);
                miComando.Parameters.AddWithValue("@Nombre", persona.Name);
                miComando.Parameters.AddWithValue("@Apellidos", persona.Surname);
                

                if (persona.fechaNac != DateTime.MinValue)
                {
                    miComando.Parameters.AddWithValue("@FechaNacimiento", persona.fechaNac);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@FechaNacimiento", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(persona.direccion))
                {
                    miComando.Parameters.AddWithValue("@Direccion", persona.direccion);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@Direccion", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(persona.telefono))
                {
                    miComando.Parameters.AddWithValue("@Telefono", persona.telefono);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                }

                miComando.Parameters.AddWithValue("@IdDepartamento", persona.Departamento);

                if (!string.IsNullOrEmpty(persona.Foto))
                {
                    miComando.Parameters.AddWithValue("@Foto", persona.Foto);
                }
                else
                {
                    miComando.Parameters.AddWithValue("@Foto", DBNull.Value);
                }

                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
               // throw exSql;
            }

            return resultado;
        }
    }
}