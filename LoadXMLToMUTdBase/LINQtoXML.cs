using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Microsoft.Win32;
using System.Xml.Linq;

namespace LoadXMLToMUTdBase
{
    class LINQtoXML
    {
        public void SelectDataXML()
        {
            var openDlg = new OpenFileDialog { Filter = "Text Files |*.xml" };
            //Был ли клик на кнопке ОК
            if (true == openDlg.ShowDialog())
            {
                /*XElement dataXMLFile = XElement.Load(openDlg.FileName);
                IEnumerable<XElement> DataXml = from stringFrom in dataXMLFile.Elements(Data.stringIn) where (string)stringFrom.Attribute(Data.stringWhere) == Data.stringBool select stringFrom;
                foreach (XElement stringFrom in DataXml)
                {
                    Data.SendConvData = (string) (stringFrom);
                }*/
                 /*var dataXMLFile = File.ReadAllLines(openDlg.FileName);
                 //var DataXml = from stringFrom in dataXMLFile where Data.stringWhere == Data.stringBool select stringFrom;
                 var DataXml = from stringFrom in dataXMLFile where stringFrom.Contains(Data.stringWhere) select stringFrom;
                foreach (string stringFrom in DataXml)
                 {
                     Data.SendXMLData = (string)(stringFrom);
                 }*/

               XDocument dataXMLFile = XDocument.Load(openDlg.FileName);
               IEnumerable<XElement> DataXml = from stringFrom in dataXMLFile.Elements() select stringFrom;;
               foreach (XElement stringFrom in DataXml)
               {
                   Data.SendXMLData = (string)(stringFrom);
               }
                
            }
            else return;
        }
    }
}
