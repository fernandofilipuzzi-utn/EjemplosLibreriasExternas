<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ej2_NPOI_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Prueba exportación/Importación excel</h1>
        <p class="lead">Librería NPOI</p>
    </div>

    <div class="container">

        <div class="row text-center">
            <div class="col text-center">

                <div class="col text-left">
                    <asp:Label ID="lbError" runat="server" Text="" />
                </div>
            
                <div class="col">
                    <h4 > Exportar a Fichero excel</h4>
                    <div class="row text-center" >
                        <div class="col-3"></div>
                        <div class="col-6">
                            <asp:Button ID="XLS" CssClass="btn btn-primary" runat="server" OnClick="btnExportarXLS_Click"  Text="Formato XLS" />
                            <asp:Button ID="XLSX" CssClass="btn btn-primary"  runat="server" OnClick="btnExportarXLSX_Click" Text="Formato XLSX" />
                        </div>
                        <div class="col-3"></div>
                    </div>
                </div>

                <div class="col">
                    <h4> Importar Fichero excel</h4>
                    <div class="form">
                        <div class="form-group">
                            <div class="custom-file">
                                <asp:FileUpload ID="fileUpload"  CssClass="custom-file-input" runat="server" />
                                <label class="custom-file-label" for="fileUpload">Seleccionar Archivo</label>
                            </div>
                            <asp:Label ID="lbStatus" runat="server"/>
                        </div>
                        <asp:Button ID="btnImportar"  CssClass="btn btn-primary"  runat="server" OnClick="btnImportarXLS_Click"  Text="Formato XLS" />
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
