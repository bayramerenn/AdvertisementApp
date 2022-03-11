using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Common
{
    internal class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public List<CustomValidatorError> ValidatorErrors { get; set; }
        public Response(ResponseType responseType,string message) : base(responseType,message)
        {
        }
        public Response(ResponseType responseType,T data):base(responseType)
        {
            Data = data;
        }
        public Response(T data,List<CustomValidatorError> errors):base(ResponseType.ValidatorError)
        {
            Data=data;
            ValidatorErrors = errors;   
        }
    }
}
