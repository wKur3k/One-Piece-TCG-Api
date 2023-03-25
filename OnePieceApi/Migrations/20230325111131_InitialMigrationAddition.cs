using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePieceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardQuantity_Cards_CardId",
                table: "CardQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_CardQuantity_Decklist_DecklistId",
                table: "CardQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_CardQuantity_User_UserId",
                table: "CardQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_Decklist_User_UserId",
                table: "Decklist");

            migrationBuilder.DropForeignKey(
                name: "FK_Decklist_Visibilities_VisibilityId",
                table: "Decklist");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Decklist",
                table: "Decklist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardQuantity",
                table: "CardQuantity");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Decklist",
                newName: "Decklists");

            migrationBuilder.RenameTable(
                name: "CardQuantity",
                newName: "DecklistCards");

            migrationBuilder.RenameIndex(
                name: "IX_Decklist_VisibilityId",
                table: "Decklists",
                newName: "IX_Decklists_VisibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Decklist_UserId",
                table: "Decklists",
                newName: "IX_Decklists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CardQuantity_UserId",
                table: "DecklistCards",
                newName: "IX_DecklistCards_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CardQuantity_DecklistId",
                table: "DecklistCards",
                newName: "IX_DecklistCards_DecklistId");

            migrationBuilder.RenameIndex(
                name: "IX_CardQuantity_CardId",
                table: "DecklistCards",
                newName: "IX_DecklistCards_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Decklists",
                table: "Decklists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DecklistCards",
                table: "DecklistCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DecklistCards_Cards_CardId",
                table: "DecklistCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DecklistCards_Decklists_DecklistId",
                table: "DecklistCards",
                column: "DecklistId",
                principalTable: "Decklists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DecklistCards_Users_UserId",
                table: "DecklistCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Decklists_Users_UserId",
                table: "Decklists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Decklists_Visibilities_VisibilityId",
                table: "Decklists",
                column: "VisibilityId",
                principalTable: "Visibilities",
                principalColumn: "VisibilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecklistCards_Cards_CardId",
                table: "DecklistCards");

            migrationBuilder.DropForeignKey(
                name: "FK_DecklistCards_Decklists_DecklistId",
                table: "DecklistCards");

            migrationBuilder.DropForeignKey(
                name: "FK_DecklistCards_Users_UserId",
                table: "DecklistCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Decklists_Users_UserId",
                table: "Decklists");

            migrationBuilder.DropForeignKey(
                name: "FK_Decklists_Visibilities_VisibilityId",
                table: "Decklists");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Decklists",
                table: "Decklists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DecklistCards",
                table: "DecklistCards");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Decklists",
                newName: "Decklist");

            migrationBuilder.RenameTable(
                name: "DecklistCards",
                newName: "CardQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_Decklists_VisibilityId",
                table: "Decklist",
                newName: "IX_Decklist_VisibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Decklists_UserId",
                table: "Decklist",
                newName: "IX_Decklist_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DecklistCards_UserId",
                table: "CardQuantity",
                newName: "IX_CardQuantity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DecklistCards_DecklistId",
                table: "CardQuantity",
                newName: "IX_CardQuantity_DecklistId");

            migrationBuilder.RenameIndex(
                name: "IX_DecklistCards_CardId",
                table: "CardQuantity",
                newName: "IX_CardQuantity_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Decklist",
                table: "Decklist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardQuantity",
                table: "CardQuantity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardQuantity_Cards_CardId",
                table: "CardQuantity",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardQuantity_Decklist_DecklistId",
                table: "CardQuantity",
                column: "DecklistId",
                principalTable: "Decklist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardQuantity_User_UserId",
                table: "CardQuantity",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Decklist_User_UserId",
                table: "Decklist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Decklist_Visibilities_VisibilityId",
                table: "Decklist",
                column: "VisibilityId",
                principalTable: "Visibilities",
                principalColumn: "VisibilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
