using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcourseApi.Models
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        public List<Tag> Tags { get; set; }

        public Notice()
        {
        }
    }
}
