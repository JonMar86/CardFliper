using System.Collections.Generic;
using Newtonsoft.Json;

namespace CardFlipperServer.Data
{
    [JsonObject]
    public class FileDbSchema
    {
        [JsonProperty]
        public Dictionary<string, GameState> GameSaves { get; set; } = new Dictionary<string, GameState>();

        [JsonProperty]
        public Dictionary<string, string> HighScores { get; set; } = new Dictionary<string, string>();
    }
}
