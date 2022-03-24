using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models
{
    public class ErrorTemplateModel
    {
        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; }
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonPropertyName("errorLink")]
        public string ErrorLink { get; set; }
    }
}
