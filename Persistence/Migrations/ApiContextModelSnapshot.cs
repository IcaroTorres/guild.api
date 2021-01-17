﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Domain.Models.Guild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Disabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Guilds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 44, 987, DateTimeKind.Utc).AddTicks(8628),
                            Disabled = false,
                            Name = "NERV"
                        },
                        new
                        {
                            Id = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 10, DateTimeKind.Utc).AddTicks(495),
                            Disabled = false,
                            Name = "WILE: EVA Pilots"
                        });
                });

            modelBuilder.Entity("Domain.Models.Invite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Disabled")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("GuildId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<short>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("MemberId");

                    b.ToTable("Invites");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89dd1816-dd87-4e8e-97f5-fc5b32f900bd"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 21, DateTimeKind.Utc).AddTicks(9653),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("8cac0c89-b5b4-4b1a-8395-525395ba3d3b"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(2951),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("3cb0ba50-03d9-48db-93ca-692cb9d68131"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("bedfa422-317d-4640-a4c7-84f47e2fcd6d"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3543),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("18234e65-8cb1-42e8-9cf4-e4d37980752a"),
                            Status = (short)3
                        },
                        new
                        {
                            Id = new Guid("700dad75-3364-4d75-ab44-cec40dcfdeca"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3613),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("bf449ca7-5183-46ad-a2eb-edf804e20a0e"),
                            Status = (short)4
                        },
                        new
                        {
                            Id = new Guid("c06ed199-312c-42f0-a582-b471129e41af"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3669),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("ae609940-4505-4977-813d-d26428672315"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3732),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("bf449ca7-5183-46ad-a2eb-edf804e20a0e"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("b2b4625b-d424-4d8e-aee7-19efa63eb062"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3802),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("18234e65-8cb1-42e8-9cf4-e4d37980752a"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("684737ff-ab4b-4b68-b7f1-a8739e0b1840"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3855),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("e3f46444-78f3-4b94-b703-bc056121fc16"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("ab532a05-606d-4931-b81b-8ce522dd4496"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3909),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("84a7896c-264e-44de-9d36-e2edc3d201e7"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("1d350c02-d364-41cf-b38c-fa2c242af4c6"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(3963),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            Status = (short)2
                        },
                        new
                        {
                            Id = new Guid("f0dc8d5a-89eb-4496-a14c-bd041b36448f"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 26, DateTimeKind.Utc).AddTicks(4018),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("9fad438a-3555-4583-9621-2c065ad93084"),
                            Status = (short)2
                        });
                });

            modelBuilder.Entity("Domain.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Disabled")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("GuildId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsGuildLeader")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf449ca7-5183-46ad-a2eb-edf804e20a0e"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 14, DateTimeKind.Utc).AddTicks(6028),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            IsGuildLeader = false,
                            Name = "Mari Makinami, EVA 05 Pilot"
                        },
                        new
                        {
                            Id = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 19, DateTimeKind.Utc).AddTicks(7994),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            IsGuildLeader = false,
                            Name = "Asuka Langley Sohryu, EVA 02 Pilot"
                        },
                        new
                        {
                            Id = new Guid("3cb0ba50-03d9-48db-93ca-692cb9d68131"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 19, DateTimeKind.Utc).AddTicks(8138),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            IsGuildLeader = false,
                            Name = "Rei Ayanami, EVA 00 Pilot"
                        },
                        new
                        {
                            Id = new Guid("18234e65-8cb1-42e8-9cf4-e4d37980752a"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 19, DateTimeKind.Utc).AddTicks(8191),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            IsGuildLeader = false,
                            Name = "Shinji Ikari, EVA 01 Pilot"
                        },
                        new
                        {
                            Id = new Guid("e3f46444-78f3-4b94-b703-bc056121fc16"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 19, DateTimeKind.Utc).AddTicks(8237),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            IsGuildLeader = true,
                            Name = "Gendo Ikari, NERV Comander"
                        },
                        new
                        {
                            Id = new Guid("84a7896c-264e-44de-9d36-e2edc3d201e7"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 19, DateTimeKind.Utc).AddTicks(9215),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            IsGuildLeader = false,
                            Name = "Kozo Fuyutsuk, NERV Deputy Comander"
                        },
                        new
                        {
                            Id = new Guid("9fad438a-3555-4583-9621-2c065ad93084"),
                            CreatedDate = new DateTime(2021, 1, 14, 2, 33, 45, 19, DateTimeKind.Utc).AddTicks(9276),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            IsGuildLeader = true,
                            Name = "Misato Katsuragi, WILE Comander"
                        });
                });

            modelBuilder.Entity("Domain.Models.Membership", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Disabled")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("GuildId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("MemberId");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            Id = new Guid("63c3c07a-7d10-4585-879e-60ff90f30cfa"),
                            CreatedDate = new DateTime(2020, 3, 17, 19, 18, 42, 619, DateTimeKind.Unspecified).AddTicks(29),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            ModifiedDate = new DateTime(2020, 3, 17, 21, 24, 25, 62, DateTimeKind.Unspecified).AddTicks(6216)
                        },
                        new
                        {
                            Id = new Guid("785e1d4f-99dd-4152-ade0-bce244c0eec1"),
                            CreatedDate = new DateTime(2020, 3, 17, 19, 20, 47, 23, DateTimeKind.Unspecified).AddTicks(5603),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("bf449ca7-5183-46ad-a2eb-edf804e20a0e"),
                            ModifiedDate = new DateTime(2020, 3, 17, 19, 54, 32, 580, DateTimeKind.Unspecified).AddTicks(284)
                        },
                        new
                        {
                            Id = new Guid("048fca04-54c9-41fd-af36-a56e01426159"),
                            CreatedDate = new DateTime(2020, 3, 17, 23, 9, 49, 47, DateTimeKind.Unspecified).AddTicks(6435),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            ModifiedDate = new DateTime(2020, 3, 17, 23, 10, 59, 525, DateTimeKind.Unspecified).AddTicks(1100)
                        },
                        new
                        {
                            Id = new Guid("ef2fbc73-2d66-4f81-bb42-1e5dad58c276"),
                            CreatedDate = new DateTime(2020, 3, 18, 0, 4, 35, 630, DateTimeKind.Unspecified).AddTicks(3147),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            ModifiedDate = new DateTime(2020, 3, 18, 0, 22, 31, 664, DateTimeKind.Unspecified).AddTicks(5485)
                        },
                        new
                        {
                            Id = new Guid("8907eb3f-b192-42f1-9fe7-a91c4dd799e0"),
                            CreatedDate = new DateTime(2020, 3, 18, 0, 14, 49, 870, DateTimeKind.Unspecified).AddTicks(9813),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("3cb0ba50-03d9-48db-93ca-692cb9d68131"),
                            ModifiedDate = new DateTime(2020, 3, 18, 15, 25, 21, 374, DateTimeKind.Unspecified).AddTicks(2161)
                        },
                        new
                        {
                            Id = new Guid("c9aa80ec-229f-4763-ac30-0b1584ac2943"),
                            CreatedDate = new DateTime(2020, 3, 18, 0, 22, 31, 665, DateTimeKind.Unspecified).AddTicks(6800),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1"),
                            ModifiedDate = new DateTime(2020, 3, 18, 15, 17, 3, 492, DateTimeKind.Unspecified).AddTicks(4124)
                        },
                        new
                        {
                            Id = new Guid("d1307584-b524-48e2-91fa-1882c9819ac8"),
                            CreatedDate = new DateTime(2020, 3, 18, 1, 3, 38, 622, DateTimeKind.Unspecified).AddTicks(9484),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("bf449ca7-5183-46ad-a2eb-edf804e20a0e")
                        },
                        new
                        {
                            Id = new Guid("970a0fea-aa33-4898-932b-e713045c9fce"),
                            CreatedDate = new DateTime(2020, 3, 18, 2, 38, 44, 175, DateTimeKind.Unspecified).AddTicks(8894),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("18234e65-8cb1-42e8-9cf4-e4d37980752a")
                        },
                        new
                        {
                            Id = new Guid("63b7cac2-07b5-4bf1-a3ae-90e4b2f65c2e"),
                            CreatedDate = new DateTime(2020, 3, 18, 7, 20, 19, 667, DateTimeKind.Unspecified).AddTicks(5361),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("e3f46444-78f3-4b94-b703-bc056121fc16")
                        },
                        new
                        {
                            Id = new Guid("408b0fcf-7a0e-46d3-aa2a-8cc41bd8c492"),
                            CreatedDate = new DateTime(2020, 3, 18, 15, 4, 32, 920, DateTimeKind.Unspecified).AddTicks(9975),
                            Disabled = false,
                            GuildId = new Guid("96685bc4-dcb7-4b22-90cc-ca83baff8186"),
                            MemberId = new Guid("84a7896c-264e-44de-9d36-e2edc3d201e7")
                        },
                        new
                        {
                            Id = new Guid("39823673-5f77-4b54-9f2b-ea2818d9c490"),
                            CreatedDate = new DateTime(2020, 3, 18, 15, 27, 11, 115, DateTimeKind.Unspecified).AddTicks(8971),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("5cd3f816-6b0f-4ba6-aeb5-26d70281f7e1")
                        },
                        new
                        {
                            Id = new Guid("016a61d1-dd66-47fe-8404-195ce90be07f"),
                            CreatedDate = new DateTime(2020, 3, 18, 15, 28, 14, 381, DateTimeKind.Unspecified).AddTicks(5450),
                            Disabled = false,
                            GuildId = new Guid("0bf46ff3-42a8-4dbb-a037-009d831b3263"),
                            MemberId = new Guid("9fad438a-3555-4583-9621-2c065ad93084")
                        });
                });

            modelBuilder.Entity("Domain.Models.Invite", b =>
                {
                    b.HasOne("Domain.Models.Guild", "Guild")
                        .WithMany("Invites")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Models.Member", b =>
                {
                    b.HasOne("Domain.Models.Guild", "Guild")
                        .WithMany("Members")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Models.Membership", b =>
                {
                    b.HasOne("Domain.Models.Guild", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Models.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
