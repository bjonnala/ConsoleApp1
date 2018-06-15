using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class ResponseJSON
    {
        public Result result { get; set; }
        public int statusCode { get; set; }
    }

    public class Result
    {
        public string guid { get; set; }
        public string expire { get; set; }
        public string user { get; set; }
        public object status { get; set; }
    }

}
