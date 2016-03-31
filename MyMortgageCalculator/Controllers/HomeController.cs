using System;
using System.Collections.Generic;
using MyMortgageCalculator.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace MyMortgageCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "The Mortgage Repayments calculator is intended to provide a general overview of what your monthly repayments.";
            ViewBag.DataPoints = JsonConvert.SerializeObject(_dataPoints);
            return View();
        }
        public ActionResult AjaxJSON()
        {
            //ViewBag.DataPoints = new DataContractJsonSerializer(dataPoints.GetType()).;
            ViewBag.DataPoints = JsonConvert.SerializeObject(_dataPoints);

            return View();
        }
        //public ContentResult JSONData()
        //{
        //    return Content(JsonConvert.SerializeObject(_dataPoints), "application/json");
        //}

        public ActionResult JSONData()
        {
            return Content(JsonConvert.SerializeObject(_dataPoints), "application/json");
        }
        List<DataPoint> _dataPoints = new List<DataPoint>() { 
            new DataPoint("apple", 10), 
            new DataPoint("orange", 15), 
            new DataPoint("banana", 25), 
            new DataPoint("mango", 30), 
            new DataPoint("grape", 28) 
        };

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult MonthlyRePayment()
        {
            Mortgage model = new Mortgage();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Mortgage model)
        {
            StringBuilder sbRepayment = new StringBuilder();
            sbRepayment.Append("Monthly Repayment: ");
            sbRepayment.Append(" £" + model.CalculateMonthlyPayment());
            ViewBag.MonthlyRepayment = sbRepayment.ToString();
            ViewBag.DataPoints = JsonConvert.SerializeObject(_dataPoints);
            //viewBag.AmortizationSchedule = model.GetAmortizationSchedule();

            return View(model);
        }
        public IEnumerable<MortgagePayment> Post(Mortgage mortgage)
        {
            //ViewBag.mgs = "asdfg";
            return mortgage.GetAmortizationSchedule();
        }
       
    }

   
}
