using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAppsConsumeApi.CRUD.Helpers;
using WebAppsConsumeApi.CRUD.Models;
using WebAppsConsumeApi.CRUD.Models.Request;
using WebAppsConsumeApi.CRUD.Models.Response;

namespace WebAppsConsumeApi.CRUD.Controllers
{
    public class MahasiswaController : Controller
    {
        // GET: MahasiswaController
        public ActionResult IndexMahasiswa()
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<MahasiswaModel>>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<MahasiswaModel>>>>(Constants.BASE_URL, Constants.GET_ALL_MAHASISWA);
            ResponseBodyModel<ResponseContentBodyModel<List<MahasiswaModel>>> result = restClient.GetAll();
            List<MahasiswaModel> listMahasiswa = result.ResponseBody.Content;
            if (listMahasiswa != null && result.ErrorCode == 0)
            {
                return View(listMahasiswa);
            }

            return View();
        }

        // GET: MahasiswaController/Details/5
        public ActionResult Details(int id)
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>>>(Constants.BASE_URL, Constants.GET_BY_ID_MAHASISWA.Replace("{id}", id.ToString()));
            ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>> result = restClient.GetSingle();
            MahasiswaModel mahasiswa = result.ResponseBody.Content;
            if (mahasiswa != null && result.ErrorCode == 0)
            {
                return View(mahasiswa);
            }

            return View();
        }

        // GET: MahasiswaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MahasiswaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexMahasiswa));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateMahasiswa(MahasiswaModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Npm) && string.IsNullOrEmpty(model.NamaMahasiswa))
                    throw new ArgumentNullException(nameof(model));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>>> restClient = null;
                MahasiswaModel post = new MahasiswaModel();
                post.Npm = model.Npm;
                post.NamaMahasiswa = model.NamaMahasiswa;
                post.Alamat = model.Alamat;
                post.Email = model.Email;
                post.JenisKelamin = model.JenisKelamin;
                post.IsActive = true;
                post.CreatedDate = DateTime.Now;

                RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>> reqPostMahasiswa = new RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>>();
                ResponseContentBodyModel<MahasiswaModel> postContent = new ResponseContentBodyModel<MahasiswaModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.Npm) && !string.IsNullOrEmpty(postContent.Content.NamaMahasiswa))
                {
                    reqPostMahasiswa.OperationType = "Added";
                    reqPostMahasiswa.OperationDesc = "Tambah Mahasiswa";
                    reqPostMahasiswa.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>>>(Constants.BASE_URL, Constants.POST_MAHASISWA);
                    string result = restClient.AddTSource(reqPostMahasiswa);
                    if (!string.IsNullOrEmpty(result))
                    {
                        responseBody = JsonSerializer.Deserialize<ResponseBodyModel<ResponseContentBodyModel<string>>>(result);
                        if (responseBody?.ErrorCode == 0)
                        {
                            return StatusCode(201, responseBody);
                        }
                    }
                }

                return View(nameof(Create));
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

        // GET: MahasiswaController/Edit/5
        public ActionResult Edit(int id)
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>>>(Constants.BASE_URL, Constants.GET_BY_ID_MAHASISWA.Replace("{id}", id.ToString()));
            ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>> result = restClient.GetSingle();
            MahasiswaModel mahasiswa = result.ResponseBody.Content;
            if (mahasiswa != null && result.ErrorCode == 0)
            {
                return View(mahasiswa);
            }

            return View();
        }

        // POST: MahasiswaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditMahasiswa(int id, MahasiswaModel model)
        {
            try
            {
                if (id == 0 && (string.IsNullOrEmpty(model.Npm) && string.IsNullOrEmpty(model.NamaMahasiswa)))
                    throw new ArgumentNullException(nameof(model));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>>> restClient = null;
                MahasiswaModel post = new MahasiswaModel();
                post.Npm = model.Npm;
                post.NamaMahasiswa = model.NamaMahasiswa;
                post.Alamat = model.Alamat;
                post.Email = model.Email;
                post.JenisKelamin = model.JenisKelamin;
                post.IsActive = true;
                post.CreatedDate = DateTime.Now;

                RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>> reqPostMahasiswa = new RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>>();
                ResponseContentBodyModel<MahasiswaModel> postContent = new ResponseContentBodyModel<MahasiswaModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.Npm) && !string.IsNullOrEmpty(postContent.Content.NamaMahasiswa))
                {
                    reqPostMahasiswa.OperationType = "Updated";
                    reqPostMahasiswa.OperationDesc = "Merubah Data Jurusan";
                    reqPostMahasiswa.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<MahasiswaModel>>>(Constants.BASE_URL, Constants.PUT_MAHASISWA.Replace("{id}", ""));
                    string result = restClient.UpdateTSource(id, reqPostMahasiswa);
                    if (!string.IsNullOrEmpty(result))
                    {
                        responseBody = JsonSerializer.Deserialize<ResponseBodyModel<ResponseContentBodyModel<string>>>(result);
                        if (responseBody?.ErrorCode == 0)
                        {
                            return StatusCode(201, responseBody);
                        }
                    }
                }

                return View(nameof(Edit));
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

        // GET: MahasiswaController/Delete/5
        public ActionResult Delete(int id)
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>>>(Constants.BASE_URL, Constants.GET_BY_ID_MAHASISWA.Replace("{id}", id.ToString()));
            ResponseBodyModel<ResponseContentBodyModel<MahasiswaModel>> result = restClient.GetSingle();
            MahasiswaModel mahasiswa = result.ResponseBody.Content;
            if (mahasiswa != null && result.ErrorCode == 0)
            {
                return View(mahasiswa);
            }

            return View();
        }

        // POST: MahasiswaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteMahasiswa(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException(nameof(id));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();
                RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<string>>> restClient = null;
                restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<string>>>(Constants.BASE_URL, Constants.DELETE_MAHASISWA.Replace("{id}", ""));
                responseBody = restClient.DeleteTSource(id);

                if (responseBody.ErrorCode == 0)
                {
                    return StatusCode(201, responseBody);
                }

                return View(nameof(Delete));
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
