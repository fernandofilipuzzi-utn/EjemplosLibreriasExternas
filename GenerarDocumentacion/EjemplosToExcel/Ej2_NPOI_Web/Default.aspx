<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ej2_NPOI_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="container">

        <div class="row">
            <asp:Label ID="lbError" runat="server" Text="" />
            
            <asp:Button ID="XLS" runat="server" OnClick="btnXLS_Click"  Text="Formato XLS" />
                        
            <asp:Button ID="XLSX" runat="server" OnClick="btnXLSX_Click" Text="Formato XLSX" />
        </div>
    </div>

</asp:Content>
