using System.Text.RegularExpressions;

namespace E_Project_3_API.Services.Utility
{
    public class RegexManagement
    {
        public static bool IsEmail(string email)
        {
            string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(strRegex);

            return regex.IsMatch(email);
        }
        public static bool IsPhoneNumber(string phoneNumber)
        {
            string strRegex = @"^\+?\d{1,3}[-. ]?\(?\d{1,4}\)?[-. ]?\d{1,4}[-. ]?\d{1,4}$";
            Regex regex = new Regex(strRegex);

            return regex.IsMatch(phoneNumber);
        }
    }
}
