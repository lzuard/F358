namespace F358.Services.User.Dto;

internal record EncryptedData(
    byte[] Data,
    int Version);