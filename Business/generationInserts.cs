using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Business
{
    public class generationInserts
    {
        public static List<string> InsertsFromQuery(DataTable dtOrigem, string tabelaDestino)
        {
            string INSERT_TEMPLATE = "INSERT INTO {0} ({1}) VALUES ({2})";
            Application.DoEvents();
            if (dtOrigem == null) return null;
            object[] arrObj = null;
            int iAux = 0;
            List<string> lstInserts = new List<string>();

            try
            {
                if (dtOrigem.Rows.Count <= 0)
                    throw new Exception("Consulta origem não trouxe registros(1)");

                foreach (DataRow drLinha in dtOrigem.Rows)
                {
                    string strColumns = string.Empty;
                    string strValues = string.Empty;
                    string strDelete = string.Empty;

                    arrObj = drLinha.ItemArray;

                    for (int i = 0; i < arrObj.Length; i++)
                    {
                        if (arrObj[i].ToString() == "False")
                            arrObj[i] = "0";
                        else if (arrObj[i].ToString() == "True")
                            arrObj[i] = "1";

                        if (strColumns == "" || strColumns == string.Empty)
                            strColumns = dtOrigem.Columns[i].ColumnName;
                        else
                            strColumns += string.Format(",{0}", dtOrigem.Columns[i].ColumnName);

                        if (strValues == "" || strValues == string.Empty)
                            strValues = formatSQLValueInsert(dtOrigem.Columns[i], arrObj[i].ToString().Trim());
                        else
                            strValues += string.Format(",{0}", formatSQLValueInsert(dtOrigem.Columns[i], arrObj[i].ToString().Trim()));
                    }

                    lstInserts.Add(string.Format(INSERT_TEMPLATE, tabelaDestino, strColumns.Trim(), strValues.Trim()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstInserts;
        }

        public static string formatSQLValueInsert(DataColumn dr, string value)
        {
            Application.DoEvents();
            try
            {
                switch (dr.DataType.ToString())
                {
                    case "System.String":
                        value = string.Format("'{0}'", value.Replace("'", ""));
                        break;
                    case "System.DateTime":
                        if (!string.IsNullOrEmpty(value))
                            value = "'" + Convert.ToDateTime(value).ToString("yyyyMMdd") + "'";
                        else
                            value = "NULL";
                        break;
                    default:
                        value = (value == "" || value == string.Empty || value == null) ? "0" : value;
                        break;
                }

                return value.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
