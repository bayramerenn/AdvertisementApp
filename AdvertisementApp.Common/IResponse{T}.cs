namespace AdvertisementApp.Common
{
    public interface IResponse<T> : IResponse
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}