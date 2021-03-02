﻿// <auto-generated />
using System;
using DotnetCoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotnetCoreApi.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20210302021519_add_table_Relation")]
    partial class add_table_Relation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DotnetCoreApi.Models.GangJingAnZhuang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GangJingChangDuPc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GangJingChangDuSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GangJingChangDuSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GaoChengPc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GaoChengSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GaoChengSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuJiaWaiJingPc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuJiaWaiJingSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuJiaWaiJingSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouDuPc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouDuSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouDuSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KuJingPc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KuJingSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KuJingSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableHeadId")
                        .HasColumnType("int");

                    b.Property<string>("ZhuJingJianJuPc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZhuJingJianJuSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZhuJingJianJuSj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GangJingAnZhuang");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.GanttLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Source")
                        .HasColumnType("int");

                    b.Property<int>("Target")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GanttLine");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.GanttTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<int>("Parent")
                        .HasColumnType("int");

                    b.Property<decimal>("Progress")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("GanttTask");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.Goods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GoodsType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.PostionTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Col")
                        .HasColumnType("int");

                    b.Property<int>("ColCount")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("RowCount")
                        .HasColumnType("int");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostionTemp");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("InstanceCount")
                        .HasColumnType("int");

                    b.Property<string>("TableDtoDataName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableDtoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Relation");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.ShuiNiHunLingTu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BanHouDuPc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BanHouDuSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BanHouDuSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DuanBanLv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GaoChaSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GaoChaSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShenDuSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShenDuSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShunZhiDuSc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShunZhiDuSj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableHeadId")
                        .HasColumnType("int");

                    b.Property<string>("XiShu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShuiNiHunLingTu");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.TableHead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CBDW")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLandscape")
                        .HasColumnType("bit");

                    b.Property<string>("JLDW")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignRecord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignReview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableType")
                        .HasColumnType("int");

                    b.Property<string>("WorkPart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TableHead");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.TodoItems", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("DotnetCoreApi.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
