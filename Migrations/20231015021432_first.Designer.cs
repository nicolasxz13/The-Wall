﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using The_Wall.Data;

#nullable disable

namespace The_Wall.Migrations
{
    [DbContext(typeof(LoginContext))]
    [Migration("20231015021432_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("The_Wall.Models.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("commentText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("userCommentId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("MessageId");

                    b.HasIndex("userCommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("The_Wall.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("userMessageId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("userMessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("The_Wall.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("The_Wall.Models.Comments", b =>
                {
                    b.HasOne("The_Wall.Models.Message", "message")
                        .WithMany("comments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("The_Wall.Models.User", "userComment")
                        .WithMany("Comments")
                        .HasForeignKey("userCommentId");

                    b.Navigation("message");

                    b.Navigation("userComment");
                });

            modelBuilder.Entity("The_Wall.Models.Message", b =>
                {
                    b.HasOne("The_Wall.Models.User", "userMessage")
                        .WithMany("Messages")
                        .HasForeignKey("userMessageId");

                    b.Navigation("userMessage");
                });

            modelBuilder.Entity("The_Wall.Models.Message", b =>
                {
                    b.Navigation("comments");
                });

            modelBuilder.Entity("The_Wall.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
