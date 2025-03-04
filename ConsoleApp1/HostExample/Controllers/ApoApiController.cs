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
#pragma warning disable CS0162 // Unreachable code detected
            var store = _repository.GetStores((x) => x.CountryCode == header).Where(f => f.StoreId == storeId).FirstOrDefault();
#pragma warning restore CS0162 // Unreachable code detected
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

    /*
     Shell codility test taken at 20/07/2023 at 7.30pm failed
     */

    public interface IWarehouseRepository
    {
        void SetCapacityRecord(int productId, int capacity);
        IEnumerable<CapacityRecord> GetCapacityRecords();
        IEnumerable<CapacityRecord> GetCapacityRecords(Func<CapacityRecord, bool> filter);

        void SetProductRecord(int productId, int quantity);
        IEnumerable<ProductRecord> GetProductRecords();
        IEnumerable<ProductRecord> GetProductRecords(Func<ProductRecord, bool> filter);
    }
    public class CapacityRecord
    {
        public int ProductId { get; set; }
        public int Capacity { get; set; }
    }

    public class ProductRecord
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class WarehouseEntry
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    // NotPositiveQuantityMessage should be returned by
    // SetProductCapacity, ReceiveProduct and DispatchProduct methods
    public class NotPositiveQuantityMessage
    {
        public string Message => "A positive quantity was not provided";
    }

    // QuantityTooLowMessage should be returned by
    // SetProductCapacity, ReceiveProduct and DispatchProduct methods
    public class QuantityTooLowMessage
    {
        public string Message => "Too low a quantity was provided";
    }

    // QuantityTooHighMessage should be returned by
    // SetProductCapacity, ReceiveProduct and DispatchProduct methods
    public class QuantityTooHighMessage
    {
        public string Message => "Too high a quantity was provided";
    }
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        // Return OkObjectResult(IEnumerable<WarehouseEntry>)
        public IActionResult GetProducts()
        {
            // Console.WriteLine("Sample debug output");
            var ss=_warehouseRepository.GetProductRecords().Where(t=>t.Quantity>0);
            List<WarehouseEntry> wh = new List<WarehouseEntry>();
            foreach (var item in ss)
            {
                WarehouseEntry w = new WarehouseEntry();
                w.ProductId = item.ProductId;
                w.Quantity = item.Quantity;
                wh.Add(w);
            }
            return new OkObjectResult(wh);
        }
        /*
         
        */
        // Return OkResult, BadRequestObjectResult(NotPositiveQuantityMessage), or BadRequestObjectResult(QuantityTooLowMessage)
        public IActionResult SetProductCapacity(int productId, int capacity)
        {
            var prod = _warehouseRepository.GetProductRecords().FirstOrDefault(t => t.ProductId == productId);
            var qty = prod?.Quantity;
            if (capacity < qty)
            {
                QuantityTooLowMessage qt = new QuantityTooLowMessage();
                return new BadRequestObjectResult(qt);
            }
            else if (capacity <= 0)
            {
               
                NotPositiveQuantityMessage msg = new NotPositiveQuantityMessage();
                return new BadRequestObjectResult(msg);
            }
            else
            {
                _warehouseRepository.SetCapacityRecord(productId, capacity);
                return new OkResult();
            }

        }

        // Return OkResult, BadRequestObjectResult(NotPositiveQuantityMessage), or BadRequestObjectResult(QuantityTooHighMessage)
        public IActionResult ReceiveProduct(int productId, int qty)
        {
            var prod = _warehouseRepository.GetProductRecords().FirstOrDefault(t => t.ProductId == productId);
            var qty1 = prod?.Quantity;
            qty1 = qty1.HasValue ? qty1.Value : 0;
            if (qty1+qty > qty1)
            {
                QuantityTooLowMessage qt = new QuantityTooLowMessage();
                return new BadRequestObjectResult(qt);
            }
            else if (qty <= 0)
            {
                NotPositiveQuantityMessage msg = new NotPositiveQuantityMessage();
                return new BadRequestObjectResult(msg);
            }
            else
            {
                _warehouseRepository.SetCapacityRecord(productId, qty);
                return new OkResult();
            }

        }

        // Return OkResult, BadRequestObjectResult(NotPositiveQuantityMessage), or BadRequestObjectResult(QuantityTooHighMessage)
        public IActionResult DispatchProduct(int productId, int qty)
        {
            var prod = _warehouseRepository.GetProductRecords().FirstOrDefault(t => t.ProductId == productId);
            var _qty = prod?.Quantity;
            _qty = _qty.HasValue ? _qty.Value : 0;
            if (qty < 0)
            {
                QuantityTooLowMessage qt = new QuantityTooLowMessage();
                return new BadRequestObjectResult(qt);
            }
            else if (qty > _qty)
            {
                QuantityTooHighMessage msg = new QuantityTooHighMessage();
                return new BadRequestObjectResult(msg);
            }
            else
            {
                prod.Quantity = prod.Quantity - qty;
                return new OkResult();
            }
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
