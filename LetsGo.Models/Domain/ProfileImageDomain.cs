using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Models.Domain
{
    public class ProfileImageDomain
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int FileStorageId { get; set; }
    }
}
