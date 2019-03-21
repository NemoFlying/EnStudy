using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.DAL
{
    public class EnStudyContextFactory
    {
        private static readonly EnStudyContext dbContext = new EnStudyContext();
        public static EnStudyContext GetdbContext()
        {
            return dbContext;
        }
    }
}