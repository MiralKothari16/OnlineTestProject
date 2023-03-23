using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model
{
    public class OnlineTestContext : DbContext
    {
        public OnlineTestContext(DbContextOptions<OnlineTestContext> opt) : base(opt)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RToken> RTokens { get; set; }

        public DbSet<Technology> Technology { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Questions> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<QuestionAnswerMapping> QuestionAnswerMapping { get; set; }

        public DbSet<TestEmailLink>TestEmailLinks { get; set; }
        public DbSet<EmailNotification> EmailNotifications { get; set; }


    }
}
