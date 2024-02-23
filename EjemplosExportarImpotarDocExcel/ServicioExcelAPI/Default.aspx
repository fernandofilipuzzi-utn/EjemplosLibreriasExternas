<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServicioAPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="jumbotron">
            <h3 class="display-4">Servicio para exportar e importar ficheros excel</h3>
        </div>

        <div class="row text-center m-2">

            <div class="col">

                <div class="border border-primary"></div>

                <div style="background-color: #ced3fa">
                    <p class="h3">Documentación</p>
                    <p class="lead">Documentación de la API</p>
                </div>

                <div class="row">

                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/registrar-encuesta.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>API Doc.</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Ver Swagger</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:HyperLink class="btn btn-primary" ID="btnExcel" Target="_blank" NavigateUrl="/swagger/ui/index#/Excel" runat="server">Ir</asp:HyperLink>
                        </div>
                    </div>
                </div>

                <div class="border border-primary"></div>

                <div style="background-color: #ced3fa">
                    <p class="h3">DTO. Ejemplos de Exportación/Importación por medio de una API Web</p>
                    <p>Ejemplos de como lamar a la API externa(aquí esta en el mismo servicio a modo de ejemplo)</p>
                    <p>Para el intercambio de entre cliente y servicio se utilizan DTO serializados</p>
                </div>


                <div class="row">
                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/excel.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Exportar a Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Generar un fichero excel(XLSX) por medio de un datatable desde API genérica</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:HyperLink class="btn btn-primary" ID="btnExcelDesdeUnDataTable" Target="_blank" NavigateUrl="~/ExportarAExcelPorAPI_ReturnFile.aspx" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:HyperLink>
                        </div>
                    </div>

                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/excel2.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Importar Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Ejemplo usando API</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:HyperLink class="btn btn-primary" ID="btnImportar" NavigateUrl="~/ImportarExcelPorAPI_InputFile.aspx" runat="server"><i class="fa fa-upload" aria-hidden="true"></i>Subir</asp:HyperLink>
                        </div>
                    </div>

                </div>

                <div style="background-color: #ced3fa">
                    <p class="h3">Sin DTO. Ejemplos de Exportación/Importación por medio de una API Web</p>
                    <p>Ejemplos de como lamar a la API externa(aquí esta en el mismo servicio a modo de ejemplo)</p>
                    <p>Se envia y recibe directamente el array de byte en el content y serializa el dataset directamente</p>
                </div>

                <div class="row">
                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/excel.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Exportar a Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Generar un fichero excel(XLSX) por medio de un datatable desde API genérica</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:HyperLink class="btn btn-primary" ID="HyperLink1" Target="_blank" NavigateUrl="~/ExportarAExcelPorAPI_ReturnFileFS.aspx" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:HyperLink>
                        </div>
                    </div>

                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/excel2.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Importar Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Ejemplo usando API</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:HyperLink class="btn btn-primary" ID="HyperLink2" NavigateUrl="~/ImportarExcelPorAPI_InputFileFS.aspx" runat="server"><i class="fa fa-upload" aria-hidden="true"></i>Subir</asp:HyperLink>
                        </div>
                    </div>

                </div>

                <div class="border border-primary"></div>

                <div style="background-color: #ced3fa">
                    <p class="h3">Ejemplos de Exportación/Importación en el mismo proyecto</p>
                    <p class="lead">
                        Para Casos particulares donde el excel a construir o a importar es muy grande o no se 
                        puede encuadrar en una tabla. Entonces aquí hay que ver que celda tomar el dato, etc.
                    </p>
                </div>

                <div class="row">
                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3" style="background-color: #dffecd">
                        <img src="./img/excel-exportar.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Exportar a Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Ejemplo sin usar API</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:LinkButton class="btn btn-primary" ID="btnExportacionCasoParticular" OnClick="btnExportacionCasoParticular_Click" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:LinkButton>
                        </div>
                    </div>

                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3" style="background-color: #dffecd">
                        <img src="./img/excel-importar.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Impotar un Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Ejemplo sin usar API</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:HyperLink class="btn btn-primary" ID="btnImportarCasoParticular" NavigateUrl="~/ImportarExcelCasoParticular.aspx" runat="server"><i class="fa fa-upload" aria-hidden="true"></i>Importar</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
