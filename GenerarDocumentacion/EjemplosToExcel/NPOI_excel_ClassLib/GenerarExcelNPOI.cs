using Ej1_NPOI.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NPOI_excel_ClassLib
{
    public class GenerarExcelNPOI
    {
        public enum TipoFormato { XLS, XLSX}

        public string GetMimeType(TipoFormato formato)
        {
            if (formato == TipoFormato.XLS)
            {
                return "application/vnd.ms-excel";
            }
            else
            {
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
        }
        public byte[] GenerarExcel(TipoFormato formato)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

            List<Ejemplo> ejemplos=Ejemplo.ListaDeEjemplos();

            int nroLinea = 0;
            int nroColumna = 0;

            #region formato
            IWorkbook wb = null;
            if (formato == TipoFormato.XLS)
            {
                wb = new HSSFWorkbook(); 
            }
            else
            {
                wb = new XSSFWorkbook();
            }
            #endregion

            var sheet = wb.CreateSheet("Hoja1");
            
            #region fuente Set font style
            IFont hFont = wb.CreateFont();
            hFont.FontName = "Arial";
            hFont.IsBold = true;
            hFont.FontHeightInPoints = 10;

            IFont font = wb.CreateFont();
            font.FontName = "Arial";
            font.FontHeightInPoints = 10;
            #endregion

            #region styles                
            ICellStyle styleHText = wb.CreateCellStyle();
            styleHText.DataFormat = wb.CreateDataFormat().GetFormat("text");
            styleHText.SetFont(hFont);

            ICellStyle styleText = wb.CreateCellStyle();
            styleText.DataFormat = wb.CreateDataFormat().GetFormat("text");
            styleText.SetFont(font);

            ICellStyle styleNumero = wb.CreateCellStyle();
            styleNumero.DataFormat = wb.CreateDataFormat().GetFormat("###,###,###;@");
            styleNumero.SetFont(font);

            ICellStyle styleFecha = wb.CreateCellStyle();
            styleFecha.DataFormat = wb.CreateDataFormat().GetFormat(" dd/mm/yy;@");
            styleFecha.SetFont(font);

            ICellStyle styleHora = wb.CreateCellStyle();
            styleHora.DataFormat = wb.CreateDataFormat().GetFormat("H:m:ss;@");
            styleHora.SetFont(font);

            ICellStyle styleMoneda = wb.CreateCellStyle();
            styleMoneda.DataFormat = wb.CreateDataFormat().GetFormat("$* #,##0.00;@");
            styleMoneda.SetFont(font);
            #endregion

            #region cabecera
            IRow headerRow = sheet.CreateRow(nroLinea);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("TEXTO");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("NUMERO");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("FECHA");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("HORA");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;
            #endregion

            foreach (Ejemplo ejemplo in ejemplos)
            {
                var row = sheet.CreateRow(++nroLinea);
                nroColumna = 0;

                //
                string texto = ejemplo.Texto;
                //
                #region texto
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.String);
                if (string.IsNullOrEmpty(texto) == false)
                    row.GetCell(nroColumna).SetCellValue(texto);
                row.GetCell(nroColumna).CellStyle = styleHText;
                nroColumna++;
                #endregion
                //
                //
                int numero = ejemplo.Numero;
                //
                #region numero
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(numero);
                row.GetCell(nroColumna).CellStyle = styleNumero;
                nroColumna++;
                #endregion
                //              
                //
                DateTime fecha = ejemplo.Fecha;
                //
                #region fecha               
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellValue(DateTime.Parse($"{fecha:dd/MM/yyyy}"));
                row.GetCell(nroColumna).CellStyle = styleFecha;
                nroColumna++;
                #endregion
                //!
                DateTime hora = fecha;
                //
                #region hora
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellValue($"{hora:h:m:ss}");
                row.GetCell(nroColumna).CellStyle = styleHora;
                nroColumna++;
                #endregion
                //
                double moneda = ejemplo.Moneda;
                //
                #region IMPORTE
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(moneda);
                row.GetCell(nroColumna).CellStyle = styleMoneda;
                nroColumna++;
                #endregion
                //                
            }

            #region rediminesionando las columnas
            sheet.DefaultColumnWidth = 15;
            /*
            int numberOfColumns = sheet.GetRow(nroColumna - 1).PhysicalNumberOfCells;
            for (int i = 0; i <= numberOfColumns; i++)
            {
                //sheet.AutoSizeColumn(i);//error en esta versión de c#
            }
            */
            #endregion

            byte[] bytes = new byte[0];
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                bytes = ms.ToArray();
            }

            GC.Collect();
            return bytes;
        }

    }
}
