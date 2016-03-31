using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using MyMortgageCalculator.Models;

namespace MyMortgageCalculator.Controllers
{
    public class AmortizationController : ApiController
    {
        //POST api/amortization
        public IEnumerable<MortgagePayment> Post(Mortgage mortgage)
        {
            return mortgage.GetAmortizationSchedule();
        }

    }
}
