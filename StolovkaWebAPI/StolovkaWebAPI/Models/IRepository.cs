using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllItems();
        Task<T> GetItem(string id);

        // add new Item document
        Task AddItem(T item);

        // remove a single document / Item
        Task<bool> RemoveItem(string id);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllItems();
    }
}
