using App.Models;
using App.Services.common;
using App.Services.Interfaces;
using Newtonsoft.Json;

namespace App.Services.Implements
{
    public class Prize : BaseClient, IPrize
    {
        public async Task<List<PrizeModel>?> getPrizes()
        {
            var response = await httpClient.GetAsync("api/Prizes/get-all");
            var result = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<List<PrizeModel>>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
