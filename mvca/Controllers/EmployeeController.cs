using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using mvca.Models;

namespace mvca.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<MVCEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MVCEmployeeModel>>().Result;
            return View(empList);
        }
        public ActionResult Create(int id = 0)
        {
            if (id == 0)
                return View(new MVCEmployeeModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Employees/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCEmployeeModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Create(MVCEmployeeModel emp)
        {
            if (emp.EmployeId == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Save Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Employees/" + emp.EmployeId, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Employees/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}