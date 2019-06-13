using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notaas.Models
{
    public class Notas
    {
        public static string cadenaConexion { get; set; }

        public string idNota { get; set; }
        public string Titulo { get; set; }
        public string nota { get; set; }  

        public bool Guardar()
        {
            MySqlConnection conexion = new MySqlConnection(Notas.cadenaConexion);
            conexion.Open();
            string sql = "insert into nota values(0,?,?)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Titulo", this.Titulo);
            comando.Parameters.AddWithValue("@nota", this.nota);
            int filas = comando.ExecuteNonQuery();
            conexion.Close();

            return (filas > 0);
        }

        public List<Notas> Consultar()
        {
            List<Notas> contactos = new List<Notas>();
            MySqlConnection conexion = new MySqlConnection(Notas.cadenaConexion);
            conexion.Open();
            string sql = "select * from nota";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader notaa = comando.ExecuteReader();
            while (notaa.Read())
            {
                Notas c = new Notas();
                c.idNota = notaa["idNota"].ToString();
                c.Titulo = notaa["Titulo"].ToString();
                c.nota = notaa["nota"].ToString();
                contactos.Add(c);
            }
            notaa.Close();
            conexion.Close();
            return contactos;
        }


        public bool Eliminar()
        {
            MySqlConnection conexion = new MySqlConnection(Notas.cadenaConexion);
            conexion.Open();
            string sql = "delete from nota where Titulo = ?";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Titulo", this.Titulo);
            int filas = comando.ExecuteNonQuery();
            conexion.Close();
            return (filas > 0);
        }

        public bool Buscar()
        {
            bool encontrado = false;
            MySqlConnection conexion = new MySqlConnection(Notas.cadenaConexion);
            conexion.Open();
            string sql = "select * from nota";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader bus = comando.ExecuteReader();

            if (bus.Read())
            {
                this.Titulo = bus["Titulo"].ToString();
                this.nota = bus["nota"].ToString();
            }
            bus.Close();
            conexion.Close();
            return encontrado;
        }

        public bool Editar()
        {

            MySqlConnection conexion = new MySqlConnection(Notas.cadenaConexion);
            conexion.Open();
            string sql = "update nota set Titulo=?,nota=?";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Titulo", this.Titulo);
            comando.Parameters.AddWithValue("@nota", this.nota);
            int filas = comando.ExecuteNonQuery();
            conexion.Close();

            return (filas > 0);
        }


        public Notas(string Titulo)
        {
            this.Titulo = Titulo;
        }

        public Notas()
        {
        }
    }
}
