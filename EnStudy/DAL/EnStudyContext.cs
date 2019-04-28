using EnStudy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EnStudy.DAL
{
    public class EnStudyContext:DbContext
    {
        public EnStudyContext()
            :base("EnStudyConnectString")
        {
           
        }

        public DbSet<User> User { get; set; }

        public DbSet<StudySchedue> StudySchedue { get; set; }

        public DbSet<UserSpeak> UserSpeak { get; set; }

        public DbSet<SpeakComents> SpeakComents { get; set; }

        public DbSet<RecommendedBook> RecommendedBook { get; set; }

        public DbSet<StudyNotesType> StudyNotesType { get; set; }

        public DbSet<StudyNodes> StudyNodes { get; set; }


        public DbSet<StudyNodes> UserMovie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().HasMany(t => t.SpeakComents)
            //    .WithRequired(p => p.User).WillCascadeOnDelete(false);
            //建立朋友关系表

            modelBuilder.Entity<UserFriend>().HasRequired(m=>m.user).WithMany(m=>m.Friends);
        }
    }
}