using System;
using System.Text.RegularExpressions;

namespace SmartMedPharmacy.Utilities
{
    public static class Validator
    {
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidEmail(string email)
        {
            if (IsEmpty(email)) return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public static bool IsValidPhone(string phone)
        {
            if (IsEmpty(phone)) return false;
            string pattern = @"^\+?[0-9]{7,15}$";
            return Regex.IsMatch(phone, pattern);
        }

        public static bool IsValidPassword(string password, int minLength = 6)
        {
            if (password == null) return false;
            return password.Length >= minLength;
        }

        public static bool IsValidPrice(string input, out decimal price)
        {
            price = 0;
            if (IsEmpty(input)) return false;
            if (decimal.TryParse(input, out price))
            {
                return price >= 0;
            }
            return false;
        }

        public static bool IsValidStock(string input, out int stock)
        {
            stock = 0;
            if (IsEmpty(input)) return false;
            if (int.TryParse(input, out stock))
            {
                return stock >= 0;
            }
            return false;
        }

        public static bool IsNumeric(string input)
        {
            if (IsEmpty(input)) return false;
            return decimal.TryParse(input, out _);
        }
    }
}
