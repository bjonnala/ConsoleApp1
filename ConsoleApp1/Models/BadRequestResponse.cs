using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    class BadRequestResponse
    {
        public List<string> errors { get; set; }
        public int statusCode { get; set; }
    }
}
