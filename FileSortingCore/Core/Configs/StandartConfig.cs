using System.Text.Json.Serialization;

namespace FileSorting.Core.Configs
{
    public class StandartConfig : ISortingConfig
    {
        [JsonPropertyName("sorting_path")]
        public string SortingPath { get; set; }
        [JsonPropertyName("change_state")]
        public ChangeNameState ChangeState { get; set; }

        public StandartConfig(string sortingPath, ChangeNameState changeState)
        {
            SortingPath = sortingPath;
            ChangeState = changeState;
        }
    }
}
