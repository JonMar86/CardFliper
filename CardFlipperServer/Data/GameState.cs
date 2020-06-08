using Newtonsoft.Json;

namespace CardFlipperServer.Data
{
    [JsonObject]
    public class GameState
    {
        [JsonProperty]
        public int Seed { get; set; }

        [JsonProperty]
        public int Pairs { get; set; }

        [JsonProperty]
        public int[] MatchesFound { get; set; } = new int[0];

        [JsonProperty]
        public int Mismatches { get; set; }

        [JsonIgnore]
        public int MatchesLeft => this.Pairs - this.MatchesFound.Length;
    }
}
