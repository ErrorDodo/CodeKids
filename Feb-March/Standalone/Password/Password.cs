/*

Rules:
    - Password must be at least 8 characters long
    - Password must contain at least one uppercase letter
    - Password must contain at least one lowercase letter
    - Password must contain at least one number
    - Password must contain at least one special character
    - Password must not contain any whitespace
    - Password must not be the same as the username
    - If the password breaks one of the rules, the program should output which rule was broken
    - If the password breaks more than one rule, the program should output all the rules that were broken
    - If a rule is broken, the program should ask to re-input a new password
    
    
    --- New Rules ---
    
    - Program must save the username and password along with date saved to a json folder
    
*/

using Password.Services;

namespace Password;

internal static class Password
{
    private static void Main()
    {
        Console.WriteLine("Enter your username:");
        var username = Console.ReadLine();

        var isValidPassword = false;
        var password = Console.ReadLine();
        while (!isValidPassword)
        {
            Console.WriteLine("Enter your password:");

            if (password == null) continue;
            if (username == null) continue;
            
            var errors = ValidatePassword(password, username);
            if (errors.Count == 0)
            {
                Console.WriteLine("Password is valid!");
                isValidPassword = true;
                var fileHelper = new FileHelper();
                var result = fileHelper.SaveFile(username, password);
                if (result)
                {
                    Console.WriteLine("Password Saved");
                }
                else
                {
                    Console.WriteLine("Password failed to save");
                }
            }
            else
            {
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
        }
    }

    private static List<string> ValidatePassword(string password, string username)
    {
        var errors = new List<string>();

        // Check password length
        if (password.Length < 8)
        {
            errors.Add("Password must be at least 8 characters long.");
        }

        // Initializing flags for character checks
        var hasUppercase = false;
        var hasLowercase = false;
        var hasNumber = false;
        var hasSpecial = false;

        // Check for required character types
        foreach (var c in password)
        {
            if (char.IsUpper(c)) hasUppercase = true;
            if (char.IsLower(c)) hasLowercase = true;
            if (char.IsDigit(c)) hasNumber = true;
            if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)) hasSpecial = true;
        }

        // Adding errors based on missing character types
        if (!hasUppercase) errors.Add("Password must contain at least one uppercase letter.");
        if (!hasLowercase) errors.Add("Password must contain at least one lowercase letter.");
        if (!hasNumber) errors.Add("Password must contain at least one number.");
        if (!hasSpecial) errors.Add("Password must contain at least one special character.");
        if (password.Contains(' ')) errors.Add("Password must not contain any whitespace.");
        if (password.Equals(username)) errors.Add("Password must not be the same as the username.");

        return errors;
    }
}