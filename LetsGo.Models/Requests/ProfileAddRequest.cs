using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Models.Requests
{
    public class ProfileAddRequest
    {
        //members
        [Required]
        [StringLength(int.MaxValue)]
        public string Bio { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Company URL")]
        [Url]
        public string CompanyUrl { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Region { get; set; }

        [Required]
        [StringLength(128)]
        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}
