using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Utility.CustomResult
{
    public class NewtonJsonResult : ActionResult
    {
        private object _data = null;
        public NewtonJsonResult(object data)
        {
            this._data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
			if (this._data != null)
			{
				response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(this._data));
			}
        }
    }
}