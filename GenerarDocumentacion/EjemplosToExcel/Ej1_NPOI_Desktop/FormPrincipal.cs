using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using NPOI_excel_ClassLib;
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

using NPOI_excel_ClassLib;
using EPPlus_excel_ClassLib;

namespace Ej1_NPOI_Desktop
{
    public partial class FormPrincipal : Form
    {
        string pathExcel;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {


        }

        private void btnNPOI_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarExcelNPOI generador = new GenerarExcelNPOI();
                byte[] bytes = new byte[0];
                string mimeType = "";
                if (comboBox1.SelectedIndex == 0)
                {

                    bytes = generador.GenerarExcel(GenerarExcelNPOI.TipoFormato.XLS);
                    pathExcel = Path.GetFullPath("../../Salida/mi_archivo.xls");
                }
                else
                {
                    bytes = generador.GenerarExcel(GenerarExcelNPOI.TipoFormato.XLSX);
                    pathExcel = Path.GetFullPath("../../Salida/mi_archivo.xlsx");
                }
                               
                File.WriteAllBytes(pathExcel, bytes);
                linkLabel1.Text = Path.GetFileName(pathExcel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (File.Exists(pathExcel))
                {
                    //System.Diagnostics.Process.Start(pathExcel);
                    System.Diagnostics.Process.Start(pathExcel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEPPlus_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarExcelEPlus generador = new GenerarExcelEPlus();
                byte[] bytes = generador.Generar();
                pathExcel = Path.GetFullPath("../../Salida/mi_archivo.xlsx");

                File.WriteAllBytes(pathExcel, bytes);
                linkLabel1.Text = Path.GetFileName(pathExcel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                btnNPOI.Enabled = true;
                btnEPPlus.Enabled = false;
            }
            else
            {
                btnNPOI.Enabled = true;
                btnEPPlus.Enabled = true;
            }
        }
    }
}