<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExportarAExcelPorAPI_ReturnFile_NoDTO.aspx.cs" Inherits="ServicioAPI.ExportarAExcelPorAPI_ReturnFile_NoDTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contain" style="min-width: 786px;">

        <div class="jumbotron" style="background-color: #dcdced; min-width: 786px;">
            <h3 class="display-4">Generar un fichero excel(XLSX) desde un datatable a través de la API genperica</h3>
            <p class="lead">Ejemplo de como llamar la API Web</p>
            <p class="lead">Creando un fichero excel a partir de la consulta sql (datable) enviando el datable serializado a una API</p>
            <p class="lead">La api web para pruebas http://localhost:7777/api/Excel/GetExcel</p>
        </div>

        <div class="row m-0 p-0">

            <div class="col-12 mb-3 mt-3" style="background-color: #dcdced;">
                <div class="col-12">
                    <div>Descarga de la exportación excel</div>
                    <div class="col text-center">                        
                        <asp:LinkButton class="btn btn-primary" ID="btnDescargarEjemploExcel" OnClick="btnExportarFichero_Click" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
