using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

// to use model in controller import models
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        decimal value;
        // GET: Home
        /*********************  Parameters *****************************/
        public string Index(int? opParam=null)
        {
            return "<a href='?opParam=1'>click to update URL</a>  <h1>" + opParam + "</h1>Observe the above URL before you click "+
                "<br/><hr/> You can change the value to any integer <a href='?opParam=24'>click to update value to 24</a> <br/><hr/>"+
                "<a href='Home/MultipleParam?id=1&name=abc'>Checkout Multiple Prameters</a><br/><hr/>" +
                "<a href='Home/Display'>Check out Model data</a><br/><hr/>"+
                "<a href='Home/RazorEngine'><b>Check out Razor View Engine</b></a><br/><hr/>"+
                "<a href='Home/Helper'>Check out Helpers</a><br/><hr/>"+
                "<a href='SimpleApp'><h1>Check out Simple Application</h1></a><br/><hr/>"
               ;
        }

        // to append multiple parameters use '&' in between them 
        public string MultipleParam(int? id, string name = null)
        {
            
            return "<a href='?id=2&name=xyz'>Click to change</a> Id : " + id + " | Name :" + name+ 
                    "<br/><hr/><a href='/Home/Display'>Check out Model data</a>";
        }

        /**********************   MODELS EXAMPLE ***********************/

        //view to display data
        public ActionResult Display()
        {
            return View(GetData());
        }

        // setting data to model
        private TestData GetData()
        {
            return new TestData
            {
                id = 121,
                name = "xyzABC" 
            };
        } // Now go to Display-view and add reference to the model

        /***********************************  View Engine *******************************/
        public ActionResult RazorEngine() 
        {
            return View();
        }

        /*********************************** Helpers ************************************/
        public ActionResult Helper()
        {
            return Display();
        }

        /*******************************************************************************
         *                    Simple Application
         * 
         *       ViewBag, Routing, Exception Handing, ErrorHandling, HttpMethods
         * 
         * *****************************************************************************/
        [Route("SimpleApp")]
        public ActionResult SimpleApp()
        {
            SimpleApp app = new SimpleApp();
            
            return View(app);
        }
        [Route("Calculate")]
        [HandleError(View="SimpleApp")]
        [HttpPost]
        public ActionResult Calculate(SimpleApp app) // Binding SimpleApp model data to use with in the function
        {
            if (ModelState.IsValid)
            {
                try
                {
                   DataTable dt = new DataTable(); // using to evalute the string 
                   ViewBag.res = "Result of " + app.expression + " = " + dt.Compute(app.expression, "");

                }
                catch(Exception e)
                {
                    ViewBag.res = "Invalid Expression";
                }
               
            }
     
            return View("SimpleApp");
        }

     
    }
}