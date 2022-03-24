using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models.Response
{
    public class ResponseBodyModel<T> : ErrorTemplateModel
    {
        [JsonPropertyName("responseType")]
        public string ResponseType { get; set; }
        [JsonPropertyName("responseMessage")]
        public string ResponseMessage { get; set; }
        [JsonPropertyName("responseBody")]
        public T ResponseBody { get; set; }
    }
}
