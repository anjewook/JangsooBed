using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ArchFx.Excel
{
    public class ArchExcelDB
    {
        public bool isUseHeader = false;

        //엑셀읽기
        public string Main()
        {
            //DataSet ds = null;
            string fileName = "d:\\test.xlsx";

            OleDbCtrl.ConnMode connMode = new OleDbCtrl.ConnMode();
            OleDbCtrl oleDbCtrl = new OleDbCtrl(connMode, true, fileName);

            string strQuery = "";
            string excelSheetName = @"Sheet1";

            strQuery = "SELECT * FROM [" + excelSheetName + "$]";

            DataSet dataSet = oleDbCtrl.GetData(strQuery);

            DataTable dataTable = dataSet.Tables[0];  // DataSet에서 DataTable을 가져옴

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];  // DataTable에서 DataRow을 가져옴.
                //if (dataRow["상위코드"].ToString() == "AC003000")
                //{
                //strQuery = String.Format("UPDATE [{0}${1}:{2}] SET 비고 = '{3}'", excelSheetName,"A6","E6", "BBBB");
                //}
            }

            strQuery = String.Format("UPDATE [Sheet1$E5] SET 비고 = 'HHHHH'");

            oleDbCtrl.ExecuteNoneQuery(strQuery);

            return "s";

        }

        //엑셀저장

    }
}
