using System;

namespace Collections
{
    public class User : IUser
    {
        private readonly string _fullName;
        private readonly string _username;
        private readonly uint? _age;
        public User(string fullName, string username, uint? age)
        {
            if( username != null)
            {
                _fullName = fullName;
                _username = username;
                _age = age;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => _age != null;

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   _fullName == user._fullName &&
                   _username == user._username &&
                   _age == user._age &&
                   Age == user.Age &&
                   FullName == user.FullName &&
                   Username == user.Username &&
                   IsAgeDefined == user.IsAgeDefined;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_fullName, _username, _age, Age, FullName, Username, IsAgeDefined);
        }
    }
}
