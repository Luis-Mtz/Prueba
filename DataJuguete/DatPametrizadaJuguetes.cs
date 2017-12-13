using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JuguetiMax.Juguetes.Data
{
    public class DatPametrizadaJuguetes
    {
        SqlConnection con = new SqlConnection();
        public DatPametrizadaJuguetes()
   
        {
            con.ConnectionString = ("Data Source=DESKTOP-GJAEV7B ; Initial Catalog=Juguetes; User id=sa; Password=12345;");

        }


        public DataTable Obtener()
        {
            SqlCommand com = new SqlCommand ("spSelectJuguetes", con);
            com.CommandType = CommandType.StoredProcedure;
                                                        
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataRow Obtener(int id)
        {

            SqlCommand com = new SqlCommand("spSelectJuguete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter(){SqlDbType = SqlDbType.Int, ParameterName="@Id", Value=id});

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }

        public int Insertar(string Nombre, int Existencia, int Marca, int Modelo, int Categoria, string Fecha, double Precio, bool Estatus, double Costo, string Foto)
        {

            SqlCommand com = new SqlCommand("spInsertJuguete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Nombre", Value = Nombre });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Existencia", Value = Existencia });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Marca", Value = Marca });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Modelo", Value = Modelo });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Categoria", Value = Categoria });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Fecha", Value = Fecha });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Float, ParameterName = "@Precio", Value = Precio });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Bit, ParameterName = "@Estatus", Value = Estatus });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Float, ParameterName = "@Costo", Value = Costo });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Foto", Value = Foto });
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {

                con.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public int Borrar(int id)
        {
            SqlCommand com = new SqlCommand("spDeleteJuguete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Id", Value = id });

            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;

            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException(ex.Message);
            }


        }

        public int Actualizar(string Nombre, int Existencia, int Marca, int Modelo, int Categoria, string Fecha, double Precio, bool Estatus, double Costo, string Foto, int id)
        {
            SqlCommand com = new SqlCommand("spActualizarJuguete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Nombre", Value = Nombre });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Existencia", Value = Existencia });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Marca", Value = Marca });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Modelo", Value= Modelo });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Categoria", Value = Categoria });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Fecha", Value = Fecha });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Float, ParameterName = "@Precio", Value = Precio });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Bit, ParameterName = "@Estatus", Value = Estatus });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Float, ParameterName = "@Costo", Value = Costo });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Foto", Value = Foto });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Id", Value = id });


            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;


            }
            catch (Exception ex)
            {

                con.Close();
                throw new ApplicationException(ex.Message);
            }




        }

        public int Actualizar(int marca, int Existencia, int modelo)
        {
            SqlCommand com = new SqlCommand("spActualizarValidacionUno", con);
            com.CommandType = CommandType.StoredProcedure;
       
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Existencia", Value = Existencia });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Marca", Value = marca });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Modelo", Value = modelo });
            

            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;


            }
            catch (Exception ex)
            {

                con.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public bool Obtener(int idMarca, int idModelo)
        {

            SqlCommand com = new SqlCommand("spObtenerbool",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@idMarca", Value = idMarca });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@idModelo", Value = idModelo }); 
            
            try
            {
                con.Open();
                bool existe = Convert.ToBoolean(com.ExecuteScalar());
                con.Close();
                return existe;

            }
            catch (Exception ex)
            {

                con.Close();
                throw new ApplicationException(ex.Message);
            }



        }

        public int Actualizar(int id, int Existencia)
        {



            SqlCommand com = new SqlCommand("spActualizarValidacionDos", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Existencia", Value = Existencia });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@Id", Value = id });

            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;

            }
            catch (Exception ex)
            {

                con.Close();
                throw new ApplicationException(ex.Message);
            }
        }




    }
}
