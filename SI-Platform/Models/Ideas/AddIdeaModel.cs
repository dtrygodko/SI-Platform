using System;
using System.ComponentModel.DataAnnotations;

namespace SI_Platform.Models.Ideas
{
    public class AddIdeaModel
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public DateTime StartFundingDate { get; set; }

        [Required]
        public DateTime StopFundingDate { get; set; }
    }
}