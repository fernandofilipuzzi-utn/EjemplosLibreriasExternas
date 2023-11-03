<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ej2_NPOI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Probando generar fichero excel</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="container">
        <asp:Label ID="lbError" runat="server" Text="" />
        <br/>

        <asp:Button ID="XLS" runat="server" OnClick="btnXLS_Click"  Text="Formato XLS" />

        <br />

        <asp:Button ID="XLSX" runat="server" OnClick="btnXLSX_Click" Text="Formato XLSX" />
    </div>

</asp:Content>
