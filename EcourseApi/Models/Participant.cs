using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcourseApi.Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        public string ScoutName { get; set; }
        public string PreName { get; set; }
        public string Name { get; set; }
        public List<Notice> Notices { get; set; } = new List<Notice>();


        public Participant()
        {
         
        }
    }
}
