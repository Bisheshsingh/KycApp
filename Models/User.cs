using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KycApp.Constants;

namespace KycApp.Models
{
    [Table(name:"users")]
    public class User
    {
        [Key]
        [Column(name:"id")]
        public int Id { get; set; }

        [Required]
        [Column(name:"role")]
        public Role Role { get; set; }

        [Required]
        [StringLength(100)]
        [Column(name:"full_name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        [Column(name:"email_id")]
        public string EmailId { get; set; }

        [Required]
        [StringLength(100)]
        [Column(name:"password")]
        public string Password { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"created_at")]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(name:"updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}