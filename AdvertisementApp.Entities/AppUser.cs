namespace AdvertisementApp.Entities
{
    public class AppUser : BaseEntity
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; }
        public ICollection<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}