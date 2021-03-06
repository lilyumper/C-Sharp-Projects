﻿// <auto-generated />
using Banker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Banker.Migrations
{
    [DbContext(typeof(BankerContext))]
    [Migration("20180516205607_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Banker.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("amount");

                    b.Property<int>("userid");

                    b.HasKey("Id");

                    b.HasIndex("userid");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Banker.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("balance");

                    b.Property<string>("email");

                    b.Property<string>("fname");

                    b.Property<string>("lname");

                    b.Property<string>("password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Banker.Models.Transaction", b =>
                {
                    b.HasOne("Banker.Models.User", "user")
                        .WithMany("transactions")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
