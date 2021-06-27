using HostExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HostExample.Controllers
{
    public class PageResponse
    {
        public string Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public IEnumerable<Movie> Data { get; set; }
    }

    public class Movie
    {
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }

        [JsonProperty("submission_count")]
        public int Submission_count { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = GetMoviesAsync(10).GetAwaiter().GetResult();
            ViewBag.Message = $"Retrieved {movies.Count()} movies.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        private static async Task<IEnumerable<Movie>> GetMoviesAsync(int threshold)
        {
            var movies = new List<Movie>();
            //var url = "http://jsonmock.hackerrank.com/api/movies/search/?Title=spiderman";
            var url = "https://jsonmock.hackerrank.com/api/article_users?";
            int currentPage = 1;
            int totalPages = 0;
            var nextUrl = $"{url}&page={currentPage}";

            using (var httpClient = new HttpClient())
            {
                do
                {
                    //
                    //https://jsonmock.hackerrank.com/api/article_users?page=3
                    //{"page":1,"per_page":10,"total":15,"total_pages":2,"data":[{"id":1,"username":"epaga","about":"Java developer / team leader at inetsoftware.de by day<p>iOS developer by night<p>http://www.mindscopeapp.com<p>http://inflightassistant.info<p>http://appstore.com/johngoering<p>[ my public key: https://keybase.io/johngoering; my proof: https://keybase.io/johngoering/sigs/I1UIk7t3PjfB5v2GI-fhiOMvdkzn370_Z2iU5GitXa0 ]<p>hnchat:oYwa7PJ4Yaf1Vw9Om4ju","submitted":654,"updated_at":"2019-08-29T13:45:12.000Z","submission_count":197,"comment_count":439,"created_at":1301039509},{"id":2,"username":"patricktomas","about":"[ my public key: https://keybase.io/ptrcktms; my proof: https://keybase.io/ptrcktms/sigs/Z_woLEAc6ZrVtIAdZbAyp23r7vsL_clxNE3RE8DEmGQ ]","submitted":9,"updated_at":"2019-01-29T22:47:01.000Z","submission_count":6,"comment_count":3,"created_at":1255392958},{"id":3,"username":"saintamh","about":"","submitted":8,"updated_at":"2019-08-21T10:04:13.000Z","submission_count":4,"comment_count":4,"created_at":1267029423},{"id":4,"username":"panny","about":"","submitted":71,"updated_at":"2019-09-06T11:13:29.000Z","submission_count":51,"comment_count":15,"created_at":1510174513},{"id":5,"username":"olalonde","about":"olalonde@gmail.com<p>http://www.github.com/olalonde<p>CTO/Co-Founder @ https://binded.com","submitted":4561,"updated_at":"2019-09-08T09:26:52.000Z","submission_count":1032,"comment_count":3045,"created_at":1261051630},{"id":6,"username":"WisNorCan","about":"bayesian optimist","submitted":177,"updated_at":"2019-07-26T01:40:10.000Z","submission_count":42,"comment_count":107,"created_at":1497196382},{"id":7,"username":"dmmalam","about":"Cofounder OctaveWealth (YCS12)","submitted":765,"updated_at":"2019-08-12T21:38:21.000Z","submission_count":645,"comment_count":115,"created_at":1312041112},{"id":8,"username":"replicatorblog","about":"https://twitter.com/josephflaherty<p>Formerly Wired:<p>https://www.wired.com/author/joseph-flaherty/<p>Now covering startups for Founder Collective, a fantastic VC firm:<p>http://www.foundercollective.com/","submitted":1441,"updated_at":"2019-09-06T02:06:35.000Z","submission_count":550,"comment_count":790,"created_at":1224455310},{"id":9,"username":"eightturn","about":"twitter: @searchbound","submitted":84,"updated_at":"2019-08-10T21:33:15.000Z","submission_count":7,"comment_count":75,"created_at":1405978844},{"id":10,"username":"vladikoff","about":"[ my public key: https://keybase.io/vladikoff; my proof: https://keybase.io/vladikoff/sigs/jxMsGDORM-qiAf0bQy91Uw4RYpHNeQa1bZD3WFdIZWo ]","submitted":65,"updated_at":"2019-05-10T22:04:36.000Z","submission_count":15,"comment_count":50,"created_at":1298054029}]}
                    HttpResponseMessage response = await httpClient.GetAsync(nextUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var pageResponse = JsonConvert.DeserializeObject<PageResponse>(json);

                        if (pageResponse != null && pageResponse.Data.Any())
                        {
                            movies.AddRange(pageResponse.Data);
                            totalPages = pageResponse.TotalPages;

                            currentPage++;
                            nextUrl = $"{url}&page={currentPage}";
                        }
                        else
                        {
                            break; // or throw exception
                        }
                    }
                    else
                    {
                        break; // or throw exception
                    }
                } while (currentPage <= totalPages);
            }

            return movies.Where(x=>x.Submission_count>threshold);
        }
        /*
         {"page":1,"per_page":10,"total":15,"total_pages":2,"data":[{"id":1,"username":"epaga","about":"Java developer / team leader at inetsoftware.de by day<p>iOS developer by night<p>http://www.mindscopeapp.com<p>http://inflightassistant.info<p>http://appstore.com/johngoering<p>[ my public key: https://keybase.io/johngoering; my proof: https://keybase.io/johngoering/sigs/I1UIk7t3PjfB5v2GI-fhiOMvdkzn370_Z2iU5GitXa0 ]<p>hnchat:oYwa7PJ4Yaf1Vw9Om4ju","submitted":654,"updated_at":"2019-08-29T13:45:12.000Z","submission_count":197,"comment_count":439,"created_at":1301039509},{"id":2,"username":"patricktomas","about":"[ my public key: https://keybase.io/ptrcktms; my proof: https://keybase.io/ptrcktms/sigs/Z_woLEAc6ZrVtIAdZbAyp23r7vsL_clxNE3RE8DEmGQ ]","submitted":9,"updated_at":"2019-01-29T22:47:01.000Z","submission_count":6,"comment_count":3,"created_at":1255392958},{"id":3,"username":"saintamh","about":"","submitted":8,"updated_at":"2019-08-21T10:04:13.000Z","submission_count":4,"comment_count":4,"created_at":1267029423},{"id":4,"username":"panny","about":"","submitted":71,"updated_at":"2019-09-06T11:13:29.000Z","submission_count":51,"comment_count":15,"created_at":1510174513},{"id":5,"username":"olalonde","about":"olalonde@gmail.com<p>http://www.github.com/olalonde<p>CTO/Co-Founder @ https://binded.com","submitted":4561,"updated_at":"2019-09-08T09:26:52.000Z","submission_count":1032,"comment_count":3045,"created_at":1261051630},{"id":6,"username":"WisNorCan","about":"bayesian optimist","submitted":177,"updated_at":"2019-07-26T01:40:10.000Z","submission_count":42,"comment_count":107,"created_at":1497196382},{"id":7,"username":"dmmalam","about":"Cofounder OctaveWealth (YCS12)","submitted":765,"updated_at":"2019-08-12T21:38:21.000Z","submission_count":645,"comment_count":115,"created_at":1312041112},{"id":8,"username":"replicatorblog","about":"https://twitter.com/josephflaherty<p>Formerly Wired:<p>https://www.wired.com/author/joseph-flaherty/<p>Now covering startups for Founder Collective, a fantastic VC firm:<p>http://www.foundercollective.com/","submitted":1441,"updated_at":"2019-09-06T02:06:35.000Z","submission_count":550,"comment_count":790,"created_at":1224455310},{"id":9,"username":"eightturn","about":"twitter: @searchbound","submitted":84,"updated_at":"2019-08-10T21:33:15.000Z","submission_count":7,"comment_count":75,"created_at":1405978844},{"id":10,"username":"vladikoff","about":"[ my public key: https://keybase.io/vladikoff; my proof: https://keybase.io/vladikoff/sigs/jxMsGDORM-qiAf0bQy91Uw4RYpHNeQa1bZD3WFdIZWo ]","submitted":65,"updated_at":"2019-05-10T22:04:36.000Z","submission_count":15,"comment_count":50,"created_at":1298054029}]}
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
