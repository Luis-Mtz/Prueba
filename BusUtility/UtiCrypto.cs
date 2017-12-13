using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de UtiCrypto
/// </summary>
public static class UtiCrypto
{
    public static string Encriptar(string cadena)
    {
        char[] base64CharArray = new char[64];
        string base64String = new string("MTkRoQ4XAgVDDyvZyVz/ai0d46YvZ/GdaopC4dedzc0=".ToCharArray());

        char[] base64CharArray2 = new char[64];
        string base64String2 = new string("58eAVNxUFAGCel6X6FjnGw==".ToCharArray());

        byte[] key = Convert.FromBase64String(base64String);
        byte[] IV = Convert.FromBase64String(base64String2);
        UtiEncryption obj = new UtiEncryption();
        string cadenaEnc = obj.EncryptString(cadena, key, IV);
        return cadenaEnc;
    }

    public static string DesEncriptar(string cadena)
    {
        char[] base64CharArray = new char[64];
        string base64String = new string("MTkRoQ4XAgVDDyvZyVz/ai0d46YvZ/GdaopC4dedzc0=".ToCharArray());

        char[] base64CharArray2 = new char[64];
        string base64String2 = new string("58eAVNxUFAGCel6X6FjnGw==".ToCharArray());

        byte[] key = Convert.FromBase64String(base64String);
        byte[] IV = Convert.FromBase64String(base64String2);
        UtiEncryption obj = new UtiEncryption();
        string cadenaDes = obj.DecryptString(cadena, key, IV);
        return cadenaDes;
    }
}