using Newtonsoft.Json;

namespace CardFlipperGame.Saving
{
    [JsonObject]
    public class GameState
    {
        [JsonProperty]
        public int Seed { get; set; }

        [JsonProperty]
        public string[] MatchesFound { get; set; }
    }
}
