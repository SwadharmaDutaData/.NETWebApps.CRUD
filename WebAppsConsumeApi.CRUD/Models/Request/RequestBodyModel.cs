using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models.Request
{
    public class RequestBodyModel<T>
    {
        [JsonPropertyName("operationType")]
        public string OperationType { get; set; }
        [JsonPropertyName("operationDesc")]
        public string OperationDesc { get; set; }
        [JsonPropertyName("request")]
        public T Request { get; set; }
    }
}
