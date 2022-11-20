using Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IKatibService
    {
        Task<List<AppUser>> GetAll();
        Task<List<AppUser>> GetUser(string userId);

        Task CreateUser(AppUser appUser);

        Task UpdateUser(AppUser appUser);
        Task DeleteUser(string userId);
    }
}
