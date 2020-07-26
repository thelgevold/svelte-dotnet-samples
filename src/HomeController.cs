using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Greetings {

    public class Friend
    {
      public string FirstName {get; set;}
      public string LastName {get; set;}
      public string MiddleName {get; set;}
      public string Profession {get; set;}
      public string Title {get; set;}
      public int Id {get; set;}
      public int Age {get; set;}
      public bool IsActive {get; set;}
      public Address Address {get; set;}
      public Phone Phone {get; set;}
      public Fax Fax {get; set;}
    }

    public class Address 
    {
      public int Zip {get; set;}
      public string StreetAddress {get; set;}
      public int AptNumber {get; set;}
      public string City {get; set;}
    }

    public class Phone
    {
      public string Number {get; set;}
      public string AreaCode {get; set;}
      public bool IsCellPhone {get; set;}
      public string CountryCode {get; set;}
    }

    public class Fax
    {
      public string Number {get; set;}
      public string AreaCode {get; set;}
      public string CountryCode {get; set;}
    }

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

        [Route ("/friends")]
        public IEnumerable<Friend> Friends () {
           var friends = new List<Friend>();

           for(var i = 0; i < 100000; i++)
           {
             var phone = new Phone() { IsCellPhone = true, Number = (i * 10000).ToString(), AreaCode = i.ToString(), CountryCode = i.ToString() };
             var fax = new Fax() { Number = (i * 10000).ToString(), AreaCode = i.ToString(), CountryCode = i.ToString() };
             var address = new Address() {StreetAddress = Guid.NewGuid().ToString(), Zip = i, AptNumber = i, City = Guid.NewGuid().ToString()};

             friends.Add(new Friend() {
                                        FirstName = Guid.NewGuid().ToString(),
                                        LastName = Guid.NewGuid().ToString(), 
                                        MiddleName = Guid.NewGuid().ToString(),
                                        Address = address,
                                        Title = Guid.NewGuid().ToString(),
                                        Phone = phone,
                                        Fax = fax,
                                        Profession = Guid.NewGuid().ToString(),
                                        Id = i, 
                                        Age = 40
                                      });
           }

           return friends;
        }
    }
}