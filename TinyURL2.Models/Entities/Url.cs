using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL2.Models.Common;

namespace TinyURL2.Models.Entities
{
    [Table(nameof(Url), Schema = Constants.DefaultSchema)]
    [Index(nameof(Code))]
    
    public class Url : BaseEntity
    {
        public required string OriginalUrl { get; set; }
        public required string Code { get; set; }
        public string FullUrl { get => $"{Constants.HOST}/url/{Code}"; }
        public int Clicks { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Account.CreatedUrls))]
        public Account? Creator { get; set; }
    }
}
