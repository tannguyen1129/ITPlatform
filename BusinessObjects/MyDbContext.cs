using Microsoft.EntityFrameworkCore;

namespace BusinessObjects
{
    public class MyDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ExpertiseProfile> ExpertiseProfiles { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillInProfile> SkillInProfiles { get; set; }
        public DbSet<SkillRequirement> SkillRequirements { get; set; }
        public DbSet<Submittion> Submittions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Application>()
        .HasOne(a => a.Freelancer)
        .WithMany(f => f.ApplicationList) 
        .HasForeignKey(a => a.FreelancerID)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Application>()
        .HasOne(a => a.Project)
        .WithMany(p => p.ApplicationList)
        .HasForeignKey(a => a.ProjectID)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}