using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basefarm.Demo.Web.Data;
using Basefarm.Demo.Web.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Basefarm.Demo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // https://octopus.com/docs/deploying-applications/deploying-asp.net-core-web-applications
            services.AddAntiforgery(opts => opts.Cookie.Name = "AntiForgery.Demo");
            services.AddDataProtection().SetApplicationName("Basefarm Demo Web");


            //services.AddDbContext<DiskContext>(opt => opt.UseSqlite("Data Source = demo.db"));
            services.AddDbContext<DiskContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Demo")));
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Demo API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            InitializeMigrations(app,false);

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API V1");
            });


            app.UseMvc();
        }

        private static void InitializeMigrations(IApplicationBuilder app, bool seedDataBase = false)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                DiskContext dbContext = serviceScope.ServiceProvider.GetRequiredService<DiskContext>();

                //dbContext.Database.EnsureCreated();
                //dbContext.Database.Migrate();

                if (seedDataBase)
                {

                    if(!dbContext.PSDrives.Any())
                    {
                        dbContext.PSDrives.AddRange(
                            new PSDrive
                            {
                                Id = 1,
                                HostName = System.Environment.MachineName,
                                Name = @"C:\",
                                Root = "C:\\",
                                Used = 351574278144,
                                Free = 647982886912
                            });
                    }
                    dbContext.SaveChanges();


                    //// TODO: Use dbContext if you want to do seeding etc.
                    //if (!dbContext.LogicalDisks.Any())
                    //{
                    //    dbContext.LogicalDisks.AddRange(
                    //        new LogicalDisk
                    //        {
                    //            Id = 1,
                    //            Name = "C:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "XPS9360R",
                    //            FreeSpace = 779430076416,
                    //            Size = 999557165056,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = false,
                    //            SupportsFileBasedCompression = true,
                    //            VolumeName = string.Empty,
                    //            VolumeSerialNumber = "D6F5CA93"
                    //        },
                    //        new LogicalDisk
                    //        {
                    //            Id = 2,
                    //            Name = "C:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "SRVFILES",
                    //            FreeSpace = 28058644480,
                    //            Size = 53317988352,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = true,
                    //            SupportsFileBasedCompression = true,
                    //            VolumeName = "",
                    //            VolumeSerialNumber = "BE083D09"
                    //        },
                    //        new LogicalDisk
                    //        {
                    //            Id = 3,
                    //            Name = "E:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "SRVFILES",
                    //            FreeSpace = 3103418286080,
                    //            Size = 3298397454336,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = true,
                    //            SupportsFileBasedCompression = false,
                    //            VolumeName = "office",
                    //            VolumeSerialNumber = "5004D410"
                    //        },
                    //        new LogicalDisk
                    //        {
                    //            Id = 4,
                    //            Name = "F:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "SRVSTOR",
                    //            FreeSpace = 24905971007488,
                    //            Size = 70368606748672,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = true,
                    //            SupportsFileBasedCompression = false,
                    //            VolumeName = "audio",
                    //            VolumeSerialNumber = "182DAEF9"
                    //        },
                    //        new LogicalDisk
                    //        {
                    //            Id = 5,
                    //            Name = "G:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "SRVFILES",
                    //            FreeSpace = 4487142572032,
                    //            Size = 5497421758464,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = true,
                    //            SupportsFileBasedCompression = false,
                    //            VolumeName = "video",
                    //            VolumeSerialNumber = "6E5EDF16"
                    //        },
                    //        new LogicalDisk
                    //        {
                    //            Id = 6,
                    //            Name = "I:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "SRVFILES",
                    //            FreeSpace = 752906055680,
                    //            Size = 1099375308800,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = true,
                    //            SupportsFileBasedCompression = true,
                    //            VolumeName = "dbBackups",
                    //            VolumeSerialNumber = "F0B5AD4B"
                    //        },
                    //        new LogicalDisk
                    //        {
                    //            Id = 7,
                    //            Name = "S:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "SRVFILES",
                    //            FreeSpace = 5497065574400,
                    //            Size = 5497421819904,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = true,
                    //            SupportsFileBasedCompression = true,
                    //            VolumeName = "video",
                    //            VolumeSerialNumber = "40355928"
                    //        },
                    //        new LogicalDisk
                    //        {
                    //            Id = 8,
                    //            Name = "Y:",
                    //            Description = "Local Fixed Disk",
                    //            SystemName = "SRVFILES",
                    //            FreeSpace = 5154517942272,
                    //            Size = 5497421758464,
                    //            Compressed = false,
                    //            DriveType = 3,
                    //            FileSystem = "NTFS",
                    //            MaximumComponentLength = 255,
                    //            MediaType = 12,
                    //            SupportsDiskQuotas = true,
                    //            SupportsFileBasedCompression = false,
                    //            VolumeName = "graphics",
                    //            VolumeSerialNumber = "6F5EBF16"
                    //        }
                    //    );
                    //    dbContext.SaveChanges();

                    //}
                }

            }
        }
    }
}
