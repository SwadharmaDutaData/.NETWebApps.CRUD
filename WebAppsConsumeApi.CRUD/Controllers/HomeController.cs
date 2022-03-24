using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppsConsumeApi.CRUD.Helpers;
using WebAppsConsumeApi.CRUD.Models;
using WebAppsConsumeApi.CRUD.Models.Response;

namespace WebAppsConsumeApi.CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<TblJurusanModel>>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<TblJurusanModel>>>>(Constants.BASE_URL, Constants.GET_ALL_JURUSAN);
            ResponseBodyModel<ResponseContentBodyModel<List<TblJurusanModel>>>  result = restClient.GetAll();
            List<TblJurusanModel> listJurusan = result.ResponseBody.Content;
            if (listJurusan != null && result.ErrorCode == 0)
            {
                return View(listJurusan);
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblJurusanModel>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblJurusanModel>>>(Constants.BASE_URL, Constants.GET_BY_ID_JURUSAN.Replace("{id}", id.ToString()));
            ResponseBodyModel<ResponseContentBodyModel<TblJurusanModel>> result = restClient.GetSingle();
            TblJurusanModel jurusan = result.ResponseBody.Content;
            if (jurusan != null && result.ErrorCode == 0)
            {
                return View(jurusan);
            }

            return View();
        }

        public IActionResult GetById (int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}