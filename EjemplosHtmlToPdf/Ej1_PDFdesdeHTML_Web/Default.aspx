<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ej1_QR_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Ejemplo QR</h2>
        <p class="lead">Generando QR en base64</p>
    </div>

    <div class="container">
        <div class="row">
            <div class="card text-center col-4">
                <img src="/img/qr_gen.jpg" class="card-img-top" alt="Ir a Checkout">
                <div class="card-body">
                    <h5 class="card-title">Generar QR</h5>
                    <p class="card-text">Generar QR de ejemplo</p>

                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                        Mostrar QR Generado
                    </button>
                </div>
            </div>

        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">QR Generado</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <asp:Image ID="imgQR" CssClass="col-12" runat="server" />
                   
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
