﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Api.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBlog.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240108141947_Initial migration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyBlog.Api.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ArticleId"));

                    b.Property<string>("BookCover")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("MyNote")
                        .HasColumnType("real");

                    b.Property<List<string>>("Quotes")
                        .HasColumnType("text[]");

                    b.Property<string>("ReviewResume")
                        .HasColumnType("text");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.Property<string>("TextSection")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ArticleId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            ArticleId = 1,
                            BookCover = "dddd",
                            MyNote = 5f,
                            Quotes = new List<string> { "dfgdfg", "dfgdfg" },
                            ReviewResume = "ikjfgdnf",
                            TagId = 1,
                            TextSection = "hfdgbhgdf dfgihdfg"
                        },
                        new
                        {
                            ArticleId = 2,
                            BookCover = "ddddghg",
                            MyNote = 4f,
                            Quotes = new List<string> { "dfgdfffg", "dfgdfgff" },
                            ReviewResume = "ikjfgddgnf",
                            TagId = 1,
                            TextSection = "hfhgdgbhgdf dfgihdfg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
