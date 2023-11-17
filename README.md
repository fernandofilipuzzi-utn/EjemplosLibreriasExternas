# Ejemplos aplicando librerías de terceros

# #

<details>
<summary>Generación de documentos PDF desde documetos HTML</summary>

### iTextSharp

### SelectPDF

</details>

# #

<details>
<summary>Generación de documentos EXCEL</summary>

### Vista prueba aplicación desktop de prueba

<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/Ej1_NPOI_Desktop/docs/desktop.jpg"/>
</div>

###  Vista prueba aplicación web de prueba
<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/Ej2_NPOI_Web/docs/appweb.jpg"/>
</div>

###  Usando NPOI (XLS y XLSX)
<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/NPOI_excel_ClassLib/docs/excel_npoi.jpg"/>
</div>

###  Usando EPPLUS (XLSX)
<div align="center">
        <img style="width:300px;" src="GenerarDocumentacion/EjemplosToExcel/EPPlus_excel_ClassLib/docs/excel_epplus.jpg"/>
</div>

</details>

# #

<details>
<summary> Generación de QR</summary>

### QRCoder
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















