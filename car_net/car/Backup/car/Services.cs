using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using car.DTO;
using car.iPadService;

namespace car
{
    public class Services
    {

        iPadService.iPadServiceSoapClient service = new iPadServiceSoapClient();
        public  LoginUserDto Login(string username, string password)
        {

           var a= service.Authentication(username, password);
           var loginuser = JsonConvert.DeserializeObject<JSONLoginUserDto>(a);
            if (loginuser.RESULT.Count > 0)
            {
                return loginuser.RESULT[0];
            }
            else
            {
                return null;
            }
            

        }
    }
}