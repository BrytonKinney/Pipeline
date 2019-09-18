using Newtonsoft.Json;

namespace Pipeline.Shared.Entities.Repositories.DTO.Git
{
    [JsonObject]
    public class GitWebhook
    {
        public string Action { get; set; }

        public Repository SourceRepository { get; set; }
    }
}
