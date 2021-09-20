using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Kulala.Learning.WebApp.Utility.CustomResult
{
    public class XmlResult : ActionResult
    {
        private object _data = null;
        public XmlResult(object data)
        {
            this._data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;

            var serializer = new XmlSerializer(_data.GetType());
            response.ContentType = "text/xml";
            serializer.Serialize(response.Output, _data);


        }
    }
}