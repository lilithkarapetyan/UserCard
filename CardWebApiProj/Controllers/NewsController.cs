using CardWebApiProj.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CardWebApiProj.Controllers
{
    public class NewsController : BaseController
    {
        protected HttpClient client = new HttpClient();

        [HttpGet]
        [Route("api/news")]
        public async Task<IHttpActionResult> Get()
        {             
            HttpResponseMessage response = await client.GetAsync(baseUri+"api/m/news2?PageSize=20&PageNumber=0");
            JObject product = null;
            if (response.IsSuccessStatusCode)
            {
                product =  await response.Content.ReadAsAsync<JObject>();
            }
          
            return Ok(product);
        }
        

        [HttpGet]
        [Route("api/news/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "api/m/news2/" + id);
            JObject news = null;
            if (response.IsSuccessStatusCode)
            {
                news = await response.Content.ReadAsAsync<JObject>();
            }

            return Ok(news);
        }


        [HttpGet]
        [Route("api/news/categories")]
        public async Task<IHttpActionResult> GetCategories()
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "api/categories");
            NewsCategory[] categories = null;
            if (response.IsSuccessStatusCode)
            {
                JArray jCategories = await response.Content.ReadAsAsync<JArray>();
                categories = JsonConvert.DeserializeObject<NewsCategory[]>(jCategories.ToString());
            }

            return Ok(categories);
        }



    }
}
