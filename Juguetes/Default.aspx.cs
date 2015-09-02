using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JuguetiMax.Juguetes.Business;
using JuguetiMax.Juguetes.Business.Entity;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarGvJuguetes();
            LlenarDdlMarca();
            LlenarDdlCategoria();
        }


    }
    private void MostrarMensaje(string mensaje)
    {

        mensaje = mensaje.Replace("'", "").Replace("/r", "//r").Replace("/n", "");
        string alerta = string.Format("alert('{0}');", mensaje);
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);

    }

    protected void ddlMarcaFT_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int idMarca = Convert.ToInt32(ddl.SelectedItem.Value);
        LlenarDdlModelo(idMarca);

    }
    private void LlenarDdlCategoria()
    {
        DropDownList ddl = (DropDownList)GvJuguetes.FooterRow.FindControl("ddlCategoriaFT");
        ddl.DataSource = new BusCatalogo().ObtenerCategoria();
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "id";
        ddl.DataBind();

    }
    private void LlenarDdlMarca()
    {
        DropDownList ddl = (DropDownList)GvJuguetes.FooterRow.FindControl("ddlMarcaFT");
        ddl.DataSource = new BusCatalogo().ObtenerMarcas();
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "id";
        ddl.DataBind();

    }
    private void LlenarDdlModelo(int idMarca)
    {
        DropDownList ddl = (DropDownList)GvJuguetes.FooterRow.FindControl("ddlModeloFT");
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem() { Text = "[Seleccione Modelo]", Value = "-1" });
        ddl.DataSource = new BusCatalogo().ObtenerModelos(idMarca);
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "id";
        ddl.DataBind();
    }
    private void LlenarGvJuguetes()
    {
        GvJuguetes.DataSource = new BusJuguete().Obtener();
        GvJuguetes.DataBind();
        GvJuguetes.FooterRow.Cells[11].ColumnSpan = 2;
        GvJuguetes.FooterRow.Cells[12].Visible = false;
    }

    protected void GvJuguetes_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvJuguetes.EditIndex = e.NewEditIndex;
        LlenarGvJuguetes();

        GvJuguetes.FooterRow.Cells.Clear();
        hidf.Value = e.NewEditIndex.ToString();


        DropDownList ddl = (DropDownList)GvJuguetes.Rows[e.NewEditIndex].FindControl("ddlMarcaEIT");
        ddl.Items.Add(new ListItem() { Text = "[Seleccione Marca]", Value = "-1" });
        ddl.DataSource = new BusCatalogo().ObtenerMarcas();
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "id";
        ddl.DataBind();

        string marca = GvJuguetes.DataKeys[e.NewEditIndex].Values["Marca_Id"].ToString();
        ddl.SelectedValue = marca;

        DropDownList ddlModelo = (DropDownList)GvJuguetes.Rows[e.NewEditIndex].FindControl("ddlModeloEIT");
        ddlModelo.Items.Add(new ListItem() { Text = "[Seleccione Modelo]", Value = "-1" });
        ddlModelo.DataSource = new BusCatalogo().ObtenerModelos(Convert.ToInt32(marca));
        ddlModelo.DataTextField = "Nombre";
        ddlModelo.DataValueField = "id";
        ddlModelo.DataBind();

        ddlModelo.SelectedValue = GvJuguetes.DataKeys[e.NewEditIndex].Values["Modelo_Id"].ToString();

        DropDownList ddlCategoria = (DropDownList)GvJuguetes.Rows[e.NewEditIndex].FindControl("ddlCategoriaEIT");

        ddlCategoria.DataSource = new BusCatalogo().ObtenerCategoria();
        ddlCategoria.DataTextField = "Nombre";
        ddlCategoria.DataValueField = "id";
        ddlCategoria.DataBind();
        ddlCategoria.SelectedValue = GvJuguetes.DataKeys[e.NewEditIndex].Values["Categoria_Id"].ToString();
    }
    protected void GvJuguetes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GvJuguetes.EditIndex = -1;
        LlenarGvJuguetes();
    }
    protected void GvJuguetes_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            EntJuguete ent = new EntJuguete();
            ent.Id = Convert.ToInt32(GvJuguetes.DataKeys[e.RowIndex].Values["Id"].ToString());
            ent.Marca_Id = Convert.ToInt32(((DropDownList)GvJuguetes.Rows[e.RowIndex].FindControl("ddlMarcaEIT")).SelectedValue);
            ent.Modelo_Id = Convert.ToInt32(((DropDownList)GvJuguetes.Rows[e.RowIndex].FindControl("ddlModeloEIT")).SelectedValue);
            ent.Categoria_Id = Convert.ToInt32(((DropDownList)GvJuguetes.Rows[e.RowIndex].FindControl("ddlCategoriaEIT")).SelectedValue);

            ent.Nombre = ((TextBox)GvJuguetes.Rows[e.RowIndex].FindControl("txtNombreEIT")).Text;
            ent.Precio = Convert.ToDouble(((TextBox)GvJuguetes.Rows[e.RowIndex].FindControl("txtPrecioEIT")).Text);
            ent.Costo = Convert.ToDouble(((Label)GvJuguetes.Rows[e.RowIndex].FindControl("lblCostoEIT")).Text);
            ent.Existencia = Convert.ToInt32(((TextBox)GvJuguetes.Rows[e.RowIndex].FindControl("txtExistenciaEIT")).Text);
            FileUpload fu = (FileUpload)GvJuguetes.Rows[e.RowIndex].FindControl("fuFotoEIT");
            bool guardado = GuardarFoto(fu);

            ent.Foto = "Img/" + fu.FileName;
            ent.Fecha = Convert.ToDateTime(((TextBox)GvJuguetes.Rows[e.RowIndex].FindControl("txtFechaEIT")).Text);
            ent.Estatus = ((CheckBox)GvJuguetes.Rows[e.RowIndex].FindControl("chkEstatusEIT")).Checked;
            new BusJuguete().Actuaizar(ent);
            Response.Redirect(Request.CurrentExecutionFilePath);
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }

    }

    private bool GuardarFoto(FileUpload fu)
    {
        String savePath = Server.MapPath("") + "\\Img\\";


        // Before attempting to perform operations
        // on the file, verify that the FileUpload 
        // control contains a file.
        if (fu.HasFile)
        {
            // Get the name of the file to upload.
            string fileName = fu.FileName;

            // Append the name of the file to upload to the path.
            savePath += fileName;


            // Call the SaveAs method to save the 
            // uploaded file to the specified path.
            // This example does not perform all
            // the necessary error checking.               
            // If a file with the same name
            // already exists in the specified path,  
            // the uploaded file overwrites it.
            fu.SaveAs(savePath);

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
    protected void ddlMarcaEIT_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GvJuguetes.FooterRow.Cells.Clear();
            DropDownList ddl = (DropDownList)sender;
            int idMarca = Convert.ToInt32(ddl.SelectedValue);

            int fila = Convert.ToInt32(hidf.Value);

            DropDownList ddlModelo = (DropDownList)GvJuguetes.Rows[fila].FindControl("ddlModeloEIT");
            ddlModelo.Items.Clear();
            ddlModelo.Items.Add(new ListItem() { Text = "[Seleccione Modelo]", Value = "-1" });
            ddlModelo.DataSource = new BusCatalogo().ObtenerModelos(Convert.ToInt32(idMarca));
            ddlModelo.DataTextField = "Nombre";
            ddlModelo.DataValueField = "Id";
            ddlModelo.DataBind();

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }

    }
    protected void GvJuguetes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EntJuguete ent = new EntJuguete();
        ent.Id = Convert.ToInt32(GvJuguetes.DataKeys[e.RowIndex].Values["Id"].ToString());
        new BusJuguete().Borrar(ent);
        Response.Redirect(Request.CurrentExecutionFilePath);


    }

    protected void lnkAgregarFT_Click1(object sender, EventArgs e)
    {

        try
        {
            EntJuguete ent = new EntJuguete();

            ent.Marca_Id = Convert.ToInt32(((DropDownList)GvJuguetes.FooterRow.FindControl("ddlMarcaFT")).SelectedValue);
            ent.Modelo_Id = Convert.ToInt32(((DropDownList)GvJuguetes.FooterRow.FindControl("ddlModeloFT")).SelectedValue);
            ent.Categoria_Id = Convert.ToInt32(((DropDownList)GvJuguetes.FooterRow.FindControl("ddlCategoriaFT")).SelectedValue);

            ent.Nombre = ((TextBox)GvJuguetes.FooterRow.FindControl("txtNombreFT")).Text;
            ent.Precio = Convert.ToDouble(((TextBox)GvJuguetes.FooterRow.FindControl("txtPrecioFT")).Text);
            ent.Costo = ent.Precio * 2.00;
            ent.Existencia = Convert.ToInt32(((TextBox)GvJuguetes.FooterRow.FindControl("txtExistenciaFT")).Text);
            FileUpload fu = (FileUpload)GvJuguetes.FooterRow.FindControl("fuFotoFT");
            bool guardado = GuardarFoto(fu);

            ent.Foto = "Img/" + fu.FileName;
            ent.Fecha = Convert.ToDateTime(((TextBox)GvJuguetes.FooterRow.FindControl("txtFechaFT")).Text);
            ent.Estatus = ((CheckBox)GvJuguetes.FooterRow.FindControl("chkEstatusFT")).Checked;
            new BusJuguete().Insertar(ent);
            Response.Redirect(Request.CurrentExecutionFilePath);
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);

        }
    }
    protected void lnkActualizarIT_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int id = Convert.ToInt32(lnk.CommandArgument);
        Response.Redirect("EdicionUrl.aspx?ID=" + id);

    }
}