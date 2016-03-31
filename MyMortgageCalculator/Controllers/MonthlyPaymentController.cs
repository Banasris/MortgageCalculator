using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using MyMortgageCalculator.Models;

namespace MyMortgageCalculator.Controllers
{
    public class MonthlyPaymentController : ApiController
    {
        // POST api/monthlypayment
        public decimal Post(Mortgage mortgage)
        {
            return mortgage.CalculateMonthlyPayment();
        }

    }
}
