using App.Models;

namespace App.Services.Interfaces
{
    public interface IPrize
    {
        public Task<List<PrizeModel>?> getPrizes();

    }
}