using JuguetiMax.Juguetes.Business;
using JuguetiMax.Juguetes.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistaconjson : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LlenarDdlMarca();


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

    [WebMethod]
    public static string ObtenerModelo()
    {
        List<EntModelo> lst = new List<EntModelo>();
        BusCatalogo obj = new BusCatalogo();
        lst = obj.ObtenerModelos();
        JavaScriptSerializer oSerealizer = new JavaScriptSerializer();
        string sJSON = oSerealizer.Serialize(lst);
        return sJSON;
    }

    [WebMethod]

    public static string ObtenerJuguete(string modelo, string marca)
    {
        
            EntJuguete ent = new EntJuguete();
            BusJuguete obj = new BusJuguete();
            ent = obj.Obtener(Convert.ToInt32(modelo), Convert.ToInt32(marca));

            JavaScriptSerializer oSerealizer = new JavaScriptSerializer();
            string sJSON = oSerealizer.Serialize(ent);
            return sJSON;
        

    }

    

}