using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Service
{
    public class ServiceResult
    {
        public Exception Exception { get; set; }
        public bool IsSuccessful
        {
            get
            {
                return Exception == null;
            }
        }
    }
}
