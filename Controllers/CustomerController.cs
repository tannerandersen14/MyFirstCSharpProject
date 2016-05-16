using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        [HttpGet]
        [Route("api/customer")]
        public IEnumerable<Customer> Get()
        {
            Customer customerTemp = new Customer();
            List<Customer> customers = new List<Customer>();
            foreach (Customer customer in Customer.Customers.Values) {
                customers.Add(customer);
            }
            return customers.AsEnumerable();
        }

        // GET: api/Customer/5
        [HttpGet]
        [Route("api/customer/{customerId}")]
        public Customer Get(int customerId)
        {
            return Customer.Customers[customerId];
        }

        // POST: api/Customer
        [HttpPost]
        [Route("api/customer")]
        public IHttpActionResult Post([FromBody]Customer customer)
        {
            Customer.Customers.Add(customer.CustomerId, customer);
            return this.Created<Customer>("/api/customer/" + customer.CustomerId.ToString(), customer);
        }

        // PUT: api/Customer/5
        [HttpPut]
        [Route("api/customer/{customerId}")]
        public HttpResponseMessage Put(int customerId, [FromBody]Customer customer)
        {
            HttpResponseMessage result = null;
            if (customerId != customer.CustomerId)
                result = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Don't try to hack...you could end up in jail...");
            else
            {
                Customer.Customers[customerId] = customer;
                result = this.Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            return result;
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        [Route("api/customer/{customerId}")]
        public HttpResponseMessage Delete(int customerId)
        {
            HttpResponseMessage result = null;
            Customer returnCustomer = null;
            foreach (Customer customer in Customer.Customers.Values)
            {
                if (customer.CustomerId == customerId)
                {
                    returnCustomer = customer;
                }
            }
            if (returnCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Customer.Customers.Remove(returnCustomer.CustomerId);
            result = this.Request.CreateResponse(HttpStatusCode.OK, returnCustomer);
            return result;
        }
    }
}
