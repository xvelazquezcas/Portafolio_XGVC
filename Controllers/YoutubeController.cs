using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using Portafolio_XGVC.Models;

namespace Portafolio_XGVC.Controllers
{
    public class YouTubeController : Controller
    {
        public async Task<IActionResult> IndexY()
        {
            // Configurar el servicio de YouTube con tu clave de API
            var youTubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyAiWpz6lDAoHyp8MJbrFr0Yi7Iq_aaQV-Y",
                ApplicationName = "Portafolio_EESA"
            });

            var searchListRequest = youTubeService.Search.List("snippet");
            searchListRequest.Q = "ElDardo Owo"; // Personaliza esto
            searchListRequest.MaxResults = 6; // Número de resultados que deseas mostrar

            var searchListResponse = await searchListRequest.ExecuteAsync();

            var videoList = searchListResponse.Items.Select(item => new YoutubeVideoModel
            {
                Title = item.Snippet.Title,
                VideoId = item.Id.VideoId
            }).ToList();

            return View(videoList);
        }
    }
}
