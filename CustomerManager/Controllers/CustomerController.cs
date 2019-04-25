using CustomerManager.Repository;
using CustomerManager.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CustomerManager.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService CustomerService;

        public CustomerController()
        {
            CustomerService = new CustomerService();
        }

        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<Customer> model = CustomerService.GetAll();
            return View(model);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer model = CustomerService.Get(id);
            return View(model);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Customer instance = new Customer();
            TryUpdateModel(instance);

            if (ModelState.IsValid)
            {
                ServiceResult result = CustomerService.Insert(instance);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if (result.Exception != null)
                    {
                        ModelState.AddModelError("backend", result.Exception.Message);
                    }
                }
            }

            return View();
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer model = CustomerService.Get(id);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Customer instance = CustomerService.Get(id);
            TryUpdateModel(instance);

            if (ModelState.IsValid)
            {
                ServiceResult result = CustomerService.Update(instance);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("backend", result.Exception.Message);
                }
            }
            return View();
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
