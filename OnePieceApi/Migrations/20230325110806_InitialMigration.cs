using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnePieceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    ArchetypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.ArchetypeId);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.AttributeId);
                });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    CardTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.CardTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    EffectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.EffectId);
                });

            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    RarityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.RarityId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    SetId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.SetId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visibilities",
                columns: table => new
                {
                    VisibilityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visibilities", x => x.VisibilityId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Power = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<byte>(type: "tinyint", nullable: true),
                    SetId = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: true),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    RarityId = table.Column<int>(type: "int", nullable: false),
                    CardTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_CardTypes_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardTypes",
                        principalColumn: "CardTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Rarities_RarityId",
                        column: x => x.RarityId,
                        principalTable: "Rarities",
                        principalColumn: "RarityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "SetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesRoleId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesRoleId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decklist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    VisibilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decklist_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decklist_Visibilities_VisibilityId",
                        column: x => x.VisibilityId,
                        principalTable: "Visibilities",
                        principalColumn: "VisibilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchetypeCard",
                columns: table => new
                {
                    ArchetypesArchetypeId = table.Column<int>(type: "int", nullable: false),
                    CardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchetypeCard", x => new { x.ArchetypesArchetypeId, x.CardsId });
                    table.ForeignKey(
                        name: "FK_ArchetypeCard_Archetypes_ArchetypesArchetypeId",
                        column: x => x.ArchetypesArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "ArchetypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchetypeCard_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardColor",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "int", nullable: false),
                    ColorsColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardColor", x => new { x.CardsId, x.ColorsColorId });
                    table.ForeignKey(
                        name: "FK_CardColor_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardColor_Colors_ColorsColorId",
                        column: x => x.ColorsColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardEffect",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "int", nullable: false),
                    EffectsEffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardEffect", x => new { x.CardsId, x.EffectsEffectId });
                    table.ForeignKey(
                        name: "FK_CardEffect_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardEffect_Effects_EffectsEffectId",
                        column: x => x.EffectsEffectId,
                        principalTable: "Effects",
                        principalColumn: "EffectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardQuantity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<byte>(type: "tinyint", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    DecklistId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardQuantity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardQuantity_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardQuantity_Decklist_DecklistId",
                        column: x => x.DecklistId,
                        principalTable: "Decklist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CardQuantity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "AttributeId", "Name" },
                values: new object[,]
                {
                    { 0, "Slash" },
                    { 1, "Strike" },
                    { 2, "Ranged" },
                    { 3, "Wisdom" },
                    { 4, "Special" }
                });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "CardTypeId", "Name" },
                values: new object[,]
                {
                    { 0, "Leader" },
                    { 1, "Character" },
                    { 2, "Event" },
                    { 3, "Stage" },
                    { 4, "Don" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "Name" },
                values: new object[,]
                {
                    { 0, "Red" },
                    { 1, "Green" },
                    { 2, "Blue" },
                    { 3, "Purple" },
                    { 4, "Black" },
                    { 5, "Yellow" }
                });

            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "EffectId", "Name" },
                values: new object[,]
                {
                    { 0, "Blocker" },
                    { 1, "Rush" },
                    { 2, "OnPlay" },
                    { 3, "OnKO" },
                    { 4, "OnBlock" },
                    { 5, "WhenAttacking" },
                    { 6, "WhenBlocking" },
                    { 7, "YourTurn" },
                    { 8, "OponnentsTurn" }
                });

            migrationBuilder.InsertData(
                table: "Rarities",
                columns: new[] { "RarityId", "Name" },
                values: new object[,]
                {
                    { 0, "Common" },
                    { 1, "Uncommon" },
                    { 2, "Rare" },
                    { 3, "SuperRare" },
                    { 4, "SecretRare" },
                    { 5, "SpecialRare" },
                    { 6, "Promo" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 0, "Admin" },
                    { 1, "User" }
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "SetId", "Name" },
                values: new object[,]
                {
                    { 0, "OP01" },
                    { 1, "OP02" },
                    { 2, "OP03" },
                    { 3, "OP04" },
                    { 4, "ST01" },
                    { 5, "ST02" },
                    { 6, "ST03" },
                    { 7, "ST04" },
                    { 8, "ST05" },
                    { 9, "ST06" },
                    { 10, "ST07" },
                    { 11, "ST08" },
                    { 12, "ST09" },
                    { 13, "P" }
                });

            migrationBuilder.InsertData(
                table: "Visibilities",
                columns: new[] { "VisibilityId", "Name" },
                values: new object[,]
                {
                    { 0, "Private" },
                    { 1, "Team" },
                    { 2, "Public" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypeCard_CardsId",
                table: "ArchetypeCard",
                column: "CardsId");

            migrationBuilder.CreateIndex(
                name: "IX_CardColor_ColorsColorId",
                table: "CardColor",
                column: "ColorsColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CardEffect_EffectsEffectId",
                table: "CardEffect",
                column: "EffectsEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_CardQuantity_CardId",
                table: "CardQuantity",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardQuantity_DecklistId",
                table: "CardQuantity",
                column: "DecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_CardQuantity_UserId",
                table: "CardQuantity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AttributeId",
                table: "Cards",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeId",
                table: "Cards",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RarityId",
                table: "Cards",
                column: "RarityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SetId",
                table: "Cards",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Decklist_UserId",
                table: "Decklist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Decklist_VisibilityId",
                table: "Decklist",
                column: "VisibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchetypeCard");

            migrationBuilder.DropTable(
                name: "CardColor");

            migrationBuilder.DropTable(
                name: "CardEffect");

            migrationBuilder.DropTable(
                name: "CardQuantity");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Archetypes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decklist");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Rarities");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Visibilities");
        }
    }
}
