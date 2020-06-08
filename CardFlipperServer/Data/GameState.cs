using Newtonsoft.Json;

namespace CardFlipperServer.Data
{
    [JsonObject]
    public class GameState
    {
        [JsonProperty]
        public int Seed { get; set; }

        [JsonIgnore]
        public int TotalCards => UniqueCards * 2 * RepeatsPerCard;

        [JsonProperty]
        public int UniqueCards { get; set; }

        [JsonProperty]
        public int RepeatsPerCard { get; set; } = 1;

        [JsonProperty]
        public int[] MatchesFound { get; set; } = new int[0];

        [JsonProperty]
        public int Mismatches { get; set; }

        [JsonIgnore]
        public int MatchesLeft => this.TotalCards - this.MatchesFound.Length;
    }
}
