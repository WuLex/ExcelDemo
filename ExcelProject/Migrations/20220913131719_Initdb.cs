using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelProject.Migrations
{
    public partial class Initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tActivities",
                columns: table => new
                {
                    fActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fDMPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tActivities", x => x.fActivityID);
                });

            migrationBuilder.CreateTable(
                name: "tCategories",
                columns: table => new
                {
                    fCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCategories", x => x.fCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tCities",
                columns: table => new
                {
                    fCityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCities", x => x.fCityID);
                });

            migrationBuilder.CreateTable(
                name: "tEmployees",
                columns: table => new
                {
                    fEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tEmployees", x => x.fEmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "tLogInWays",
                columns: table => new
                {
                    fLogInWayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tLogInWays", x => x.fLogInWayID);
                });

            migrationBuilder.CreateTable(
                name: "tPayWays",
                columns: table => new
                {
                    fPayWayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPayWays", x => x.fPayWayID);
                });

            migrationBuilder.CreateTable(
                name: "tPetClasses",
                columns: table => new
                {
                    fPetClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPetClasses", x => x.fPetClassID);
                });

            migrationBuilder.CreateTable(
                name: "tPurchases",
                columns: table => new
                {
                    fPurchaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fPurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPurchases", x => x.fPurchaseID);
                });

            migrationBuilder.CreateTable(
                name: "tReplies",
                columns: table => new
                {
                    fReplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fArticleID = table.Column<int>(type: "int", nullable: false),
                    fMemberID = table.Column<int>(type: "int", nullable: false),
                    fContext = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tReplies", x => x.fReplyID);
                });

            migrationBuilder.CreateTable(
                name: "tShipVias",
                columns: table => new
                {
                    fShipViaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tShipVias", x => x.fShipViaID);
                });

            migrationBuilder.CreateTable(
                name: "tRegions",
                columns: table => new
                {
                    fRegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCityID = table.Column<int>(type: "int", nullable: false),
                    tCityfCityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tRegions", x => x.fRegionID);
                    table.ForeignKey(
                        name: "FK_tRegions_tCities_tCityfCityID",
                        column: x => x.tCityfCityID,
                        principalTable: "tCities",
                        principalColumn: "fCityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tBreeds",
                columns: table => new
                {
                    fBreedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPetClassID = table.Column<int>(type: "int", nullable: false),
                    fPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tPetClassfPetClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tBreeds", x => x.fBreedID);
                    table.ForeignKey(
                        name: "FK_tBreeds_tPetClasses_tPetClassfPetClassID",
                        column: x => x.tPetClassfPetClassID,
                        principalTable: "tPetClasses",
                        principalColumn: "fPetClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tMembers",
                columns: table => new
                {
                    fMemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fIDCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fNickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fEnconomicStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fEMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fLogInWayID = table.Column<int>(type: "int", nullable: true),
                    fIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fRecentLogInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fCityID = table.Column<int>(type: "int", nullable: false),
                    fRegionID = table.Column<int>(type: "int", nullable: false),
                    fAddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPetCoin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    tCityfCityID = table.Column<int>(type: "int", nullable: false),
                    tRegionfRegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tMembers", x => x.fMemberID);
                    table.ForeignKey(
                        name: "FK_tMembers_tCities_tCityfCityID",
                        column: x => x.tCityfCityID,
                        principalTable: "tCities",
                        principalColumn: "fCityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tMembers_tRegions_tRegionfRegionID",
                        column: x => x.tRegionfRegionID,
                        principalTable: "tRegions",
                        principalColumn: "fRegionID");
                });

            migrationBuilder.CreateTable(
                name: "tSuppliers",
                columns: table => new
                {
                    fSupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCityID = table.Column<int>(type: "int", nullable: false),
                    fRegionID = table.Column<int>(type: "int", nullable: false),
                    fPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tCityfCityID = table.Column<int>(type: "int", nullable: false),
                    tRegionfRegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tSuppliers", x => x.fSupplierID);
                    table.ForeignKey(
                        name: "FK_tSuppliers_tCities_tCityfCityID",
                        column: x => x.tCityfCityID,
                        principalTable: "tCities",
                        principalColumn: "fCityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tSuppliers_tRegions_tRegionfRegionID",
                        column: x => x.tRegionfRegionID,
                        principalTable: "tRegions",
                        principalColumn: "fRegionID");
                });

            migrationBuilder.CreateTable(
                name: "tDiscussions",
                columns: table => new
                {
                    fArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fMemberID = table.Column<int>(type: "int", nullable: true),
                    fContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fDiscussionClassID = table.Column<int>(type: "int", nullable: false),
                    fTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCommenttime = table.Column<int>(type: "int", nullable: true),
                    fReportcheck = table.Column<bool>(type: "bit", nullable: true),
                    fLike = table.Column<int>(type: "int", nullable: true),
                    fLock = table.Column<bool>(type: "bit", nullable: true),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tDiscussions", x => x.fArticleID);
                    table.ForeignKey(
                        name: "FK_tDiscussions_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tFoundPets",
                columns: table => new
                {
                    fFoundPetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fMemberID = table.Column<int>(type: "int", nullable: true),
                    fStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fFoundTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPetClassID = table.Column<int>(type: "int", nullable: false),
                    fBreedID = table.Column<int>(type: "int", nullable: false),
                    fPetPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fSkin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCollar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fChipID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCityID = table.Column<int>(type: "int", nullable: false),
                    fRegionID = table.Column<int>(type: "int", nullable: false),
                    fRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fSignInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tBreedfBreedID = table.Column<int>(type: "int", nullable: false),
                    tCityfCityID = table.Column<int>(type: "int", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false),
                    tPetClassfPetClassID = table.Column<int>(type: "int", nullable: false),
                    tRegionfRegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tFoundPets", x => x.fFoundPetID);
                    table.ForeignKey(
                        name: "FK_tFoundPets_tBreeds_tBreedfBreedID",
                        column: x => x.tBreedfBreedID,
                        principalTable: "tBreeds",
                        principalColumn: "fBreedID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tFoundPets_tCities_tCityfCityID",
                        column: x => x.tCityfCityID,
                        principalTable: "tCities",
                        principalColumn: "fCityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tFoundPets_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                    table.ForeignKey(
                        name: "FK_tFoundPets_tPetClasses_tPetClassfPetClassID",
                        column: x => x.tPetClassfPetClassID,
                        principalTable: "tPetClasses",
                        principalColumn: "fPetClassID");
                    table.ForeignKey(
                        name: "FK_tFoundPets_tRegions_tRegionfRegionID",
                        column: x => x.tRegionfRegionID,
                        principalTable: "tRegions",
                        principalColumn: "fRegionID");
                });

            migrationBuilder.CreateTable(
                name: "tOrders",
                columns: table => new
                {
                    fOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fMemberID = table.Column<int>(type: "int", nullable: false),
                    fOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fShipOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fReceiverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCityID = table.Column<int>(type: "int", nullable: false),
                    fRegionID = table.Column<int>(type: "int", nullable: false),
                    fAddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fReceiverMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPayWayID = table.Column<int>(type: "int", nullable: false),
                    fStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tCityfCityID = table.Column<int>(type: "int", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false),
                    tPayWayfPayWayID = table.Column<int>(type: "int", nullable: false),
                    tRegionfRegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tOrders", x => x.fOrderID);
                    table.ForeignKey(
                        name: "FK_tOrders_tCities_tCityfCityID",
                        column: x => x.tCityfCityID,
                        principalTable: "tCities",
                        principalColumn: "fCityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tOrders_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                    table.ForeignKey(
                        name: "FK_tOrders_tPayWays_tPayWayfPayWayID",
                        column: x => x.tPayWayfPayWayID,
                        principalTable: "tPayWays",
                        principalColumn: "fPayWayID");
                    table.ForeignKey(
                        name: "FK_tOrders_tRegions_tRegionfRegionID",
                        column: x => x.tRegionfRegionID,
                        principalTable: "tRegions",
                        principalColumn: "fRegionID");
                });

            migrationBuilder.CreateTable(
                name: "tPetMembers",
                columns: table => new
                {
                    fPetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fMemberID = table.Column<int>(type: "int", nullable: false),
                    fPetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPetClassID = table.Column<int>(type: "int", nullable: false),
                    fBreedID = table.Column<int>(type: "int", nullable: false),
                    fCityID = table.Column<int>(type: "int", nullable: false),
                    fRegionID = table.Column<int>(type: "int", nullable: false),
                    fPetPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fChipID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCollar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fSkin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tBreedfBreedID = table.Column<int>(type: "int", nullable: false),
                    tCityfCityID = table.Column<int>(type: "int", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false),
                    tPetClassfPetClassID = table.Column<int>(type: "int", nullable: false),
                    tRegionfRegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPetMembers", x => x.fPetID);
                    table.ForeignKey(
                        name: "FK_tPetMembers_tBreeds_tBreedfBreedID",
                        column: x => x.tBreedfBreedID,
                        principalTable: "tBreeds",
                        principalColumn: "fBreedID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tPetMembers_tCities_tCityfCityID",
                        column: x => x.tCityfCityID,
                        principalTable: "tCities",
                        principalColumn: "fCityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tPetMembers_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                    table.ForeignKey(
                        name: "FK_tPetMembers_tPetClasses_tPetClassfPetClassID",
                        column: x => x.tPetClassfPetClassID,
                        principalTable: "tPetClasses",
                        principalColumn: "fPetClassID");
                    table.ForeignKey(
                        name: "FK_tPetMembers_tRegions_tRegionfRegionID",
                        column: x => x.tRegionfRegionID,
                        principalTable: "tRegions",
                        principalColumn: "fRegionID");
                });

            migrationBuilder.CreateTable(
                name: "tProducts",
                columns: table => new
                {
                    fProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCategoryID = table.Column<int>(type: "int", nullable: false),
                    fUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fUnitOnOrder = table.Column<int>(type: "int", nullable: false),
                    fUnitInStock = table.Column<int>(type: "int", nullable: false),
                    fOnShelfDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fSupplierID = table.Column<int>(type: "int", nullable: false),
                    fSafeStock = table.Column<int>(type: "int", nullable: false),
                    fDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tCategoryfCategoryID = table.Column<int>(type: "int", nullable: false),
                    tSupplierfSupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tProducts", x => x.fProductID);
                    table.ForeignKey(
                        name: "FK_tProducts_tCategories_tCategoryfCategoryID",
                        column: x => x.tCategoryfCategoryID,
                        principalTable: "tCategories",
                        principalColumn: "fCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tProducts_tSuppliers_tSupplierfSupplierID",
                        column: x => x.tSupplierfSupplierID,
                        principalTable: "tSuppliers",
                        principalColumn: "fSupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tComments",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fMemberID = table.Column<int>(type: "int", nullable: true),
                    fContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fArticleID = table.Column<int>(type: "int", nullable: true),
                    tDiscussionfArticleID = table.Column<int>(type: "int", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tComments", x => x.fId);
                    table.ForeignKey(
                        name: "FK_tComments_tDiscussions_tDiscussionfArticleID",
                        column: x => x.tDiscussionfArticleID,
                        principalTable: "tDiscussions",
                        principalColumn: "fArticleID");
                    table.ForeignKey(
                        name: "FK_tComments_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                });

            migrationBuilder.CreateTable(
                name: "tFavorites",
                columns: table => new
                {
                    fFavoriteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fMemberID = table.Column<int>(type: "int", nullable: true),
                    fArticleID = table.Column<int>(type: "int", nullable: true),
                    tDiscussionfArticleID = table.Column<int>(type: "int", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tFavorites", x => x.fFavoriteID);
                    table.ForeignKey(
                        name: "FK_tFavorites_tDiscussions_tDiscussionfArticleID",
                        column: x => x.tDiscussionfArticleID,
                        principalTable: "tDiscussions",
                        principalColumn: "fArticleID");
                    table.ForeignKey(
                        name: "FK_tFavorites_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                });

            migrationBuilder.CreateTable(
                name: "tLikes",
                columns: table => new
                {
                    fLikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fArticleID = table.Column<int>(type: "int", nullable: true),
                    fMemberID = table.Column<int>(type: "int", nullable: true),
                    tDiscussionfArticleID = table.Column<int>(type: "int", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tLikes", x => x.fLikeID);
                    table.ForeignKey(
                        name: "FK_tLikes_tDiscussions_tDiscussionfArticleID",
                        column: x => x.tDiscussionfArticleID,
                        principalTable: "tDiscussions",
                        principalColumn: "fArticleID");
                    table.ForeignKey(
                        name: "FK_tLikes_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                });

            migrationBuilder.CreateTable(
                name: "tReports",
                columns: table => new
                {
                    fReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fArticleID = table.Column<int>(type: "int", nullable: false),
                    fMemberID = table.Column<int>(type: "int", nullable: false),
                    fReportComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tDiscussionfArticleID = table.Column<int>(type: "int", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tReports", x => x.fReportID);
                    table.ForeignKey(
                        name: "FK_tReports_tDiscussions_tDiscussionfArticleID",
                        column: x => x.tDiscussionfArticleID,
                        principalTable: "tDiscussions",
                        principalColumn: "fArticleID");
                    table.ForeignKey(
                        name: "FK_tReports_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                });

            migrationBuilder.CreateTable(
                name: "tAdoptMessages",
                columns: table => new
                {
                    fMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fPetID = table.Column<int>(type: "int", nullable: false),
                    fMemberID = table.Column<int>(type: "int", nullable: false),
                    fContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false),
                    tPetMemberfPetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAdoptMessages", x => x.fMessageID);
                    table.ForeignKey(
                        name: "FK_tAdoptMessages_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                    table.ForeignKey(
                        name: "FK_tAdoptMessages_tPetMembers_tPetMemberfPetID",
                        column: x => x.tPetMemberfPetID,
                        principalTable: "tPetMembers",
                        principalColumn: "fPetID");
                });

            migrationBuilder.CreateTable(
                name: "tLostPets",
                columns: table => new
                {
                    fLostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fPetID = table.Column<int>(type: "int", nullable: false),
                    fLostPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fLostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fReward = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fCompareLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fSignInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tPetMemberfPetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tLostPets", x => x.fLostID);
                    table.ForeignKey(
                        name: "FK_tLostPets_tPetMembers_tPetMemberfPetID",
                        column: x => x.tPetMemberfPetID,
                        principalTable: "tPetMembers",
                        principalColumn: "fPetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tOrder_Detail",
                columns: table => new
                {
                    fOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fQuantity = table.Column<int>(type: "int", nullable: false),
                    fPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tOrderfOrderID = table.Column<int>(type: "int", nullable: false),
                    tProductfProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tOrder_Detail", x => x.fOrderID);
                    table.ForeignKey(
                        name: "FK_tOrder_Detail_tOrders_tOrderfOrderID",
                        column: x => x.tOrderfOrderID,
                        principalTable: "tOrders",
                        principalColumn: "fOrderID");
                    table.ForeignKey(
                        name: "FK_tOrder_Detail_tProducts_tProductfProductID",
                        column: x => x.tProductfProductID,
                        principalTable: "tProducts",
                        principalColumn: "fProductID");
                });

            migrationBuilder.CreateTable(
                name: "tPurchase_Detials",
                columns: table => new
                {
                    fPurchaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fQuantity = table.Column<int>(type: "int", nullable: false),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fSupplierID = table.Column<int>(type: "int", nullable: false),
                    tProductfProductID = table.Column<int>(type: "int", nullable: false),
                    tPurchasefPurchaseID = table.Column<int>(type: "int", nullable: false),
                    tSupplierfSupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPurchase_Detials", x => x.fPurchaseID);
                    table.ForeignKey(
                        name: "FK_tPurchase_Detials_tProducts_tProductfProductID",
                        column: x => x.tProductfProductID,
                        principalTable: "tProducts",
                        principalColumn: "fProductID");
                    table.ForeignKey(
                        name: "FK_tPurchase_Detials_tPurchases_tPurchasefPurchaseID",
                        column: x => x.tPurchasefPurchaseID,
                        principalTable: "tPurchases",
                        principalColumn: "fPurchaseID");
                    table.ForeignKey(
                        name: "FK_tPurchase_Detials_tSuppliers_tSupplierfSupplierID",
                        column: x => x.tSupplierfSupplierID,
                        principalTable: "tSuppliers",
                        principalColumn: "fSupplierID");
                });

            migrationBuilder.CreateTable(
                name: "tPurchaseShoppingCarts",
                columns: table => new
                {
                    fCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fSupplierID = table.Column<int>(type: "int", nullable: false),
                    fUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fQuantity = table.Column<int>(type: "int", nullable: false),
                    fPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tProductfProductID = table.Column<int>(type: "int", nullable: false),
                    tSupplierfSupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPurchaseShoppingCarts", x => x.fCartID);
                    table.ForeignKey(
                        name: "FK_tPurchaseShoppingCarts_tProducts_tProductfProductID",
                        column: x => x.tProductfProductID,
                        principalTable: "tProducts",
                        principalColumn: "fProductID");
                    table.ForeignKey(
                        name: "FK_tPurchaseShoppingCarts_tSuppliers_tSupplierfSupplierID",
                        column: x => x.tSupplierfSupplierID,
                        principalTable: "tSuppliers",
                        principalColumn: "fSupplierID");
                });

            migrationBuilder.CreateTable(
                name: "tShoppingCarts",
                columns: table => new
                {
                    fCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fMemberID = table.Column<int>(type: "int", nullable: false),
                    fUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fQuantity = table.Column<int>(type: "int", nullable: false),
                    fPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tMemberfMemberID = table.Column<int>(type: "int", nullable: false),
                    tProductfProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tShoppingCarts", x => x.fCartID);
                    table.ForeignKey(
                        name: "FK_tShoppingCarts_tMembers_tMemberfMemberID",
                        column: x => x.tMemberfMemberID,
                        principalTable: "tMembers",
                        principalColumn: "fMemberID");
                    table.ForeignKey(
                        name: "FK_tShoppingCarts_tProducts_tProductfProductID",
                        column: x => x.tProductfProductID,
                        principalTable: "tProducts",
                        principalColumn: "fProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tAdoptMessages_tMemberfMemberID",
                table: "tAdoptMessages",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tAdoptMessages_tPetMemberfPetID",
                table: "tAdoptMessages",
                column: "tPetMemberfPetID");

            migrationBuilder.CreateIndex(
                name: "IX_tBreeds_tPetClassfPetClassID",
                table: "tBreeds",
                column: "tPetClassfPetClassID");

            migrationBuilder.CreateIndex(
                name: "IX_tComments_tDiscussionfArticleID",
                table: "tComments",
                column: "tDiscussionfArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_tComments_tMemberfMemberID",
                table: "tComments",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tDiscussions_tMemberfMemberID",
                table: "tDiscussions",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tFavorites_tDiscussionfArticleID",
                table: "tFavorites",
                column: "tDiscussionfArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_tFavorites_tMemberfMemberID",
                table: "tFavorites",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tFoundPets_tBreedfBreedID",
                table: "tFoundPets",
                column: "tBreedfBreedID");

            migrationBuilder.CreateIndex(
                name: "IX_tFoundPets_tCityfCityID",
                table: "tFoundPets",
                column: "tCityfCityID");

            migrationBuilder.CreateIndex(
                name: "IX_tFoundPets_tMemberfMemberID",
                table: "tFoundPets",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tFoundPets_tPetClassfPetClassID",
                table: "tFoundPets",
                column: "tPetClassfPetClassID");

            migrationBuilder.CreateIndex(
                name: "IX_tFoundPets_tRegionfRegionID",
                table: "tFoundPets",
                column: "tRegionfRegionID");

            migrationBuilder.CreateIndex(
                name: "IX_tLikes_tDiscussionfArticleID",
                table: "tLikes",
                column: "tDiscussionfArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_tLikes_tMemberfMemberID",
                table: "tLikes",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tLostPets_tPetMemberfPetID",
                table: "tLostPets",
                column: "tPetMemberfPetID");

            migrationBuilder.CreateIndex(
                name: "IX_tMembers_tCityfCityID",
                table: "tMembers",
                column: "tCityfCityID");

            migrationBuilder.CreateIndex(
                name: "IX_tMembers_tRegionfRegionID",
                table: "tMembers",
                column: "tRegionfRegionID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrder_Detail_tOrderfOrderID",
                table: "tOrder_Detail",
                column: "tOrderfOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrder_Detail_tProductfProductID",
                table: "tOrder_Detail",
                column: "tProductfProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrders_tCityfCityID",
                table: "tOrders",
                column: "tCityfCityID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrders_tMemberfMemberID",
                table: "tOrders",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrders_tPayWayfPayWayID",
                table: "tOrders",
                column: "tPayWayfPayWayID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrders_tRegionfRegionID",
                table: "tOrders",
                column: "tRegionfRegionID");

            migrationBuilder.CreateIndex(
                name: "IX_tPetMembers_tBreedfBreedID",
                table: "tPetMembers",
                column: "tBreedfBreedID");

            migrationBuilder.CreateIndex(
                name: "IX_tPetMembers_tCityfCityID",
                table: "tPetMembers",
                column: "tCityfCityID");

            migrationBuilder.CreateIndex(
                name: "IX_tPetMembers_tMemberfMemberID",
                table: "tPetMembers",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tPetMembers_tPetClassfPetClassID",
                table: "tPetMembers",
                column: "tPetClassfPetClassID");

            migrationBuilder.CreateIndex(
                name: "IX_tPetMembers_tRegionfRegionID",
                table: "tPetMembers",
                column: "tRegionfRegionID");

            migrationBuilder.CreateIndex(
                name: "IX_tProducts_tCategoryfCategoryID",
                table: "tProducts",
                column: "tCategoryfCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tProducts_tSupplierfSupplierID",
                table: "tProducts",
                column: "tSupplierfSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tPurchase_Detials_tProductfProductID",
                table: "tPurchase_Detials",
                column: "tProductfProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tPurchase_Detials_tPurchasefPurchaseID",
                table: "tPurchase_Detials",
                column: "tPurchasefPurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_tPurchase_Detials_tSupplierfSupplierID",
                table: "tPurchase_Detials",
                column: "tSupplierfSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tPurchaseShoppingCarts_tProductfProductID",
                table: "tPurchaseShoppingCarts",
                column: "tProductfProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tPurchaseShoppingCarts_tSupplierfSupplierID",
                table: "tPurchaseShoppingCarts",
                column: "tSupplierfSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tRegions_tCityfCityID",
                table: "tRegions",
                column: "tCityfCityID");

            migrationBuilder.CreateIndex(
                name: "IX_tReports_tDiscussionfArticleID",
                table: "tReports",
                column: "tDiscussionfArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_tReports_tMemberfMemberID",
                table: "tReports",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tShoppingCarts_tMemberfMemberID",
                table: "tShoppingCarts",
                column: "tMemberfMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_tShoppingCarts_tProductfProductID",
                table: "tShoppingCarts",
                column: "tProductfProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tSuppliers_tCityfCityID",
                table: "tSuppliers",
                column: "tCityfCityID");

            migrationBuilder.CreateIndex(
                name: "IX_tSuppliers_tRegionfRegionID",
                table: "tSuppliers",
                column: "tRegionfRegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tActivities");

            migrationBuilder.DropTable(
                name: "tAdoptMessages");

            migrationBuilder.DropTable(
                name: "tComments");

            migrationBuilder.DropTable(
                name: "tEmployees");

            migrationBuilder.DropTable(
                name: "tFavorites");

            migrationBuilder.DropTable(
                name: "tFoundPets");

            migrationBuilder.DropTable(
                name: "tLikes");

            migrationBuilder.DropTable(
                name: "tLogInWays");

            migrationBuilder.DropTable(
                name: "tLostPets");

            migrationBuilder.DropTable(
                name: "tOrder_Detail");

            migrationBuilder.DropTable(
                name: "tPurchase_Detials");

            migrationBuilder.DropTable(
                name: "tPurchaseShoppingCarts");

            migrationBuilder.DropTable(
                name: "tReplies");

            migrationBuilder.DropTable(
                name: "tReports");

            migrationBuilder.DropTable(
                name: "tShipVias");

            migrationBuilder.DropTable(
                name: "tShoppingCarts");

            migrationBuilder.DropTable(
                name: "tPetMembers");

            migrationBuilder.DropTable(
                name: "tOrders");

            migrationBuilder.DropTable(
                name: "tPurchases");

            migrationBuilder.DropTable(
                name: "tDiscussions");

            migrationBuilder.DropTable(
                name: "tProducts");

            migrationBuilder.DropTable(
                name: "tBreeds");

            migrationBuilder.DropTable(
                name: "tPayWays");

            migrationBuilder.DropTable(
                name: "tMembers");

            migrationBuilder.DropTable(
                name: "tCategories");

            migrationBuilder.DropTable(
                name: "tSuppliers");

            migrationBuilder.DropTable(
                name: "tPetClasses");

            migrationBuilder.DropTable(
                name: "tRegions");

            migrationBuilder.DropTable(
                name: "tCities");
        }
    }
}
