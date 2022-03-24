using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models
{
    public class TblUserModel
    {
        [JsonPropertyName("")]
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
