using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car.DTO
{
    public class JSONLoginUserDto
    {
        public IList<LoginUserDto> RESULT { get; set; }
    }

    public class LoginUserDto
    {
        public string EMPLOYEEID { get; set; }
        public string EMPLOYEENAME { get; set; }
    }
}