using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OA.Entity;

namespace BookShopOnionArchi.Models
{
    public class BookViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string CoverPath { get; set; }
        public string Language { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }  
    }
}
