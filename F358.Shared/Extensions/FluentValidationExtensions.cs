using FluentValidation.Results;

namespace F358.Shared.Extensions;

public static class FluentValidationExtensions
{
    public static HashSet<string> GetErrorMessages(this ValidationResult? validationResult) => 
        validationResult is null 
            ? [] 
            : validationResult.Errors.Select(x => x.GetMessage()).ToHashSet();

    private static string GetMessage(this ValidationFailure error) =>
        error.ErrorMessage;
}