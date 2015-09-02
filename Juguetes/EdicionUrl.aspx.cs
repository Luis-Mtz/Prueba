using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JuguetiMax.Juguetes.Business.Entity;
using JuguetiMax.Juguetes.Business;

public partial class EdicionUrl : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = Convert.ToInt32(Request.QueryString["ID"]);
        if (!IsPostBack)
        {
            LlenarDdlMarca();
            LlenarddlCategoria();

            EntJuguete ent = new BusJuguete().Obtener(Id);
            ddlMarca.SelectedValue = ent.Marca_Id.ToString();

            LlenarDdlModelo(ent.Marca_Id);
            ddlModelo.SelectedValue = ent.Modelo_Id.ToString();
            ddlCategoria.SelectedValue = ent.Categoria_Id.ToString();

            txtNombre.Text = ent.Nombre;
            txtExistencia.Text = ent.Existencia.ToString();
            txtFecha.Text = ent.Fecha.ToString("dd/MM/yyyy");
            txtPrecio.Text = ent.Precio.ToString();
            lblCosto.Text = ent.Costo.ToString();
           
            imgFoto.ImageUrl = ent.Foto;
            chkEstatus.Checked = ent.Estatus;

        }
          

    }

    private void LlenarddlCategoria()
    {
        List<EntCategoria> lst = new List<EntCategoria>();
        BusCatalogo obj = new BusCatalogo();
        lst = obj.ObtenerCategoria();
        ddlCategoria.DataSource = lst;
        ddlCategoria.DataTextField = "Nombre";
        ddlCategoria.DataValueField = "Id";
        ddlCategoria.DataBind();
    }

    private void LlenarDdlMarca()
    {
        List<EntMarca> lst = new List<EntMarca>();
        BusCatalogo obj = new BusCatalogo();
        lst = obj.ObtenerMarcas();
        ddlMarca.DataSource = lst;
        ddlMarca.DataTextField = "Nombre";
        ddlMarca.DataValueField = "Id";
        ddlMarca.DataBind();
    }
    private void LlenarDdlModelo(int idMarca)
    {
        List<EntModelo> lst = new List<EntModelo>();
        BusCatalogo obj = new BusCatalogo();
        lst = obj.ObtenerModelos(idMarca);
        ddlModelo.DataSource = lst;
        ddlModelo.DataTextField = "Nombre";
        ddlModelo.DataValueField = "Id";
        ddlModelo.DataBind();
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        EntJuguete ent = new EntJuguete();

        ent.Nombre = txtNombre.Text;
        ent.Existencia = Convert.ToInt32(txtExistencia.Text);
        ent.Fecha = Convert.ToDateTime(txtFecha.Text);
        ent.Costo = Convert.ToInt32(lblCosto.Text);
        ent.Precio = Convert.ToInt32(txtPrecio.Text);
        ent.Marca_Id =  Convert.ToInt32(ddlMarca.SelectedValue);
        ent.Modelo_Id = Convert.ToInt32(ddlModelo.SelectedValue);
        ent.Categoria_Id = Convert.ToInt32(ddlCategoria.SelectedValue);
        ent.Id = Convert.ToInt32(Request.QueryString["ID"]);

        ent.Foto = "Img/" + fuFoto.FileName;
        bool guardado = GuardarFoto(fuFoto);
        imgFoto.ImageUrl = "Img/" + fuFoto.FileName;

        ent.Estatus = chkEstatus.Checked;

        try
        {

            BusJuguete obj = new BusJuguete();
            obj.Actuaizar(ent);

            Response.Redirect("EdicionUrl.aspx?ID=" + ent.Id);
        }
        catch (Exception ex)
        {

            Title = ex.Message;
        }      
        

    }
    private bool GuardarFoto(FileUpload fuFoto)
    {
        String savePath = Server.MapPath("") + "\\Img\\";


        // Before attempting to perform operations
        // on the file, verify that the FileUpload 
        // control contains a file.
        if (fuFoto.HasFile)
        {
            // Get the name of the file to upload.
            string fileName = fuFoto.FileName;

            // Append the name of the file to upload to the path.
            savePath += fileName;


            // Call the SaveAs method to save the 
            // uploaded file to the specified path.
            // This example does not perform all
            // the necessary error checking.               
            // If a file with the same name
            // already exists in the specified path,  
            // the uploaded file overwrites it.
            fuFoto.SaveAs(savePath);

            // Notify the user of the name of the file
            // was saved under.
            Title = "Your file was saved as " + fileName;
            return true;
        }
        else
        {
            // Notify the user that a file was not uploaded.
            Title = "You did not specify a file to upload.";
            return false;
        }

    }
    protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idMarca = Convert.ToInt32(ddlMarca.SelectedItem.Value);
        LlenarDdlModelo(idMarca);
    }
}