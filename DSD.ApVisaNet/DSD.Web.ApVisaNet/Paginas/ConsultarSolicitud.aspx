<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarSolicitud.aspx.cs" Inherits="Paginas_ConsultarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/PopUpOverlay.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gv-solicitudes th:nth-child(4), .gv-solicitudes th:nth-child(6), .gv-solicitudes th:nth-child(7),
        .gv-solicitudes td:nth-child(4), .gv-solicitudes td:nth-child(6), .gv-solicitudes td:nth-child(7){
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upConsultaSolicitud" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Consulta de Solicitudes</legend>
                <table>
                    <tr>
                        <td>N° de Solicitud:</td>
                        <td><asp:TextBox ID="txtNumSolicitud" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>

            <fieldset>
                <legend>Solicitudes Generadas</legend>
                <div class="gv-solicitudes">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        onrowcommand="GridView1_RowCommand">
                        <EmptyDataTemplate>
                            No existe registro disponible
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="Número de Solicitud" DataField="CodigoSolicitud" />
                            <asp:BoundField HeaderText="Estado" DataField="EstadoDescripcion" />
                            <asp:BoundField HeaderText="Fecha Registro" DataField="FechaHora" />
                            <asp:BoundField HeaderText="Codigo Cliente" DataField="CodigoAfiliado" />
                            <asp:BoundField HeaderText="Nombre Cliente" DataField="NombreCliente" />
                            <asp:BoundField DataField="DNI" />
                            <asp:BoundField DataField="RUC" />
                            <asp:ButtonField Text="Ver Detalle" CommandName="VER" />
                        </Columns>
                    </asp:GridView>
                    
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upPopUps" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="panelOverlay" runat="server" class="OverlayCol" Visible="false"></asp:Panel>
            <asp:Panel ID="panelPopUpPanel" runat="server" class="PopUpPanelCol" Visible="false">
                <fieldset>
                    <legend>Detalle de Solicitud</legend>
                    <table>
                        <tr>
                            <td>
                                Código de Cliente:</td>
                            <td>
                                <asp:TextBox ID="txtCodCol" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                Número de Solicitud:</td>
                            <td>
                                <asp:TextBox ID="txtNumSol" runat="server" 
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nombre Completo:</td>
                            <td>
                                <asp:TextBox ID="txtNombres" runat="server" Enabled="False" Width="248px"></asp:TextBox>
                            </td>
                            <td>
                                Número de Documento:</td>
                            <td>
                                <asp:TextBox ID="txtDni" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                RUC:</td>
                            <td>
                                <asp:TextBox ID="txtRUC" runat="server" 
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                    onclick="btnAceptar_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
        
</asp:Content>

