using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace com.jesusnoseq.util
{
    public static class Hasher
    {
        public static string SHA256(string text, Encoding encoding)
        {
            byte[] hashValue;
            byte[] message = encoding.GetBytes(text);

            SHA256Managed hashString = new SHA256Managed();
            string hex = "";
            
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
