<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExportarAExcelPorAPI_ReturnFile.aspx.cs" Inherits="ServicioEncuestasAPIClient.ExportarAExcelPorAPI_ReturnFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contain" style="min-width: 786px;">

        <div class="jumbotron" style="background-color: #dcdced; min-width: 786px;">
            <h3 class="display-4">Importación Excel a DataTable </h3>
            <p class="lead">Ejemplo importación Fichero Excel a DataTable</p>
        </div>

        <div class="row m-0 p-0">

            <asp:Button ID="btnExportarFichero" OnClick="btnExportarFichero_Click" runat="server">
        </div>

  </div>      

</asp:Content>
