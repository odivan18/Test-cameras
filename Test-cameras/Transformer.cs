using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace Test_cameras
{
    class Transformer
    {
        public async Task<string> HttpResponseToString(HttpResponseMessage httpResponse, CancellationToken cancelToken)
        {
            if (httpResponse == null)
            {
                throw new Exception("Попытка преобразоания пустого ответа в строку");
            }

            return await httpResponse.Content.ReadAsStringAsync(cancelToken);
        }

        public XmlDocument ResponseStringToXmlDocument(string response)
        {
            if (response == null)
            {
                throw new Exception("Попытка преобразоания пустой строки в xmlDoc");
            }

            var xDoc = new XmlDocument();
            xDoc.LoadXml(response);

            return xDoc;
        }

        public List<Camera> XmlDocToCameraList(XmlDocument xmlDoc)
        {
            if (xmlDoc == null)
            {
                throw new Exception("Попытка преобразования пустого xmlDoc в список камер");
            }

            var cameras = new List<Camera>();

            //парс хмл
            XmlElement xmlRoot = xmlDoc.DocumentElement;
            if (xmlRoot != null)
            {
                foreach (XmlElement xmlNode in xmlRoot)
                {
                    var tempCam = new Camera();

                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == "ID")
                        {
                            tempCam.id = childNode.InnerText;
                        }
                        if (childNode.Name == "Name")
                        {
                            tempCam.name = childNode.InnerText;
                        }
                    }

                    cameras.Add(tempCam);
                }
            }

            return cameras;
        }

        public async Task<List<Camera>> HttpResponseToCameraList(HttpResponseMessage httpResponse, CancellationToken cancelToken)
        {
            return XmlDocToCameraList(ResponseStringToXmlDocument(await HttpResponseToString(httpResponse, cancelToken)));
        }


    }
}
