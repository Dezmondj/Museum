﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MuseumData;

#nullable disable

namespace MuseumData.Migrations
{
    [DbContext(typeof(MuseumDBContext))]
    partial class MuseumDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MuseumDomain.Exhibit", b =>
                {
                    b.Property<int>("ExhibitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExhibitID"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HallID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage_conditions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExhibitID");

                    b.HasIndex("HallID");

                    b.ToTable("Exhibits");
                });

            modelBuilder.Entity("MuseumDomain.Hall", b =>
                {
                    b.Property<int>("HallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HallID"));

                    b.Property<string>("Adress_of_museum")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count_of_exhibit")
                        .HasColumnType("int");

                    b.Property<string>("Type_of_hall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HallID");

                    b.HasIndex("Adress_of_museum");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("MuseumDomain.Museum", b =>
                {
                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count_of_employees")
                        .HasColumnType("int");

                    b.Property<int>("Count_of_exhibit")
                        .HasColumnType("int");

                    b.Property<int>("Count_of_hall")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Adress");

                    b.HasAlternateKey("Name");

                    b.ToTable("Museums");
                });

            modelBuilder.Entity("MuseumDomain.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MuseumDomain.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketID"));

                    b.Property<string>("Adress_of_museum")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerID")
                        .HasColumnType("int");

                    b.HasKey("TicketID");

                    b.HasIndex("Adress_of_museum");

                    b.HasIndex("ClientID");

                    b.HasIndex("WorkerID");

                    b.ToTable("Tickects");
                });

            modelBuilder.Entity("MuseumDomain.Client", b =>
                {
                    b.HasBaseType("MuseumDomain.Person");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("MuseumDomain.Worker", b =>
                {
                    b.HasBaseType("MuseumDomain.Person");

                    b.Property<string>("Adress_of_museum")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mobile_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Staff");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasIndex("Adress_of_museum");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CH_Salary", "Salary > 14999");
                        });

                    b.HasDiscriminator().HasValue("Worker");
                });

            modelBuilder.Entity("MuseumDomain.Exhibit", b =>
                {
                    b.HasOne("MuseumDomain.Hall", "Hall")
                        .WithMany("Exhibits")
                        .HasForeignKey("HallID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("MuseumDomain.Hall", b =>
                {
                    b.HasOne("MuseumDomain.Museum", "Museum")
                        .WithMany("Halls")
                        .HasForeignKey("Adress_of_museum")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("MuseumDomain.Ticket", b =>
                {
                    b.HasOne("MuseumDomain.Museum", "Museum")
                        .WithMany("Tickets")
                        .HasForeignKey("Adress_of_museum")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MuseumDomain.Client", "Client")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MuseumDomain.Worker", "Worker")
                        .WithMany("Tickets")
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Museum");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("MuseumDomain.Worker", b =>
                {
                    b.HasOne("MuseumDomain.Museum", "Museum")
                        .WithMany("Workers")
                        .HasForeignKey("Adress_of_museum")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("MuseumDomain.Hall", b =>
                {
                    b.Navigation("Exhibits");
                });

            modelBuilder.Entity("MuseumDomain.Museum", b =>
                {
                    b.Navigation("Halls");

                    b.Navigation("Tickets");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("MuseumDomain.Client", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MuseumDomain.Worker", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
