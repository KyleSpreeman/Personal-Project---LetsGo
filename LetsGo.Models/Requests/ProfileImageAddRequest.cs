using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Models.Requests
{
    public class ProfileImageAddRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProfileId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int FileStorageId { get; set; }
    }
}
