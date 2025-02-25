﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using PBP.DataAccess.Context;

#nullable disable

namespace PBP.DataAccess.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20250225121959_AddContactChangeHistoryModel")]
partial class AddContactChangeHistoryModel
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "9.0.2")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("PBP.DataAccess.Models.Contact", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<DateTime?>("BirthDate")
                    .HasColumnType("Date");

                b.Property<int?>("ImageId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("ImageId");

                b.HasIndex("PhoneNumber")
                    .IsUnique();

                b.ToTable("Contact");
            });

        modelBuilder.Entity("PBP.DataAccess.Models.ContactChangeHistory", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<DateTime>("ChangedDate")
                    .HasColumnType("Date");

                b.Property<string>("ChangedTime")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("ContactId")
                    .HasColumnType("int");

                b.Property<int>("FieldName")
                    .HasColumnType("int");

                b.Property<byte[]>("NewImage")
                    .HasColumnType("varbinary(max)");

                b.Property<string>("NewValue")
                    .HasColumnType("nvarchar(max)");

                b.Property<byte[]>("OldImage")
                    .HasColumnType("varbinary(max)");

                b.Property<string>("OldValue")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("ContactId");

                b.ToTable("ContactChangeHistory");
            });

        modelBuilder.Entity("PBP.DataAccess.Models.Image", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<byte[]>("Data")
                    .IsRequired()
                    .HasColumnType("varbinary(max)");

                b.HasKey("Id");

                b.ToTable("Image");
            });

        modelBuilder.Entity("PBP.DataAccess.Models.Contact", b =>
            {
                b.HasOne("PBP.DataAccess.Models.Image", "Image")
                    .WithMany()
                    .HasForeignKey("ImageId");

                b.Navigation("Image");
            });

        modelBuilder.Entity("PBP.DataAccess.Models.ContactChangeHistory", b =>
            {
                b.HasOne("PBP.DataAccess.Models.Contact", "Contact")
                    .WithMany("ChangesHistory")
                    .HasForeignKey("ContactId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Contact");
            });

        modelBuilder.Entity("PBP.DataAccess.Models.Contact", b =>
            {
                b.Navigation("ChangesHistory");
            });
#pragma warning restore 612, 618
    }
}