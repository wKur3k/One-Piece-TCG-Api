﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnePieceApi.Entities;

#nullable disable

namespace OnePieceApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230327171705_FuckMeMigration")]
    partial class FuckMeMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArchetypeCard", b =>
                {
                    b.Property<int>("ArchetypesArchetypeId")
                        .HasColumnType("int");

                    b.Property<int>("CardsId")
                        .HasColumnType("int");

                    b.HasKey("ArchetypesArchetypeId", "CardsId");

                    b.HasIndex("CardsId");

                    b.ToTable("ArchetypeCard");
                });

            modelBuilder.Entity("CardColor", b =>
                {
                    b.Property<int>("CardsId")
                        .HasColumnType("int");

                    b.Property<int>("ColorsColorId")
                        .HasColumnType("int");

                    b.HasKey("CardsId", "ColorsColorId");

                    b.HasIndex("ColorsColorId");

                    b.ToTable("CardColor");
                });

            modelBuilder.Entity("CardEffect", b =>
                {
                    b.Property<int>("CardsId")
                        .HasColumnType("int");

                    b.Property<int>("EffectsEffectId")
                        .HasColumnType("int");

                    b.HasKey("CardsId", "EffectsEffectId");

                    b.HasIndex("EffectsEffectId");

                    b.ToTable("CardEffect");
                });

            modelBuilder.Entity("OnePieceApi.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<byte?>("Cost")
                        .HasColumnType("tinyint");

                    b.Property<int?>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ImageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Power")
                        .HasColumnType("int");

                    b.Property<int>("RarityId")
                        .HasColumnType("int");

                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.Property<string>("SetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("ImageId");

                    b.HasIndex("RarityId");

                    b.HasIndex("SetId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("OnePieceApi.Entities.CardQuantity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<long?>("DecklistId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Quantity")
                        .HasColumnType("tinyint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("DecklistId");

                    b.HasIndex("UserId");

                    b.ToTable("DecklistCards");
                });

            modelBuilder.Entity("OnePieceApi.Entities.Decklist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("VisibilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VisibilityId");

                    b.ToTable("Decklists");
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Archetype", b =>
                {
                    b.Property<int>("ArchetypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArchetypeId");

                    b.ToTable("Archetypes");

                    b.HasData(
                        new
                        {
                            ArchetypeId = 0,
                            Name = "FormerNavy"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Attribute", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttributeId");

                    b.ToTable("Attributes");

                    b.HasData(
                        new
                        {
                            AttributeId = 0,
                            Name = "Slash"
                        },
                        new
                        {
                            AttributeId = 1,
                            Name = "Strike"
                        },
                        new
                        {
                            AttributeId = 2,
                            Name = "Ranged"
                        },
                        new
                        {
                            AttributeId = 3,
                            Name = "Wisdom"
                        },
                        new
                        {
                            AttributeId = 4,
                            Name = "Special"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.CardType", b =>
                {
                    b.Property<int>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardTypeId");

                    b.ToTable("CardTypes");

                    b.HasData(
                        new
                        {
                            CardTypeId = 0,
                            Name = "Leader"
                        },
                        new
                        {
                            CardTypeId = 1,
                            Name = "Character"
                        },
                        new
                        {
                            CardTypeId = 2,
                            Name = "Event"
                        },
                        new
                        {
                            CardTypeId = 3,
                            Name = "Stage"
                        },
                        new
                        {
                            CardTypeId = 4,
                            Name = "Don"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorId");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            ColorId = 0,
                            Name = "Red"
                        },
                        new
                        {
                            ColorId = 1,
                            Name = "Green"
                        },
                        new
                        {
                            ColorId = 2,
                            Name = "Blue"
                        },
                        new
                        {
                            ColorId = 3,
                            Name = "Purple"
                        },
                        new
                        {
                            ColorId = 4,
                            Name = "Black"
                        },
                        new
                        {
                            ColorId = 5,
                            Name = "Yellow"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Effect", b =>
                {
                    b.Property<int>("EffectId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EffectId");

                    b.ToTable("Effects");

                    b.HasData(
                        new
                        {
                            EffectId = 0,
                            Name = "Blocker"
                        },
                        new
                        {
                            EffectId = 1,
                            Name = "Rush"
                        },
                        new
                        {
                            EffectId = 2,
                            Name = "OnPlay"
                        },
                        new
                        {
                            EffectId = 3,
                            Name = "OnKO"
                        },
                        new
                        {
                            EffectId = 4,
                            Name = "OnBlock"
                        },
                        new
                        {
                            EffectId = 5,
                            Name = "WhenAttacking"
                        },
                        new
                        {
                            EffectId = 6,
                            Name = "WhenBlocking"
                        },
                        new
                        {
                            EffectId = 7,
                            Name = "YourTurn"
                        },
                        new
                        {
                            EffectId = 8,
                            Name = "OponnentsTurn"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Rarity", b =>
                {
                    b.Property<int>("RarityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RarityId");

                    b.ToTable("Rarities");

                    b.HasData(
                        new
                        {
                            RarityId = 0,
                            Name = "Common"
                        },
                        new
                        {
                            RarityId = 1,
                            Name = "Uncommon"
                        },
                        new
                        {
                            RarityId = 2,
                            Name = "Rare"
                        },
                        new
                        {
                            RarityId = 3,
                            Name = "SuperRare"
                        },
                        new
                        {
                            RarityId = 4,
                            Name = "SecretRare"
                        },
                        new
                        {
                            RarityId = 5,
                            Name = "SpecialRare"
                        },
                        new
                        {
                            RarityId = 6,
                            Name = "Promo"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 0,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 1,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Set", b =>
                {
                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SetId");

                    b.ToTable("Sets");

                    b.HasData(
                        new
                        {
                            SetId = 0,
                            Name = "OP01"
                        },
                        new
                        {
                            SetId = 1,
                            Name = "OP02"
                        },
                        new
                        {
                            SetId = 2,
                            Name = "OP03"
                        },
                        new
                        {
                            SetId = 3,
                            Name = "OP04"
                        },
                        new
                        {
                            SetId = 4,
                            Name = "ST01"
                        },
                        new
                        {
                            SetId = 5,
                            Name = "ST02"
                        },
                        new
                        {
                            SetId = 6,
                            Name = "ST03"
                        },
                        new
                        {
                            SetId = 7,
                            Name = "ST04"
                        },
                        new
                        {
                            SetId = 8,
                            Name = "ST05"
                        },
                        new
                        {
                            SetId = 9,
                            Name = "ST06"
                        },
                        new
                        {
                            SetId = 10,
                            Name = "ST07"
                        },
                        new
                        {
                            SetId = 11,
                            Name = "ST08"
                        },
                        new
                        {
                            SetId = 12,
                            Name = "ST09"
                        },
                        new
                        {
                            SetId = 13,
                            Name = "P"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Enums.Visibility", b =>
                {
                    b.Property<int>("VisibilityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisibilityId");

                    b.ToTable("Visibilities");

                    b.HasData(
                        new
                        {
                            VisibilityId = 0,
                            Name = "Private"
                        },
                        new
                        {
                            VisibilityId = 1,
                            Name = "Team"
                        },
                        new
                        {
                            VisibilityId = 2,
                            Name = "Public"
                        });
                });

            modelBuilder.Entity("OnePieceApi.Entities.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ImageB64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("OnePieceApi.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("RolesRoleId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ArchetypeCard", b =>
                {
                    b.HasOne("OnePieceApi.Entities.Enums.Archetype", null)
                        .WithMany()
                        .HasForeignKey("ArchetypesArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Card", null)
                        .WithMany()
                        .HasForeignKey("CardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CardColor", b =>
                {
                    b.HasOne("OnePieceApi.Entities.Card", null)
                        .WithMany()
                        .HasForeignKey("CardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Enums.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorsColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CardEffect", b =>
                {
                    b.HasOne("OnePieceApi.Entities.Card", null)
                        .WithMany()
                        .HasForeignKey("CardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Enums.Effect", null)
                        .WithMany()
                        .HasForeignKey("EffectsEffectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnePieceApi.Entities.Card", b =>
                {
                    b.HasOne("OnePieceApi.Entities.Enums.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Enums.CardType", "CardType")
                        .WithMany()
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Enums.Rarity", "Rarity")
                        .WithMany()
                        .HasForeignKey("RarityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Enums.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("CardType");

                    b.Navigation("Image");

                    b.Navigation("Rarity");

                    b.Navigation("Set");
                });

            modelBuilder.Entity("OnePieceApi.Entities.CardQuantity", b =>
                {
                    b.HasOne("OnePieceApi.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Decklist", null)
                        .WithMany("DecklistCardsList")
                        .HasForeignKey("DecklistId");

                    b.HasOne("OnePieceApi.Entities.User", null)
                        .WithMany("Collection")
                        .HasForeignKey("UserId");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("OnePieceApi.Entities.Decklist", b =>
                {
                    b.HasOne("OnePieceApi.Entities.User", "User")
                        .WithMany("Decklists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.Enums.Visibility", "Visibility")
                        .WithMany()
                        .HasForeignKey("VisibilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Visibility");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("OnePieceApi.Entities.Enums.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePieceApi.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnePieceApi.Entities.Decklist", b =>
                {
                    b.Navigation("DecklistCardsList");
                });

            modelBuilder.Entity("OnePieceApi.Entities.User", b =>
                {
                    b.Navigation("Collection");

                    b.Navigation("Decklists");
                });
#pragma warning restore 612, 618
        }
    }
}
