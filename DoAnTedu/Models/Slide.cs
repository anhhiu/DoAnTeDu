﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("Slides")]
    public class Slide
    {
        [Key]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string? Name { set; get; }

        [MaxLength(256)]
        public string? Description { set; get; }

        [MaxLength(256)]
        public string? Image { set; get; }

        [MaxLength(256)]
        public string? Url { set; get; }

        public int? DisplayOrder { set; get; }

        public bool Status { set; get; }

        public string? Content { set; get; }
    }
}
