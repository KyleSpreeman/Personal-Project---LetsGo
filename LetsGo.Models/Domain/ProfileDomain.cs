using LetsGo.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Models.Domain
{
    public class ProfileDomain : ProfileAddRequest
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
