using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAppsConsumeApi.CRUD.Helpers;
using WebAppsConsumeApi.CRUD.Models;
using WebAppsConsumeApi.CRUD.Models.Request;
using WebAppsConsumeApi.CRUD.Models.Response;

namespace WebAppsConsumeApi.CRUD.Controllers
{
    public class JurusanController : Controller
    {
        // GET: JurusanController
        public ActionResult IndexJurusan()
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<TblJurusanModel>>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<TblJurusanModel>>>>(Constants.BASE_URL, Constants.GET_ALL_JURUSAN);
            ResponseBodyModel<ResponseContentBodyModel<List<TblJurusanModel>>> result = restClient.GetAll();
            List<TblJurusanModel> listJurusan = result.ResponseBody.Content;
            if (listJurusan != null && result.ErrorCode == 0)
            {
                return View(listJurusan);
            }

            return View();
        }

        // GET: JurusanController/Details/5
        public ActionResult Details(int id)
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

        // GET: JurusanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JurusanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("JurusanId, NamaJurusan, DeskripsiJurusan, CreatedTime, IsActive")] TblJurusanModel model)
        {
            try
            {
                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>> restClient = null;
                TblJurusanModel post = new TblJurusanModel();
                post.NamaJurusan = model.NamaJurusan;
                post.DeskripsiJurusan = model.DeskripsiJurusan;
                post.CreatedTime = DateTime.Now;
                post.IsActive = true;

                RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>> reqPostJurusan = new RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>();
                ResponseContentBodyModel<TblJurusanModel> postContent = new ResponseContentBodyModel<TblJurusanModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.NamaJurusan) && !string.IsNullOrEmpty(postContent.Content.DeskripsiJurusan))
                {
                    reqPostJurusan.OperationType = "Added";
                    reqPostJurusan.OperationDesc = "Tambah Jurusan";
                    reqPostJurusan.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>>(Constants.BASE_URL, Constants.POST_JURUSAN);
                    string result = restClient.AddTSource(reqPostJurusan);
                    if (!string.IsNullOrEmpty(result))
                    {
                        responseBody = JsonSerializer.Deserialize<ResponseBodyModel<ResponseContentBodyModel<string>>>(result);
                        if (responseBody?.ErrorCode == 0)
                        {
                            return RedirectToAction(nameof(IndexJurusan));
                        }
                    }
                }

