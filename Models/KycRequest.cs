using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KycApp.Constants;

namespace KycApp.Models
{
    [Table(name:"kyc_requests")]
    public class KycRequest
    {
        [Key]
        [Column(name:"kyc_id")]
        public int KycId { get; set; }

        [Required]
        [Column(name:"customer_id")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        [Column(name:"doc_type")]
        public string DocType { get; set; }

        [Required]
        [StringLength(100)]
        [Column(name:"doc_data")]
        public string DocData { get; set; }

        [Required]
        [Column(name:"status")]
        public Status Status { get; set; } = Status.Pending;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"created_at")]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(name:"updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}