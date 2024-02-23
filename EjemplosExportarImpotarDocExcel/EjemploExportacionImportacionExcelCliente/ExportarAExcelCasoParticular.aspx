<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExportarAExcelCasoParticular.aspx.cs" Inherits="ServicioEncuestasAPIClient.ExportarAExcelCasoParticular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contain" style="min-width: 786px;">

        <div class="jumbotron" style="background-color: #dcdced; min-width: 786px;">
            <h3 class="display-4">Ejemplo de un caso particular</h3>
            <p class="lead">Ejemplo de un caso particular, donde el excel a generar es complejo y no se puede enmarcar en un simple datatable</p>
        </div>

        <div class="row m-0 p-0">

            <div class="col-12 mb-3 mt-3" style="background-color: #dcdced;">
                <div class="col-12">
                    <div>Descarga de la exportación excel</div>
                    <div class="col text-center">                        
                        <asp:LinkButton class="btn btn-primary" ID="btnExportacionCasoParticular" OnClick="btnExportacionCasoParticular_Click" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

