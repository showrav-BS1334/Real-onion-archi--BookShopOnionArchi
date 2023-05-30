using Microsoft.AspNetCore.Mvc;
using OA.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookShopOnionArchi.Models
{
    public class AuthorViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Book>? Books { get; set; }
        public string Uni { get; set; }
    }
}
