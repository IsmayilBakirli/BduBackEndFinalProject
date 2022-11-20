using Business.Services;
using Entity.Identity;
using Exceptions.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class KatibRepository : IKatibService
    {
        private readonly UserManager<AppUser> _userManager;

        public KatibRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<List<AppUser>> GetAll()
        {
            var users = await _userManager.GetUsersInRoleAsync("Katib");

            if(users is null)
            {
                throw new UserNotFoundException();
            }
            return (List<AppUser>)users;
        }

        public Task<List<AppUser>> GetUser(string userId)
        {
            throw new NotImplementedException();
        }
        public Task CreateUser(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

 

        public Task UpdateUser(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
