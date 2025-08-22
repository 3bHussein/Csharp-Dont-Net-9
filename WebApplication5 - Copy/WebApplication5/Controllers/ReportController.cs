using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace WebApplication5.Controllers
{
    public class ReportController : Controller
    {
        private readonly IConfiguration config;

        public ReportController(IConfiguration config)
        {
            this.config = config;
        }
        public IActionResult Index( int ID)
        {
            ViewBag.InvoiceId = ID;
            return View();
        }
        [HttpPost]
        public IActionResult GetReport([FromQuery]int ID)
         {
            var report = new StiReport();
            report.Load("Reports/Report.mrt"); // Your report file
            report.Dictionary.Databases.Clear();
            report.Dictionary.Databases.Add(new StiSqlDatabase("Connection",this.config.GetConnectionString("WebApplication5Context")));
            report["@ID"] = ID;
            //report.Compile();
            report.Render();

            return StiNetCoreViewer.GetReportResult(this,report);
        }
        [HttpGet]
        [HttpPost]
        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
