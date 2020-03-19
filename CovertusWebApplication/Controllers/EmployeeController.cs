using CovertusWebApplication.Common;
using Newtonsoft.Json;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CovertusWebApplication.Controllers
{
    [RoutePrefix("Covert/Emp")]
    public class EmployeeController : BaseAPIController
    {
        public EmployeeController() { }

        [Route("all"), HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetAllEmployees()
        {
            string ServResponse = null;
            List<object> custtiers = new List<object>();    
            ServiceManager serv = new ServiceManager();
            try
            {
                ServResponse = serv.getServResponse("sample/employee");
                custtiers = JsonConvert.DeserializeObject<List<object>>(ServResponse);
                if (custtiers != null)
                {
                    return Ok(custtiers);
                }
                else
                    return Ok(new HttpError(string.Format("No Records Found..!")));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Route("tableOrder"), HttpPost]
        [EnableCors(origins:"*", headers:"*", methods:"*")]
        public IHttpActionResult UpdateTableOrder(List<EmployeeViewModel> employee)
        {
            ServiceManager serv = new ServiceManager();
            try
            {
                if (employee != null)
                {
                    var ServResponse = serv.postRequest("sample/OrderRows/", employee);

                    return Ok(ServResponse);
                }
                else
                    return BadRequest();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
