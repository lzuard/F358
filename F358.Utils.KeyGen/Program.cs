using System.Security.Cryptography;
// ReSharper disable ConditionIsAlwaysTrueOrFalse



var funcType = FuncType.Rsa;

var rnd = RandomNumberGenerator.Create();
if (funcType == FuncType.BytesKey)
{
    var bytes = new byte[256];
    rnd.GetNonZeroBytes(bytes);
    Console.WriteLine($"Result:\n{Convert.ToBase64String(bytes)}");
}
else if (funcType == FuncType.Rsa)
{
    var rsa = RSA.Create();
    var privateKey = rsa.ExportRSAPrivateKey();
    var publicKey = rsa.ExportRSAPublicKey();
    
    Console.WriteLine($"PublicKey: {Convert.ToBase64String(publicKey)}");
    Console.WriteLine($"PrivateKey: {Convert.ToBase64String(privateKey)}");
}
else
{
    throw new NotImplementedException("Not implemented");
}






enum FuncType
{
    Rsa,
    BytesKey
}
