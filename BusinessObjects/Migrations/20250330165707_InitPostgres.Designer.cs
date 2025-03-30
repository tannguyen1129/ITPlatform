﻿// <auto-generated />
using System;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20250330165707_InitPostgres")]
    partial class InitPostgres
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.Account", b =>
                {
                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BusinessObjects.Application", b =>
                {
                    b.Property<string>("ApplicationID")
                        .HasColumnType("text");

                    b.Property<string>("CV")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FreelancerID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ApplicationID");

                    b.HasIndex("FreelancerID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("BusinessObjects.Certification", b =>
                {
                    b.Property<string>("CertID")
                        .HasColumnType("text");

                    b.Property<string>("CertURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Issuer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CertID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("BusinessObjects.Client", b =>
                {
                    b.Property<string>("ClientID")
                        .HasColumnType("text");

                    b.Property<string>("AccountID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Field")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("TaxID")
                        .HasColumnType("text");

                    b.Property<string>("WebsiteURL")
                        .HasColumnType("text");

                    b.HasKey("ClientID");

                    b.HasIndex("AccountID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BusinessObjects.ExpertiseProfile", b =>
                {
                    b.Property<string>("ProfileID")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FreelancerID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PortfolioURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProfileID");

                    b.HasIndex("FreelancerID");

                    b.ToTable("ExpertiseProfiles");
                });

            modelBuilder.Entity("BusinessObjects.Freelancer", b =>
                {
                    b.Property<string>("FreelancerID")
                        .HasColumnType("text");

                    b.Property<string>("AccountID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CIN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FreelancerID");

                    b.HasIndex("AccountID");

                    b.ToTable("Freelancers");
                });

            modelBuilder.Entity("BusinessObjects.Location", b =>
                {
                    b.Property<string>("LocationID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LocationID");

                    b.HasIndex("ClientID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BusinessObjects.Milestone", b =>
                {
                    b.Property<string>("MilestoneID")
                        .HasColumnType("text");

                    b.Property<double>("Budget")
                        .HasColumnType("double precision");

                    b.Property<string>("ProjectID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MilestoneID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("BusinessObjects.Package", b =>
                {
                    b.Property<string>("PackageID")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Period")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PackageID");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("BusinessObjects.Project", b =>
                {
                    b.Property<string>("ProjectID")
                        .HasColumnType("text");

                    b.Property<double>("BudgetMax")
                        .HasColumnType("double precision");

                    b.Property<double>("BudgetMin")
                        .HasColumnType("double precision");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientID1")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ProjectID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ClientID1");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BusinessObjects.Skill", b =>
                {
                    b.Property<string>("SkillID")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SkillID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("BusinessObjects.SkillInProfile", b =>
                {
                    b.Property<string>("SkillInProfileID")
                        .HasColumnType("text");

                    b.Property<string>("ProficiencyLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SkillID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SkillInProfileID");

                    b.HasIndex("ProfileID");

                    b.HasIndex("SkillID");

                    b.ToTable("SkillInProfiles");
                });

            modelBuilder.Entity("BusinessObjects.SkillRequirement", b =>
                {
                    b.Property<string>("SkillRequirementID")
                        .HasColumnType("text");

                    b.Property<string>("ProficiencyLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SkillID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SkillRequirementID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("SkillID");

                    b.ToTable("SkillRequirements");
                });

            modelBuilder.Entity("BusinessObjects.Submittion", b =>
                {
                    b.Property<string>("SubmittionID")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FreelancerID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MilestoneID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubmittionID");

                    b.HasIndex("FreelancerID");

                    b.HasIndex("MilestoneID");

                    b.ToTable("Submittions");
                });

            modelBuilder.Entity("BusinessObjects.Subscription", b =>
                {
                    b.Property<string>("SubscriptionID")
                        .HasColumnType("text");

                    b.Property<string>("ClientID")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FreelancerID")
                        .HasColumnType("text");

                    b.Property<string>("PackageID")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SubscriptionID");

                    b.HasIndex("ClientID");

                    b.HasIndex("FreelancerID");

                    b.HasIndex("PackageID");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("BusinessObjects.Application", b =>
                {
                    b.HasOne("BusinessObjects.Freelancer", "Freelancer")
                        .WithMany("ApplicationList")
                        .HasForeignKey("FreelancerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Project", "Project")
                        .WithMany("ApplicationList")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BusinessObjects.Certification", b =>
                {
                    b.HasOne("BusinessObjects.ExpertiseProfile", "ExpertiseProfile")
                        .WithMany("CertificationList")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpertiseProfile");
                });

            modelBuilder.Entity("BusinessObjects.Client", b =>
                {
                    b.HasOne("BusinessObjects.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObjects.ExpertiseProfile", b =>
                {
                    b.HasOne("BusinessObjects.Freelancer", "Freelancer")
                        .WithMany("ExpertiseProfileList")
                        .HasForeignKey("FreelancerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("BusinessObjects.Freelancer", b =>
                {
                    b.HasOne("BusinessObjects.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObjects.Location", b =>
                {
                    b.HasOne("BusinessObjects.Client", "Client")
                        .WithMany("LocationList")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BusinessObjects.Milestone", b =>
                {
                    b.HasOne("BusinessObjects.Project", "Project")
                        .WithMany("MilestoneList")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BusinessObjects.Project", b =>
                {
                    b.HasOne("BusinessObjects.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Client", null)
                        .WithMany("ProjectList")
                        .HasForeignKey("ClientID1");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BusinessObjects.SkillInProfile", b =>
                {
                    b.HasOne("BusinessObjects.ExpertiseProfile", "ExpertiseProfile")
                        .WithMany("SkillInProfileList")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Skill", "Skill")
                        .WithMany("SkillInProfileList")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpertiseProfile");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("BusinessObjects.SkillRequirement", b =>
                {
                    b.HasOne("BusinessObjects.Project", "Project")
                        .WithMany("SkillRequirementList")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Skill", "Skill")
                        .WithMany("SkillRequirementList")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("BusinessObjects.Submittion", b =>
                {
                    b.HasOne("BusinessObjects.Freelancer", "Freelancer")
                        .WithMany("SubmittionList")
                        .HasForeignKey("FreelancerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Milestone", "Milestone")
                        .WithMany("SubmittionList")
                        .HasForeignKey("MilestoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Milestone");
                });

            modelBuilder.Entity("BusinessObjects.Subscription", b =>
                {
                    b.HasOne("BusinessObjects.Client", "Client")
                        .WithMany("SubscriptionList")
                        .HasForeignKey("ClientID");

                    b.HasOne("BusinessObjects.Freelancer", "Freelancer")
                        .WithMany("SubscriptionList")
                        .HasForeignKey("FreelancerID");

                    b.HasOne("BusinessObjects.Package", null)
                        .WithMany("SubscriptionList")
                        .HasForeignKey("PackageID");

                    b.Navigation("Client");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("BusinessObjects.Client", b =>
                {
                    b.Navigation("LocationList");

                    b.Navigation("ProjectList");

                    b.Navigation("SubscriptionList");
                });

            modelBuilder.Entity("BusinessObjects.ExpertiseProfile", b =>
                {
                    b.Navigation("CertificationList");

                    b.Navigation("SkillInProfileList");
                });

            modelBuilder.Entity("BusinessObjects.Freelancer", b =>
                {
                    b.Navigation("ApplicationList");

                    b.Navigation("ExpertiseProfileList");

                    b.Navigation("SubmittionList");

                    b.Navigation("SubscriptionList");
                });

            modelBuilder.Entity("BusinessObjects.Milestone", b =>
                {
                    b.Navigation("SubmittionList");
                });

            modelBuilder.Entity("BusinessObjects.Package", b =>
                {
                    b.Navigation("SubscriptionList");
                });

            modelBuilder.Entity("BusinessObjects.Project", b =>
                {
                    b.Navigation("ApplicationList");

                    b.Navigation("MilestoneList");

                    b.Navigation("SkillRequirementList");
                });

            modelBuilder.Entity("BusinessObjects.Skill", b =>
                {
                    b.Navigation("SkillInProfileList");

                    b.Navigation("SkillRequirementList");
                });
#pragma warning restore 612, 618
        }
    }
}
