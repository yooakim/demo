﻿// <auto-generated />
using Basefarm.Demo.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Web.Migrations
{
    [DbContext(typeof(DiskContext))]
    partial class DiskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Basefarm.Demo.Web.Entities.LogicalDisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Compressed");

                    b.Property<string>("Description");

                    b.Property<int>("DriveType");

                    b.Property<string>("FileSystem");

                    b.Property<long>("FreeSpace");

                    b.Property<int>("MaximumComponentLength");

                    b.Property<int>("MediaType");

                    b.Property<string>("Name");

                    b.Property<long>("Size");

                    b.Property<bool>("SupportsDiskQuotas");

                    b.Property<bool>("SupportsFileBasedCompression");

                    b.Property<string>("SystemName");

                    b.Property<bool>("VolumeDirty");

                    b.Property<string>("VolumeName");

                    b.Property<string>("VolumeSerialNumber");

                    b.HasKey("Id");

                    b.ToTable("LogicalDisks");
                });
#pragma warning restore 612, 618
        }
    }
}
