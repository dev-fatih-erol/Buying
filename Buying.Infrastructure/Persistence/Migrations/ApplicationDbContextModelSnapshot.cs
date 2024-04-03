﻿// <auto-generated />
using Buying.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Buying.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Channel", (string)null);
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.Instruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ExecutionDay")
                        .HasColumnType("integer");

                    b.Property<int>("InstructionStatus")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Instruction", (string)null);
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.InstructionChannel", b =>
                {
                    b.Property<int>("InstructionId")
                        .HasColumnType("integer");

                    b.Property<int>("ChannelId")
                        .HasColumnType("integer");

                    b.HasKey("InstructionId", "ChannelId");

                    b.HasIndex("ChannelId");

                    b.ToTable("InstructionChannel", (string)null);
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.Instruction", b =>
                {
                    b.HasOne("Buying.Infrastructure.Domain.Entities.User", "User")
                        .WithMany("Instructions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.InstructionChannel", b =>
                {
                    b.HasOne("Buying.Infrastructure.Domain.Entities.Channel", "Channel")
                        .WithMany("InstructionChannels")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buying.Infrastructure.Domain.Entities.Instruction", "Instruction")
                        .WithMany("InstructionChannels")
                        .HasForeignKey("InstructionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Instruction");
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.Channel", b =>
                {
                    b.Navigation("InstructionChannels");
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.Instruction", b =>
                {
                    b.Navigation("InstructionChannels");
                });

            modelBuilder.Entity("Buying.Infrastructure.Domain.Entities.User", b =>
                {
                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}