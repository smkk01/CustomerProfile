using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCwithWebAPI.Models;

namespace MVCwithWebAPI.Controllers
{
    public class CustomersController : Controller
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAddress"];
        public async Task<ActionResult> Index()
        {
            IEnumerable<Customer> customers = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync("customers/get");

                if (result.IsSuccessStatusCode)
                {
                    customers = await result.Content.ReadAsAsync<IList<Customer>>();
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(customers);
        }
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"Customers/details/{id}");

                if (result.IsSuccessStatusCode)
                {
                    customer = await result.Content.ReadAsAsync<Customer>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Age,DOB,Gender,Occupation,Email,PhoneNo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);

                    var response = await client.PostAsJsonAsync("customers/Create", customer);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
            }
            return View(customer);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"Customers/details/{id}");

                if (result.IsSuccessStatusCode)
                {
                    customer = await result.Content.ReadAsAsync<Customer>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Age,DOB,Gender,Occupation,Email,PhoneNo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    var response = await client.PutAsJsonAsync("customers/edit", customer);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"Customers/details/{id}");

                if (result.IsSuccessStatusCode)
                {
                    customer = await result.Content.ReadAsAsync<Customer>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var response = await client.DeleteAsync($"Customers/delete/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View();
        }

    }
}
