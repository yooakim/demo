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

            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;

            try
            {
                var result = processes.Select(p =>
                  new
                  {
                      p.Id,
                      p.MachineName,
                      p.ProcessName,
                      p.WorkingSet64,
                      Environment.WorkingSet,
                      Environment.ProcessorCount,
                      osNameAndVersion,
                      Environment.Version
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
        public dynamic Get(int id)
        {
            var process = Process.GetProcessById(id);
            if(process == null)
            {
                return NotFound();
            } else
            {
                return new {
                    process.Id,
                    process.ProcessName,
                    process.WorkingSet64,
                    process.VirtualMemorySize64,
                    process.PrivateMemorySize64,
                    Threads = process.Threads.Count
                };
            }
        }

    }
}
