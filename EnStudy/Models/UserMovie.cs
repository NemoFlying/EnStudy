using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnStudy.Models
{
    public class UserMovie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        public string MovieName { get; set; }

        public string MovieDesc { get; set; }

        public string MovieUrl { get; set; }

        public virtual User user { get; set; }

    }
}