using SierraPacific.Core.Models;
using SierraPacific.Core.Service;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System;

namespace SierraPacific.Api.Controllers
{
    [RoutePrefix("api/sample")]
    public class SampleController : ApiController
    {
        private readonly ISampleService sampleService;
        public SampleController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        // GET api/<controller>
        //[ResponseType(typeof(IEnumerable<Loan>))]
        //public IEnumerable<Loan> Get()
        //{
        //    var customer = new Customer
        //    {
        //        Id = 1,
        //        Name = "Sample User",
        //    };

        //    var loans = new List<Loan> {
        //        new Loan {Id=1, Customer=customer, CustomerId=1, Descriptor="Car loan"  },
        //        new Loan {Id=2, Customer=customer, CustomerId=1, Descriptor="Home Loan"  },
        //    };
        //    return loans;
        //}

        public int Get()
        {
            try
            {
                int zero = 0;
                int result = 5 / zero;
            }
            catch (DivideByZeroException ex)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //this.Log().Info("DivideByZeroException");
                this.Log().Error(ex.Message,ex);
                //logger.ErrorException("Whoops!", ex);
            }
            return 0;
        }


        #region oldcode

        // GET api/<controller>/5

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //[ResponseType(typeof(Loan))]
        //public Loan Post([FromBody]Loan loan)
        //{
        //    loan.Id = 99;
        //    return loan;//Request.CreateResponse(HttpStatusCode.OK, loan);
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}

        #endregion
    }
}