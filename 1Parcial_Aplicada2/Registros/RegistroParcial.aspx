<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroParcial.aspx.cs" Inherits="_1Parcial_Aplicada2.Registros.RegistroParcial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="card text-center bg-light">
            <div class="card-header"><%:Page.Title %></div>

            <%--ID--%>
            <div>
                <label for="UtilsID" runat="server">ID</label>
                <asp:TextBox ID="UtilsID" runat="server" TextMode="Number" placeHolder="ID"></asp:TextBox>
                <asp:Button ID="BuscarButton" class="btn btn-info btn-lg" Text="Buscar" OnClick="BuscarButton_Click" runat="server" />
            </div>

            <%--FECHA--%>
            <div>
                <label for="FechaTextBox" runat="server">Fecha</label>
                <asp:TextBox ID="FechaTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <%--BOTON AGREGAR--%>
            <div>
                <asp:Button ID="AgregarButton" Text="Agregar" runat="server" OnClick="AgregarButton_Click" />
            </div>

            <%--GRID--%>
            <div>
                <div class="row">
                    <div class="table table-responsive col-md-12">
                        <asp:GridView ID="DetalleGridView" runat="server"
                            CssClass="table table-condensed table-bordered table-responsive"
                            GridLines="None" CellPadding="4" ForeColor="#333333" 
                            AllowPaging="true" PageSize="5">
                        </asp:GridView>
                    </div>
                </div>
            </div>


            <%--BOTONES--%>
            <div class="panel-footer">
                <div class="text-center">
                    <div class="form-group" display: inline-block>
                        <asp:Button Text="Nuevo" class="btn btn-warning btn-lg" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-success btn-lg" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-danger btn-lg" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>

            <%--MENSAJES--%>
            <asp:Label ID="MostrarMensajes" runat="server" Text="Label" Visible="false"></asp:Label>

        </div>
    </div>
</asp:Content>
