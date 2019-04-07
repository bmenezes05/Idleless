using Newtonsoft.Json;

namespace WebHackathon.CrossCutting
{
    public class ScoreResponse : ResponseBase
    {
        [JsonProperty(PropertyName = "Pontuacao")]
        public int Pontuacao { get; set; }
    }
}