namespace FileSorting.Core.Configs
{
    public interface ISortingConfig
    {
        string SortingPath { get; set; }
        ChangeNameState ChangeState { get; set; }
    }
}
