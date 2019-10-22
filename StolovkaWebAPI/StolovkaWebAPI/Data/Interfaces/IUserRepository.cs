using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllItems();

        Task<User> GetItem(string id);

        // add new Item document
        Task AddItem(User item);

        // remove a single document / Item
        Task<bool> RemoveItem(string id);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllItems();
    }
}
