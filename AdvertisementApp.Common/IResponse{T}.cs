using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Common
{
    internal interface IResponse<T>:IResponse
    {
        public T Data { get; set; }
        public List<CustomValidatorError> ValidatorErrors { get; set; }
    }
}
