﻿// <auto-generated />
using System;
using ChatApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChatApp.Data.Migrations
{
    [DbContext(typeof(ChatAppDbContext))]
    partial class ChatAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChatApp.Data.Entities.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            GroupName = "Random"
                        },
                        new
                        {
                            GroupId = 2,
                            GroupName = "General"
                        });
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.GroupMessage", b =>
                {
                    b.Property<int>("GroupMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupMessageId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.HasKey("GroupMessageId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SenderId");

                    b.ToTable("GroupMessages");

                    b.HasData(
                        new
                        {
                            GroupMessageId = 1,
                            DateTime = new DateTime(2024, 1, 1, 19, 50, 0, 0, DateTimeKind.Utc),
                            GroupId = 1,
                            Message = "Hello world",
                            SenderId = 1
                        },
                        new
                        {
                            GroupMessageId = 2,
                            DateTime = new DateTime(2024, 1, 1, 19, 11, 0, 0, DateTimeKind.Utc),
                            GroupId = 1,
                            Message = "Hello world",
                            SenderId = 2
                        },
                        new
                        {
                            GroupMessageId = 3,
                            DateTime = new DateTime(2024, 1, 1, 19, 51, 0, 0, DateTimeKind.Utc),
                            GroupId = 2,
                            Message = "Hello from the other side",
                            SenderId = 1
                        });
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.GroupUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupUsers");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            GroupId = 1
                        },
                        new
                        {
                            UserId = 2,
                            GroupId = 1
                        },
                        new
                        {
                            UserId = 3,
                            GroupId = 1
                        },
                        new
                        {
                            UserId = 4,
                            GroupId = 1
                        },
                        new
                        {
                            UserId = 1,
                            GroupId = 2
                        },
                        new
                        {
                            UserId = 2,
                            GroupId = 2
                        });
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.PrivateMessage", b =>
                {
                    b.Property<int>("PrivateMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrivateMessageId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.HasKey("PrivateMessageId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("PrivateMessages");

                    b.HasData(
                        new
                        {
                            PrivateMessageId = 1,
                            DateTime = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Message = "Sretna Nova godina!",
                            ReceiverId = 2,
                            SenderId = 1
                        },
                        new
                        {
                            PrivateMessageId = 2,
                            DateTime = new DateTime(2024, 1, 1, 0, 0, 1, 0, DateTimeKind.Utc),
                            Message = "Sretna Nova godina :)",
                            ReceiverId = 1,
                            SenderId = 2
                        });
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "lucija@gmail.com",
                            IsAdmin = true,
                            Password = "lucija123",
                            UserName = "lucija"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "gabriela@gmail.com",
                            IsAdmin = true,
                            Password = "gabriela123",
                            UserName = "gabriela"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "daria@gmail.com",
                            IsAdmin = true,
                            Password = "daria123",
                            UserName = "daria"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "tea@gmail.com",
                            IsAdmin = false,
                            Password = "tea123",
                            UserName = "tea"
                        });
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.Group", b =>
                {
                    b.HasOne("ChatApp.Data.Entities.Models.User", null)
                        .WithMany("Groups")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.GroupMessage", b =>
                {
                    b.HasOne("ChatApp.Data.Entities.Models.Group", "Group")
                        .WithMany("GroupMessages")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApp.Data.Entities.Models.User", "Sender")
                        .WithMany("GroupMessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.GroupUser", b =>
                {
                    b.HasOne("ChatApp.Data.Entities.Models.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApp.Data.Entities.Models.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.PrivateMessage", b =>
                {
                    b.HasOne("ChatApp.Data.Entities.Models.User", "Receiver")
                        .WithMany("ReceivedPrivateMesssages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApp.Data.Entities.Models.User", "Sender")
                        .WithMany("SentPrivateMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.Group", b =>
                {
                    b.Navigation("GroupMessages");

                    b.Navigation("GroupUsers");
                });

            modelBuilder.Entity("ChatApp.Data.Entities.Models.User", b =>
                {
                    b.Navigation("GroupMessagesSent");

                    b.Navigation("GroupUsers");

                    b.Navigation("Groups");

                    b.Navigation("ReceivedPrivateMesssages");

                    b.Navigation("SentPrivateMessages");
                });
#pragma warning restore 612, 618
        }
    }
}