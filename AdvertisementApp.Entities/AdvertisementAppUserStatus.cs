using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities
{
    public class AdvertisementAppUserStatus:BaseEntity
    {
        public string Definition { get; set; }
        public ICollection<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
