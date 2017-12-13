using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuguetiMax.Juguetes.Business.Entity
{
    public class EntJuguete
    {
        public EntJuguete() { }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Existencia { get; set; }
        public int Marca_Id { get; set; }
        public int Modelo_Id { get; set; }
        public int Categoria_Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Precio { get; set; }
        public bool Estatus  { get; set; }
        public string Foto { get; set; }

        public string MarcaNombre { get; set; }
        public string ModeloNombre { get; set; }
        public string FechaJSon { get; set; }
        public double Costo { get; set; }

        private EntMarca marca;

        public EntMarca Marca
        {

            get
            {
                if (marca == null)
                {
                    marca = new EntMarca();
                }
                return marca;
            }
            set
            {
                if (marca == null)
                {
                    marca = new EntMarca();
                }
                marca = value;
            }
        }

        private EntModelo modelo;

        public EntModelo Modelo
        {
            get
            {
                if (modelo == null)
                {
                    modelo = new EntModelo();
                }
                return modelo;
            }
            set
            {
                if (modelo == null)
                {
                    modelo = new EntModelo();
                }
                modelo = value;
            }
        }

        private EntModelo categoria;

        public EntModelo Categoria
        {
            get
            {
                if (categoria == null)
                {
                    categoria = new EntModelo();
                }
                return categoria;
            }
            set
            {
                if (categoria == null)
                {
                    categoria = new EntModelo();
                }
                categoria = value;
            }
        }


    }





}










