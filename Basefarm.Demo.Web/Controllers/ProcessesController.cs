using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Processes")]
    public class ProcessesController : Controller
    {
        // GET: api/Processes
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {

            IEnumerable<Process> processes = Process.GetProcesses();


            try
            {
                var result = processes.Select(p =>
                  new
                  {
                      p.Id,
                      p.MachineName,
                      p.ProcessName,
                      p.PagedMemorySize64,
                      p.PagedSystemMemorySize64,
                      p.PeakWorkingSet64,
                      p.PrivateMemorySize64,
                      p.WorkingSet64,
                      p.VirtualMemorySize64

                  });
                return result;
            }
            catch (Exception e)
            {

                throw new Exception("{0}",e.InnerException);
            }

           
        }

        // GET: api/Processes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Processes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Processes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
