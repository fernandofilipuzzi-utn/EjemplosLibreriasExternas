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

            #region cabecera
            IRow headerRow = sheet.CreateRow(0);

            headerRow.CreateCell(0);
            headerRow.GetCell(0).SetCellValue("DNI");
            headerRow.GetCell(0).CellStyle.SetFont(font);

            headerRow.CreateCell(1);
            headerRow.GetCell(1).SetCellValue("NOMBRE");
            headerRow.GetCell(1).CellStyle.SetFont(font);

            headerRow.CreateCell(2);
            headerRow.GetCell(2).SetCellValue("FECHA NACIMIENTO");
            headerRow.GetCell(2).CellStyle.SetFont(font);

            headerRow.CreateCell(3);
            headerRow.GetCell(3).SetCellValue("HORA NACIMIENTO");
            headerRow.GetCell(3).CellStyle.SetFont(font);
            #endregion

            int n = 1;
            foreach (Persona p in personas)
            {
                var row= sheet.CreateRow(n++);

                //
                row.CreateCell(0);
                row.GetCell(0).CellStyle = wb.CreateCellStyle();
                row.GetCell(0).CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("#.###.###");                    
                row.GetCell(0).SetCellType(CellType.Numeric);
                row.GetCell(0).CellStyle.SetFont(font);
                //
                row.CreateCell(1);
                row.GetCell(1).SetCellType(CellType.String);
                row.GetCell(1).CellStyle.SetFont(font);
                //
                row.CreateCell(2);
                row.GetCell(2).CellStyle.DataFormat = wb.CreateDataFormat().GetFormat("d/m/y");                
                row.GetCell(2).CellStyle.SetFont(font);
                //
                row.CreateCell(3);
                row.GetCell(3).SetCellType(CellType.String);
                row.GetCell(3).CellStyle.SetFont(font);

                //
                row.GetCell(0).SetCellValue(p.Dni);

                row.GetCell(1).SetCellValue(p.Nombre);

                row.GetCell(2).SetCellValue(p.Nacimiento);

                row.GetCell(3).SetCellValue($"{p.Nacimiento:HH:mm:ss}");
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