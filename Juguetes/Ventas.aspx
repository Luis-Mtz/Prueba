<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ventas.aspx.cs" Inherits="Ventas" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Juguetes </title>
      <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
   
    <!-- Bootstrap -->

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 898px">
        <asp:GridView ID="GvJuguetes" Style="text-align: center; margin-top: 0px;" runat="server"
            AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" ShowFooter="True"
            DataKeyNames="Id,Marca_Id,Modelo_Id,Categoria_Id,Existencia" BackColor="White" BorderColor="#999999"
            BorderStyle="None" BorderWidth="1px" OnRowCancelingEdit="GvJuguetes_RowCancelingEdit"
            OnRowEditing="GvJuguetes_RowEditing" 
            OnRowUpdating="GvJuguetes_RowUpdating" OnRowDeleting="GvJuguetes_RowDeleting">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <EditItemTemplate>
                        <asp:Label ID="lblIdEIT" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </EditItemTemplate>
                   
                    <ItemTemplate>
                        <asp:Label ID="lblIdIT" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblIdFT" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </FooterTemplate>

                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOMBRE">
                    <EditItemTemplate>
                        <asp:Label ID="txtNombreEIT" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>


                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNombreFT" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtNombreFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta"  runat="server" 
                            ErrorMessage="Nombre Oblogatorio"></asp:RequiredFieldValidator>
                            
                    
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EXISTENCIA">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtExistenciaEIT" runat="server" Text='<%# Bind("Existencia") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator90" ControlToValidate="txtExistenciaEIT"
                            ForeColor="Red" Text="***" ValidationGroup="cambio" runat="server" ErrorMessage="Existecia Oblogatoria"></asp:RequiredFieldValidator>
                           
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10000" runat="server" ControlToValidate="txtExistenciaEIT"
ErrorMessage="Please Enter Only Numbers" ValidationGroup="cambio"></asp:RegularExpressionValidator>--%>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExistenciaIT" runat="server" Text='<%# Bind("Existencia") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtExistenciaFT" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtExistenciaFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta" runat="server" ErrorMessage="Existecia Oblogatoria"></asp:RequiredFieldValidator>
                           <%--
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtExistenciaFT"
ErrorMessage="Please Enter Only Numbers" ValidationGroup="alta"></asp:RegularExpressionValidator>--%>

                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MARCA">
                    <EditItemTemplate>
                        <asp:Label ID="lblMarcaEIT" runat="server" Text='<%# Bind("Marca.Nombre") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Marca.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlMarcaFT" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlMarcaFT_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Text="[Selecciona Marca]" Value="-1" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlMarcaFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta" runat="server" InitialValue="-1"
                            ErrorMessage="Marca Oblogatoria"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MODELO">
                    <EditItemTemplate>
                        <asp:Label ID="lblModeloEIT" runat="server" Text='<%# Bind("Modelo.Nombre") %>'></asp:Label>
                         
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Modelo.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlModeloFT" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="[Selecciona Modelo]" Value="-1" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlModeloFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta" runat="server" InitialValue="-1"
                            ErrorMessage="Modelo Oblogatorio"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CATEGORIA">
                    <EditItemTemplate>
                        <asp:Label ID="lblCategoriaEIT" runat="server" Text='<%# Bind("Categoria.Nombre") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Categoria.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlCategoriaFT" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="[Selecciona Categoria]" Value="-1" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlCategoriaFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta" runat="server" InitialValue="-1"
                            ErrorMessage="Categoria Oblogatoria"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FECHA">
                    <EditItemTemplate>
                        <asp:Label ID="txtFechaEIT" runat="server" Text='<%# Bind("Fecha","{0:dd/MM/yyyy}") %>'></asp:Label>
                         
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Fecha","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFechaFT" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtFechaFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta" runat="server" ErrorMessage="Fecha Oblogatoria"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ErrorMessage="Error fecha- Ejempo -Mes/Dia/Año"
                   ControlToValidate="txtFechaFT"  Text="***" Type="Date" ValidationGroup="alta" Display="Dynamic"
                   ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"></asp:RegularExpressionValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PRECIO">
                    <EditItemTemplate>
                        <asp:Label ID="lblPrecioEIT" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Precio", "{0:C}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPrecioFT" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrecioFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta" runat="server" ErrorMessage="Precio Oblogatorio"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FOTO">
                    <EditItemTemplate>
                        <asp:Image ID="imgFotoEIT" Width="100px" ImageUrl='<%# Bind("Foto") %>'  runat="server" />
                                               
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgFotoIT" Width="100px" ImageUrl='<%# Bind("Foto") %>' runat="server" />
                        
                       

                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuFotoFT" runat="server"></asp:FileUpload>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator189890" ControlToValidate="fuFotoFT"
                            ForeColor="Red" Text="***" ValidationGroup="alta" runat="server" ErrorMessage="Foto Oblogatoria"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COSTO">
                    <EditItemTemplate>
                       
                        <asp:Label ID="lblCostoEIT" runat="server" Text='<%# Bind("Costo") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl213421" runat="server" Text='<%# Bind("Costo") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblCostoFT" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ESTATUS">
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkEstatusEIT" runat="server" Checked='<%# Bind("Estatus") %>'>
                        </asp:CheckBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox Enabled="false" Checked='<%# Bind("Estatus") %>' ID="chk" runat="server">
                        </asp:CheckBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="chkEstatusFT" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Ventas" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton  ID="LnkUpdate" runat="server" CausesValidation="True"  ValidationGroup="cambio" CommandName="Update"
                            Text="Realizar-Venta"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lnkCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancelar"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" runat="server" ValidationGroup="cambio" CausesValidation="False" CommandName="Edit"
                            Text="Ventas"></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton Text="Agregar" ID="lnkAgregarFT" ValidationGroup="alta" runat="server"
                            OnClick="lnkAgregarFT_Click1" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Eliminar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actualizar">
                    
                    <ItemTemplate>
                        
                        <asp:LinkButton ID="lnkActualizarIT" target="_blank" Text="Actualizar" runat="server" 
                            onclick="lnkActualizarIT_Click" CommandArgument='<%# Bind("Id") %>' ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </div>
    <asp:ValidationSummary ID="vsAlta" ValidationGroup="alta" runat="server" />
     <asp:ValidationSummary ID="vsCambio" ValidationGroup="cambio" runat="server" />

    <asp:HiddenField ID="hidf" runat="server" />
    </form>
    <h1>Hello, world!</h1>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
