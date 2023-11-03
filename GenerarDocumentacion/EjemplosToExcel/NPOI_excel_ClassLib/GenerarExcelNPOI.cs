using Ej1_NPOI.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
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
        public byte[] GenerarExcelXlsx()
        {
            byte[] bytes = new byte[0];

            var prevCulture = Thread.CurrentThread.CurrentCulture;
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            try
            {
                List<Persona> personas = new List<Persona>
                {
                    new Persona{ Dni=40122312,Nombre="Juan", Nacimiento=new DateTime(2000,02,1,3,4,5)},
                    new Persona{ Dni=23142512,Nombre="Giuliana", Nacimiento=new DateTime(2000,12,12,3,4,5) },
                    new Persona{ Dni=36322312,Nombre="Regina", Nacimiento=new DateTime(1995,1,12,6,7,8) },
                    new Persona{ Dni=37332212,Nombre="Natalia", Nacimiento=new DateTime(1995,1,12,6,7,8) }
                };


                IWorkbook wb = new XSSFWorkbook();
                var sheet = wb.CreateSheet("hoja 1");

                ICellStyle style = wb.CreateCellStyle();

                #region fuente Set font style
                IFont hFont = wb.CreateFont();
                hFont.FontName = "Arial";
                hFont.IsBold = true;
                hFont.FontHeightInPoints = 10;

                IFont font = wb.CreateFont();
                font.FontName = "Arial";
                font.IsBold = false;
                font.FontHeightInPoints = 10;
                #endregion

                int nroFila = 0;

                #region cabecera
                IRow headerRow = sheet.CreateRow(nroFila);


                int nroColumna = 0;

                headerRow.CreateCell(nroColumna);
                headerRow.GetCell(nroColumna).SetCellValue("DNI");
                headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);


                headerRow.CreateCell(nroColumna);
                headerRow.GetCell(nroColumna).SetCellValue("NOMBRE");
                headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

                headerRow.CreateCell(nroColumna);
                headerRow.GetCell(nroColumna).SetCellValue("FECHA NACIMIENTO");
                headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

                headerRow.CreateCell(nroColumna);
                headerRow.GetCell(nroColumna).SetCellValue("HORA NACIMIENTO");
                headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

                headerRow.CreateCell(nroColumna);
                headerRow.GetCell(nroColumna).SetCellValue("VALOR");
                headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

                headerRow.CreateCell(nroColumna);
                headerRow.GetCell(nroColumna).SetCellValue("PESO");
                headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);
                #endregion

                foreach (Persona p in personas)
                {
                    var row = sheet.CreateRow(++nroFila);
                    nroColumna = 0;
                    //
                    #region celda con formato de numero con separador de miles
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    //el formato que toma es por ejemplo: 12.232.212
                    //con @ tomaría la configuración regional
                    //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("###,###,###;@");
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("###,###,###");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(p.Dni);
                    #endregion
                    //
                    #region celda con formato de texto
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.String);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(p.Nombre);
                    #endregion
                    //
                    #region  formato fecha de celda puesto como texto
                    //row.CreateCell(nroColumna);
                    //row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    //row.GetCell(nroColumna).CellStyle.DataFormat=HSSFDataFormat.GetBuiltinFormat("dd/mm/yyyy");
                    //row.GetCell(nroColumna).CellStyle.SetFont(font);
                    //row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:d/M/yyyy}");
                    #endregion
                    //
                    #region fromato de celda toma el formato de celda con el tipo fecha y el formato especificado

                    //!!! este tiene el problema que arrastra la hora de la fecha- ej 12/12/2000  03:04:05
                    //aunque la formatea bien -puede haber problema para quien importe ese excel

                    //row.CreateCell(nroColumna);
                    //row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    ////row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yyyy");
                    //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yy");
                    //row.GetCell(nroColumna).CellStyle.SetFont(font);
                    //row.GetCell(nroColumna++).SetCellValue(p.Nacimiento);
                    #endregion
                    //
                    #region fromato de celda toma el formato de celda con el tipo fecha y el formato especificado
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yyyy");
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yy;@");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(DateTime.Parse($"{p.Nacimiento:dd/MM/yyyy}"));
                    #endregion
                    //
                    #region hora fecha nacimiento
                    //row.CreateCell(nroColumna);
                    //row.GetCell(nroColumna).SetCellType(CellType.String);
                    //row.GetCell(nroColumna).CellStyle.SetFont(font);
                    //row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:HH:mm:ss}");
                    #endregion 
                    //
                    #region hora fecha nacimiento formato celda
                    //row.CreateCell(nroColumna);
                    //row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("h:m:s");
                    //row.GetCell(nroColumna).CellStyle.SetFont(font);
                    //row.GetCell(nroColumna++).SetCellValue(p.Nacimiento);
                    #endregion
                    //
                    #region hora fecha nacimiento formato celda
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yyyy");
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("h:m:ss;@");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:HH:mm:ss}");
                    //row.GetCell(nroColumna++).SetCellValue($"=time(hour({p.Nacimiento:H}), minute({p.Nacimiento:M}), second({p.Nacimiento:s}))");
                    #endregion
                    //
                    #region formato numerico
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("* 0.00;@");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(0.12);
                    #endregion
                    //
                    //
                    #region formato moneda
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("$* #,##0.00;@");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(23432.12);
                    #endregion
                }

                #region rediminesionando las columnas
                /*
                int numberOfColumns = sheet.GetRow(nroColumna - 1).PhysicalNumberOfCells;
                for (int i = 0; i <= numberOfColumns; i++)
                {
                    sheet.AutoSizeColumn(i);
                }
                */
                //EPPlus
                #endregion

                bytes = new byte[0];
                using (var ms = new MemoryStream())
                {
                    wb.Write(ms);
                    bytes = ms.ToArray();
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                Thread.CurrentThread.CurrentCulture = prevCulture;
            }
            return bytes;
        }

        public byte[] GenerarExcelXls()
        {
            List<Persona> personas = new List<Persona>
            {
                new Persona{ Dni=40122312,Nombre="Juan", Nacimiento=new DateTime(2000,02,1,3,4,5)},
                new Persona{ Dni=23142512,Nombre="Giuliana", Nacimiento=new DateTime(2000,12,12,3,4,5) },
                new Persona{ Dni=36322312,Nombre="Regina", Nacimiento=new DateTime(1995,1,12,6,7,8) },
                new Persona{ Dni=37332212,Nombre="Natalia", Nacimiento=new DateTime(1995,1,12,6,7,8) }
            };

            //formato excel 97-2003
            IWorkbook wb = new HSSFWorkbook();
            var sheet = wb.CreateSheet("hoja 1");

            ICellStyle style = wb.CreateCellStyle();

            #region fuente Set font style
            IFont hFont = wb.CreateFont();
            hFont.FontName = "Arial";
            hFont.IsBold = true;
            hFont.FontHeightInPoints = 10;

            IFont font = wb.CreateFont();
            font.FontName = "Arial";
            font.IsBold = false;
            font.FontHeightInPoints = 10;
            #endregion

            int nroFila = 0;

            #region cabecera
            IRow headerRow = sheet.CreateRow(nroFila);

            int nroColumna = 0;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("DNI");
            headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
            headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);


            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("NOMBRE");
            headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
            headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("FECHA NACIMIENTO");
            headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
            headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("HORA NACIMIENTO");
            headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
            headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("Valor");
            headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
            headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("Moneda");
            headerRow.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
            headerRow.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(hFont);
            #endregion

            foreach (Persona p in personas)
            {
                var row = sheet.CreateRow(++nroFila);
                nroColumna = 0;
                //
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                //el formato que toma es por ejemplo: 12.232.212
                //con @ tomaría la configuración regional
                //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("###,###,###;@");
                row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("###,###,###");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(p.Dni);
                //
                #region celda text
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.String);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(p.Nombre);
                #endregion
                //
                #region fecha como texto
                // forma 1 - formato forzado
                //row.CreateCell(nroColumna);
                //row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                //row.GetCell(nroColumna).CellStyle.DataFormat=HSSFDataFormat.GetBuiltinFormat("dd/mm/yyyy");
                //row.GetCell(nroColumna).CellStyle.SetFont(font);
                //row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:d/M/yyyy}");
                #endregion
                //
                #region fecha con formato de celda
                // form 2 - la celda toma el formato de celda con el tipo fecha y el formato especificado
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                //formato año largo
                //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yyyy");
                //formato año corto
                row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yy");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(p.Nacimiento);
                #endregion
                //
                // forma 1
                //row.CreateCell(nroColumna);
                //row.GetCell(nroColumna).SetCellType(CellType.String);
                //row.GetCell(nroColumna).CellStyle.SetFont(font);
                //row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:HH:mm:ss}");
                //
                #region hora minuto segundo con formato de celda
                // forma 2
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                //row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("h:m:s");
                row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("hh:mm:ss");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(p.Nacimiento);
                #endregion
                //
                #region valor decimal
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("0.00");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(0.12);
                #endregion
                //
                #region formato moneda
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("$#,##0.00");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(0.12);
                #endregion
            }

            #region rediminesionando las columnas
            int numberOfColumns = 6;//sheet.GetRow(nroColumna - 1).PhysicalNumberOfCells;
            for (int i = 0; i <= numberOfColumns; i++)
            {
                sheet.AutoSizeColumn(i);
            }
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
