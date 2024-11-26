using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnTedu.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BPAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BPSizes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPSizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrgnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicTradNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllArea = table.Column<bool>(type: "bit", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllBrand = table.Column<bool>(type: "bit", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllItemType = table.Column<bool>(type: "bit", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllIndustry = table.Column<bool>(type: "bit", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllPacking = table.Column<bool>(type: "bit", nullable: false),
                    Packing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllBPArea = table.Column<bool>(type: "bit", nullable: false),
                    BPArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllBPSize = table.Column<bool>(type: "bit", nullable: true),
                    BPSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CrD1s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPID = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrD1s", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrD1s_Customers_BPID",
                        column: x => x.BPID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrD2s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrD2s", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrD2s_Customers_BPID",
                        column: x => x.BPID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrD3s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrD3s", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrD3s_Customers_BPID",
                        column: x => x.BPID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrD4s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysOverdue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountOverdue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrD4s", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrD4s_Customers_BPID",
                        column: x => x.BPID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrD5s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPID = table.Column<int>(type: "int", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrD5s", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrD5s_Customers_BPID",
                        column: x => x.BPID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrD1s_BPID",
                table: "CrD1s",
                column: "BPID");

            migrationBuilder.CreateIndex(
                name: "IX_CrD2s_BPID",
                table: "CrD2s",
                column: "BPID");

            migrationBuilder.CreateIndex(
                name: "IX_CrD3s_BPID",
                table: "CrD3s",
                column: "BPID");

            migrationBuilder.CreateIndex(
                name: "IX_CrD4s_BPID",
                table: "CrD4s",
                column: "BPID");

            migrationBuilder.CreateIndex(
                name: "IX_CrD5s_BPID",
                table: "CrD5s",
                column: "BPID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BPAreas");

            migrationBuilder.DropTable(
                name: "BPSizes");

            migrationBuilder.DropTable(
                name: "CrD1s");

            migrationBuilder.DropTable(
                name: "CrD2s");

            migrationBuilder.DropTable(
                name: "CrD3s");

            migrationBuilder.DropTable(
                name: "CrD4s");

            migrationBuilder.DropTable(
                name: "CrD5s");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
