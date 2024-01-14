using CodereTest.Domain.Entities;
using CodereTest.Domain.Services;
using ISF.FAF_RF.Domain.Common;
using Newtonsoft.Json;

namespace CodereTest.Infrastructure.Services
{
    public class TvMazeService : ITvMazeService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string _APIURL = "http://api.tvmaze.com/shows/";

        public TvMazeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ShowItem> GetShowById(int id, CancellationToken cancellationToken)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(_APIURL+id);

            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var showItemResponse = JsonConvert.DeserializeObject<ShowItem>(content)!;
                return ResetIds(showItemResponse);
            }
            else
            {
                throw new AppException(CustomError.IdError);
            }
        }

        private ShowItem ResetIds(ShowItem showItem)
        {
            showItem.Id = 0;
            showItem.Rating.Id = 0;
            showItem.Network.Id = 0;
            showItem.Network.Country.Id = 0;
            showItem.Externals.Id = 0;
            showItem.Image.Id = 0;
            showItem.Schedule.Id = 0;

            return showItem;
        }
    }
}
