using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevActivator.Common.BL.Config;
using DevActivator.Common.DAL;
using DevActivator.Meetups.BL.Entities;
using DevActivator.Meetups.BL.Interfaces;
using DevActivator.Meetups.DAL.Config;
using Microsoft.Extensions.Logging;

namespace DevActivator.Meetups.DAL.Providers
{
    public class FriendProvider : IFriendProvider
    {
//        public FriendProvider(ILogger<FriendProvider> l, Settings s) : base(l, s, FriendConfig.DirectoryName)
//        {
//        }

        public Task<List<Friend>> GetAllFriendsAsync()
            => throw new NotImplementedException(); //GetAllAsync();

        public Task<Friend> GetFriendOrDefaultAsync(string friendId)
            => throw new NotImplementedException(); //GetEntityByIdAsync(friendId);

        public Task<Friend> SaveFriendAsync(Friend friend)
            =>                  throw new NotImplementedException(); //SaveEntityAsync(friend);
    }
}