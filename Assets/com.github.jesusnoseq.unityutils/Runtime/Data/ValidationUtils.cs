using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public class ValidationUtils
    {

        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        public const string MatchPasswordPattern = "/^.{6,}$/";


        public static bool Validate(string text, string pattern)
        {
            if (text != null)
                return Regex.IsMatch(text, pattern);

            return false;
        }

        public static bool ValidateEmail(string text)
        {
            return Validate(text, MatchEmailPattern);
        }

        public static bool ValidatePassword(string text)
        {
            return Validate(text, MatchPasswordPattern);
        }
    }
}
