using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models
{
    public class TblUserModel
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("isActive")]
        public bool? IsActive { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; }
    }
}
