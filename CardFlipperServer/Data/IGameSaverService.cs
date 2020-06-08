using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardFlipperServer.Data
{
    interface IGameSaverService
    {
        Task StoreGameSave(string key, GameState state);

        Task StoreHighScore(string key, string score);

        Task<GameState> RetrieveGameSave(string key);

        Task<IList<string>> GetSaveGames();
    }
}