                return View();
            }
            catch (ArgumentNullException ar)
            {
                return BadRequest(ar.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddingJurusan(TblJurusanModel model)
        {
            try
            {
                if(string.IsNullOrEmpty(model.NamaJurusan) && string.IsNullOrEmpty(model.DeskripsiJurusan))
                    throw new ArgumentNullException(nameof(model));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>> restClient = null;
                TblJurusanModel post = new TblJurusanModel();
                post.NamaJurusan = model.NamaJurusan;
                post.DeskripsiJurusan = model.DeskripsiJurusan;
                post.CreatedTime = DateTime.Now;
                post.IsActive = true;

                RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>> reqPostJurusan = new RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>();
                ResponseContentBodyModel<TblJurusanModel> postContent = new ResponseContentBodyModel<TblJurusanModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.NamaJurusan) && !string.IsNullOrEmpty(postContent.Content.DeskripsiJurusan))
                {
                    reqPostJurusan.OperationType = "Added";
                    reqPostJurusan.OperationDesc = "Tambah Jurusan";
                    reqPostJurusan.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>>(Constants.BASE_URL, Constants.POST_JURUSAN);
                    string result = restClient.AddTSource(reqPostJurusan);
                    if (!string.IsNullOrEmpty(result))
                    {
                        responseBody = JsonSerializer.Deserialize<ResponseBodyModel<ResponseContentBodyModel<string>>>(result);
                        if (responseBody?.ErrorCode == 0)
                        {
                            return StatusCode(201, responseBody);
                        }
                    }
                }

                return View();
            }
            catch (ArgumentNullException ar)
            {
                return BadRequest(ar.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: JurusanController/Edit/5
        public ActionResult Edit(int id)
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

        // POST: JurusanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("JurusanId, NamaJurusan, DeskripsiJurusan, CreatedTime, IsActive")] TblJurusanModel model)
        {
            try
            {
                if (id == 0 && (string.IsNullOrEmpty(model.NamaJurusan) && string.IsNullOrEmpty(model.DeskripsiJurusan)))
                    throw new ArgumentNullException(nameof(model));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>> restClient = null;
                TblJurusanModel post = new TblJurusanModel();
                post.NamaJurusan = model.NamaJurusan;
                post.DeskripsiJurusan = model.DeskripsiJurusan;
                post.CreatedTime = DateTime.Now;
                post.IsActive = true;

                RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>> reqPostJurusan = new RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>();
                ResponseContentBodyModel<TblJurusanModel> postContent = new ResponseContentBodyModel<TblJurusanModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.NamaJurusan) && !string.IsNullOrEmpty(postContent.Content.DeskripsiJurusan))
                {
                    reqPostJurusan.OperationType = "Updated";
                    reqPostJurusan.OperationDesc = "Merubah Data Jurusan";
                    reqPostJurusan.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>>(Constants.BASE_URL, Constants.POST_JURUSAN);
                    string result = restClient.UpdateTSource(id, reqPostJurusan);
                    if (!string.IsNullOrEmpty(result))
                    {
                        responseBody = JsonSerializer.Deserialize<ResponseBodyModel<ResponseContentBodyModel<string>>>(result);
                        if (responseBody?.ErrorCode == 0)
                        {
                            return StatusCode(201, responseBody);
                        }
                    }
                }

                return View();
            }
            catch (ArgumentNullException ar)
            {
                return BadRequest(ar.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditJurusan(int id, TblJurusanModel model)
        {
            try
            {
                if (id == 0 && (string.IsNullOrEmpty(model.NamaJurusan) && string.IsNullOrEmpty(model.DeskripsiJurusan)))
                    throw new ArgumentNullException(nameof(model));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>> restClient = null;
                TblJurusanModel post = new TblJurusanModel();
                post.NamaJurusan = model.NamaJurusan;
                post.DeskripsiJurusan = model.DeskripsiJurusan;
                post.CreatedTime = DateTime.Now;
                post.IsActive = true;

                RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>> reqPostJurusan = new RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>();
                ResponseContentBodyModel<TblJurusanModel> postContent = new ResponseContentBodyModel<TblJurusanModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.NamaJurusan) && !string.IsNullOrEmpty(postContent.Content.DeskripsiJurusan))
                {
                    reqPostJurusan.OperationType = "Updated";
                    reqPostJurusan.OperationDesc = "Merubah Data Jurusan";
                    reqPostJurusan.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblJurusanModel>>>(Constants.BASE_URL, Constants.PUT_JURUSAN.Replace("{id}", ""));
                    string result = restClient.UpdateTSource(id, reqPostJurusan);
                    if (!string.IsNullOrEmpty(result))
                    {
                        responseBody = JsonSerializer.Deserialize<ResponseBodyModel<ResponseContentBodyModel<string>>>(result);
                        if (responseBody?.ErrorCode == 0)
                        {
                            return StatusCode(201, responseBody);
                        }
                    }
                }

                return View();
            }
            catch (ArgumentNullException ar)
            {
                return BadRequest(ar.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: JurusanController/Delete/5
        public ActionResult Delete(int id)
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

        // POST: JurusanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("JurusanId, NamaJurusan, DeskripsiJurusan, CreatedTime, IsActive")] TblJurusanModel model)
        {
            try
            {
                return RedirectToAction(nameof(IndexJurusan));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteJurusan(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException(nameof(id));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();
                RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<string>>> restClient = null;
                restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<string>>>(Constants.BASE_URL, Constants.DELETE_JURUSAN.Replace("{id}", ""));
                responseBody = restClient.DeleteTSource(id);

                if (responseBody.ErrorCode == 0)
                {
                    return StatusCode(201, responseBody);
                }

                return View();
            }
            catch (ArgumentNullException ar)
            {
                return BadRequest(ar.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
