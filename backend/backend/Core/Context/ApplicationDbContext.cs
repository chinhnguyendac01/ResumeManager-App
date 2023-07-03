using backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Job>().HasOne(Job => Job.Company)
            .WithMany(Company => Company.Jobs)
            .HasForeignKey(job => job.CompanyId);
            modelBuilder.Entity<Candidate>()
            .HasOne(Candidate => Candidate.job)
            .WithMany(job => job.Candidates)
            .HasForeignKey(Candidate => Candidate.JobId);
            modelBuilder.Entity<Company>()
                .Property(company => company.Size)
                .HasConversion<string>();
            modelBuilder.Entity<Job>()
                .Property(job => job.Level)
                .HasConversion<string>();
        }
    }
}



