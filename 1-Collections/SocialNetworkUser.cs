using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private IDictionary<string, ISet<TUser>> _followed = new Dictionary<string, ISet<TUser>>();

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if(_followed.ContainsKey(group) && _followed[group].Contains(user))
            {
                return false;
            }
            else
            {
                if(!(_followed.ContainsKey(group)))
                {
                    _followed.Add(group, new HashSet<TUser>());
                }
                _followed[group].Add(user);
                return true;
            }
        }

        public IList<TUser> FollowedUsers
        {
            get 
            {
                IList<TUser> AllFollowed = new List<TUser>();
                foreach (var group in _followed.Values)
                {
                    foreach (var user in group)
                    {
                        AllFollowed.Add(user);
                    }
                }
                return AllFollowed;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if(_followed.ContainsKey(group))
            {
                return _followed[group];
            }
            else
            {
                return new HashSet<TUser>();
            }
        }
    }
}
