using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/DoWork")]
    public class DoWorkController : Controller
    {


        // POST: api/DoWork
        [HttpPost]
        public async void PostAsync([FromBody] int duration = 20)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            await Task.Run(() => CpuIntensiveMulti(duration));
            watch.Stop();

        }

        void CpuIntensiveMulti(int duration = 10)
        {
            int pRange;
            if (Environment.ProcessorCount == 1)
            {
                pRange = 1;
            } else
            {
                pRange = Environment.ProcessorCount - 1;
            }
            Enumerable
                .Range(1, pRange) // replace with lesser number if 100% usage is not what you are after.
                .AsParallel()
                .Select(i =>
                {
                    var end = DateTime.Now + TimeSpan.FromSeconds(duration);
                    while (DateTime.Now < end)
                        /*nothing here */
                        ;
                    return i;
                })
                .ToList(); // ToList makes the query execute.
        }

    }
}
