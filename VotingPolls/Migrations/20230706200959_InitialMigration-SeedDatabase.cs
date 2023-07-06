using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VotingPolls.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationSeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingPolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalAnswers = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingPolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingPolls_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    VotingPollId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_VotingPolls_VotingPollId",
                        column: x => x.VotingPollId,
                        principalTable: "VotingPolls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VotingPollId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_VotingPolls_VotingPollId",
                        column: x => x.VotingPollId,
                        principalTable: "VotingPolls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VotingPollsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VotingPollId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingPollsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingPollsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotingPollsUsers_VotingPolls_VotingPollId",
                        column: x => x.VotingPollId,
                        principalTable: "VotingPolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VotingPollId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votes_AspNetUsers_VoterId",
                        column: x => x.VoterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_VotingPolls_VotingPollId",
                        column: x => x.VotingPollId,
                        principalTable: "VotingPolls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VotingPollsComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    VotingPollId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingPollsComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingPollsComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotingPollsComments_VotingPolls_VotingPollId",
                        column: x => x.VotingPollId,
                        principalTable: "VotingPolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1de47819-99ec-4882-800a-5277c4a58df4", 0, "d5088bcc-d9f6-40f1-be6f-14fd32b88d84", "Benedict1@mail.com", true, "Budapest", "Pumpkinpatch", false, null, "BENEDICT1@MAIL.COM", "BENEDICT1@MAIL.COM", "AQAAAAIAAYagAAAAEHz0QZMgc9wq6G86TnzBIWEm8NlQav6LPoatXr/bHfokWlHzzaFKSHn2RSJQE4Q1Ew==", null, false, "fef98c95-352c-4a76-aa4c-033de00956a2", false, "Benedict1@mail.com" },
                    { "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 0, "aff6c221-7ccd-4e9f-bd1b-fb655944b927", "Benedict5@mail.com", true, "Baseballbat", "Tennismatch", false, null, "BENEDICT5@MAIL.COM", "BENEDICT5@MAIL.COM", "AQAAAAIAAYagAAAAEB9T89jDtwBO6G2fV1uWtVegWHzxab7khhi/9kHO8JAB/FGjA9vlBJSfuccJfknx/A==", null, false, "3919884b-2987-4347-a67f-2a364d4d23c7", false, "Benedict5@mail.com" },
                    { "cb994c3c-a4d5-4540-af5a-dffea8451899", 0, "81f9fd2a-7ecb-4edc-b4b1-91136085ee8c", "Benedict4@mail.com", true, "Butternut", "Crinkle-Fries", false, null, "BENEDICT4@MAIL.COM", "BENEDICT4@MAIL.COM", "AQAAAAIAAYagAAAAEMycq811wkHchhEDSs70lfznrBjSMXBBsNspipEP46/f3nBbrHGumF8i+gQqcGztMQ==", null, false, "fb88ddab-1203-4d88-84d6-1d0c21386a11", false, "Benedict4@mail.com" },
                    { "d797574c-6e0a-483e-a639-73f3203c9f85", 0, "54eb74eb-dd81-48ba-beea-369013b44efb", "Benedict2@mail.com", true, "Beezlebub", "Wafflesmack", false, null, "BENEDICT2@MAIL.COM", "BENEDICT2@MAIL.COM", "AQAAAAIAAYagAAAAEBCLFvwBmX6wCAB9gVxAefUkotBEmMtLlf3B1eTI4PoTiO/F8q847YdN3EEgaOZtgQ==", null, false, "fc01d6f8-91d8-4335-9766-7a5cb783250e", false, "Benedict2@mail.com" },
                    { "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 0, "091cff7f-264f-4812-a247-06901d45488d", "Benedict3@mail.com", true, "Buckingham", "Ampersand", false, null, "BENEDICT3@MAIL.COM", "BENEDICT3@MAIL.COM", "AQAAAAIAAYagAAAAEGowfwB/uar6xP2RKUSmjjioXzgIRKRwiylDxbyHQbJKShsSHgyWoXtJQ3loPFEEEA==", null, false, "b8749102-c22c-498d-a6ca-40b438bdb02e", false, "Benedict3@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "VotingPolls",
                columns: new[] { "Id", "AdditionalAnswers", "DateCreated", "DateModified", "MultipleChoice", "Name", "OwnerId", "Question" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(5912), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6125), true, "Poll about dogs", "1de47819-99ec-4882-800a-5277c4a58df4", "Who let the dogs out?" },
                    { 2, true, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6135), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6139), false, "Very importart poll", "d797574c-6e0a-483e-a639-73f3203c9f85", "Which answer is correct?" },
                    { 3, false, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6145), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6168), true, "Philosophical poll", "f351991b-d3d7-4abd-a4c5-36337b91fbfd", "What is love?" },
                    { 4, false, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6181), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6185), false, "Tricky poll", "cb994c3c-a4d5-4540-af5a-dffea8451899", "Does it smell like updog in here?" },
                    { 5, true, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6191), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6195), false, "Simple poll", "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", "YES or NO?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AuthorId", "DateCreated", "DateModified", "Number", "Text", "VotingPollId" },
                values: new object[,]
                {
                    { 1, "1de47819-99ec-4882-800a-5277c4a58df4", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6338), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6344), 0, "Baha Men", 1 },
                    { 2, "1de47819-99ec-4882-800a-5277c4a58df4", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6352), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6356), 1, "I did", 1 },
                    { 3, "1de47819-99ec-4882-800a-5277c4a58df4", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6361), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6395), 2, "Nobody knows", 1 },
                    { 4, "d797574c-6e0a-483e-a639-73f3203c9f85", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6401), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6405), 0, "This one", 2 },
                    { 5, "d797574c-6e0a-483e-a639-73f3203c9f85", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6410), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6414), 1, "This one", 2 },
                    { 6, "d797574c-6e0a-483e-a639-73f3203c9f85", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6419), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6422), 2, "This one", 2 },
                    { 7, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6428), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6431), 0, "An intense feeling of deep affection", 3 },
                    { 8, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6437), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6440), 1, "Baby don't hurt me", 3 },
                    { 9, "cb994c3c-a4d5-4540-af5a-dffea8451899", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6446), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6450), 0, "What's updog?", 4 },
                    { 10, "cb994c3c-a4d5-4540-af5a-dffea8451899", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6647), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6661), 1, "Nice try!", 4 },
                    { 11, "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6728), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6733), 0, "Yes", 5 },
                    { 12, "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6738), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6742), 1, "No", 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "DateCreated", "DateModified", "Text", "VotingPollId" },
                values: new object[,]
                {
                    { 1, "1de47819-99ec-4882-800a-5277c4a58df4", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7038), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7044), "Simple indeed.", 5 },
                    { 2, "d797574c-6e0a-483e-a639-73f3203c9f85", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7050), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7054), "Haha, nice question!", 1 },
                    { 3, "1de47819-99ec-4882-800a-5277c4a58df4", new DateTime(2023, 7, 6, 22, 14, 59, 597, DateTimeKind.Local).AddTicks(7060), new DateTime(2023, 7, 6, 22, 14, 59, 597, DateTimeKind.Local).AddTicks(7066), "Thx man!", 1 },
                    { 4, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7073), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7077), "It was a difficult decision.", 2 },
                    { 5, "cb994c3c-a4d5-4540-af5a-dffea8451899", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7083), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7087), "I love this song.", 3 },
                    { 6, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", new DateTime(2023, 7, 6, 22, 14, 59, 597, DateTimeKind.Local).AddTicks(7092), new DateTime(2023, 7, 6, 22, 14, 59, 597, DateTimeKind.Local).AddTicks(7096), "Yeah, me too!", 3 },
                    { 7, "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7101), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(7105), "Nobody will fall for that.", 4 }
                });

            migrationBuilder.InsertData(
                table: "VotingPollsUsers",
                columns: new[] { "Id", "UserId", "VotingPollId" },
                values: new object[,]
                {
                    { 1, "1de47819-99ec-4882-800a-5277c4a58df4", 2 },
                    { 2, "1de47819-99ec-4882-800a-5277c4a58df4", 3 },
                    { 3, "1de47819-99ec-4882-800a-5277c4a58df4", 4 },
                    { 4, "1de47819-99ec-4882-800a-5277c4a58df4", 5 },
                    { 5, "d797574c-6e0a-483e-a639-73f3203c9f85", 1 },
                    { 6, "d797574c-6e0a-483e-a639-73f3203c9f85", 3 },
                    { 7, "d797574c-6e0a-483e-a639-73f3203c9f85", 4 },
                    { 8, "d797574c-6e0a-483e-a639-73f3203c9f85", 5 },
                    { 9, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 1 },
                    { 10, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 2 },
                    { 11, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 4 },
                    { 12, "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 5 },
                    { 13, "cb994c3c-a4d5-4540-af5a-dffea8451899", 1 },
                    { 14, "cb994c3c-a4d5-4540-af5a-dffea8451899", 2 },
                    { 15, "cb994c3c-a4d5-4540-af5a-dffea8451899", 3 },
                    { 16, "cb994c3c-a4d5-4540-af5a-dffea8451899", 5 },
                    { 17, "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 1 },
                    { 18, "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 2 },
                    { 19, "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 3 },
                    { 20, "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 4 }
                });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "AnswerId", "DateCreated", "DateModified", "VoterId", "VotingPollId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6798), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6804), "d797574c-6e0a-483e-a639-73f3203c9f85", 1 },
                    { 2, 2, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6810), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6814), "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 1 },
                    { 3, 3, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6819), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6823), "cb994c3c-a4d5-4540-af5a-dffea8451899", 1 },
                    { 4, 1, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6828), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6831), "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 1 },
                    { 5, 1, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6836), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6840), "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 1 },
                    { 6, 4, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6847), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6850), "d797574c-6e0a-483e-a639-73f3203c9f85", 2 },
                    { 7, 5, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6856), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6860), "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 2 },
                    { 8, 6, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6866), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6870), "cb994c3c-a4d5-4540-af5a-dffea8451899", 2 },
                    { 9, 6, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6875), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6879), "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 2 },
                    { 10, 8, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6885), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6889), "d797574c-6e0a-483e-a639-73f3203c9f85", 3 },
                    { 11, 7, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6894), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6897), "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 3 },
                    { 12, 8, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6903), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6907), "cb994c3c-a4d5-4540-af5a-dffea8451899", 3 },
                    { 13, 8, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6913), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6917), "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 3 },
                    { 14, 10, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6922), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6926), "d797574c-6e0a-483e-a639-73f3203c9f85", 4 },
                    { 15, 10, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6930), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6934), "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 4 },
                    { 16, 10, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6939), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6943), "cb994c3c-a4d5-4540-af5a-dffea8451899", 4 },
                    { 17, 10, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6948), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6951), "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 4 },
                    { 18, 11, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6956), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6960), "d797574c-6e0a-483e-a639-73f3203c9f85", 5 },
                    { 19, 11, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6965), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6969), "f351991b-d3d7-4abd-a4c5-36337b91fbfd", 5 },
                    { 20, 12, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6975), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6979), "cb994c3c-a4d5-4540-af5a-dffea8451899", 5 },
                    { 21, 12, new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6986), new DateTime(2023, 7, 6, 22, 9, 59, 597, DateTimeKind.Local).AddTicks(6990), "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AuthorId",
                table: "Answers",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_VotingPollId",
                table: "Answers",
                column: "VotingPollId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VotingPollId",
                table: "Comments",
                column: "VotingPollId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_AnswerId",
                table: "Votes",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId",
                table: "Votes",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotingPollId",
                table: "Votes",
                column: "VotingPollId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingPolls_OwnerId",
                table: "VotingPolls",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingPollsComments_CommentId",
                table: "VotingPollsComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingPollsComments_VotingPollId",
                table: "VotingPollsComments",
                column: "VotingPollId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingPollsUsers_UserId",
                table: "VotingPollsUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingPollsUsers_VotingPollId",
                table: "VotingPollsUsers",
                column: "VotingPollId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "VotingPollsComments");

            migrationBuilder.DropTable(
                name: "VotingPollsUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "VotingPolls");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
