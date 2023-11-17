# Ejemplos aplicando librerías de terceros#

<details>
<summary>Generación de documentos PDF desde documetos HTML</summary>

<h4>iTextSharp</h4>

<h4>SelectPDF</h4>

</details>

# #
<details>
<summary>Generación de documentos EXCEL</summary>

<h4>Vista prueba aplicación desktop de prueba</h4>

<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/Ej1_NPOI_Desktop/docs/desktop.jpg"/>
</div>

<h4>Vista prueba aplicación web de prueba</h4>
<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/Ej2_NPOI_Web/docs/appweb.jpg"/>
</div>

<h4>Usando NPOI (XLS y XLSX)</h4>
<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/NPOI_excel_ClassLib/docs/excel_npoi.jpg"/>
</div>

<h4>Usando EPPLUS (XLSX)</h4>
<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/EPPlus_excel_ClassLib/docs/excel_epplus.jpg"/>
</div>

</details>

# #
<details>
<summary> Generación de QR</summary>

  <h4>QRCoder</h4>
<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosQR/Ej1_QR_Desktop/docs/pantallazo.jpg"/>
</div>

```csharp
  QRCodeGenerator qrGenerator = new QRCodeGenerator();
  QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
  QRCode qrCode = new QRCode(qrCodeData);
  Bitmap qrCodeImage = qrCode.GetGraphic(sizeModulo);
```

</details>















