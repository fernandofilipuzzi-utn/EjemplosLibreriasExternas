<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportarExcelPorAPI_InputFile_DTO.aspx.cs" Inherits="ServicioEncuestasAPIClient.ImportarExcelPorAPI_InputFile_DTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contain" style="min-width: 786px;">

        <div class="jumbotron" style="background-color: #dcdced; min-width: 786px;">
            <h3 class="display-4">Importación Excel a DataTable </h3>
            <p class="lead">Ejemplo importación Fichero Excel a DataTable</p>
        </div>

        <div class="row m-0 p-0">

            <div class="col-12 mb-3 mt-3" style="background-color: #dcdced;">

                <div class="row justify-content-end p-2">
                    <div class="col-8">
                        <asp:FileUpload ID="fuFicheroExcel" class="file-upload" ToolTip="Elegir excel" name="Subir fichero" value="elegir" runat="server" accept=".xlsx" />
                    </div>
                </div>

                <div class="col-12  text-center p-2">
                    <asp:Button ID="btnEnviar" type="submit" class="btn btn-primary mx-auto" OnClick="btnEnviar_Click" runat="server" Text="Enviar" />
                </div>
            </div>
        </div>

        <div class="row m-0 p-0">

            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table class="table table-condensed table-borderless table-hover text-center">
                        <thead class="table-dark">
                            <th>Texto</th>
                            <th>Entero</th>
                            <th>Decimal</th>
                            <th>Moneda</th>
                            <th>Fecha</th>
                            <th>Hora</th>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Texto") %></td>
                        <td><%# Eval("Entero") %></td>
                        <td><%# Eval("Decimal") %></td>
                        <td><%# Eval("Moneda") %></td>
                        <td><%# Eval("Fecha") %></td>
                        <td><%# Eval("Hora") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>