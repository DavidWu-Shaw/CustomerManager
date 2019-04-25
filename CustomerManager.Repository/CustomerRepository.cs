using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private testEntities db = null;

        public CustomerRepository()
        {
            this.db = new testEntities();
        }

        public CustomerRepository(testEntities db)
        {
            this.db = db;
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Insert(Customer obj)
        {
            db.Customers.Add(obj);
        }

        public void Update(Customer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer existing = db.Customers.Find(id);
            db.Customers.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

