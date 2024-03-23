﻿// <auto-generated />
using System;
using Dev_space.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dev_space.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240323192242_myMigratoin")]
    partial class myMigratoin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AccountTag", b =>
                {
                    b.Property<int>("AccountsId")
                        .HasColumnType("int");

                    b.Property<int>("tagsId")
                        .HasColumnType("int");

                    b.HasKey("AccountsId", "tagsId");

                    b.HasIndex("tagsId");

                    b.ToTable("AccountTag");
                });

            modelBuilder.Entity("Dev_space.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("Dev_space.Models.Code", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("postId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("postId");

                    b.ToTable("Code");
                });

            modelBuilder.Entity("Dev_space.Models.Commint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("accountId")
                        .HasColumnType("int");

                    b.Property<int?>("postId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("accountId");

                    b.HasIndex("postId");

                    b.ToTable("Commint");
                });

            modelBuilder.Entity("Dev_space.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int>("IdFriend")
                        .HasColumnType("int");

                    b.Property<int>("accountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("accountId");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("Dev_space.Models.Img", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<string>("pathImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("postId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("postId");

                    b.ToTable("Img");
                });

            modelBuilder.Entity("Dev_space.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("accountId")
                        .HasColumnType("int");

                    b.Property<int?>("postId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("accountId");

                    b.HasIndex("postId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("Dev_space.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("accountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("accountId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("Dev_space.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("Dev_space.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("int");

                    b.Property<int>("tagsId")
                        .HasColumnType("int");

                    b.HasKey("PostsId", "tagsId");

                    b.HasIndex("tagsId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("AccountTag", b =>
                {
                    b.HasOne("Dev_space.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dev_space.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("tagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dev_space.Models.Code", b =>
                {
                    b.HasOne("Dev_space.Models.Post", "post")
                        .WithMany("Codes")
                        .HasForeignKey("postId");

                    b.Navigation("post");
                });

            modelBuilder.Entity("Dev_space.Models.Commint", b =>
                {
                    b.HasOne("Dev_space.Models.Account", "account")
                        .WithMany("commints")
                        .HasForeignKey("accountId");

                    b.HasOne("Dev_space.Models.Post", "post")
                        .WithMany("commints")
                        .HasForeignKey("postId");

                    b.Navigation("account");

                    b.Navigation("post");
                });

            modelBuilder.Entity("Dev_space.Models.Friend", b =>
                {
                    b.HasOne("Dev_space.Models.Account", "account")
                        .WithMany("friends")
                        .HasForeignKey("accountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("Dev_space.Models.Img", b =>
                {
                    b.HasOne("Dev_space.Models.Post", "post")
                        .WithMany("Imgs")
                        .HasForeignKey("postId");

                    b.Navigation("post");
                });

            modelBuilder.Entity("Dev_space.Models.Like", b =>
                {
                    b.HasOne("Dev_space.Models.Account", "account")
                        .WithMany("likes")
                        .HasForeignKey("accountId");

                    b.HasOne("Dev_space.Models.Post", "post")
                        .WithMany("likes")
                        .HasForeignKey("postId");

                    b.Navigation("account");

                    b.Navigation("post");
                });

            modelBuilder.Entity("Dev_space.Models.Link", b =>
                {
                    b.HasOne("Dev_space.Models.Account", "account")
                        .WithMany("links")
                        .HasForeignKey("accountId");

                    b.Navigation("account");
                });

            modelBuilder.Entity("Dev_space.Models.Post", b =>
                {
                    b.HasOne("Dev_space.Models.Account", "Account")
                        .WithMany("posts")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("Dev_space.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dev_space.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("tagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dev_space.Models.Account", b =>
                {
                    b.Navigation("commints");

                    b.Navigation("friends");

                    b.Navigation("likes");

                    b.Navigation("links");

                    b.Navigation("posts");
                });

            modelBuilder.Entity("Dev_space.Models.Post", b =>
                {
                    b.Navigation("Codes");

                    b.Navigation("Imgs");

                    b.Navigation("commints");

                    b.Navigation("likes");
                });
#pragma warning restore 612, 618
        }
    }
}
