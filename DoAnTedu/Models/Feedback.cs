﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [StringLength(250)]
        [Required]
        public string? Name { set; get; }

        [StringLength(250)]
        public string? Email { set; get; }

        [StringLength(500)]
        public string? Message { set; get; }

        public DateTime CreatedDate { set; get; }

        [Required]
        public bool Status { set; get; }
    }
}