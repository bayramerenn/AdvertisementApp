using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}