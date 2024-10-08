using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL2.Models.Entities
{
    [Table(nameof(AuthenticationMethod), Schema = "TinyURL2")]
    public class AuthenticationMethod
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
