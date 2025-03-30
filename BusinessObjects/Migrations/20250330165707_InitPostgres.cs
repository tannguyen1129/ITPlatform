using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class InitPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageID = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Field = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    WebsiteURL = table.Column<string>(type: "text", nullable: true),
                    TaxID = table.Column<string>(type: "text", nullable: true),
                    AccountID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    FreelancerID = table.Column<string>(type: "text", nullable: false),
                    CIN = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    AccountID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.FreelancerID);
                    table.ForeignKey(
                        name: "FK_Freelancers_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ClientID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BudgetMin = table.Column<double>(type: "double precision", nullable: false),
                    BudgetMax = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ClientID = table.Column<string>(type: "text", nullable: false),
                    ClientID1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID1",
                        column: x => x.ClientID1,
                        principalTable: "Clients",
                        principalColumn: "ClientID");
                });

            migrationBuilder.CreateTable(
                name: "ExpertiseProfiles",
                columns: table => new
                {
                    ProfileID = table.Column<string>(type: "text", nullable: false),
                    Field = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PortfolioURL = table.Column<string>(type: "text", nullable: false),
                    FreelancerID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertiseProfiles", x => x.ProfileID);
                    table.ForeignKey(
                        name: "FK_ExpertiseProfiles_Freelancers_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "Freelancers",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionID = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FreelancerID = table.Column<string>(type: "text", nullable: true),
                    ClientID = table.Column<string>(type: "text", nullable: true),
                    PackageID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionID);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID");
                    table.ForeignKey(
                        name: "FK_Subscriptions_Freelancers_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "Freelancers",
                        principalColumn: "FreelancerID");
                    table.ForeignKey(
                        name: "FK_Subscriptions_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "PackageID");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<string>(type: "text", nullable: false),
                    CV = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    FreelancerID = table.Column<string>(type: "text", nullable: false),
                    ProjectID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Applications_Freelancers_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "Freelancers",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    MilestoneID = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ProjectID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => x.MilestoneID);
                    table.ForeignKey(
                        name: "FK_Milestones_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillRequirements",
                columns: table => new
                {
                    SkillRequirementID = table.Column<string>(type: "text", nullable: false),
                    ProficiencyLevel = table.Column<string>(type: "text", nullable: false),
                    SkillID = table.Column<string>(type: "text", nullable: false),
                    ProjectID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillRequirements", x => x.SkillRequirementID);
                    table.ForeignKey(
                        name: "FK_SkillRequirements_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillRequirements_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    CertID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Issuer = table.Column<string>(type: "text", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CertURL = table.Column<string>(type: "text", nullable: false),
                    ProfileID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.CertID);
                    table.ForeignKey(
                        name: "FK_Certifications_ExpertiseProfiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "ExpertiseProfiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillInProfiles",
                columns: table => new
                {
                    SkillInProfileID = table.Column<string>(type: "text", nullable: false),
                    ProficiencyLevel = table.Column<string>(type: "text", nullable: false),
                    SkillID = table.Column<string>(type: "text", nullable: false),
                    ProfileID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillInProfiles", x => x.SkillInProfileID);
                    table.ForeignKey(
                        name: "FK_SkillInProfiles_ExpertiseProfiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "ExpertiseProfiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillInProfiles_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submittions",
                columns: table => new
                {
                    SubmittionID = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    FreelancerID = table.Column<string>(type: "text", nullable: false),
                    MilestoneID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submittions", x => x.SubmittionID);
                    table.ForeignKey(
                        name: "FK_Submittions_Freelancers_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "Freelancers",
                        principalColumn: "FreelancerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submittions_Milestones_MilestoneID",
                        column: x => x.MilestoneID,
                        principalTable: "Milestones",
                        principalColumn: "MilestoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_FreelancerID",
                table: "Applications",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ProjectID",
                table: "Applications",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_ProfileID",
                table: "Certifications",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AccountID",
                table: "Clients",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseProfiles_FreelancerID",
                table: "ExpertiseProfiles",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_AccountID",
                table: "Freelancers",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ClientID",
                table: "Locations",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Milestones_ProjectID",
                table: "Milestones",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID1",
                table: "Projects",
                column: "ClientID1");

            migrationBuilder.CreateIndex(
                name: "IX_SkillInProfiles_ProfileID",
                table: "SkillInProfiles",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillInProfiles_SkillID",
                table: "SkillInProfiles",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillRequirements_ProjectID",
                table: "SkillRequirements",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillRequirements_SkillID",
                table: "SkillRequirements",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Submittions_FreelancerID",
                table: "Submittions",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Submittions_MilestoneID",
                table: "Submittions",
                column: "MilestoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ClientID",
                table: "Subscriptions",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_FreelancerID",
                table: "Subscriptions",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PackageID",
                table: "Subscriptions",
                column: "PackageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "SkillInProfiles");

            migrationBuilder.DropTable(
                name: "SkillRequirements");

            migrationBuilder.DropTable(
                name: "Submittions");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "ExpertiseProfiles");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Milestones");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Freelancers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
