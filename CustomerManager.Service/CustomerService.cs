using CustomerManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Service
{
    public class CustomerService
    {
        private CustomerRepository Repository { get; set; }
        public CustomerService()
        {
            Repository = new CustomerRepository();
        }

        public IEnumerable<Customer> GetAll()
        {
            return Repository.GetAll();
        }

        public Customer Get(int id)
        {
            return Repository.Get(id);
        }

        public ServiceResult Insert(Customer instance)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Repository.Insert(instance);
                Repository.Save();
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public ServiceResult Update(Customer instance)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Repository.Update(instance);
                Repository.Save();
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }
    }
}
