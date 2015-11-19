using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace ArchFx.Excel
{
    public class OleDbCtrl
    {
        public enum ConnMode { Write = 0, Read = 1, Linked = 2 }

        public bool bIsHasHeaders = false;
        public ConnMode enConnMode = ConnMode.Read;

        OleDbConnection conn;
        OleDbCommand comm;
        OleDbDataAdapter ad;

        public OleDbCtrl(ConnMode enConnMode, bool bIsHasHeaders, string strFileName)
        {
            this.enConnMode = enConnMode;
            this.bIsHasHeaders = bIsHasHeaders;

            string strConn = ExcelConnection(strFileName);

            if (String.IsNullOrEmpty(strConn) == true)
            {
                throw new Exception("NeoFX : Excel 형식이 아닙니다.");
            }
            else
            {
                conn = new OleDbConnection(strConn);
                comm = new OleDbCommand("", conn);
                ad = new OleDbDataAdapter(comm);
            }
        }

        public int ExecuteNoneQuery(string strQuery)
        {
            int nResultCount = 0;

            comm.CommandType = CommandType.Text;
            comm.CommandText = strQuery;

            conn.Open();
            try
            {
                nResultCount = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();

                throw ex;
            }

            return nResultCount;
        }

        public DataSet GetData(string strQuery)
        {
            comm.CommandType = CommandType.Text;
            comm.CommandText = strQuery;

            DataSet ds = new DataSet();
            ad.Fill(ds);

            return ds;
        }

        private string ExcelConnection(string strFileName)
        {
            string strExtension = System.IO.Path.GetExtension(strFileName).ToUpper();

            if (strExtension == ".XLS")
            {
                return
                  @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                  @"Data Source=" + strFileName + ";" +
                  @"Extended Properties=" + Convert.ToChar(34).ToString() +
                  @"Excel 8.0;" + ExcelConnectionOptions() + Convert.ToChar(34).ToString();
            }
            else if (strExtension == ".XLSX")
            {
                return
                @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=" + strFileName + ";" +
                @"Extended Properties=" + Convert.ToChar(34).ToString() +
                @"Excel 12.0;" + ExcelConnectionOptions() + Convert.ToChar(34).ToString();
            }
            else
            {
                return null;
            }
        }

        private string ExcelConnectionOptions()
        {
            int imex = (int)this.enConnMode;

            string strOpts = "Imex=" + imex + ";";
            if (this.bIsHasHeaders)
            {
                strOpts += "HDR=Yes;";
            }
            else
            {
                strOpts += "HDR=No;";
            }
            return strOpts;
        }

    }
}
