namespace WebApps.CRUD.Models
{
    public class TblJurusanModel
    {
        public int JurusanId { get; set; }
        public string NamaJurusan { get; set; }
        public string DeskripsiJurusan { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
