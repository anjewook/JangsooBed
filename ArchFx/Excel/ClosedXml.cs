using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;

namespace ArchFx.Excel
{
    public class ClosedXml
    {
        public void Test()
        {
            XLWorkbook wb = new XLWorkbook("D:\\aaa.xlsx");
            wb.Worksheet("Sheet1").Cell(1, 5).Value = 3;
            wb.Worksheet("Sheet1").Cell(2, 5).Value = "BBB";
            wb.Worksheet("Sheet1").Cell(3, 5).SetValue("ASDASDASDASD");
            //wb.AddWorksheet("CCC");
            wb.SaveAs("D:\\bbb.xlsx");
            //wb.Save();
        }
    }
}
