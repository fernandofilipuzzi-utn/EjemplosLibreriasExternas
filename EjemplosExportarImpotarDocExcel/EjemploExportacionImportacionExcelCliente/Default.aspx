﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjemploExportacionImportacionExcelCliente._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Exportando e Importando desde una aplicación externa.</h3>
        <p class="lead">LLamando a la API</p>
    </div>

    <div class="container row text-center m-2">

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="./img/excel.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Exportar Excel</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Ejemplo usando API Web!</p>
                </div>

            </div>
            <div class="text-center">
                <asp:LinkButton class="btn btn-primary" ID="btnExcel1" 
                                OnClick="btnExcel1_Click" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:LinkButton>
                <asp:LinkButton class="btn btn-primary" ID="btnExcel2" 
                                OnClick="btnExcel2_Click" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:LinkButton>
            </div>
        </div>
           

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="./img/api-web.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Importar Excel</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Ejemplo usando API Web</p>
                </div>

            </div>
            <div class="text-center">
                <asp:LinkButton class="btn btn-primary" ID="btnImportar" OnClick="btnImportar_Click" runat="server"><i class="fa fa-upload" aria-hidden="true"></i>Subir</asp:LinkButton>
            </div>
        </div>

    </div>

</asp:Content>
