public static class HashCollider
{
	private readonly Dictionary<string,string> dbDict;
	
	public void shorten(string longURL)
	{
		if(dbDict.ContainsKey(longURL))
			throw exception();
		while(no sql db contains shortURL)
		{
			using var SHA256 = SHA256.Create();
			byte[] hash = sha256.ComputeHash(Encoding.UTF.GetBytes(longURL));
			string hexString = BitConverter.ToString(hash).using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public static class HashCollider
{
    private static readonly Dictionary<string, string> dbDict = new(); // Initialize the dictionary

    public static string Shorten(string longURL, int length = 7)
    {
        // Check if the long URL already exists in the dictionary
        if (dbDict.ContainsKey(longURL))
            throw new Exception("URL already shortened!");

        string shortURL = "";
        while (dbDict.ContainsValue(shortURL) || string.IsNullOrEmpty(shortURL))
        {
            // Use SHA256 to generate the hash
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(longURL));

            // Convert hash to a hexadecimal string and take the first `length` characters
            string hexString = BitConverter.ToString(hash).Replace("-", "").ToLower(); // 64 hex chars
            shortURL = hexString.Substring(0, length);
        }

        // Save the mapping in the dictionary
        dbDict[longURL] = shortURL;
        return shortURL;
    }
}
Replace("-", "").ToLower(); // 64 hex chars
			var shortURL =  hexString.Substring(0, length);
		}
		dict[longURL] = shortURL;
	}
}