using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace paulbanreservas.Models
{
    public class PersonaDataAccessLayer
    {
        string connectionString = "Server=tcp:paulbanreservas.database.windows.net,1433;Initial Catalog=paulbanreservas;Persist Security Info=False;User ID=paulbanreservas;Password=banreservas1234@.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public IEnumerable<Persona> GetAllPersonas()
        {
            List<Persona> lstpersona = new List<Persona>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Spgetallpersona", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Persona persona = new Persona();
                    persona.id = Convert.ToInt32(rdr["id"]);
                    persona.nombre =  rdr["nombre"].ToString();
                    persona.fechaDeNacimiento = Convert.ToDateTime(rdr["fechaDeNacimiento"]);
                    lstpersona.Add(persona);
                }
                con.Close();
            }
            return lstpersona;
        }
        public void AddPersona(Persona persona)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Spaddpersona", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@fechaDeNacimiento", persona.fechaDeNacimiento);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdatePersona(Persona persona)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Spupdatepersona", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", persona.id);
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@fechaDeNacimiento", persona.fechaDeNacimiento);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Persona GetPersonaData(int? id)
        {
            Persona persona = new Persona();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM persona WHERE id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    persona.id = Convert.ToInt32(rdr["id"]);
                    persona.nombre = rdr["nombre"].ToString();
                    persona.fechaDeNacimiento = Convert.ToDateTime(rdr["fechaDeNacimiento"]);
                }
            }
            return persona;
        }
        public void DeletePersona(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Spdeletepersona", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}