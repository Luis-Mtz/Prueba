using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Descripción breve de UtiEncryption
/// </summary>
public class UtiEncryption
{
	public UtiEncryption()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public SymmetricAlgorithm GetAlgorithm()
    {
        return new RijndaelManaged();
    }

    public byte[] GenerateKey()
    {
        SymmetricAlgorithm algorithm = GetAlgorithm();
        algorithm.GenerateKey();
        return algorithm.Key;
    }

    public byte[] GenerateIV()
    {
        SymmetricAlgorithm algorithm = GetAlgorithm();
        algorithm.GenerateIV();
        return algorithm.IV;
    }

    private ICryptoTransform GetCrytoTransfomer(CryptoDirection direction, Byte[] key, Byte[] IV)
    {
        SymmetricAlgorithm algorithm = GetAlgorithm();
        algorithm.Mode = CipherMode.CBC;

        if (key == null)
            key = algorithm.Key;
        else
            algorithm.Key = key;
        if (IV == null)
            IV = algorithm.IV;
        else
            algorithm.IV = IV;
        switch (direction)
        {
            case CryptoDirection.Encrypt:
                return algorithm.CreateEncryptor();
                break;
            case CryptoDirection.Decrypt:
                return algorithm.CreateDecryptor();
                break;
            default:
                throw new ArgumentException("Invalid Crypto Direction");
                break;
        }
    }

    public string EncryptString(string valueToEncrypt, byte[] key, byte[] IV)
    {
        ASCIIEncoding encoder = new ASCIIEncoding();
        byte[] value = encoder.GetBytes(valueToEncrypt);
        byte[] encrypted = EncryptByteArray(value, key, IV);
        return Convert.ToBase64String(encrypted);
    }

    public byte[] EncryptByteArray(byte[] byteArrayToEncrypt, byte[] key, byte[] IV)
    {
        ICryptoTransform algorithm = GetCrytoTransfomer(CryptoDirection.Encrypt, key, IV);
        MemoryStream buffer = new MemoryStream();
        CryptoStream encStream = new CryptoStream(buffer, algorithm, CryptoStreamMode.Write);
        try
        {
            encStream.Write(byteArrayToEncrypt, 0, byteArrayToEncrypt.Length);
            encStream.FlushFinalBlock();
        }
        catch (Exception ex)
        {
            throw new IOException("Could not encrypt data", ex);
        }
        finally
        {
            encStream.Close();
        }
        return buffer.ToArray();
    }

    public string DecryptString(string valueToDecrypt, byte[] key, byte[] IV)
    {
        ASCIIEncoding encoder = new ASCIIEncoding();
        byte[] value = Convert.FromBase64String(valueToDecrypt);
        byte[] decrypted = DecryptByteArray(value, key, IV);
        return encoder.GetString(decrypted);
    }

    public byte[] DecryptByteArray(byte[] byteArrayToEncrypt, byte[] key, byte[] IV)
    {
        ICryptoTransform algorithm = GetCrytoTransfomer(CryptoDirection.Decrypt, key, IV);
        MemoryStream buffer = new MemoryStream();
        CryptoStream decStream = new CryptoStream(buffer, algorithm, CryptoStreamMode.Write);
        try
        {
            decStream.Write(byteArrayToEncrypt, 0, byteArrayToEncrypt.Length);
            decStream.FlushFinalBlock();
        }
        catch (Exception ex)
        {
            throw new IOException("Could not decrypt data", ex);
        }
        finally
        {
            decStream.Close();
        }
        return buffer.ToArray();
    }

}

public enum EncryptionAlgorithmType
{
    DES,
    RC2,
    Rijndael,
    TripleDES
}

public enum CryptoDirection
{
    Encrypt,
    Decrypt
}