﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vet02.App.Persistencia;

namespace Vet02.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210925051712_VetInicial")]
    partial class VetInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Vet02.App.Dominio.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<string>("HoraCita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMascota")
                        .HasColumnType("int");

                    b.Property<int>("IdVeterinario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Vet02.App.Dominio.Diagnostico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiagnosticoMascota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdHistoriaMedica")
                        .HasColumnType("int");

                    b.Property<string>("Recomendaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnosticos");
                });

            modelBuilder.Entity("Vet02.App.Dominio.HistoriaMedica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EstadoMascota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHClinica")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaviones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("Vet02.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("GeneroM")
                        .HasColumnType("int");

                    b.Property<int>("IdCuidador")
                        .HasColumnType("int");

                    b.Property<int>("IdHistoriaClinica")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoAnimal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Vet02.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDocumento")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Vet02.App.Dominio.Vacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaProduccion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMascota")
                        .HasColumnType("int");

                    b.Property<string>("Lote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Vet02.App.Dominio.Administrador", b =>
                {
                    b.HasBaseType("Vet02.App.Dominio.Persona");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("Vet02.App.Dominio.Cuidador", b =>
                {
                    b.HasBaseType("Vet02.App.Dominio.Persona");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Cuidador");
                });

            modelBuilder.Entity("Vet02.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("Vet02.App.Dominio.Persona");

                    b.Property<string>("Especializacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });
#pragma warning restore 612, 618
        }
    }
}
