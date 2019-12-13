using System;
using System.ComponentModel.DataAnnotations;

namespace URLShortener.Data.Entities
{
    public class URLInfo    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string URL { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string HashedURL { get; set; }
        
        [Required]
        public DateTime CreatedOn { get; set; }

    }
}
