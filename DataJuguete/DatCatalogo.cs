using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace JuguetiMax.Juguetes.Data
{
    public class DatCatalogo
    {
        SqlConnection con = new SqlConnection();

        public DatCatalogo()
        {
            con.ConnectionString = ("Data Source=DESKTOP-GJAEV7B ; Initial Catalog=Juguetes; User id=sa; Password=12345;");
            con.Open();
        }

        public DataTable ObtenerMarcas()
        {
            SqlDataAdapter da = new SqlDataAdapter(" select * from Cata_Marca", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable ObtenerModelos(int idMarca)
        {
            SqlDataAdapter da = new SqlDataAdapter(" select * from Cata_Modelo where cata_modelo_marca_id = "+ idMarca, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable ObtenerCategoria()
        {
            SqlDataAdapter da = new SqlDataAdapter(" select * from Cata_Categoria", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }


        public DataTable ObtenerModelos()
        {
            SqlDataAdapter da = new SqlDataAdapter(" select * from Cata_Modelo ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
