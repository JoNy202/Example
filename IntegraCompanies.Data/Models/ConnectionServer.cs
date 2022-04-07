using EasyEncryption;
using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class ConnectionServer
    {
        public Guid ConnectionServerId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Source { get; set; }
        [Required]
        [MaxLength(100)]
        public string User { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
    }
}