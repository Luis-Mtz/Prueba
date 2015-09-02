using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JuguetiMax.Juguetes.Business.Entity;
using System.Data;
using JuguetiMax.Juguetes.Data;

namespace JuguetiMax.Juguetes.Business
{
    public class BusCatalogo
    {
        public BusCatalogo() { }
        public List<EntModelo> ObtenerModelos(int idMarca)
        {
            DataTable dt = new DatCatalogo().ObtenerModelos(idMarca);
            List<EntModelo> lst = new List<EntModelo>();

            foreach (DataRow dr in dt.Rows)
            {
                EntModelo ent = new EntModelo();
                ent.id = Convert.ToInt32(dr["Cata_Modelo_Id"]);
                ent.Nombre = dr["Cata_Modelo_Nombre"].ToString();
                ent.Marca_id = Convert.ToInt32(dr["Cata_Modelo_Marca_Id"]);

                lst.Add(ent);
            }
            return lst;
        }
        public List<EntMarca> ObtenerMarcas()
        {
            DataTable dt = new DatCatalogo().ObtenerMarcas();
            List<EntMarca> lstdos = new List<EntMarca>();

            foreach (DataRow dr in dt.Rows)
            {
                EntMarca ent = new EntMarca();
                ent.id = Convert.ToInt32(dr["Cata_Id"]);
                ent.Nombre = dr["Cata_Nombre"].ToString();

                lstdos.Add(ent);
            }
            return lstdos;

        }

        public List<EntCategoria> ObtenerCategoria()
        {
            DataTable dt = new DatCatalogo().ObtenerCategoria();
            List<EntCategoria> lst = new List<EntCategoria>();
            foreach (DataRow dr in dt.Rows)
            {

                EntCategoria ent = new EntCategoria();
                ent.id = Convert.ToInt32(dr["Cate_id"]);
                ent.Nombre = dr["cate_nombre"].ToString();

                lst.Add(ent);
            }
            return lst;

        }




    }
}
