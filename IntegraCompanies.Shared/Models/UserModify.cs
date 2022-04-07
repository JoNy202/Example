using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Shared.Models
{
    public class UserModify
    {
        [MaxLength(100)]
        public string? Login { get; set; }
        [MaxLength(32)]
        public byte[]? Password { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(10)]
        public string? Mobile { get; set; }
        [MaxLength(250)]
        public string? Fname { get; set; }
        [MaxLength(250)]
        public string? Mname { get; set; }
        [MaxLength(250)]
        public string? Lname { get; set; }
    }
}
