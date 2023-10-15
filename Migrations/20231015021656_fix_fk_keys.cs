using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Wall.Migrations
{
    public partial class fix_fk_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_userCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userMessageId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "userMessageId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userCommentId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_userCommentId",
                table: "Comments",
                column: "userCommentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_userMessageId",
                table: "Messages",
                column: "userMessageId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_userCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userMessageId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "userMessageId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userCommentId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_userCommentId",
                table: "Comments",
                column: "userCommentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_userMessageId",
                table: "Messages",
                column: "userMessageId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
