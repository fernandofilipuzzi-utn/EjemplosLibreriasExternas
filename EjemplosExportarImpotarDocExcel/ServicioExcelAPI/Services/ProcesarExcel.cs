using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace ServicioAPI.Services
{    
    public class ProcesarExcel
    {        
        public byte[] ExportarDataTableToExcel(DataTable dataTable, ImportacionExcelUtils.TipoFormato formato = ImportacionExcelUtils.TipoFormato.XLSX)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

            int nroLinea = 0;
            int nroColumna = 0;

            #region formato
            IWorkbook wb = null;
            if (formato == ImportacionExcelUtils.TipoFormato.XLS)
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
            styleHText.WrapText = true;
            styleHText.SetFont(hFont);

            ICellStyle styleText = wb.CreateCellStyle();
            styleHText.DataFormat = wb.CreateDataFormat().GetFormat("text");
            styleHText.WrapText = true;
            styleHText.SetFont(font);
            #endregion

            #region procesando los nombres de las columnas
            nroColumna = 0;
            var row = sheet.CreateRow(0);
            foreach (DataColumn dr in dataTable.Columns)
            {
                string texto = dr.ColumnName;

                #region headers
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.String);
                if (string.IsNullOrEmpty(texto) == false)
                    row.GetCell(nroColumna).SetCellValue(texto);
                row.GetCell(nroColumna).CellStyle = styleHText;
                nroColumna++;
                #endregion
            }
            #endregion

            #region procesando las filas de datos
            foreach (DataRow dr in dataTable.Rows)
            {
                nroColumna = 0;
                row = sheet.CreateRow(++nroLinea);

                foreach (object cell in dr.ItemArray)
                {
                    string texto = Convert.ToString(cell);

                    #region texto
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.String);
                    if (string.IsNullOrEmpty(texto) == false)
                        row.GetCell(nroColumna).SetCellValue(texto);
                    row.GetCell(nroColumna).CellStyle = styleHText;
                    nroColumna++;
                    #endregion
                }
            }
            #endregion

            #region fichero
            byte[] bytes = new byte[0];
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                bytes = ms.ToArray();
            }
            GC.Collect();
            #endregion

            return bytes;
        }

        public DataSet ImportarExcelToDataSet(Stream stream, ImportacionExcelUtils.TipoFormato formato = ImportacionExcelUtils.TipoFormato.XLSX)
        {
            IWorkbook hssfwb = new XSSFWorkbook(stream);
            ISheet sheet = hssfwb.GetSheetAt(0);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            IRow headerRow = sheet.GetRow(0);
            if (headerRow != null)
            {
                #region importando los nombres de las columnas
                for (int i = 0; i < headerRow.LastCellNum; i++)
                {
                    string columnName = headerRow.GetCell(i).StringCellValue;
                    dt.Columns.Add(columnName, typeof(string));
                }
                #endregion

                #region importando las filas
                for (int rowIdx = 1; rowIdx <= sheet.LastRowNum; rowIdx++)
                {
                    IRow row = sheet.GetRow(rowIdx);
                    if (row != null)
                    {
                        DataRow newRow = dt.NewRow();
                        for (int cellIdx = 0; cellIdx < headerRow.LastCellNum; cellIdx++)
                        {
                            if (row.GetCell(cellIdx) != null)
                            {
                                newRow[cellIdx] = Convert.ToString(row.GetCell(cellIdx).ToString());
                            }
                        }
                        dt.Rows.Add(newRow);
                    }
                }
                #endregion
            }
            return ds;
        }
    }
}