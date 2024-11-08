﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Course.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order Name")]
        [Range(1,100,ErrorMessage ="Display Order must be 1-100")]

        public int  DisplayOrder { get; set; }
    }
}
