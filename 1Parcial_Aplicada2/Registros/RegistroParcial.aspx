<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroParcial.aspx.cs" Inherits="_1Parcial_Aplicada2.Registros.RegistroParcial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="card text-center bg-light">
            <div class="card-header"><%:Page.Title %></div>

            <%--ID--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="EstudianteID" runat="server">ID</label>
                <asp:TextBox ID="EstudianteID" runat="server" TextMode="Number"  CssClass="form-control" placeHolder="ID"></asp:TextBox>
                <asp:Button ID="BuscarButton" class="btn btn-info btn-lg" Text="Buscar" OnClick="BuscarButton_Click" runat="server" />
                </div>
            </div>
           </div>

            <%--FECHA--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="FechaTextBox" runat="server">Fecha</label>
                <asp:TextBox ID="FechaTextBox" runat="server"  CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
              </div>
              </div>

            <%--ESTUDIANTE--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="EstudianteTextBox" CssClass="col-md-2 control-label">Estudiante</asp:Label>
                <asp:TextBox runat="server" ID="EstudianteTextBox" CssClass="form-control" placeHolder="Estudiante"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EstudianteTextBox" CssClass="text-danger" ErrorMessage="Este Estudiante no es Valido."/>
                </div>   
              </div>
            </div>

            <%--SERVICIO--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="ServicioTextBox" CssClass="col-md-2 control-label">Servicio</asp:Label>
                <asp:TextBox runat="server" ID="ServicioTextBox" CssClass="form-control" placeHolder="Servicio"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ServicioTextBox" CssClass="text-danger" ErrorMessage="Este Servicio no es Valido."/>
                </div>   
              </div>
            </div>

            <%--CANTIDAD--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="CantidadTextBox" CssClass="col-md-2 control-label">Cantidad</asp:Label>
                <asp:TextBox runat="server" TextMode="Number" ID="CantidadTextBox" CssClass="form-control" placeHolder="Cantidad"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CantidadTextBox" CssClass="text-danger" ErrorMessage="Esta Cantidad no es Valida."/>
                </div>   
              </div>
            </div>

            <%--PRECIO--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="PrecioTextBox" CssClass="col-md-2 control-label">Precio</asp:Label>
                <asp:TextBox runat="server" TextMode="Number" ID="PrecioTextBox" CssClass="form-control" placeHolder="Precio"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrecioTextBox" CssClass="text-danger" ErrorMessage="Este Precio no es Valido."/>
                </div>   
              </div>
            </div>

            <%--IMPORTE--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="ImporteTextBox" CssClass="col-md-2 control-label">Importe</asp:Label>
                <asp:TextBox runat="server" ID="ImporteTextBox" CssClass="form-control" placeHolder="Importe"></asp:TextBox>
                </div>   
              </div>
            </div>

            <%--BOTON AGREGAR--%>
            <div>
                <asp:Button ID="AgregarButton" class="btn btn-success btn-lg" Text="Agregar" runat="server" OnClick="AgregarButton_Click" />
            </div>

            <%--GRID--%>

            <asp:ScriptManager ID="ScriptManger" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="table table-responsive col-md-12">
                                <asp:GridView ID="DetalleGridView"
                                    runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-condensed table-hover table-responsive"
                                    CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AllowPaging="true" PageSize="5">
                                    <AlternatingRowStyle BackColor="LightBlue" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Opciones">
                                            <ItemTemplate>
                                            <asp:Button ID="RemoverDetalleClick" runat="server" CausesValidation="false" CommandName="Select"
                                              Text="Remover" CssClass="btn btn-danger btn-sm" OnClick="RemoverDetalleClick_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="DetalleID" DataField="DetalleID" Visible="false" />
                                        <asp:BoundField HeaderText="EstudianteID" DataField="EvaluacionID" Visible="false" />
                                        <asp:BoundField HeaderText="Servicio" DataField="Servicio" />
                                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                                        <asp:BoundField HeaderText="Importe" DataField="Importe" />
                                    </Columns>
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DetalleGridView" />
                    </Triggers>
                </asp:UpdatePanel>

            <%--TOTAL--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <asp:Label runat="server" for="TotalTextBox" CssClass="col-md-2 control-label">Total</asp:Label>
                <asp:TextBox runat="server" ID="TotalTextBox" CssClass="form-control" placeHolder="Total"></asp:TextBox>
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
