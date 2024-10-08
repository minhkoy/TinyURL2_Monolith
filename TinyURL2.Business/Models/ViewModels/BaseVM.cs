using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL2.Business.Models.ViewModels
{
    public abstract class BaseVM
    {
        public Guid? Id { get; set; }
        public AccountVM? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public AccountVM? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
