using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KycApp.Constants;

namespace KycApp.Models
{
    public class KycRequest
    {
        [Key]
        public int KycId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string DocType { get; set; }

        [Required]
        [StringLength(100)]
        public string DocData { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Pending;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}