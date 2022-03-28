namespace WebApps.CRUD.Models.ViewModels
{
    public class MahasiswaViewModel
    {
        public List<MahasiswaModel> ListMahasiswa { get; set; } = new List<MahasiswaModel>();
        public MahasiswaModel Mahasiswa { get; set; } = new MahasiswaModel();
    }
}
