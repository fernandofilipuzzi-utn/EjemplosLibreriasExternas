<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportarExcelCasoParticular.aspx.cs" Inherits="ServicioAPI.ImportarExcelCasoParticular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contain" style="min-width: 786px;">

        <div class="jumbotron" style="background-color: #dcdced; min-width: 786px;">
            <h3 class="display-4">Importación Excel (caso particular) </h3>
            <p class="lead">Ejemplo de importación de un Fichero Excel para el caso de que un documento Excel no esté estructurado en una simple tabla.</p>
            <p class="lead">En este ejemplo el proceso de importación depende de como fue organizado el fichero Excel.</p>
        </div>

        <div class="row m-0 p-0">

            <div class="col-12 mb-3 mt-3" style="background-color: #dcdced;">
                <div class="col-12">
                    <div>Descarga del fichero de prueba para el que fue hecho esté particular ejemplo</div>
                    <div class="col text-center">
                        <asp:LinkButton class="btn btn-primary" ID="btnDescargarEjemploExcel" OnClick="btnDescargarEjemploExcel_Click" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:LinkButton>
                    </div>
                </div>
            </div>
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
                            <th>Numero</th>
                            <th>Fecha</th>
                            <th>Monto Total</th>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Numero") %></td>
                        <td><%# Eval("Fecha") %></td>
                        <td><%# Eval("Monto_Total") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>

