﻿namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, username, password, emailAddress;
            int age;

            // get the user inputs until all are valid.
            // The username should only be output once

            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();


            while (ValidName(firstName) == false)
            {
                Console.WriteLine("Please enter a at least 2 character and only letters ");
                firstName = Console.ReadLine();
                ValidName(firstName);
            }


            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();

            while (ValidName(lastName) == false)
            {
                Console.WriteLine("Please enter a 2 character and only letter name");
                lastName = Console.ReadLine();
                ValidName(lastName);
            }



            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());

            while (validAge(age) == false)
            {
                Console.WriteLine("Please enter an age between 11 and 18");
                age = Convert.ToInt32(Console.ReadLine());
                validAge(age);
            }

            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            Console.Write("Enter email address: ");
            emailAddress = Console.ReadLine();


            username = createUserName(firstName, lastName, age);
            Console.WriteLine($"Username is {username}, you have successfully registered please remember your password");

            //  Test your program with a range of tests to show all validation works
            // Show your evidence in the Readme

        }

        static bool validAge(int age)
        {
            //age must be between 11 and 18 inclusive
            if (age < 11 || age > 18)
            {
                return false;
            }

            return true;
        }


        static bool ValidName(string name)
        {
            // name must be at least two characters and contain only letters
            int numOfChars = 0;
            numOfChars = name.Length;
            int num1;
            bool valid = int.TryParse(name, out num1);
            if (numOfChars < 2 || valid == true ) 

            {
                return false;
            }

            return true;
        }

        static bool ValidPassword(string password)
        {
            // Check password is at least 8 characters in length


            // Check password contains a mix of lower case, upper case and non letter characters
            // QWErty%^& = valid
            // QWERTYUi = not valid
            // ab£$%^&* = not valid
            // QWERTYu! = valid


            // Check password contains no runs of more than 2 consecutive or repeating letters or numbers
            // AAbbdd!2 = valid (only 2 consecutive letters A and B and only 2 repeating of each)
            // abC461*+ = not valid (abC are 3 consecutive letters)
            // 987poiq! = not valid (987 are consecutive)


            return true;
        }
        static bool validEmail(string email)
        {
            // a valid email address
            // has at least 2 characters followed by an @ symbol
            // has at least 2 characters followed by a .
            // has at least 2 characters after the .
            // contains only one @ and any number of .
            // does not contain any other non letter or number characters
            return true;
        }
        static string createUserName(string firstName, string lastName, int age)
        {
            // username is made up from:
            // first two characters of first name
            // last two characters of last name
            // age
            //e.g. Bob Smith aged 34 would have the username Both34
            firstName = firstName.Substring(0, 2);
            int lastnamelength = lastName.Length;
            
            lastName = lastName.Substring((lastnamelength-2),(lastnamelength-1));
            
            return (firstName + lastName + age);
        }

    }
}
