using Ej1.Models;
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


namespace Ej1
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
                new Persona{ Dni=40122312,Nombre="Juan", Nacimiento=new DateTime(2000,08,23)},
                new Persona{ Dni=23142512,Nombre="Giuliana", Nacimiento=new DateTime(2000,12,12) },
                new Persona{ Dni=36322312,Nombre="Regina", Nacimiento=new DateTime(1995,1,12) }
            };

            IWorkbook wb = new XSSFWorkbook();
            var sheet = wb.CreateSheet("hoja 1");

            ICellStyle style = wb.CreateCellStyle();

            # region fuente Set font style
            IFont font = wb.CreateFont();
            font.FontName = "Arial";
            font.FontHeightInPoints = 10;
            #endregion

            int nroFila = 0;

            #region cabecera
            IRow headerRow = sheet.CreateRow(nroFila);

            int nroColumna = 0;

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("DNI");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(font);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("NOMBRE");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(font);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("FECHA NACIMIENTO");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(font);

            headerRow.CreateCell(nroColumna);
            headerRow.GetCell(nroColumna).SetCellValue("HORA NACIMIENTO");
            headerRow.GetCell(nroColumna++).CellStyle.SetFont(font);
            #endregion

            
            foreach (Persona p in personas)
            {
                var row= sheet.CreateRow(++nroFila);
                nroColumna = 0;
                //
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("#");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(p.Dni);
                //
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.String);
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue(p.Nombre);
                //
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).CellStyle = wb.CreateCellStyle();
                row.GetCell(nroColumna).CellStyle.DataFormat=HSSFDataFormat.GetBuiltinFormat("dd/mm/yyyy");
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:d/M/yyyy}");
                //
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.String);
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna++).SetCellValue($"{p.Nacimiento:HH:mm:ss}");
                //
                row.CreateCell(nroColumna);
                row.GetCell(nroColumna).SetCellType(CellType.Numeric);
                row.GetCell(nroColumna).CellStyle.SetFont(font);
                row.GetCell(nroColumna).CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("#,#0.00");
                row.GetCell(nroColumna++).SetCellValue(0.12);
            }
           
            byte[] bytes = new byte[0];
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                bytes = ms.ToArray();
            }

            string filePath = "mi_archivo.xlsx";
            File.WriteAllBytes(filePath, bytes);

            /*
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                wb.Write(fs);
            }
            */
        }
    }
}