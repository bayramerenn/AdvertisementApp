namespace AdvertisementApp.Entities
{
    public class AppRole : BaseEntity
    {
        public int Definition { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}