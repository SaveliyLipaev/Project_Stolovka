using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public class UnitOfWork : IDisposable
    {
        //ЗДЕСЬ ПРОБЛЕМА!!!!!!!!
        //private OrderContext db = new OrderContext();
        private UserRepository userRepository;
        private CanteenRepository canteenRepository;

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public CanteenRepository Canteens
        {
            get
            {
                if (canteenRepository == null)
                    canteenRepository = new CanteenRepository(db);
                return canteenRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
