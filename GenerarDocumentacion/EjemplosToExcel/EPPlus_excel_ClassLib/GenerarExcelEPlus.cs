using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EPPlus_excel_ClassLib.Models;
using OfficeOpenXml;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FontSize = DocumentFormat.OpenXml.Spreadsheet.FontSize;

namespace EPPlus_excel_ClassLib
{
    public class GenerarExcelEPlus
    {
        public enum TipoFormato { XLS, XLSX }

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

        public byte[] Generar()
        {
            List<Ejemplo> ejemplos = Ejemplo.ListaDeEjemplos();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            byte[] bytes = new byte[0];
            // Crear un nuevo paquete de trabajo de Excel
            using (var package = new ExcelPackage())
            {
                // Agregar una nueva hoja de cálculo al paquete
                var sheet = package.Workbook.Worksheets.Add("MiHojaDeCalculo");

                int fila = 1;
                foreach (Ejemplo ejemplo in ejemplos)
                {
                    sheet.SetValue($"A{fila}", ejemplo.Texto);
                    sheet.Cells[$"B{fila}"].Value = ejemplo.Numero;
                    sheet.Cells[$"C{fila}"].Value = DateTime.Parse($"{ejemplo.Fecha:dd/MM/yyyy}");
                    sheet.Cells[$"D{fila}"].Value = new TimeSpan(ejemplo.Fecha.Hour, ejemplo.Fecha.Minute, ejemplo.Fecha.Second);
                    sheet.Cells[$"E{fila}"].Value = ejemplo.Moneda;

                    fila++;
                }

                sheet.Cells[$"A1:A{fila - 1}"].Style.Numberformat.Format = "@";
                sheet.Cells[$"B1:B{fila - 1}"].Style.Numberformat.Format = "#,###";
                sheet.Cells[$"C1:C{fila - 1}"].Style.Numberformat.Format = "d/m/yy";
                sheet.Cells[$"D1:D{fila - 1}"].Style.Numberformat.Format = "[Red]h:mm:ss;@";
                sheet.Cells[$"E1:E{fila - 1}"].Style.Numberformat.Format = "$* #,##0.00;@";

                sheet.Cells[$"A1:E{fila - 1}"].Style.Font.Size = 10;
                sheet.Cells[$"A1:E{fila - 1}"].Style.Font.Name = "Arial";
                sheet.Cells[$"A1:E{fila - 1}"].Style.Font.Bold = true;

                sheet.Cells.AutoFitColumns();

                //_-[$$-es-AR]\" \"* #.##0,00_-
                using (var ms = new MemoryStream())
                {
                    package.SaveAs(ms);
                    bytes = ms.ToArray();
                }

                GC.Collect();
            }

            return bytes;
        }
        public byte[] GenerarExcel1()
        {
            SLDocument sl = new SLDocument();

            // set a boolean at "A1"
            sl.SetCellValue("A1", true);

            // set at row 2, columns 1 through 20, a value that's equal to the column index
            for (int i = 1; i <= 20; ++i) sl.SetCellValue(2, i, i);

            // set the value of PI
            sl.SetCellValue("B3", 3.14159);

            // set the value of PI at row 4, column 2 (or "B4") in string form.
            // use this when you already have numeric data in string form and don't
            // want to parse it to a double or float variable type
            // and then set it as a value.
            // Note that "3,14159" is invalid. Excel (or Open XML) stores numerals in
            // invariant culture mode. Frankly, even "1,234,567.89" is invalid because
            // of the comma. If you can assign it in code, then it's fine, like so:
            // double fTemp = 1234567.89;
            sl.SetCellValueNumeric(4, 2, "3.14159");

            // normal string data
            sl.SetCellValue("C6", "This is at C6!");

            // typical XML-invalid characters are taken care of,
            // in particular the & and < and >
            sl.SetCellValue("I6", "Dinner & Dance costs < $10");

            // this sets a cell formula
            // Note that if you want to set a string that starts with the equal sign,
            // but is not a formula, prepend a single quote.
            // For example, "'==" will display 2 equal signs
            sl.SetCellValue(7, 3, "=SUM(A2:T2)");

            // if you need cell references and cell ranges *really* badly, consider the SLConvert class.
            sl.SetCellValue(SLConvert.ToCellReference(7, 4), string.Format("=SUM({0})", SLConvert.ToCellRange(2, 1, 2, 20)));

            // dates need the format code to be displayed as the typical date.
            // Otherwise it just looks like a floating point number.
            sl.SetCellValue("C8", new DateTime(3141, 5, 9));
            SLStyle style = sl.CreateStyle();
            style.FormatCode = "d-mmm-yyyy";
            sl.SetCellStyle("C8", style);

            sl.SetCellValue(8, 6, "I predict this to be a significant date. Why, I do not know...");

            sl.SetCellValue(9, 4, 456.123789);
            // we don't have to create a new SLStyle because
            // we only used the FormatCode property
            style.FormatCode = "0.000%";
            sl.SetCellStyle(9, 4, style);

            sl.SetCellValue(9, 6, "Perhaps a phenomenal growth in something?");

            byte[] bytes = new byte[0];
            using (var ms = new MemoryStream())
            {
                sl.SaveAs(ms);
                bytes = ms.ToArray();
            }

            GC.Collect();
            return bytes;
        }

        public byte[] GenerarExcel()
        {
            List<Ejemplo> ejemplos = Ejemplo.ListaDeEjemplos();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create a new spreadsheet document in memory.
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());

                    Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                    sheets.Append(sheet);

                    WorkbookStylesPart workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    workbookStylesPart.Stylesheet = GenerateStylesheet();

                    foreach (Ejemplo ejemplo in ejemplos)
                    {
                        Row row = new Row();
                        Cell cell1 = new Cell() { CellValue = new CellValue(ejemplo.Texto), DataType = CellValues.String };
                        Cell cell2 = new Cell() { CellValue = new CellValue(ejemplo.Numero), DataType = CellValues.Number, StyleIndex = 1 };
                        Cell cell3 = new Cell() { CellValue = new CellValue(ejemplo.Fecha), DataType = CellValues.Date, StyleIndex = 2 };
                        row.Append(cell1, cell2, cell3);
                        SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                        sheetData.AppendChild(row);
                    }
                }
                return memoryStream.ToArray();
            }
        }

        private Stylesheet GenerateStylesheet()
        {
            Stylesheet stylesheet = new Stylesheet();

            Fonts fonts = new Fonts(
                new Font()
                {
                    FontSize = new FontSize() { Val = 10 },
                    FontName = new FontName() { Val = "Arial" }
                }
            );

            Fills fills = new Fills(
                new Fill() { PatternFill = new PatternFill() { PatternType = PatternValues.None } }
            );

            Borders borders = new Borders(
                new Border() { LeftBorder = new LeftBorder(), RightBorder = new RightBorder(), TopBorder = new TopBorder(), BottomBorder = new BottomBorder(), DiagonalBorder = new DiagonalBorder() }
            );

            CellFormats cellFormats = new CellFormats(
                new CellFormat() { NumberFormatId = 2, FontId = 0, FillId = 0, BorderId = 0 },
                 new CellFormat() { NumberFormatId = 20, FontId = 0, FillId = 0, BorderId = 0 }
            );
            stylesheet.Append(fonts, fills, borders, cellFormats);

            return stylesheet;
        }
    }
}
