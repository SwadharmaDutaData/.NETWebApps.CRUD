using System.Text.Json.Serialization;

namespace WebAppsConsumeApi.CRUD.Models
{
    public class TblJurusanModel
    {
        [JsonPropertyName("jurusanId")]
        public int JurusanId { get; set; }
        [JsonPropertyName("namaJurusan")]
        public string NamaJurusan { get; set; }
        [JsonPropertyName("deskripsiJurusan")]
        public string DeskripsiJurusan { get; set; }
        [JsonPropertyName("createdTime")]
        public DateTime? CreatedTime { get; set; }
        [JsonPropertyName("isActive")]
        public bool? IsActive { get; set; }
    }
}
