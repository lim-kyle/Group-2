using System;
using System.ComponentModel.DataAnnotations;

namespace PennyWise.Data.Models
{
    public class Wish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string WishName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
