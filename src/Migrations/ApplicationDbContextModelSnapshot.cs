﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Snap.Genshin.Website.Entities;

#nullable disable

namespace Snap.Genshin.Website.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Player", b =>
                {
                    b.Property<Guid>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("InnerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.AvatarDetail", b =>
                {
                    b.Property<long>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("ActivedConstellationNum")
                        .HasColumnType("int");

                    b.Property<int>("AffixLevel")
                        .HasColumnType("int");

                    b.Property<int>("AvatarId")
                        .HasColumnType("int");

                    b.Property<int>("AvatarLevel")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponLevel")
                        .HasColumnType("int");

                    b.HasKey("InnerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("AvatarDetails");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.PlayerRecord", b =>
                {
                    b.Property<long>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UploadTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.HasKey("InnerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerRecords");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.ReliquarySetDetail", b =>
                {
                    b.Property<long>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AvatarDetailId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("InnerId");

                    b.HasIndex("AvatarDetailId");

                    b.ToTable("ReliquarySetDetails");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssAvatar", b =>
                {
                    b.Property<long>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("AvatarId")
                        .HasColumnType("int");

                    b.Property<long>("SpiralAbyssBattleId")
                        .HasColumnType("bigint");

                    b.HasKey("InnerId");

                    b.HasIndex("SpiralAbyssBattleId");

                    b.ToTable("SpiralAbyssAvatars");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssBattle", b =>
                {
                    b.Property<long>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("BattleIndex")
                        .HasColumnType("int");

                    b.Property<long>("SpiralAbyssLevelId")
                        .HasColumnType("bigint");

                    b.HasKey("InnerId");

                    b.HasIndex("SpiralAbyssLevelId");

                    b.ToTable("SpiralAbyssBattles");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssLevel", b =>
                {
                    b.Property<long>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("FloorIndex")
                        .HasColumnType("int");

                    b.Property<int>("LevelIndex")
                        .HasColumnType("int");

                    b.Property<long>("RecordId")
                        .HasColumnType("bigint");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.HasKey("InnerId");

                    b.HasIndex("RecordId");

                    b.ToTable("SpiralAbyssLevels");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Statistics", b =>
                {
                    b.Property<long>("InnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("InnerId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.User", b =>
                {
                    b.Property<Guid>("AppId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AppId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersClaims");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.UserSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersSecrets");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.AvatarDetail", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.Player", "Player")
                        .WithMany("Avatars")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.PlayerRecord", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.ReliquarySetDetail", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.Record.AvatarDetail", "AvatarInfo")
                        .WithMany("ReliquarySets")
                        .HasForeignKey("AvatarDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvatarInfo");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssAvatar", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.Record.SpiralAbyssBattle", "SpiralAbyssBattle")
                        .WithMany("Avatars")
                        .HasForeignKey("SpiralAbyssBattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpiralAbyssBattle");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssBattle", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.Record.SpiralAbyssLevel", "AbyssLevel")
                        .WithMany("Battles")
                        .HasForeignKey("SpiralAbyssLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbyssLevel");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssLevel", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.Record.PlayerRecord", "Record")
                        .WithMany("SpiralAbyssLevels")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.UserClaim", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.UserSecret", b =>
                {
                    b.HasOne("Snap.Genshin.Website.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Player", b =>
                {
                    b.Navigation("Avatars");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.AvatarDetail", b =>
                {
                    b.Navigation("ReliquarySets");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.PlayerRecord", b =>
                {
                    b.Navigation("SpiralAbyssLevels");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssBattle", b =>
                {
                    b.Navigation("Avatars");
                });

            modelBuilder.Entity("Snap.Genshin.Website.Entities.Record.SpiralAbyssLevel", b =>
                {
                    b.Navigation("Battles");
                });
#pragma warning restore 612, 618
        }
    }
}