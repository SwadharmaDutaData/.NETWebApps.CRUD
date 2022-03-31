using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAppsConsumeApi.CRUD.Helpers;
using WebAppsConsumeApi.CRUD.Models;
using WebAppsConsumeApi.CRUD.Models.Request;
using WebAppsConsumeApi.CRUD.Models.Response;

namespace WebAppsConsumeApi.CRUD.Controllers
{
    public class UsersController : Controller
    {
        // GET: UsersController
        public ActionResult HomeUser()
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<TblUserModel>>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<List<TblUserModel>>>>(Constants.BASE_URL, Constants.GET_ALL_USER);
            ResponseBodyModel<ResponseContentBodyModel<List<TblUserModel>>> result = restClient.GetAll();
            List<TblUserModel> listJurusan = result.ResponseBody.Content;
            if (listJurusan != null && result.ErrorCode == 0)
            {
                return View(listJurusan);
            }

            return View();
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblUserModel>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblUserModel>>>(Constants.BASE_URL, Constants.GET_BY_ID_USER.Replace("{id}", id.ToString()));
            ResponseBodyModel<ResponseContentBodyModel<TblUserModel>> result = restClient.GetSingle();
            TblUserModel jurusan = result.ResponseBody.Content;
            if (jurusan != null && result.ErrorCode == 0)
            {
                return View(jurusan);
            }

            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(HomeUser));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateUser(TblUserModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Firstname))
                    throw new ArgumentNullException(nameof(model));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblUserModel>>> restClient = null;
                TblUserModel post = new TblUserModel();
                post.Firstname = model.Firstname;
                post.Lastname = model.Lastname;
                post.Username = model.Username;
                post.EmailAddress = model.EmailAddress;
                post.Password = model.Password;
                post.IsActive = true;
                post.CreatedDate = DateTime.Now;

                RequestBodyModel<ResponseContentBodyModel<TblUserModel>> reqPostUser = new RequestBodyModel<ResponseContentBodyModel<TblUserModel>>();
                ResponseContentBodyModel<TblUserModel> postContent = new ResponseContentBodyModel<TblUserModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.Username) && !string.IsNullOrEmpty(postContent.Content.Firstname))
                {
                    reqPostUser.OperationType = "Added";
                    reqPostUser.OperationDesc = "Tambah User";
                    reqPostUser.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblUserModel>>>(Constants.BASE_URL, Constants.POST_USER);
                    string result = restClient.AddTSource(reqPostUser);
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

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblUserModel>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblUserModel>>>(Constants.BASE_URL, Constants.GET_BY_ID_USER.Replace("{id}", id.ToString()));
            ResponseBodyModel<ResponseContentBodyModel<TblUserModel>> result = restClient.GetSingle();
            TblUserModel jurusan = result.ResponseBody.Content;
            if (jurusan != null && result.ErrorCode == 0)
            {
                return View(jurusan);
            }

            return View();
        }

        // POST: UsersController/Edit/5
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
        public ActionResult EditUser(int id, TblUserModel model)
        {
            try
            {
                if (id == 0 && (string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Firstname)))
                    throw new ArgumentNullException(nameof(model));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();

                RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblUserModel>>> restClient = null;
                TblUserModel post = new TblUserModel();
                post.UserId = model.UserId;
                post.Firstname = model.Firstname;
                post.Lastname = model.Lastname;
                post.Username = model.Username;
                post.EmailAddress = model.EmailAddress;
                post.Password = model.Password;
                post.IsActive = true;
                post.CreatedDate = DateTime.Now;

                RequestBodyModel<ResponseContentBodyModel<TblUserModel>> reqPostUser = new RequestBodyModel<ResponseContentBodyModel<TblUserModel>>();
                ResponseContentBodyModel<TblUserModel> postContent = new ResponseContentBodyModel<TblUserModel>();
                postContent.Content = post;

                if (postContent.Content != null && !string.IsNullOrEmpty(postContent.Content.Username) && !string.IsNullOrEmpty(postContent.Content.Firstname))
                {
                    reqPostUser.OperationType = "Updated";
                    reqPostUser.OperationDesc = "Merubah Data Jurusan";
                    reqPostUser.Request = postContent;

                    restClient = new RestClientConfig<RequestBodyModel<ResponseContentBodyModel<TblUserModel>>>(Constants.BASE_URL, Constants.PUT_USER.Replace("{id}", ""));
                    string result = restClient.UpdateTSource(id, reqPostUser);
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

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblUserModel>>> restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<TblUserModel>>>(Constants.BASE_URL, Constants.GET_BY_ID_USER.Replace("{id}", id.ToString()));
            ResponseBodyModel<ResponseContentBodyModel<TblUserModel>> result = restClient.GetSingle();
            TblUserModel jurusan = result.ResponseBody.Content;
            if (jurusan != null && result.ErrorCode == 0)
            {
                return View(jurusan);
            }

            return View();
        }

        // POST: UsersController/Delete/5
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
        public ActionResult DeleteUser(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException(nameof(id));

                ResponseBodyModel<ResponseContentBodyModel<string>>? responseBody = new ResponseBodyModel<ResponseContentBodyModel<string>>();
                ResponseContentBodyModel<string> contentBody = new ResponseContentBodyModel<string>();
                RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<string>>> restClient = null;
                restClient = new RestClientConfig<ResponseBodyModel<ResponseContentBodyModel<string>>>(Constants.BASE_URL, Constants.DELETE_USER.Replace("{id}", ""));
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
