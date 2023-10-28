using Ej1_NPOI.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ej1_NPOI
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Persona> personas = new List<Persona>
            {
                new Persona{ Dni=40122312,Nombre="Juan", Nacimiento=new DateTime(2000,02,1,3,4,5)},
                new Persona{ Dni=23142512,Nombre="Giuliana", Nacimiento=new DateTime(2000,12,12,3,4,5) },
                new Persona{ Dni=36322312,Nombre="Regina", Nacimiento=new DateTime(1995,1,12,6,7,8) },
                new Persona{ Dni=37332212,Nombre="Natalia", Nacimiento=new DateTime(1995,1,12,6,7,8) }
            };

            try
            {
                IWorkbook wb = new XSSFWorkbook();
                var sheet = wb.CreateSheet("hoja 1");
                
                ICellStyle style = wb.CreateCellStyle();

                # region fuente Set font style
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
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.String);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("text");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(p.Nombre);
                    //
                    // forma 1 - formato forzado
                    //row.CreateCell(nroColumna);
                    //row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    //row.GetCell(nroColumna).CellStyle.DataFormat=HSSFDataFormat.GetBuiltinFormat("dd/mm/yyyy");
                    //row.GetCell(nroColumna).CellStyle.SetFont(font);
                    //row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:d/M/yyyy}");
                    //
                    // form 2 - la celda toma el formato de celda con el tipo fecha y el formato especificado
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("dd/mm/yyyy");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(p.Nacimiento);
                    //
                    // forma 1
                    //row.CreateCell(nroColumna);
                    //row.GetCell(nroColumna).SetCellType(CellType.String);
                    //row.GetCell(nroColumna).CellStyle.SetFont(font);
                    //row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:HH:mm:ss}");
                    //
                    // forma 2
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("h:m:s");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(p.Nacimiento);
                    //
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                    row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                    row.GetCell(nroColumna).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("0.00");
                    row.GetCell(nroColumna).CellStyle.SetFont(font);
                    row.GetCell(nroColumna++).SetCellValue(0.12);
                }

                #region rediminesionando las columnas
                int numberOfColumns = sheet.GetRow(nroColumna - 1).PhysicalNumberOfCells;
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

                string filePath = "../../Salida/mi_archivo.xlsx";
                File.WriteAllBytes(filePath, bytes);

                /*
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    wb.Write(fs);
                }
                */
                linkLabel1.Text = Path.GetFullPath(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = linkLabel1.Text;

            try
            {
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}