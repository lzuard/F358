namespace F358.Shared.Dto;

public record ProcessResultWithData<T> : ProcessResult
{
    public List<T> Data { get; set; } = [];
}