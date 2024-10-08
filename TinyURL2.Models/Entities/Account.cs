using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL2.Models.Common;

namespace TinyURL2.Models.Entities
{
    [Table(nameof(Account), Schema = "TinyURL2")]
    public class Account : BaseEntity
    {
        public required string Username { get; set; }
        public required string Salt { get; set; }
        public required string HashedPassword { get; set; }
        public Guid AuthenticationMethodId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[]? Avatar { get; set; }
        public string? LastestOTP { get; set; }
        public DateTime? LastestOTPTime { get; set; }
        [InverseProperty(nameof(Url.Creator))]
        public virtual ICollection<Url>? CreatedUrls { get; set; }
        [ForeignKey(nameof(AuthenticationMethodId))]
        public virtual AuthenticationMethod? AuthenticationMethod { get; set; }
    }
}
