﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(SIPlatformDbContext))]
    [Migration("20180609200804_Transactions")]
    partial class Transactions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Idea", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<double>("Fullfillment");

                    b.Property<DateTime>("StartFundingDate");

                    b.Property<int>("Status");

                    b.Property<DateTime>("StopFundingDate");

                    b.Property<double>("Target");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("IdeaId");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Idea", b =>
                {
                    b.HasOne("Domain.Entities.User", "Author")
                        .WithMany("Ideas")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Domain.Entities.Idea", "Idea")
                        .WithMany("Transactions")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
