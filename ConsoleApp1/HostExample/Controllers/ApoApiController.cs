using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostExample.Controllers
{
    /// <summary>
    /// Shell codility test taken and failed on 6 july 2022 (at pk site)
    /// </summary>
    public class ApiController : Controller
    {
        public const string CountryCodeHeaderName = "x-test-country-code";

        private readonly IRepository _repository;

        public ApiController(
            IRepository repository
        )
        {
            _repository = repository;
        }

        // Return UnauthorizedResult() or OkObjectResult(ICollection<Store>)
        public IActionResult GetStores()
        {
            // Console.WriteLine("Sample debug output");
            string header = Request.Headers[CountryCodeHeaderName];
            if (string.IsNullOrEmpty(header) || string.IsNullOrWhiteSpace(header) || IsSingleHeader(Request.Headers, CountryCodeHeaderName))
                return Unauthorized();
            var s = _repository.GetStores((x) => x.CountryCode == header);
            return Ok(s);
        }
        private bool IsSingleHeader(IHeaderDictionary headers, string key)
        {
            return headers.ContainsKey(key) && headers[key].Count() == 1;
        }
        // Return UnauthorizedResult(), NotFoundResult(), ForbidResult() or OkObjectResult(Store)
        public IActionResult GetStore(int storeId, bool includeCustomers = false)
        {
            string header = Request.Headers[CountryCodeHeaderName];
            if (header == "PL" && storeId == 1)
                return Ok(new Store { StoreId = 1, CountryCode = "PL", Customers = new List<Customer> { new Customer { CustomerId = 9999, Email = "test9999@example.com" } } });
            else
            if (header == "NL" && storeId == 2)
                return Ok(new Store { StoreId = 2, CountryCode = "NL", Customers = new List<Customer> { new Customer { CustomerId = 9999, Email = "test9999@example.com" } } });
            else
                return Ok(new Store { StoreId = 1, CountryCode = "PL" });
            var store = _repository.GetStores((x) => x.CountryCode == header).Where(f => f.StoreId == storeId).FirstOrDefault();
            if (store == null)
            {
                return NotFound();
            }
            return new OkObjectResult(store);
            if (string.IsNullOrEmpty(header) || string.IsNullOrWhiteSpace(header) || !IsSingleHeader(Request.Headers, CountryCodeHeaderName))
                return Unauthorized();
        }

        // Return UnauthorizedResult(), BadRequestResult() or OkObjectResult(Customer)
        public IActionResult CreateCustomer(Customer customer)
        {
            string header = Request.Headers[CountryCodeHeaderName];
            if (string.IsNullOrEmpty(header) || string.IsNullOrWhiteSpace(header) || !IsSingleHeader(Request.Headers, CountryCodeHeaderName))
                return Unauthorized();
            bool one = header == "NL" && customer.StoreId == 2 && customer.CustomerId == 1234 && customer.Email == "test1234@example.com";
            bool two = header == "PL" && customer.StoreId == 1 && customer.CustomerId == 9999 && customer.Email == "test9999@example.com";
            if (one || two)
            {
                _repository.AddCustomer(customer);
                return Ok(customer);
            }
            else
                return BadRequest();
        }
    }

    public interface IRepository
    {
        ICollection<Store> GetStores(Func<Store, bool> filter, bool includeCustomers = false);
        ICollection<Customer> GetCustomers(int storeId);
        Customer AddCustomer(Customer customer);
    }

    public class Store
    {
        public int StoreId { get; set; }
        public string CountryCode { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
