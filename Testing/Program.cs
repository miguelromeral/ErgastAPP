using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            /* RestService RestService = new RestService();
            string uri = "https://ergast.com/api/f1/seasons";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(args[0]);

            XslTransform xslTransform = new XslTransform();
            xslTransform.Load("mrd-1.4.xsl");


            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xslTransform.Transform(xmlDocument, null, xmlTextWriter);

            xmlTextWriter.Flush();
            Console.Write(stringWriter.ToString()); */
        }
    }
}
