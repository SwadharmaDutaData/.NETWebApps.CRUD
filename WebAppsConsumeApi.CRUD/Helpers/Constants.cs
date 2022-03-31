namespace WebAppsConsumeApi.CRUD.Helpers
{
    public class Constants
    {
        public static readonly string BASE_URL = "http://10.12.4.166:8083/";

        // Address Mahasiswa
        public static readonly string GET_ALL_MAHASISWA = "api/Mahasiswa";
        public static readonly string GET_BY_ID_MAHASISWA = "api/Mahasiswa/id/{id}";
        public static readonly string POST_MAHASISWA = "api/Mahasiswa";
        public static readonly string PUT_MAHASISWA = "api/Mahasiswa/update/{id}";
        public static readonly string DELETE_MAHASISWA = "api/Mahasiswa/delete/{id}";

        // Address Jurusan
        public static readonly string GET_ALL_JURUSAN = "api/Jurusan";
        public static readonly string GET_BY_ID_JURUSAN = "api/Jurusan/id/{id}";
        public static readonly string POST_JURUSAN = "api/Jurusan";
        public static readonly string PUT_JURUSAN = "api/Jurusan/update/{id}";
        public static readonly string DELETE_JURUSAN = "api/Jurusan/delete/{id}";

        // Address Jurusan
        public static readonly string GET_ALL_USER = "api/User";
        public static readonly string GET_BY_ID_USER = "api/User/id/{id}";
        public static readonly string POST_USER = "api/User";
        public static readonly string PUT_USER = "api/User/update/{id}";
        public static readonly string DELETE_USER = "api/User/delete/{id}";
    }
}
