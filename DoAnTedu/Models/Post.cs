﻿using DoAnTedu.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string? Name { set; get; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string? Alias { set; get; }

        [Required]
        public int CategoryID { set; get; }

        [MaxLength(256)]
        public string? Image { set; get; }

        [MaxLength(500)]
        public string? Description { set; get; }

        public string? Content { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        [ForeignKey("CategoryID")]
        public virtual PostCategory? PostCategory { set; get; }

        public virtual IEnumerable<PostTag>? PostTags { set; get; } = Enumerable.Empty<PostTag>();
    }
}
