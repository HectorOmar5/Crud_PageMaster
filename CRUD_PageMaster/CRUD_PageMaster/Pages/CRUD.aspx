<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD_PageMaster.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
             <div class="mb-3">
            <label class="formm-label">Nombre</label>
            <asp:TextBox ID="tbnombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="formm-label">Edad</label>
            <asp:TextBox ID="tbedad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="formm-label">Email</label>
            <asp:TextBox ID="tbemail" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="formm-label">Fecha de Nacimiento</label>
            <asp:TextBox ID="tbdate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
                    <!-- Se mostraran dinamicamente -->
        <asp:Button runat="server" CssClass="btn btn-success" ID="btnCreate" Text="Crear Nuevo" Visible="false" OnClick="btnCreate_Click" />
        <asp:Button runat="server" CssClass="btn btn-success" ID="btnUpdate" Text="Guardar" Visible="false" OnClick="btnUpdate_Click" />
        <asp:Button runat="server" CssClass="btn btn-danger" ID="btnDelete" Text="Eliminar" Visible="false" OnClick="btnDelete_Click" />
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="btnVolver" Text="Volver" Visible="true" OnClick="btnVolver_Click" />
        </div>
    </form>
</asp:Content>
