using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CovertusWebApplication.Controllers
{
    public class FileUploadController : ApiController
    {
        [Route("fileUpload")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UploadFile(UploadData jsonData)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var httpRequest = HttpContext.Current.Request;

                var documentFilePath = "";
                if (jsonData.fileName != null)
                {
                    if (jsonData.fileName.Length < 50)
                    {
                        if (jsonData.fileName != "")
                        {
                            documentFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile/" + jsonData.fileName));
                            System.IO.Directory.CreateDirectory(documentFilePath);
                            FileInfo oFileInfo = new FileInfo(documentFilePath);
                            jsonData.Attachment = System.IO.File.ReadAllBytes(documentFilePath);
                        }
                    }
                    //foreach(string file in httpRequest.Files)
                    //{
                    //    var postedFile = httpRequest.Files[file];
                    //    data.File_Name = Path.GetFileNameWithoutExtension(postedFile.FileName);
                    //    data.File_Extn = Path.GetExtension(postedFile.FileName);
                    //    if (!Directory.Exists(ESMFilepath))
                    //    {
                    //        Directory.CreateDirectory(ESMFilepath);
                    //    }
                    //    var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + data.File_Name + data.File_Extn);

                    //    postedFile.SaveAs(ESMFilepath + postedFile.FileName);
                    //}
                }
                return Ok();
            }
            catch (Exception ex)
            {
                jsonData.fileName = ex.Message;
                File.AppendAllText(HttpContext.Current.Server.MapPath("~/UploadFile/error.txt"), jsonData.fileName);
            }
            return Ok(jsonData.fileName);
        }

        [HttpPost]
        [Route("api/uploadattachment")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UploadAttachment()
        {
            string fileName = "", fextn = "";

            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var httpRequest = HttpContext.Current.Request;

                string ESMFilepath = ConfigurationManager.AppSettings["ESMFilepath"].ToString();
                var postedFile1 = httpRequest.Files["xlsx"];

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file1 in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file1];


                        fileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
                        fextn = Path.GetExtension(postedFile.FileName);
                        if (!Directory.Exists(ESMFilepath))
                        {
                            Directory.CreateDirectory(ESMFilepath);
                        }
                        var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + fileName + fextn);

                        postedFile.SaveAs(ESMFilepath + postedFile.FileName);
                    }
                }
            }
            catch (Exception err)
            {
                fileName = err.Message;
                File.AppendAllText(HttpContext.Current.Server.MapPath("~/UploadFile/error.txt"), fileName);
            }
            return Ok(fileName);


        }
        //    public async Task<HttpResponseMessage> PostFormData()
        //    {
        //        if(!Request.Content.IsMimeMultipartContent())
        //        {
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //        }
        //        string root = HttpContext.Current.Server.MapPath("~/UploadFile");
        //        var provider = new MultipartFormDataStreamProvider(root);
        //        var task = Request.Content.ReadAsMultipartAsync(provider).
        //            ContinueWith<HttpResponseMessage>(t =>
        //            {
        //                if (t.IsFaulted || t.IsCanceled)
        //                {
        //                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);

        //                }
        //                foreach (MultipartFileData file in provider.FileData)
        //                {
        //                    Console.WriteLine(file.Headers.ContentDisposition.FileName);
        //                    Console.WriteLine("Server file path: " + file.LocalFileName);
        //                }
        //                return Request.CreateResponse(HttpStatusCode.OK);
        //            });
        //        return task;
        //    }
        }
    


    public class UploadData
    {
        public string name { get; set; }
        public string email { get; set; }
        public string fileName { get; set; }
        public byte[] Attachment { get; set; }

    }
}
