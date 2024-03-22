using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;

namespace CSIMedia.Controllers
{
    public class SortController : Controller
    {
        CSIMediaContext _context = new CSIMediaContext();
        // GET: Sort
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SortData sort)
        {
            try
            {
                    if (string.IsNullOrWhiteSpace(sort.UserInput))
                        throw new ArgumentException("Please enter at least one number.");

                    var numberList = sort.UserInput.Split(',').Select(int.Parse).ToList();
                    var startTime = DateTime.Now;
                    // Sort numbers based on user input
                    if (sort.SortDirection == "Ascending")
                        numberList.Sort();
                    else if (sort.SortDirection == "Descending")
                        numberList.Sort((a, b) => b.CompareTo(a));
                    else
                        throw new ArgumentException("Invalid sort order.");
                    // Insert sort data into the database
                    var endTime = DateTime.Now;
                    var sortData = new SortData
                    {
                        Id = Guid.NewGuid().ToString(),
                        SortedNumbers = string.Join(",", numberList),
                        SortDirection = sort.SortDirection,
                        SortTime = Convert.ToDateTime((endTime - startTime).ToString()),
                        UserInput = sort.UserInput
                    };
                    _context.SortDatas.Add(sortData);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpGet]
        public ActionResult GetSortedData()
        {
            try
            {
                var sortedList = _context.SortDatas.ToList();
                return View(sortedList);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public FileContentResult DownloadCsv()
        {
            List<SortData> sortedList = _context.SortDatas.ToList();

            var csv = "SortedNumbers,SortDirection,SortTime\n";

            foreach (var sortList in sortedList)
            {
                csv += $"{sortList.SortedNumbers.ToString()},{sortList.SortDirection},{sortList.SortTime}\n";
            }
            
            return File(new UTF8Encoding().GetBytes(csv), "text/csv", "users.csv");
        }
        public ActionResult DownloadJson()
        {
            var sorts = _context.SortDatas.ToList();
            var json = JsonConvert.SerializeObject(sorts, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Content(json, "application/json");
        }
    }
}