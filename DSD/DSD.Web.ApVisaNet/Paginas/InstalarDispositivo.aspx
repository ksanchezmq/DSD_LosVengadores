<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="InstalarDispositivo.aspx.cs" Inherits="Paginas_InstalarDispositivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/PopUpOverlay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upInstalSolicitud" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Atención de Solicitudes</legend>
                <table>
                    <tr>
                        <td>N° de Solicitud:</td>
                        <td><asp:TextBox ID="txtNumSolicitud" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                </table>
            </fieldset>

             <fieldset>
                <legend>Solicitudes a Atender</legend>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        onrowcommand="GridView1_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Número de Solicitud" 
                                DataField="Número de Solicitud" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            <asp:BoundField HeaderText="Fecha de Registro" DataField="Fecha de Registro" />
                            <asp:BoundField HeaderText="Código de Cliente" DataField="Código de Cliente" />
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
                    <legend>Detalle de Solicitud a Atender</legend>
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
                        </tr>
                        <tr style="font-weight: 700; text-decoration: underline">
                            <td>Asociar Número de Serie</td>
                        </tr>
                        <tr>
                            <td>Número de Serie:</td>
                            <td>
                                <asp:TextBox ID="txtTipoInter0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAsociar" runat="server" Text="Asociar" 
                                    onclick="btnAsociar_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

