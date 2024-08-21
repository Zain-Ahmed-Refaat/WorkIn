using System.ComponentModel.DataAnnotations;

namespace WorkIn.Domain.Entities
{
    public class JobTitle : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}