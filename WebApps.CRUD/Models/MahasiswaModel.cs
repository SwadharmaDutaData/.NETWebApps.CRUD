namespace WebApps.CRUD.Models
{
    public class MahasiswaModel
    {
        public int ID { get; set; }
        public string Npm { get; set; }
        public string NamaMahasiswa { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public bool IsActive { get; set; }
    }
}
