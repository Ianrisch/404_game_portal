using System.Security.Cryptography;

namespace _404_game_portal.backend.Services;

public class PasswordHasher
{
    private static string _hashIdentifier = "$MYHASH$V1$";
    private static HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
    private static int _iterations = 10000;


    /// <summary>
    /// Size of salt.
    /// </summary>
    private const int SaltSize = 16;

    /// <summary>
    /// Size of hash.
    /// </summary>
    private const int HashSize = 20;

    /// <summary>
    /// Creates a hash from a password.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="iterations">Number of iterations.</param>
    /// <returns>The hash.</returns>
    public static string Hash(string password, int iterations)
    {
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, _hashAlgorithmName);
        var hash = pbkdf2.GetBytes(HashSize);

        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        var base64Hash = Convert.ToBase64String(hashBytes);

        return $"{_hashIdentifier}{iterations}${base64Hash}";
    }

    /// <summary>
    /// Creates a hash from a password with 10000 iterations
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>The hash.</returns>
    public static string Hash(string password)
    {
        return Hash(password, _iterations);
    }

    /// <summary>
    /// Checks if hash is supported.
    /// </summary>
    /// <param name="hashString">The hash.</param>
    /// <returns>Is supported?</returns>
    public static bool IsHashSupported(string hashString)
    {
        return hashString.Contains(_hashIdentifier);
    }

    /// <summary>
    /// Verifies a password against a hash.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="hashedPassword">The hash.</param>
    /// <returns>Could be verified?</returns>
    public static bool Verify(string password, string hashedPassword)
    {
        if (!IsHashSupported(hashedPassword))
        {
            throw new NotSupportedException("The hashtype is not supported");
        }

        var splittedHashString = hashedPassword.Replace(_hashIdentifier, "").Split('$');
        var iterations = int.Parse(splittedHashString[0]);
        var base64Hash = splittedHashString[1];

        var hashBytes = Convert.FromBase64String(base64Hash);

        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, _hashAlgorithmName);
        var hash = pbkdf2.GetBytes(HashSize);

        return IsHashMatch(hashBytes, hash);
    }

    private static bool IsHashMatch(byte[] hashBytes, byte[] hash)
    {
        for (var i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != hash[i])
                return false;
        }

        return true;
    }
}