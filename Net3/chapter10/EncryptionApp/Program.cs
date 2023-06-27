using Packt.Shared;
using System.Security;
using System.Security.Claims;
using static System.Console;

namespace Test
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            ValidateSecureFeature();

        }

        public static void ValidateSecureFeature()
        {
            try {
                SecureFeature();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void SecureFeature()
        { 
            if (Thread.CurrentPrincipal == null) 
            {
                throw new SecurityException("A user must be loggedin to access this feature");
            }

            if (!Thread.CurrentPrincipal.IsInRole("Admins"))
            { 
                throw new SecurityException("User must be a member of Admins to access this feature");
            }

            WriteLine("You have access to this feature");
        }

        public static void ValidateAuthentication()
        {
            Protector.Register("Alice", "Pa$$w0rd", new[] {"Admins"});
            Protector.Register("Bob", "Pa$$w0rd", new[] { "TeamLeads" });
            Protector.Register("Eve", "Pa$$w0rd");

            WriteLine($"Enter your name");
            string username = ReadLine();
            Write($"Enter your password");
            string password = ReadLine();

            Protector.Login(username, password);

            if (Thread.CurrentPrincipal == null)
            {
                WriteLine("Login failed");
                return;
            }

            var p = Thread.CurrentPrincipal;

            WriteLine($"Is authenticated : {p.Identity.IsAuthenticated}");
            WriteLine($"Authentication type : {p.Identity.AuthenticationType}");
            WriteLine($"Name : {p.Identity.Name}");
            WriteLine($"Is admin role  : {p.IsInRole("Admins")}");
            WriteLine($"Is sales role : {p.IsInRole("Sales")}");

            if (p is ClaimsPrincipal)
            {
                WriteLine($"{p.Identity} has following claims:");

                foreach (Claim claim in (p as ClaimsPrincipal).Claims)
                {
                    WriteLine($"claim type {claim.Type} : {claim.Value}");
                }
            }
        }

        public static void ValidatePasswordHashing()
        {
            WriteLine($"Registering Alice with Pa$$w0rd");
            var alice = Protector.Register("Alice", "Pa$$w0rd");
            WriteLine($"{alice.Name}");
            WriteLine($"{alice.Salt}");
            WriteLine($"{alice.SaltedHashedPassword}");

            bool checkPassword = Protector.CheckPassword("Alice", "Pa$$w0rd");
            WriteLine($"Is password match {checkPassword}");
        }

        public static void ValidateEncryption()
        {
            Write("Enter a message that you want to encrypt");
            string message = Console.ReadLine();
            WriteLine("Enter a password");
            string password = Console.ReadLine();

            string crytoText = Protector.Encrypt(message, password);

            WriteLine($"Encrypted password : {crytoText}");
            WriteLine("Enter the password");
            string password2 = ReadLine();

            try
            {
                string clearText = Protector.Decrypt(crytoText, password2);
                WriteLine($"Decrypted text {clearText}");
            }
            catch (Exception e)
            {
                WriteLine(e.ToString());
            }
        }
    }
}