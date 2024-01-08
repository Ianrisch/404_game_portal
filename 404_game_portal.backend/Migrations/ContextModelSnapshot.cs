﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _404_game_portal.backend;

#nullable disable

namespace _404_game_portal.backend.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_404_game_portal.backend.Entities.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FeatureDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<int>("USK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.GameFeature", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("char(36)");

                    b.HasKey("GameId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("GameFeatures");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.GameLanguage", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("char(36)");

                    b.HasKey("GameId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("GameLanguages");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.GamePlatform", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("GamePlatforms");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlatformType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlatformVersion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.GameFeature", b =>
                {
                    b.HasOne("_404_game_portal.backend.Entities.Feature", "Feature")
                        .WithMany("GameFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_404_game_portal.backend.Entities.Game", "Game")
                        .WithMany("GameFeatures")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.GameLanguage", b =>
                {
                    b.HasOne("_404_game_portal.backend.Entities.Game", "Game")
                        .WithMany("GameLanguages")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_404_game_portal.backend.Entities.Language", "Language")
                        .WithMany("GameLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.GamePlatform", b =>
                {
                    b.HasOne("_404_game_portal.backend.Entities.Game", "Game")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_404_game_portal.backend.Entities.Platform", "Platform")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.Feature", b =>
                {
                    b.Navigation("GameFeatures");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.Game", b =>
                {
                    b.Navigation("GameFeatures");

                    b.Navigation("GameLanguages");

                    b.Navigation("GamePlatforms");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.Language", b =>
                {
                    b.Navigation("GameLanguages");
                });

            modelBuilder.Entity("_404_game_portal.backend.Entities.Platform", b =>
                {
                    b.Navigation("GamePlatforms");
                });
#pragma warning restore 612, 618
        }
    }
}
