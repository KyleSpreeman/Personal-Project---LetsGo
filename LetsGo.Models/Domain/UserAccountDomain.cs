using LetsGo.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Models.Domain
{
    public class UserAccountDomain : UserRegisterRequest
    {
        [Range(1, int.MaxValue)]
        [Display(Name = "Id Required")]
        public int Id { get; set; }

        [Display(Name = "Is Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        public string Token { get; set; }

        public string Salt { get; set; }

        public string PasswordHash { get; set; }

        public string access_token { get; set; }

    }
}

