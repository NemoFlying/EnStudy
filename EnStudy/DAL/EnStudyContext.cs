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





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }
    }
}