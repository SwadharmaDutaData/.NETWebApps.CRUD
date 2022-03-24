using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models
{
    public class MahasiswaModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("npm")]
        public string Npm { get; set; }
        [JsonPropertyName("namaMahasiswa")]
        public string NamaMahasiswa { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("alamat")]
        public string Alamat { get; set; }
        [JsonPropertyName("jenisKelamin")]
        public string JenisKelamin { get; set; }
        [JsonPropertyName("isActive")]
        public bool? IsActive { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; }
    }
}
