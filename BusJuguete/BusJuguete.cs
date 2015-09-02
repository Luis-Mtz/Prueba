using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JuguetiMax.Juguetes.Business.Entity;
using System.Data;
using JuguetiMax.Juguetes.Data;

namespace JuguetiMax.Juguetes.Business
{
    public class BusJuguete
    {
        public BusJuguete() { }

        public List<EntJuguete> Obtener()
        {
            DataTable dt = new DatJuguetes().Obtener();
            List<EntJuguete> lst = new List<EntJuguete>();
            foreach (DataRow dr in dt.Rows)
            {
                EntJuguete ent = new EntJuguete();
                ent.Id = Convert.ToInt32(dr["Jugue_Id"]);
                ent.Nombre = dr["Jugue_Nombre"].ToString();
                ent.Marca_Id = Convert.ToInt32(dr["Jugue_Marca_Id"]);
                ent.Modelo_Id = Convert.ToInt32(dr["Jugue_Modelo_Id"]);
                ent.Categoria_Id = Convert.ToInt32(dr["Jugue_Categoria_Id"]);
                ent.Costo = Convert.ToDouble(dr["Jugue_Costo"]);
                ent.Estatus = Convert.ToBoolean(dr["Jugue_Estatus"]);
                ent.Existencia = Convert.ToInt32(dr["Jugue_Existencia"]);
                ent.Fecha = Convert.ToDateTime(dr["Jugue_Fecha_Alta"]);
                ent.Foto = dr["Jugue_Foto"].ToString();
                ent.Precio = Convert.ToDouble(dr["Jugue_Precio"]);
                ent.Marca.Nombre = Convert.ToString(dr["Cata_Nombre"]);
                ent.Modelo.Nombre = Convert.ToString(dr["Cata_Modelo_Nombre"]);
                ent.Categoria.Nombre = Convert.ToString(dr["Cate_Nombre"]);
                lst.Add(ent);

            }
            return lst;

        }

        public EntJuguete Obtener(int Id)
        {
            DataRow dr = new DatJuguetes().Obtener(Id);
            EntJuguete ent = new EntJuguete();
            ent.Id = Convert.ToInt32(dr["Jugue_Id"]);
            ent.Nombre = dr["Jugue_Nombre"].ToString();
            ent.Marca_Id = Convert.ToInt32(dr["Jugue_Marca_Id"]);
            ent.Modelo_Id = Convert.ToInt32(dr["Jugue_Modelo_Id"]);
            ent.Categoria_Id = Convert.ToInt32(dr["Jugue_Categoria_Id"]);
            ent.Costo = Convert.ToDouble(dr["Jugue_Costo"]);
            ent.Estatus = Convert.ToBoolean(dr["Jugue_Estatus"]);
            ent.Existencia = Convert.ToInt32(dr["Jugue_Existencia"]);
            ent.Fecha = Convert.ToDateTime(dr["Jugue_Fecha_Alta"]);
            ent.Foto = dr["Jugue_Foto"].ToString();
            ent.Precio = Convert.ToDouble(dr["Jugue_Precio"]);
            return ent;

        }

        public void Insertar(EntJuguete ent)
        {
            bool existe = Validar(ent.Marca_Id, ent.Modelo_Id);
            if (existe)
            {
                int filas = new DatJuguetes().Actualizar(ent.Marca_Id, ent.Existencia, ent.Modelo_Id);
                if (filas != 1) 
                    throw new ApplicationException("error al actualizar");
            }
            else
            {
                int filas = new DatJuguetes().Insertar(ent.Nombre, ent.Existencia, ent.Marca_Id, ent.Modelo_Id, ent.Categoria_Id, ent.Fecha.ToString("MM/dd/yyyy"), ent.Precio, ent.Estatus, ent.Costo, ent.Foto);
                if (filas != 1)
                    throw new ApplicationException(string.Format("Error al Insertar"));
            }
        }

        public void Actuaizar(EntJuguete ent)
        {


            int filas = new DatJuguetes().Actualizar(ent.Nombre, ent.Existencia, ent.Marca_Id, ent.Modelo_Id, ent.Categoria_Id, ent.Fecha.ToString("MM/dd/yyyy"), ent.Precio, ent.Estatus, ent.Costo, ent.Foto, ent.Id);
            if (filas != 1)
            {
                throw new ApplicationException(string.Format("Error al Actualizar"));
            }


        }

        public void Borrar(EntJuguete ent)
        {

            int filas = new DatJuguetes().Borrar(ent.Id);
            if (filas != 1)
            {
                throw new ApplicationException(string.Format("Error al Borrar"));
            }


        }

        /// <summary>
        /// Hace la actualizacion despues de restar la existencia actual con la nueva ingresada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Existencia"></param>
        public void Actuaizar(int id, int Existencia)
        {
            int filas = new DatJuguetes().Actualizar(id, Existencia);
            if (filas != 1)
                throw new ApplicationException("Error al vender");

        }

        
        public bool Validar(int idMarca, int idModelo)
        {
            bool existe = new DatJuguetes().Obtener(idMarca, idModelo);
            return existe;
        }
    }



}