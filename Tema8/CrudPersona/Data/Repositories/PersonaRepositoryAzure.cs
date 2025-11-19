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
    public class PersonaRepositoryAzure : IGetPeopleListRepository
    {

        public Person[] GetPeopleList()
        {
            SqlConnection miConexion = new SqlConnection();

            List<Person> listadoPersonas = new List<Person>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Person oPersona;

            miConexion.ConnectionString = (Conection.GetConnectionString());
            try

            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oPersona = new Person();

                        oPersona.ID = (int)miLector["ID"];

                        oPersona.name = (string)miLector["Nombre"];

                        oPersona.surname = (string)miLector["apellidos"];
    
//Si sospechamos que el campo puede ser Null en la BBDD

                    if (miLector["FechaNacimiento"] != System.DBNull.Value)

                        { oPersona.fechaNac = (DateTime)miLector["FechaNacimiento"]; }

                        oPersona.direccion = (string)miLector["Direccion"];

                        oPersona.telefono = (string)miLector["Telefono"];

                        listadoPersonas.Add(oPersona);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)

            {

                throw exSql;

            }

            return listadoPersonas.ToArray();



        }


    }
}
