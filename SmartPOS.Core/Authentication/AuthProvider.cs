using System;

namespace SmartPOS.Core.Authentication
{
    public class AuthProvider
    {
        public User Authenticate(string username, string password)
        {
            if (username == password)
                return new User
                {
                    FirstName = "Admin",
                    LastName = "istrator"
                };

            throw new Exception("Authentication failed.");
        }
    }
}