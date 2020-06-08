using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CardFlipperServer.Data
{
    public class GameSaverService : IGameSaverService
    {
        private const string fileDbPath = "wwwroot/FileDb.json";
        private static FileDbSchema fileDbSchema;

        public async Task<GameState> RetrieveGameSave(string key)
        {
            await LoadFileDb();

            if (fileDbSchema.GameSaves.TryGetValue(key, out GameState save))
            {
                return save;
            }

            return null;
        }

        public async Task StoreGameSave(string key, GameState state)
        {
            await LoadFileDb();

            fileDbSchema.GameSaves[key] = state;

            await UpdateFileDb();
        }

        public async Task<IList<string>> GetSaveGames()
        {
            await LoadFileDb();

            return new List<string>(fileDbSchema.GameSaves.Keys);
        }

        public async Task<Dictionary<string, string>> GetHighScores()
        {
            await LoadFileDb();

            return fileDbSchema.HighScores;
        }

        public async Task StoreHighScore(string key, string score)
        {
            await LoadFileDb();

            fileDbSchema.HighScores[key] = score;

            await UpdateFileDb();
        }

        private async Task LoadFileDb()
        {
            if (fileDbSchema == null)
            {
                string fileText = await File.ReadAllTextAsync(fileDbPath);
                fileDbSchema = JsonConvert.DeserializeObject<FileDbSchema>(fileText);
            }
        }

        private async Task UpdateFileDb()
        {
            if (fileDbSchema != null)
            {
                string fileText = JsonConvert.SerializeObject(fileDbSchema);
                await File.WriteAllTextAsync(fileDbPath, fileText);
            }
        }


    }
}
