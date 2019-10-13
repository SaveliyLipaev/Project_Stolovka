using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public class UnitOfWork //: IDisposable
    {
        // ЗДЕСЬ ПРОБЛЕМА!!!!!!!!
        // private OrderContext db = new OrderContext();
        //private UserRepository _userRepository;
        //private CanteenRepository _canteenRepository;

        //public UserRepository Users
        //{
        //    get { return _userRepository ?? (_userRepository = new UserRepository(db)); }
        //}

        //public CanteenRepository Canteens
        //{
        //    get { return _canteenRepository ?? (_canteenRepository = new CanteenRepository(db)); }
        //}

        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing) db.Dispose();
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
