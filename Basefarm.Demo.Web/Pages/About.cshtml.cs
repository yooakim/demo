using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Basefarm.Demo.Web.Pages
{
    public class AboutModel : PageModel
    {
        public string container { get; set; }
        public string host { get; set; }
        public string os { get; set; }
        public string procs { get; set; }
        public string arch { get; set; }
        public string framework { get; set; }
        public string ip { get; set; }
        public string mem { get; set; }

        public Dictionary<string, string> envs = new Dictionary<string, string>();

        public void OnGet()
        {
            container = (System.IO.File.Exists(".insidedocker")) ? "Docker container" : "regular process";
            host = System.Environment.MachineName;
            os = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            procs = Environment.ProcessorCount.ToString();
            arch = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();
            framework = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            mem = (System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64 / (1024 * 1024 * 1024)).ToString();

            var httpConnectionFeature = HttpContext.Features.Get<IHttpConnectionFeature>();
            ip = httpConnectionFeature?.LocalIpAddress.ToString();

            // Harvest a few "interesting" environmental vars which may or may not be present
            var env = Environment.GetEnvironmentVariables().GetEnumerator();
            string[] interesting_envs = { "PROCESSOR_IDENTIFIER", "MACHTYPE", "DOTNET_VERSION", "HOSTTYPE", "PROCESSOR_ARCHITECTURE", "RELEASE" };
            while (env.MoveNext())
            {
                if (interesting_envs.Any(s => env.Key.ToString().Equals(s)))
                {
                    envs.Add(env.Key.ToString(), env.Value.ToString());
                }
            }

        }
    }
}
