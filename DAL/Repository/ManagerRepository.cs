using DAL.Interface;
using DAL.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        readonly AppDbContext appDbContext;
        public ManagerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Manager Create(Manager manager)
        {
            if (appDbContext.Managers.Any(x => x.Email == manager.Email || manager.Name == x.Name))
                throw new Exception("you have aa account, pleese try login");
            manager = appDbContext.Managers.Add(manager).Entity;
            appDbContext.SaveChanges();
            return manager;

        }

        

        public Manager? Login(string email, string password)
        {
            return appDbContext.Managers.FirstOrDefault(e => e.Email == email && e.Password == password);
        }
    }
}
