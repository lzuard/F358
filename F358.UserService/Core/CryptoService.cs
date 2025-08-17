using System.Security.Cryptography;
using F358.UserService.Base;
using F358.UserService.Dto;
using Microsoft.Extensions.Options;

namespace F358.UserService.Core;

internal class CryptoService(IOptions<SecretOptions> secretOptions)
{
     private const int CurrentVersion = 1;

    private const int KeySize = 256;
    private const int BlockSize = 128;


    public EncryptedData Encrypt(string text, int version = CurrentVersion) => version switch
    {
        1 => EncryptV1(text),
        _ => throw new NotImplementedException($"Algorithm v.{version} is not implemented.")
    };
    
    private EncryptedData EncryptV1(string text)
    { 
        using var aes = Aes.Create();
        aes.KeySize = KeySize;
        aes.BlockSize = BlockSize;
        aes.Key = GetKey();
        aes.GenerateIV();

        byte[] data;
        
        using (var encryptor = aes.CreateEncryptor())
        using (var stream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            using (var writer = new StreamWriter(cryptoStream))
            {
                writer.Write(text);
            }
            data = stream.ToArray();
        }
        
        var resultData = new byte[data.Length + aes.IV.Length];
        
        Array.Copy(aes.IV, 0, resultData, 0, aes.IV.Length);
        Array.Copy(data, 0, resultData, aes.IV.Length, data.Length);
        
        return new EncryptedData(resultData, 1);
    }

    public string Decrypt(EncryptedData encryptedData) =>
        Decrypt(encryptedData.Data, encryptedData.Version);
    
    public string Decrypt(byte[] data, int version = CurrentVersion) => version switch
    {
        1 => DecryptV1(data),
        _ => throw new NotImplementedException($"Algorithm v.{version} is not implemented.")
    };

    private string DecryptV1(byte[] data)
    {
        var iv = new byte[16];
        var actualData = new byte[data.Length - iv.Length];
        
        Array.Copy(data, 0, iv, 0, iv.Length);
        Array.Copy(data, iv.Length, actualData,0, actualData.Length);
        
        using var aes = Aes.Create();
        aes.KeySize = KeySize;
        aes.BlockSize = BlockSize;
        aes.IV = iv;
        aes.Key = GetKey();

        using (var decryptor = aes.CreateDecryptor())
        using (var stream = new MemoryStream(actualData))
        using (var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
        using (var reader = new StreamReader(cryptoStream))
        { 
            return reader.ReadToEnd();
        }
    }
    
    private byte[] GetKey() => Convert.FromBase64String(
        secretOptions.Value.AuthEncryptionKey ?? 
        throw new ArgumentNullException(null, "Encryption Key is null."));
}