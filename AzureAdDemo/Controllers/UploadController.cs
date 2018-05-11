using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AzureAdDemo.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Image()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;

                var base64imageString = httpRequest["image"];

                if (base64imageString != null)
                {
                    string filePath = HttpContext.Current.Server.MapPath("~/UserImage/" + Guid.NewGuid() + ".PNG");

                    File.WriteAllBytes(filePath, Convert.FromBase64String(base64imageString));

                    return Request.CreateErrorResponse(HttpStatusCode.Created, "Image Updated Successfully."); ;
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "Please Upload a image.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage DelImage([FromBody] string fileName)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/UserImage/" + fileName);

            if (File.Exists(filePath))
                try
                {
                    File.Delete(filePath);

                    return Request.CreateErrorResponse(HttpStatusCode.Created, "Image deleted Successfully."); ;

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }

            return Request.CreateResponse(HttpStatusCode.NotFound, "File not found");
        }
    }
}
