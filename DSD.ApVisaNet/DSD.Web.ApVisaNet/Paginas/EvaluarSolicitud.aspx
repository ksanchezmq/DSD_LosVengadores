<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="EvaluarSolicitud.aspx.cs" Inherits="Paginas_EvaluarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/PopUpOverlay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upEvalSolicitud" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Evaluación de Solicitud</legend>
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
                <legend>Solicitudes a Evaluar</legend>
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
                    <legend>Detalle de Solicitud a Evaluar</legend>
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
                                <asp:Button ID="btnEvaluar" runat="server" Text="Evaluar" 
                                    onclick="btnEvaluar_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

