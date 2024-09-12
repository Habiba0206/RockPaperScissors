using System.Security.Cryptography;
using System.Text;

namespace Main;

public class HMACGenerator
{
    public byte[] GenerateSecureKey() 
    {
        byte[] key = new byte[32];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }

        return key;
    }

    public string ConvertKeyToHex(byte[] key) 
    {
        return BitConverter.ToString(key).Replace("-", "");
    }

    public string ComputeHMAC(string move, byte[] key)
    {
        using (var hmac = new HMACSHA256(key))
        {
            byte[] moveBytes = Encoding.UTF8.GetBytes(move);
            byte[] hash = hmac.ComputeHash(moveBytes);

            return ConvertKeyToHex(hash);
        }
    }
}
