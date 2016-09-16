<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="rep2.aspx.vb" Inherits="reportes.WebRepNeotel.rep2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: #428bca">
        <b>
            <asp:Label ID="lblTituloPrincipal" Text="Reporte - Busqueda de Usuario" runat="server" Font-Size="Medium" ForeColor="White" /></b>
    </div>
    <div class="padding_user">
    </div>

    <div class="row">
        <div>
            <div class="row">
                <div class="col-xs-12 col-md-8">
                    <div class="input-group input-group-sm">
                        <asp:CheckBoxList ID="ckbListaServidore" runat="server" RepeatDirection="Horizontal" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-6 col-md-2">
                    <div class="input-group input-group-sm">
                        <div class="input-group-addon">
                            Fecha &nbsp; &nbsp; Inicio:
                        </div>
                        <asp:TextBox ID="txtFecIni" runat="server" CssClass="form-control input-sm" ClientIDMode="Static" Style="top: 0px !important"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-6 col-md-2">
                    <div class="input-group input-group-sm">
                        <div class="input-group-addon">
                            Fecha Termino:
                        </div>
                        <asp:TextBox ID="txtFecFin" runat="server" CssClass="form-control input-sm" ClientIDMode="Static" Style="top: 0px !important"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-6 col-md-2" align="right">
                    <asp:Button ID="btnBuscar" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary btn-sm" ClientIDMode="Static" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6 col-md-6">
                    <asp:Literal runat="server" ID="ltMsg" />
                </div>
            </div>

            <div class="row">
                <div class="col-xs-1 col-md-1">
                    <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="btnExportar" runat="server" Width="120px" Visible="false">
                                <img src="resources/img/Excel-32.png" />Excel
                                </asp:LinkButton>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="btnExportarCsv" runat="server" Width="120px" Visible="false">
                                <img src="resources/img/Csv-32.png" />
                                </asp:LinkButton>

                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtLimitacion" Width="25px" Visible="false" />
                            </td>
                        </tr>
                    </table>

                </div>
            </div>

            <div class="padding_user">
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <asp:Panel ID="panel_01" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="grvReporte" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="active" HeaderStyle-HorizontalAlign="Center"
                            RowStyle-CssClass="text-left" Font-Size="Smaller" AllowPaging="True" >
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>











</asp:Content>
