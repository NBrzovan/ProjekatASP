using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.DataAccess
{
    public class SocialPlatformContext : DbContext
    {
        private readonly string _connectionString;
        public SocialPlatformContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SocialPlatformContext()
        {
            _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=socialplatform;Integrated Security=True;Trust Server Certificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<QuestionTag>().HasKey(x => new { x.QuestionId, x.TagId });
            modelBuilder.Entity<UserCommunity>().HasKey(x => new { x.UserId, x.CommunityId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });

            modelBuilder.Entity<Question>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Answer>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Community>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Follow>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Reaction>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Tag>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Topic>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<QuestionTag>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UserUseCase>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UserCommunity>().HasQueryFilter(x => !x.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            e.DeletedAt = DateTime.UtcNow;
                            e.IsDeleted = true;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCommunity> UserCommunities { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
