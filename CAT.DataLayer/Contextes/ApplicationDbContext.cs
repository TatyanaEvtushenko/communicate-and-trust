using CAT.DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CAT.DataLayer.Contextes
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Dialog> Dialogs { get; set; }

        public DbSet<UserDialog> UserDialogs { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<TrainingSession> TrainingSessions { get; set; }

        public DbSet<TrainingSource> TrainingSources { get; set; }

        public DbSet<TrainingLog> TrainingLogs { get; set; }

        public DbSet<TestSession> TestSessions { get; set; }

        public DbSet<TestLog> TestLogs { get; set; }

        public DbSet<ActionLog> ActionLogs { get; set; }

        public DbSet<Emotion> Emotions { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
