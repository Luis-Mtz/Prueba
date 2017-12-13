<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vistaconjson.aspx.cs" Inherits="vistaconjson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
     <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bootstrap 101 Template</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlMarca" AppendDataBoundItems="true" runat="server">
            <asp:ListItem Text="[Seleccione Marca]" Value="-1"  />

        </asp:DropDownList>
        <asp:DropDownList ID="ddlModelo" runat="server"></asp:DropDownList>
        <br />  
        
        <div id="tabladinamica">
           <%-- 
            <table class="auto-style1">
                <tr>
                    <td>ID</td>
                    <td>NOMBRE</td>
                    <td>EXISTENCIA</td>
                    <td>MARCA</td>
                    <td>MODELO</td>
                    <td>CATEGORIA</td>
                    <td>FECHA</td>
                    <td>PRECIO</td>
                    <td>ESTATUS</td>
                    <td>FOTO</td>
                    <td>COSTO</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>LUIS</td>
                    <td>1</td>
                    <td>2</td>
                    <td>2</td>
                    <td>2</td>
                    <td>2</td>
                    <td>2</td>
                    <td>2</td>
                    <td>2</td>
                    <td>2</td>
                </tr>
            </table>--%>
        </div>
        
    
    </div>
    </form>
    <script src="jquery-2.1.4.js"></script>
  
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <%--<script>    
        $(document).ready(function () {
            var modelos = '{}';
            //Método para obtener modelos
            $.ajax({
                type: "POST",
                url: "vistaconjson.aspx/ObtenerModelo",
                data: '',
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    modelos = $.parseJSON(msg.d);
                },
                error: function (msg) {
                    alert('Error al cargar las causas' + msg.responseText);
                }
            });

            //Evento click del ddlMarca para llenar modelos
            $('#ddlMarca').change(function () {
                var marca = $('#ddlMarca').val();
                $('#ddlModelo').empty();
                $('#ddlModelo').append($('<option>', { value: '', text: '[Selecciona Modelo]' }));
                $(modelos).each(function () {
                    if (marca == this.Marca_id) {
                        $('#ddlModelo').append($('<option>', { value: this.id, text: this.Nombre }));
                    }
                });
            });

            //evento change del ddlModelo para llenar tabla juguete

            $('#ddlMarca').change(function () {
                var marca = $('#ddlMarca').val();
                var modelo = $('#ddlModelo').val();
                var misDatos = '';
                misDatos = '{"fechaInicial":"' + fechaInicial + '", "serie":"' + serie + '"}';







        //cierre del evento ready
        });




    </script>--%>

    <script>
        $(document).ready(function () {
            var modelos = '{}';
            //Metodo para obtener Modelos
            $.ajax({
                type: "POST",
                url: "vistaconjson.aspx/ObtenerModelo",
                data: '',
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    modelos = $.parseJSON(msg.d);
                },
                error: function (msg) {
                    alert('Error al cargar las causas' + msg.responseText);
                }
            });// cierre del ajax

            //Llenar ddlModelo
            $('#ddlMarca').change(function () {
                var marca = $('#ddlMarca').val();
                $('#ddlModelo').empty();
                $('#ddlModelo').append($('<option>', { value: '', text: '[Selecciona Modelo]' }));
                $(modelos).each(function () {
                    if (marca == this.Marca_id) {
                        $('#ddlModelo').append($('<option>', { value: this.id, text: this.Nombre }));
                    }
                });
            });

            //llenar tabla juguete
            $('#ddlModelo').change(function () {
                $('#tabladinamica').children().remove();
                var marca = $('#ddlMarca').val();
                var modelo = $('#ddlModelo').val();

                var misDatos = '';
                misDatos = '{"marca":"' + marca + '", "modelo":"' + modelo + '"}';

                $.ajax({
                    type: "POST",
                    url: "vistaconjson.aspx/ObtenerJuguete",
                    data: misDatos,
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        list = $.parseJSON(msg.d);
                        tabla = '';
                        tabla += '<table id=" #tabladinamica" class="table table-responsive table-hover">';
                        tabla += '                                <tr style="background-color: #d9edf7; border-color:"#bce8f1" text-align:center;">';
                        tabla += '                                    <td>ID</td>';
                        tabla += '                                    <td>Nombre</td>';
                        tabla += '                                    <td>existencia</td>';
                        tabla += '                                    <td>Marca</td>';
                        tabla += '                                    <td>Modelo</td>';
                        tabla += '                                    <td>Categoria</td>';
                        tabla += '                                    <td>Fecha</td>';
                        tabla += '                                    <td>Precio</td>';
                        tabla += '                                    <td>Estatus</td>';
                        tabla += '                                    <td>Foto</td>';
                        tabla += '                                    <td>Costo</td>';
                        tabla += '                                </tr>';

                        $(list).each(function () {
                            tabla += '                                <tr style="text-align:center;">'
                            tabla += '                                    <td>' + this.Id + '</td>';
                            tabla += '                                    <td>' + this.Nombre + '</td>';
                            tabla += '                                    <td>' + this.Existencia + '</td>';
                            tabla += '                                    <td>' + this.Marca.Nombre + '</td>';
                            tabla += '                                    <td>' + this.Modelo.Nombre + '</td>';
                            tabla += '                                    <td>' + this.Categoria.Nombre + ' </td>';
                            tabla += '                                    <td>' + this.FechaJSon + ' </td>';
                            tabla += '                                    <td>' + this.Precio + ' </td>';
                            if (this.Estatus == true) {
                                tabla += '                                    <td><input type="checkbox" checked> </td>';
                            }
                            else {
                                tabla += '                                    <td><input type="checkbox" > </td>';
                            }
                            tabla += '                                   <td> <img src="' + this.Foto + '" alt="" width="100px" /></td>';
                            tabla += '                                    <td>' + this.Costo + ' </td>';
                            tabla += '                                </tr>';
                            
                        });

                        tabla += '                            </table>';

                        $('#tabladinamica').append(tabla);
                    },
                    error: function (msg) {
                        alert('Error al cargar las causas' + msg.responseText);
                    }
                });
            });
        });//cierre del.ready
    </script>
</body>
</html>
