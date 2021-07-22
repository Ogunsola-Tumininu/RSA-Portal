using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace PalRSA.Helpers
{
    public class UtilityHelper
    {
        public static bool IsEmailValid(string emailAddress)
        {
            if (String.IsNullOrEmpty(emailAddress)) return false;

            var checkEmail = new EmailAddressAttribute();
            return (checkEmail.IsValid(emailAddress));
        }
        public static string GenerateRandomResetPassword()
        {
            const string passwordString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; //!%$
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string numeric = "0123456789";
            const string special = "!%$";
            const int pwdLenght = 8;
            var password = new StringBuilder();
            var rnd = new Random();
            password.Append(upper[rnd.Next(upper.Length)]);
            for (int i = 1; i <= 4; i++)
            {
                password.Append(lower[rnd.Next(lower.Length)]);
            }

            for (int i = 1; i <= 3; i++)
            {
                password.Append(numeric[rnd.Next(numeric.Length)]);
            }
            // return password.Append(special[rnd.Next(special.Length)]).ToString();
            return password.ToString();
        }
    }
}