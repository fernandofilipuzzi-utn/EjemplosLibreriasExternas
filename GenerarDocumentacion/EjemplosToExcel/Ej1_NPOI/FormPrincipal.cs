using Ej1_NPOI.Models;
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
            try
            { 
                GenerarExcelNPOI gen = new GenerarExcelNPOI();
                byte [] bytes=gen.GenerarExcelXlsx();

                string filePath = "../../Salida/mi_archivo.xlsx";
                File.WriteAllBytes(filePath, bytes);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarExcelNPOI gen = new GenerarExcelNPOI();
                byte[] bytes = gen.GenerarExcelXls();

                string filePath = "../../Salida/mi_archivo.xls";
                File.WriteAllBytes(filePath, bytes);

                linkLabel1.Text = Path.GetFullPath(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}