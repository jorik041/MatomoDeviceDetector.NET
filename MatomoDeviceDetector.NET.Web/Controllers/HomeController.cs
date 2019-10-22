using MatomoDeviceDetectorNET.Web.Models;
using MatomoDeviceDetectorNET.Parser;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MatomoDeviceDetectorNET.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MatomoDeviceDetectorNET.DeviceDetector.SetVersionTruncation(VersionTruncation.VERSION_TRUNCATION_NONE);

            var userAgent = Request.Headers["User-Agent"];
            var result = MatomoDeviceDetectorNET.DeviceDetector.GetInfoFromUserAgent(userAgent);

            var output = result.Success ? result.ToString().Replace(Environment.NewLine, "<br />") : "Unknown";

            return View(new IndexModel { Content = output });
        }
    }
}
