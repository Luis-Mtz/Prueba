using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace JuguetiMax.Juguetes.Data
{

    public class DatJuguetes
    {
        SqlConnection con = new SqlConnection();

        public DatJuguetes()
        {
            con.ConnectionString = ("Data Source=DESKTOP-GJAEV7B ; Initial Catalog=Juguetes; User id=sa; Password=12345;");

        }


        public DataTable Obtener()
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT  [Jugue_Id],[Jugue_Nombre],[Jugue_Existencia],[Jugue_Marca_Id],Jugue_Modelo_Id,[Jugue_Categoria_Id],[Jugue_Fecha_Alta],[Jugue_Precio],[Jugue_Estatus],[Jugue_Foto],[Jugue_Costo],Cata_Id, Cata_Nombre,Cata_Modelo_Id, Cata_Modelo_Nombre, Cata_Modelo_Marca_Id, Cate_Id, Cate_Nombre  FROM Juguetes.[dbo].[Juguete]  inner join [dbo].[Cata_Marca] on  [Cata_Id]= [Jugue_Marca_Id]  inner join [dbo].[Cata_Modelo] on  [Cata_Modelo_Id] = [Jugue_Modelo_Id] inner join [dbo].[Cata_Categoria] on [Cate_Id] = [Jugue_Categoria_Id]", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataRow Obtener(int id)
        {

            SqlDataAdapter da = new SqlDataAdapter(string.Format("select * from Juguete where Jugue_Id =" + id), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }

        public int Insertar(string Nombre, int Existencia, int Marca, int Modelo, int Categoria, string Fecha, double Precio, bool Estatus, double Costo, string Foto)
        {


            SqlCommand com = new SqlCommand(string.Format("INSERT INTO [dbo].[Juguete] ([Jugue_Id],[Jugue_Nombre],[Jugue_Existencia],[Jugue_Marca_Id],Jugue_Modelo_Id,[Jugue_Categoria_Id],[Jugue_Fecha_Alta],[Jugue_Precio],[Jugue_Estatus],[Jugue_Costo],[Jugue_Foto]) VALUES ((SELECT ISNULL(MAX(Jugue_Id)+1,1) FROM Juguete),'{0}',{1},{2},{3},{4},'{5}',{6},'{7}',{8},'{9}')", Nombre, Existencia, Marca, Modelo, Categoria, Fecha, Precio, Estatus, Costo, Foto), con);
            //DataTable dt = new DataTable();

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
            SqlCommand com = new SqlCommand(string.Format("DELETE FROM [dbo].[Juguete] WHERE Jugue_Id ='{0}' ", id), con);

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
            SqlCommand com = new SqlCommand(string.Format("UPDATE [dbo].[Juguete]   SET [Jugue_Nombre] = '{0}',[Jugue_Existencia] = {1},Jugue_Marca_Id = {2},[Jugue_Modelo_Id] = {3},[Jugue_Categoria_Id] = {4},[Jugue_Fecha_Alta] = '{5}',[Jugue_Precio] = {6},[Jugue_Estatus] = '{7}',[Jugue_Costo]={8},[Jugue_Foto] = '{9}' WHERE [Jugue_Id] = {10}", Nombre, Existencia, Marca, Modelo, Categoria, Fecha, Precio, Estatus, Costo, Foto, id), con);

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
            SqlCommand com = new SqlCommand(string.Format(" UPDATE [dbo].[Juguete]   SET [Jugue_Existencia] = (Jugue_Existencia + {0}) WHERE [Jugue_Marca_Id] = {1} AND Jugue_Modelo_Id = {2}", Existencia, marca, modelo), con);

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

            SqlCommand com = new SqlCommand(string.Format("select * from Juguete where  [Jugue_Marca_Id]= {0} and [Jugue_Modelo_Id] = {1}", idMarca, idModelo), con);
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
            SqlCommand com = new SqlCommand(string.Format(" UPDATE [dbo].[Juguete]   SET [Jugue_Existencia] ={0} WHERE [Jugue_Id] = {1}", Existencia, id), con);

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

        public DataRow Obtener(string email, string password)
        {
            SqlDataAdapter da = new SqlDataAdapter(string.Format("Select * from Usuarios where User_Email='{0}' and User_Password='{1}' ", email, password), con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt.Rows[0];
        
        }

        public DataRow ObtenerJuguete(int modelo, int marca)
        {
            SqlDataAdapter da = new SqlDataAdapter(string.Format("select Cate_Id, Cate_Nombre, Cata_Modelo_Id, Cata_Modelo_Nombre, Cata_Modelo_Marca_Id,Cata_Id, Cata_Nombre,Jugue_Id, Jugue_Nombre, Jugue_Existencia, Jugue_Marca_Id, Jugue_Modelo_Id, Jugue_Categoria_Id, Jugue_Fecha_Alta, Jugue_Precio, Jugue_Estatus, Jugue_Foto, Jugue_Costo from Juguete inner join Cata_Marca on Cata_Id = Jugue_Marca_Id inner join Cata_Modelo on [Cata_Modelo_Id] = Jugue_Modelo_Id INNER join [dbo].[Cata_Categoria] on [Cate_Id] = [Jugue_Categoria_Id] where Jugue_Modelo_Id ={0} and Jugue_Marca_Id = {1}", modelo, marca), con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows[0];
           

           
        }

    }
}