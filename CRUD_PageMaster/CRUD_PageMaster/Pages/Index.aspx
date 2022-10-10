<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD_PageMaster.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width: 300px">
            <h2>Listado de Registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="btnCreate" CssClass="btn btn-success form control" Text="Crear Nuevo" OnClick="btnCreate_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless tabble-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Detalles" CssClass="btn form-control-sm btn-info" ID="btnRead" OnClick="btnRead_Click" />
                                <asp:Button runat="server" Text="Actualizar" CssClass="btn form-control-sm btn-warning" ID="btnUpdate" OnClick="btnUpdate_Click" />
                                <asp:Button runat="server" Text="Eliminar" CssClass="btn form-control-sm btn-danger" ID="btnDelete" OnClick="btnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
