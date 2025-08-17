namespace F358.UserService.Dto;

internal record EncryptedData(
    byte[] Data,
    int Version);