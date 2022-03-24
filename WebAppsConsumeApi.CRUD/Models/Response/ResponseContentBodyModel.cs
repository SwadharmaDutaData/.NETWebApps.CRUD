using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models.Response
{
    public class ResponseContentBodyModel<T>
    {
        [JsonPropertyName("content")]
        public T Content { get; set; }
    }
}
