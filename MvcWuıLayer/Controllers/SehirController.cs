using Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcWuıLayer.Models;
using System.Text;
using System.Text.Json;

namespace MvcWuıLayer.Controllers
{
    public class SehirController : Controller
    {


        #region INDEX
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApiUrl sehirUrl = new ApiUrl("Sehir");
            HttpClient httpClient = new HttpClient();
            HttpClient httpClient2 = new HttpClient();

            httpClient.BaseAddress = new Uri(sehirUrl.GetAll);
            var ulke = httpClient2.BaseAddress = new Uri("https://localhost:7229/api/Ulke");

            //var url = httpClient.BaseAddress + "Sehir/FindAllInclude";
            var response = httpClient.GetAsync(httpClient.BaseAddress);


            if (response != null)
            {
                //var result = await response.Content.ReadAsStringAsync();
                var result = await response.Result.Content.ReadAsStringAsync();
                var selectDto = JsonSerializer.Deserialize<ICollection<SehirlerSelectDto>>(result);
                //var sehirlerVM = JsonSerializer.Deserialize<ICollection<SehirlerDto>>(result);


                //for (int i = 0; i < GelenSonuc.Count; i++)
                //{

                //}


                //foreach (var item in sonuc)
                //{
                //    //var response2 = httpClient2.GetAsync(ulke + "/" + item.ulkeId);
                //    //var resul2 = await response2.Result.Content.ReadAsStringAsync();
                //    //var sonuc2 = JsonSerializer.Deserialize<ICollection<UlkeSelectDto>>(resul2);


                //    return View(sonuc);
                //}

                return View(selectDto);
            }

            return View();



        }
        #endregion


        #region GET ULKELER
        [NonAction]
        public async Task<List<SelectListItem>> GetUlkelerAsync()
        {
            List<SelectListItem> ulkelerListItem = new();

            ApiUrl ulkeUrl = new ApiUrl("Ulke");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ulkeUrl.GetAll);
            //var url = httpClient.BaseAddress + "Sehir/FindAllInclude";
            var response = httpClient.GetAsync(httpClient.BaseAddress);

            if (response != null)
            {
                //var result = await response.Content.ReadAsStringAsync();
                var result2 = await response.Result.Content.ReadAsStringAsync();
                var sonuc = JsonSerializer.Deserialize<ICollection<UlkeSelectDto>>(result2);
                foreach (var item in sonuc)
                {
                    SelectListItem listItem = new SelectListItem()
                    {
                        Text = item.ulkeAdi,
                        Value = item.id.ToString()
                    };

                    ulkelerListItem.Add(listItem);
                }
            }
            return ulkelerListItem;
        }
        #endregion


        #region CREATE
        [HttpGet]
        public async Task<IActionResult> Post()
        {
            SehirlerInsertDto sehirInsertDto = new SehirlerInsertDto();
            ApiUrl ulkeUrl = new ApiUrl("Ulke");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ulkeUrl.GetAll);
            //var url = httpClient.BaseAddress + "Sehir/FindAllInclude";
            var response = httpClient.GetAsync(httpClient.BaseAddress);

            if (response != null)
            {
                List<SelectListItem> ulkelerListItem = new();
                //var result = await response.Content.ReadAsStringAsync();
                var result2 = await response.Result.Content.ReadAsStringAsync();
                var sonuc = JsonSerializer.Deserialize<ICollection<UlkeSelectDto>>(result2);
                foreach (var item in sonuc)
                {
                    SelectListItem listItem = new SelectListItem()
                    {
                        Text = item.ulkeAdi,
                        Value = item.id.ToString()
                    };

                    ulkelerListItem.Add(listItem);
                }
                ViewBag.UlkeListItems = await GetUlkelerAsync();
                return View(sehirInsertDto);
            }
            return View(sehirInsertDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SehirlerInsertDto sehirDto)
        {
            if (!ModelState.IsValid)
            {
                return View(sehirDto);
            }

            ApiUrl sehirUrl = new ApiUrl("Sehir");
            HttpClient httpClient = new HttpClient();


            httpClient.BaseAddress = new Uri(sehirUrl.Post);
            //var url = httpClient.BaseAddress + "Sehir/FindAllInclude";
            Sehir sehir = new Sehir
            {
                Id = 0,
                SehirAdi = sehirDto.SehirAdi,
                UlkeId = sehirDto.UlkeId,
                SehirKodu = sehirDto.SehirKodu
            };

            var serializeSehir = JsonSerializer.Serialize(sehir);
            StringContent stringContent = new StringContent(serializeSehir, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(httpClient.BaseAddress, stringContent).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UlkeListItems = await GetUlkelerAsync();
                return View(sehirDto);
            }
        }

        #endregion


        #region UPDATE
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SehirUpdateDto sehirUpdateDto = new SehirUpdateDto();
            ApiUrl sehirUrl = new ApiUrl("Sehir");
            HttpClient httpClient = new HttpClient();
            var ulke = httpClient.BaseAddress = new Uri("https://localhost:7229/api/Ulke");
            httpClient.BaseAddress = new Uri(sehirUrl.GetById + "/" + id);
            //var url = httpClient.BaseAddress + "Sehir/FindAllInclude";
            var response = await httpClient.GetAsync(httpClient.BaseAddress);
            var response2 = await httpClient.GetAsync(ulke);

            if (response != null)
            {
                List<SelectListItem> ulkelerListItem = new();
                //var result = await response.Content.ReadAsStringAsync();
                var result2 = await response.Content.ReadAsStringAsync();
                var result3 = await response2.Content.ReadAsStringAsync();
                var sonuc = JsonSerializer.Deserialize<ICollection<UlkeSelectDto>>(result3);
                var sonuc2 = JsonSerializer.Deserialize<SehirUpdateDto>(result2);

                sehirUpdateDto.SehirId = sonuc2.SehirId;
                sehirUpdateDto.SehirAdi = sonuc2.SehirAdi;
                sehirUpdateDto.SehirKodu = sonuc2.SehirKodu;
                sehirUpdateDto.UlkeId = sonuc2.UlkeId;

                foreach (var item in sonuc)
                {
                    SelectListItem listItem = new SelectListItem()
                    {
                        Text = item.ulkeAdi,
                        Value = item.id.ToString()
                    };

                    ulkelerListItem.Add(listItem);
                }
                ViewBag.UlkeListItems = await GetUlkelerAsync();
                return View(sehirUpdateDto);
            }
            return View(sehirUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, SehirUpdateDto sehirUpdateDto)
        {

            if (!ModelState.IsValid)
            {
                return View(sehirUpdateDto);
            }

            ApiUrl sehirUrl = new ApiUrl("Sehir");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(sehirUrl.Put + "/" + id);
            //var url = httpClient.BaseAddress + "Sehir/FindAllInclude";
            Sehir sehir = new Sehir
            {
                Id = id,
                SehirAdi = sehirUpdateDto.SehirAdi,
                UlkeId = sehirUpdateDto.UlkeId,
                SehirKodu = sehirUpdateDto.SehirKodu
            };

            var serializeSehir = JsonSerializer.Serialize(sehir);
            StringContent stringContent = new StringContent(serializeSehir, Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(httpClient.BaseAddress, stringContent).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UlkeListItems = await GetUlkelerAsync();
                return View(sehirUpdateDto);
            }
        }
        #endregion


        #region DELETE

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ApiUrl sehirUrl = new ApiUrl("Sehir");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(sehirUrl.GetById + "/" + id);
            var response = await httpClient.DeleteAsync(httpClient.BaseAddress);
            return RedirectToAction("Index");

        }
        #endregion


    }
}
