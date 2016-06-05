
using MoneyController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySearchMvcApp.Controllers
{
    public class HomeController : Controller
    {
        List<MoneyChange> moneyChangeList=null;
        MoneyChangeController moneyChangeController = null;
       
        public ActionResult Index()
        {
          
            return View();
        }

       
        public JsonResult GetAllSearches()
        {
            moneyChangeController = new MoneyChangeController();
            moneyChangeList = moneyChangeController.GetAllMoneyChanges();
            return Json(moneyChangeList, JsonRequestBehavior.AllowGet); 
        }


        public JsonResult ConvertChange(decimal number)
        {
            string error="";
            moneyChangeController = new MoneyChangeController();
            moneyChangeList = moneyChangeController.GetMoneyChangeFromDataBase(number);
            if (moneyChangeController.Error != null && moneyChangeList.Count<=0)
            { 
                //There is an error with the sql, try no connection
                error = moneyChangeController.Error;
                moneyChangeList = moneyChangeController.GetMoneyChange(number);
            }
            return Json(moneyChangeList, JsonRequestBehavior.AllowGet); 
        }

    }
}
