using System;
using dSTORMWeb.Client.Models.Enums;
using Newtonsoft.Json;

namespace dSTORMWeb.Client.Models
{
    public class ResponseModel : IResponseModel
    {

        [JsonProperty(PropertyName = "result")]
        public ResultCode Result { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "ServerErrorField")]
        public string ServerErrorField { get; set; }
    }
    public class SubmitResponseModel : ResponseModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

    }
    public class SubmitResponseModelString : ResponseModel
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }



    }
    public interface IResponseModel
    {
        public ResultCode Result { get; set; }

        string Description { get; set; }

        public string ServerErrorField { get; set; }

    }
}
