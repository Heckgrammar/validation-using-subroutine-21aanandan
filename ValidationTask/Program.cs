namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            {
                string firstName, lastName, username, password, emailAddress;
                int age;

                // get the user inputs until all are valid.
                // The username should only be output once

                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();
                while (!ValidName(firstName))
                {
                    Console.WriteLine("Please enter at least 2 characters and only letters.");
                    firstName = Console.ReadLine();
                }

                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
                while (!ValidName(lastName))
                {
                    Console.WriteLine("Please enter at least 2 characters and only letters.");
                    lastName = Console.ReadLine();
                }

                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                while (!validAge(age))
                {
                    Console.WriteLine("Please enter an age between 11 and 18.");
                    age = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                while (!ValidPassword(password))
                {
                    Console.WriteLine("Password must be at least 8 characters long, contain both upper and lower case letters, non-letter characters, and no runs of more than 2 consecutive characters.");
                    password = Console.ReadLine();
                }

                Console.Write("Enter email address: ");
                emailAddress = Console.ReadLine();
                while (!validEmail(emailAddress))
                {
                    Console.WriteLine("Please enter a valid email address.");
                    emailAddress = Console.ReadLine();
                }

                username = createUserName(firstName, lastName, age);
                Console.WriteLine($"Username is {username}, you have successfully registered. Please remember your password.");
            }

            static bool validAge(int age)
            {
                // Age must be between 11 and 18 inclusive
                return age >= 11 && age <= 18;
            }

            static bool ValidName(string name)
            {
                // Name must be at least two characters and contain only letters
                return name.Length >= 2 && name.All(char.IsLetter);
            }

            static bool ValidPassword(string password)
            {
                // Check if the password is at least 8 characters long
                if (password.Length < 8)
                    return false;

                // Check if the password contains at least one uppercase, one lowercase, and one non-letter character
                if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(ch => !char.IsLetterOrDigit(ch)))
                    return false;

                // Check for consecutive or repeating characters
                for (int i = 0; i < password.Length - 2; i++)
                {
                    if (password[i] == password[i + 1] && password[i] == password[i + 2])
                        return false;  // Repeating characters more than twice
                    if (password[i + 1] == password[i] + 1 && password[i + 2] == password[i] + 2)
                        return false;  // Consecutive characters
                }

                return true;
            }

            static bool validEmail(string email)
            {
                // Ensure email contains exactly one "@" symbol
                if (email.Count(c => c == '@') != 1)
                    return false;

                // Split email into local part and domain part
                var emailParts = email.Split('@');
                var localPart = emailParts[0];
                var domainPart = emailParts[1];

                // Check that local part (before "@") is at least 2 characters
                if (localPart.Length < 2)
                    return false;

                // Ensure domain contains at least one dot "." and is not too short
                if (!domainPart.Contains('.') || domainPart.Length < 3)
                    return false;

                // Ensure the domain has valid segments (at least 2 characters before and after each dot)
                var domainSegments = domainPart.Split('.');
                if (domainSegments.Any(segment => segment.Length < 2))
                    return false;

                // Validate local part: letters, digits, dots, underscores, and hyphens are allowed
                if (!localPart.All(c => char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '-'))
                    return false;

                // Validate domain part: letters, digits, dots, and hyphens are allowed
                if (!domainPart.All(c => char.IsLetterOrDigit(c) || c == '.' || c == '-'))
                    return false;

                return true;
            }



            static string createUserName(string firstName, string lastName, int age)
            {
                // Username is made up from:
                // First two characters of the first name
                // Last two characters of the last name
                // The age

                firstName = firstName.Substring(0, 2);
                lastName = lastName.Substring(lastName.Length - 2);

                return firstName + lastName + age;
            }
        }
    }

}

