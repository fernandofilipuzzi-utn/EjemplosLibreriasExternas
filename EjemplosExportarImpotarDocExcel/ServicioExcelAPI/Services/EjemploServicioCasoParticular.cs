using NPOI.HSSF.UserModel;
using NPOI.SS.Format;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace ServicioAPI.Services
{
    /// <summary>
    /// Caso especifico, donde el excel no se estructura en una simple tabla
    /// </summary>
    public class EjemploServicioCasoParticular
    {
      
        public byte[] ExportarAExcel(ImportacionExcelUtils.TipoFormato formato)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

            DataTable dt = ConsultaBase().Tables[0];

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

            /*
            #region formato de celda texto
            ICellStyle styleText = wb.CreateCellStyle();
            styleText.DataFormat = wb.CreateDataFormat().GetFormat("text");
            styleText.SetFont(font);
            #endregion

            #region formato de celda numerico
            ICellStyle stylesShortNumero = wb.CreateCellStyle();
            stylesShortNumero.DataFormat = wb.CreateDataFormat().GetFormat("0");
            stylesShortNumero.SetFont(font);
            #endregion

            #region formato de celda Personalizado - coloreado y centrado
            ICellStyle styleNumero1 = wb.CreateCellStyle();
            styleNumero1.DataFormat = wb.CreateDataFormat().GetFormat("0;[Red]-0;@");
            styleNumero1.SetFont(font);
            styleNumero1.Alignment = HorizontalAlignment.Center;
            styleNumero1.FillForegroundColor = IndexedColors.Yellow.Index;
            styleNumero1.FillPattern = FillPattern.SolidForeground;
            styleNumero1.BorderTop = BorderStyle.Thin;
            styleNumero1.BorderBottom = BorderStyle.Thin;
            styleNumero1.BorderLeft = BorderStyle.Thin;
            styleNumero1.BorderRight = BorderStyle.Thin;
            styleNumero1.TopBorderColor = IndexedColors.Grey25Percent.Index;
            styleNumero1.BottomBorderColor = IndexedColors.Grey25Percent.Index;
            styleNumero1.LeftBorderColor = IndexedColors.Grey25Percent.Index;
            styleNumero1.RightBorderColor = IndexedColors.Grey25Percent.Index;
            #endregion

            #region formato de celda Personalizado 
            ICellStyle styleNumero = wb.CreateCellStyle();
            styleNumero.DataFormat = wb.CreateDataFormat().GetFormat("###,###,##0");
            styleNumero.SetFont(font);
            #endregion
            //
            #region formato de celda Personalizado
            ICellStyle styleCuit = wb.CreateCellStyle();
            styleCuit.DataFormat = wb.CreateDataFormat().GetFormat("##-########-#;@");
            styleCuit.SetFont(font);
            #endregion
            //
            #region formato de celda Fecha
            ICellStyle styleFecha = wb.CreateCellStyle();
            styleFecha.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yy;@");
            styleFecha.SetFont(font);
            #endregion
            //
            #region formato de celda Hora
            ICellStyle styleHora = wb.CreateCellStyle();
            styleHora.DataFormat = wb.CreateDataFormat().GetFormat("hh:mm:ss;@");
            styleHora.SetFont(font);
            #endregion
            //
            #region formato de celda Personalizado
            ICellStyle styleMoneda = wb.CreateCellStyle();
            styleMoneda.DataFormat = wb.CreateDataFormat().GetFormat("$* #,##0.00;@");
            styleMoneda.SetFont(font);
            #endregion
            */
            #endregion

            #region cabecera
            IRow headerRow = sheet.CreateRow(nroLinea);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("TEXTO");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;

            /*
            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("NUMERO CORTO");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("NUMERO");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("NUMERO");
            headerRow.GetCell(nroColumna).CellStyle = styleHText;
            nroColumna++;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellType(CellType.String);
            headerRow.GetCell(nroColumna).SetCellValue("CUIL");
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
            */
            #endregion

            foreach (DataRow dr in dt.Rows)
            {
                var row = sheet.CreateRow(++nroLinea);
                nroColumna = 0;

                //
                string texto = Convert.ToString( dr["TEXTO"] );
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
                /*
                //
                int numeroCorto = Convert.ToInt32(dr["NUMERO CORTO"]);
                //
                //
                #region numero
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(numeroCorto);
                row.GetCell(nroColumna).CellStyle = stylesShortNumero;
                nroColumna++;
                #endregion
                //
                int numero = Convert.ToInt32(dr["NUMERO CORTO"]);
                //
                #region numero
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(numero);
                row.GetCell(nroColumna).CellStyle = styleNumero1;
                nroColumna++;
                #endregion
                //
                #region numero
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(numero);
                row.GetCell(nroColumna).CellStyle = styleNumero;
                nroColumna++;
                #endregion
                //
                long cuit = Convert.ToInt64(dr["CUIT"]);
                string cuitString = cuit.ToString();
                if (cuitString.Length == 10)
                {
                    cuitString = cuitString.Insert(2, "0");
                }
                //
                #region cuit
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(long.Parse(cuitString));
                row.GetCell(nroColumna).CellStyle = styleCuit;
                nroColumna++;
                #endregion
                //
                DateTime fecha = Convert.ToDateTime(dr["FECHA"]); 
                DateTime hora = fecha;
                //esta movida es para que excel reconozca el tipo de celda.
                int oaFecha = (int)fecha.ToOADate();
                double oaTiempo = fecha.TimeOfDay.TotalDays;
                //
                #region fecha - alternativa 1    
                //esta alternativa debería excel hacer que tome por defecto el tipo Fecha o Date
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(oaFecha);
                row.GetCell(nroColumna).CellStyle = styleFecha;
                nroColumna++;
                #endregion              
                //
                #region fecha - alternativa 2             
                //row.CreateCell(nroColumna);
                //row.GetCell(nroColumna).SetCellValue(DateTime.Parse($"{fecha:dd/MM/yyyy}"));
                //row.GetCell(nroColumna).CellStyle = styleFecha;
                //nroColumna++;
                #endregion              
                //
                #region hora -alternativa 1
                //esta alternativa debería excel hacer que tome por defecto el tipo Hora o Time
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(oaTiempo);
                row.GetCell(nroColumna).CellStyle = styleHora;
                nroColumna++;
                #endregion

                #region hora - alternativa 2
                //row.CreateCell(nroColumna);
                //row.GetCell(nroColumna).SetCellValue($"{hora:HH:mm:ss}");
                //row.GetCell(nroColumna).CellStyle = styleHora;
                //nroColumna++;
                #endregion
                //
                double moneda = Convert.ToDateTime(dr["MONEDA"]);
                //
                #region IMPORTE
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).SetCellValue(moneda);
                row.GetCell(nroColumna).CellStyle = styleMoneda;
                nroColumna++;
                #endregion
                //
                //     
                */
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

        private DataSet ConsultaBase()
        {
            DataSet dataSet = new DataSet();

            DataTable dt = new DataTable();
            dataSet.Tables.Add(dt);

            dt.Columns.Add("TEXTO", typeof(string));
            /*
            dt.Columns.Add("NUMERO CORTO", typeof(int));
            dt.Columns.Add("NUMERO", typeof(DateTime));
            dt.Columns.Add("NUMERO", typeof(DateTime));
            */

            DataRow fila = dt.NewRow();
            fila["TEXTO"] = "texto 1"; /*fila["B"] = 3; fila["C"] = DateTime.Now;*/
            dt.Rows.Add(fila);

            fila = dt.NewRow();
            fila["TEXTO"] = "texto 2"; /*fila["B"] = 3; fila["C"] = DateTime.Now;*/
            dt.Rows.Add(fila);

            fila = dt.NewRow();
            fila["TEXTO"] = "texto 3"; /*fila["B"] = 3; fila["C"] = DateTime.Now;*/
            dt.Rows.Add(fila);

            /*
            fila = dt.NewRow();
            fila["A"] = "contenido 2"; fila["B"] = 5; fila["C"] = DateTime.Now;
            dt.Rows.Add(fila);
            */
            return dataSet;
        }

        public DataSet ImportarExcelResumenInsumos(Stream stream, ImportacionExcelUtils.TipoFormato formato = ImportacionExcelUtils.TipoFormato.XLSX)
        {
            #region tipo de documento
            IWorkbook hssfwb = new XSSFWorkbook(stream);
            ISheet sheet = hssfwb.GetSheetAt(0);
            #endregion

            //emulando tener las tablas
            DataSet ds = getTablasParaCasoParticular();

            #region sección  maestro
            int numero = 0;
            DateTime fecha = DateTime.MinValue;
            double montoTotal = 0;

            IRow headerRow = sheet.GetRow(1); //fila 2
            if (headerRow != null)
            {              
                numero =(int) headerRow.GetCell((int)ImportacionExcelUtils.COL.B).NumericCellValue; //importante que la celda tenga formato número
             
                fecha = headerRow.GetCell((int)ImportacionExcelUtils.COL.G).DateCellValue; //importante que la celda tenga formato fecha
            }

            headerRow = sheet.GetRow(7); //fila 8
            if (headerRow != null)
            {
                 montoTotal = headerRow.GetCell((int)ImportacionExcelUtils.COL.G).NumericCellValue; //importante que la celda tenga formato  numeric o $
            }
            #endregion

            InsertResumen(ds, numero, fecha, montoTotal);

            #region detalle
            string descripcion = "";
            double monto = 0;

            headerRow = sheet.GetRow(4);//fila 5
            if (headerRow != null)
            {
                descripcion = headerRow.GetCell((int)ImportacionExcelUtils.COL.A).StringCellValue; 
                monto = headerRow.GetCell((int)ImportacionExcelUtils.COL.G).NumericCellValue;
            }
            InsertDetalleResumen(ds, numero, descripcion, monto);
            #endregion

            return ds;
        }

        /// <summary>
        /// recreando tablas en memoria a modo de ejemplo
        /// </summary>
        /// <returns></returns>
        public DataSet getTablasParaCasoParticular()
        {
            DataSet ds = new DataSet();

            DataTable dtMaestro = new DataTable("Resumenes");
            ds.Tables.Add(dtMaestro);

            dtMaestro.Columns.Add("Numero", typeof(int));
            dtMaestro.Columns.Add("Fecha", typeof(DateTime));
            dtMaestro.Columns.Add("Monto_Total", typeof(double));

            DataTable dtDetalle = new DataTable("Detalles_Resumen");
            ds.Tables.Add(dtDetalle);

            dtDetalle.Columns.Add("Numero_Reporte", typeof(int));
            dtDetalle.Columns.Add("Descripcion", typeof(string));
            dtDetalle.Columns.Add("Cantidad_UD", typeof(double));
            dtDetalle.Columns.Add("Precio_UD", typeof(double));
            dtDetalle.Columns.Add("Monto", typeof(double));

            return ds;
        }

        public void InsertResumen(DataSet ds, int numero, DateTime fecha, double montoTotal)
        {
            //nueva fila
            DataRow dataRow = ds.Tables["Resumenes"].NewRow();

            //asigna
            dataRow["Numero"] = numero;
            dataRow["Fecha"] = fecha;
            dataRow["Monto_Total"] = montoTotal;

            ds.Tables["Resumenes"].Rows.Add(dataRow);
        }

        public void InsertDetalleResumen(DataSet ds, int numeroReporte, string Descripcion, double monto)
        {
            //nueva fila
            DataRow dataRow = ds.Tables["Detalles_Resumen"].NewRow();

            //asigna
            dataRow["Numero_Reporte"] = numeroReporte;
            dataRow["Descripcion"] = Descripcion;
            dataRow["Monto"] = monto;

            ds.Tables["Detalles_Resumen"].Rows.Add(dataRow);
        }
    }
}