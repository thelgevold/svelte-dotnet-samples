using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Greetings {
    [Route ("")]
    public class HomeController : Controller {
        [Route ("")]
        public async Task<IActionResult> Index () {
           var filePath = Path.Combine (Directory.GetCurrentDirectory (), "src/server.exe/index.html");

           using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
           using (var ms = new MemoryStream())
           {
             await stream.CopyToAsync(ms);
             return File(ms.ToArray(), "text/html");
           }
        }
    }
}