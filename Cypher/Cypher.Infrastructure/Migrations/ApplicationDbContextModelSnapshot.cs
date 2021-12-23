﻿// <auto-generated />
using System;
using Cypher.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cypher.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("AspNetCoreHero.EntityFrameworkCore.AuditTrail.Models.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AffectedColumns")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NewValues")
                        .HasColumnType("text");

                    b.Property<string>("OldValues")
                        .HasColumnType("text");

                    b.Property<string>("PrimaryKey")
                        .HasColumnType("text");

                    b.Property<string>("TableName")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Catalog.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Tax")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Catalog.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Rate")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Info")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PuzzleId")
                        .HasColumnType("integer");

                    b.Property<string>("Trigger")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PuzzleId");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ItemType")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Lobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("LobbyAdminId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LobbyAdminId");

                    b.ToTable("Lobbies");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MessageText")
                        .HasColumnType("text");

                    b.Property<int?>("SenderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.MessagePlayer", b =>
                {
                    b.Property<int>("MessageId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("MessageId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("MessagePlayer");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Puzzle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Puzzles");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.UserCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Base64Credential")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("LobbyPlayer", b =>
                {
                    b.Property<int>("LobbiesJoinedId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayersId")
                        .HasColumnType("integer");

                    b.HasKey("LobbiesJoinedId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("LobbyPlayer");
                });

            modelBuilder.Entity("PlayerPlayer", b =>
                {
                    b.Property<int>("FriendsId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayersId")
                        .HasColumnType("integer");

                    b.HasKey("FriendsId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerPlayer");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Catalog.Product", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Catalog.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Action", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Puzzle", "Puzzle")
                        .WithMany("Actions")
                        .HasForeignKey("PuzzleId");

                    b.Navigation("Puzzle");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Item", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Inventory", null)
                        .WithMany("Items")
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Lobby", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Player", "LobbyAdmin")
                        .WithMany("LobbiesAdmin")
                        .HasForeignKey("LobbyAdminId");

                    b.Navigation("LobbyAdmin");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Message", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Player", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.MessagePlayer", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Message", "Message")
                        .WithMany("MessagePlayers")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cypher.Domain.Entities.Cypher.Player", "Player")
                        .WithMany("MessagePlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Player", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("LobbyPlayer", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Lobby", null)
                        .WithMany()
                        .HasForeignKey("LobbiesJoinedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cypher.Domain.Entities.Cypher.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayerPlayer", b =>
                {
                    b.HasOne("Cypher.Domain.Entities.Cypher.Player", null)
                        .WithMany()
                        .HasForeignKey("FriendsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cypher.Domain.Entities.Cypher.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Inventory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Message", b =>
                {
                    b.Navigation("MessagePlayers");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Player", b =>
                {
                    b.Navigation("LobbiesAdmin");

                    b.Navigation("MessagePlayers");
                });

            modelBuilder.Entity("Cypher.Domain.Entities.Cypher.Puzzle", b =>
                {
                    b.Navigation("Actions");
                });
#pragma warning restore 612, 618
        }
    }
}
