using System.Text.Json.Serialization;
using F358.Shared.Enums;
using F358.Shared.Extensions;

namespace F358.Shared.Dto;

[Serializable]
public record ProcessResult
{
    public HashSet<string> Errors { get; init; } = [];
    public HashSet<string> Warnings { get; init; } = [];
    public HashSet<string> Messages { get; init; } = [];
    
    public ProcessResultStatus? ForceStatus { get; set; }

    [JsonIgnore]
    public ProcessResultStatus StatusType =>
        (ForceStatus, Errors: Errors.Count, Warnings: Warnings.Count, Messages: Messages.Count) switch
        {
            { ForceStatus: not null } => ForceStatus.Value,
            { Errors: > 0 } => ProcessResultStatus.Error,
            { Warnings: > 0 } => ProcessResultStatus.Warning,
            _ => ProcessResultStatus.Success
        };

    public string Status => StatusType.GetString();


    public void SetStatus(ProcessResultStatus status) => ForceStatus = status;
    public void ClearStatus(ProcessResultStatus status) => ForceStatus = null;
}