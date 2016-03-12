<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true"
    CodeFile="GenerarSolicitud.aspx.cs" Inherits="Paginas_GenerarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/PopUpOverlay.css" rel="stylesheet" type="text/css" />
    <link href="../css/estilos.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <style type="text/css">
        .style2
        {
            text-decoration: underline;
        }
    </style>

    <script type="text/javascript">
        function js_BuscarDatos() {
            var msg = '';
            var result = true;

            var NumSolicitud = $("#<%= txtCodAfiliado.ClientID %>").val();

            NumSolicitud = $.trim(NumSolicitud);
            if (NumSolicitud.length == 0) { msg = msg + '<br />' + '- Debe ingresar un número de solicitud.'; }

            if (msg.length > 0) {
                js_MostrarAlertaAtencion('Generar Solicitud de Reactivación', msg);
                result = false;
            }
            else {
                result = true;
            }

            return result;
        }

        function js_GenerarDatos() {
            var msg = '';
            var result = true;

            var NumSolicitud = $("#<%= txtCodAfiliado.ClientID %>").val();
            var TipoPos = $("#<%= RadioButtonList3.ClientID %>").val();

            NumSolicitud = $.trim(NumSolicitud);
            if (NumSolicitud.length == 0) { msg = msg + '<br />' + '- Debe ingresar un número de solicitud.'; }

//            if (TipoPos == '') { msg = msg + '<br />' + '- Debe seleccionar un tipo de POS.'; }

            if (msg.length > 0) {
                js_MostrarAlertaAtencion('Generar Solicitud de Reactivación', msg);
                result = false;
            }
            else {
                result = true;
            }

            return result;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upSolicitud" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Generar Solicitud de Reactivación</legend>
                <table>
                    <tr>
                        <td>
                            Código de Afiliado:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodAfiliado" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClientClick="return js_BuscarDatos();" 
                                onclick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b style="text-decoration: underline">Datos Personales</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Apellido Paterno:
                        </td>
                        <td>
                            <asp:TextBox ID="txtApePat" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Apellido Materno:
                        </td>
                        <td>
                            <asp:TextBox ID="txtApeMat" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombres:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombres" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Número de Documento:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDni" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Teléfono 1:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFono1" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            Teléfono 2:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFono2" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ¿Cambiar Dirección?
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                RepeatDirection="Horizontal" AutoPostBack="True" 
                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="1">SI</asp:ListItem>
                                <asp:ListItem Value="0">NO</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Dirección:
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtDireccion" runat="server" Width="376px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Departamento:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDpto" runat="server" AppendDataBoundItems="True" 
                                Enabled="False">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">LIMA</asp:ListItem>
                                <asp:ListItem Value="2">LAMBAYEQUE</asp:ListItem>
                                <asp:ListItem Value="3">LA LIBERTAD</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Provincia:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProvincia" runat="server" AppendDataBoundItems="True" 
                                Enabled="False">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">LIMA</asp:ListItem>
                                <asp:ListItem Value="2">TRUJILLO</asp:ListItem>
                                <asp:ListItem Value="3">CHICLAYO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Distrito:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistrito" runat="server" AppendDataBoundItems="True" 
                                Enabled="False">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">MIRAFLORES</asp:ListItem>
                                <asp:ListItem Value="2">SAN JUAN DE MIRAFLORES</asp:ListItem>
                                <asp:ListItem Value="3">SURCO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="style2">
                            <b>Datos de la Empresa</b>
                        </td>
                    </tr>
                    <tr>
                        <td>RUC:</td>
                        <td>
                            <asp:TextBox ID="txtRuc" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Teléfono 1:</td>
                        <td>
                            <asp:TextBox ID="txtFonoEmp1" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>Teléfono 2:</td>
                        <td>
                            <asp:TextBox ID="txtFonoEmp2" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ¿Cambiar Dirección?
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                                RepeatDirection="Horizontal" AutoPostBack="True" 
                                onselectedindexchanged="RadioButtonList2_SelectedIndexChanged">
                                <asp:ListItem Value="1">SI</asp:ListItem>
                                <asp:ListItem Value="0">NO</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Dirección:
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtDireccionEmp" runat="server" Width="376px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Departamento:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDptoEmp" runat="server" AppendDataBoundItems="True" 
                                Enabled="False">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">LIMA</asp:ListItem>
                                <asp:ListItem Value="2">LAMBAYEQUE</asp:ListItem>
                                <asp:ListItem Value="3">LA LIBERTAD</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Provincia:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProvEmp" runat="server" AppendDataBoundItems="True" 
                                Enabled="False">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">LIMA</asp:ListItem>
                                <asp:ListItem Value="2">TRUJILLO</asp:ListItem>
                                <asp:ListItem Value="3">CHICLAYO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Distrito:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistritoEmp" runat="server" AppendDataBoundItems="True" 
                                Enabled="False">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">MIRAFLORES</asp:ListItem>
                                <asp:ListItem Value="2">SAN JUAN DE MIRAFLORES</asp:ListItem>
                                <asp:ListItem Value="3">SURCO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2"><b>Tipo de POS</b></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                                RepeatDirection="Horizontal" AutoPostBack="True" >
                                <asp:ListItem Value="1">Inalámbrico</asp:ListItem>
                                <asp:ListItem Value="2">Fijo</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnGenerar" runat="server" Text="Generar" 
                                OnClientClick="return js_GenerarDatos();" onclick="btnGenerar_Click"/>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upAlerta" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="click" />
    </Triggers>
    <ContentTemplate>
         <asp:Panel ID="panel1" runat="server" class="OverlayAlert" Visible="false"></asp:Panel>
         <asp:Panel ID="panelAlert" runat="server" class="PopUpPanelAlert" Visible="false">
            <div style="text-align:center;">
                    <div class="txt05" >&nbsp;<asp:Label ID="lblAlert" runat="server"></asp:Label>
                    </div>
                    <div class="contenedor8">
                    </div>
                    <br />
                    <div><asp:Image ID="imgAlerta" runat="server" Height="43px" Width="49px"/></div>
                    <div><asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label></div>
                    <br />
                    <asp:ImageButton ID="btnAceptar" runat="server" Text="Aceptar" 
                        ImageUrl="~/Images/aceptar.png" onclick="btnAceptar_Click"/>
               </div>                               
               <div>&nbsp;</div>
         </asp:Panel>
    </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>
