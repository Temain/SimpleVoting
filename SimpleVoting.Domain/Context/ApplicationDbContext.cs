using SimpleVoting.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClassSchedule.Domain.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
            : base("SimpleVotingConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany(s => s.Answers)
                .WithMany(c => c.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("AnswerId");
                    cs.ToTable("UserAnswer");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
