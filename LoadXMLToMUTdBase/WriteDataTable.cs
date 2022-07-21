using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Microsoft.Data.SqlXml;


namespace xmlparse
{
    class WriteDataTable
    {
        public void DataLoad(string[] args)
        {
            try
            {
                string sPath = @"C:\MUTSW_SE\MUT3_SE\Temp\";

                string FileName, xmlPath, xsdPath;
                FileName = "Vehicle";

                xmlPath = sPath + FileName + ".xml";
                xsdPath = sPath + FileName + ".xsd";

                SQLXMLBULKLOADLib.SQLXMLBulkLoad4 objBL = new SQLXMLBULKLOADLib.SQLXMLBulkLoad4();
                objBL.ConnectionString = @"Provider=sqloledb; server=127.0.0.1\CAESARCOMPDB;database=CAESARCOMPDB2;User ID=CAESAR-DB;Password=CAESAR;Connection Timeout=60";

                objBL.SchemaGen = true;
                //objBL.XMLFragment = true;
                //objBL.BulkLoad = false;
                //objBL.SGUseID = true;
                //objBL.SGDropTables = true;
                objBL.ErrorLogFile = "error.xml";
                //objBL.KeepIdentity = true;

                objBL.Execute(xsdPath, xmlPath);
                //objBL.Execute(xmlPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }
            Console.Read();
        }
    }
}
