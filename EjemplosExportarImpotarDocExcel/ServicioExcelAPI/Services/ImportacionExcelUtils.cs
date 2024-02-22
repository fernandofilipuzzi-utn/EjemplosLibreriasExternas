using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Services
{
    public class ImportacionExcelUtils
    {
        public enum COL { A=0,B,C,D,E,F,G,H,I,J,K };
        public enum TipoFormato { XLS, XLSX }

        static public string GetMimeType(TipoFormato formato)
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
    }
}