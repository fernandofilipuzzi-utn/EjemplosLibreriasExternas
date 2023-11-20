<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
                CodeBehind="Default.aspx.cs" Inherits="Ej1_QR_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Ejemplo Generación de PDF</h2>
        <p class="lead">Prueba de generación de fichero pdf desde documento HTML</p>
    </div>

    <div class="container">
        <div class="row">
            <div class="card text-center col-4">
                <img src="/img/qr_gen.jpg" class="card-img-top" alt="Ir a Checkout">
                <div class="card-body">
                    <h5 class="card-title">PDF</h5>
                    <p class="card-text">Generación PDF</p>

                    <asp:Button type="button" class="btn btn-primary" runat="server" OnClick="Unnamed_Click" Text="Generar pdf"/>
                </div>
            </div>

        </div>
    </div>

   
</asp:Content>
