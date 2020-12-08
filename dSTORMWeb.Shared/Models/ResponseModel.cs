using System;
using dSTORMWeb.Shared.Enums;
using Newtonsoft.Json;

namespace dSTORMWeb.Shared.Models
{
    public class ResponseModel : IResponseModel
    {
        [JsonProperty(PropertyName = "result")]
        public ResultCode Result { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

    public interface IResponseModel
    {
        public ResultCode Result { get; set; }

        string Description { get; set; }

    }

    public class SubmitResponseModel : ResponseModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
    public class SubmitResponseModelString : ResponseModel
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
    }
}
