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
        public LoginUserDto Login(string username, string password)
        {

            var a = service.Authentication(username, password);
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
        
        public PlateList GetAllPlate()
        {
            return JsonConvert.DeserializeObject<PlateList>(service.GetAllPlate());
        }

        public Message UploadBillData(MasterDetail masterDetail)
        {
            var message = service.UploadBillData(JsonConvert.SerializeObject(masterDetail));
            return JsonConvert.DeserializeObject<MessageList>(message).MessageResult.FirstOrDefault();
        }

        public FirstGoodsList GetAllGoodsCategory()
        {
            var list = service.GetAllGoodsCategory();
            return JsonConvert.DeserializeObject<FirstGoodsList>(list);
        }

        public SecondGoodsList GetGoodsTypeByCategoryID(string strCategoryID)
        {
            var list = service.GetGoodsTypeByCategoryID(strCategoryID);
            return JsonConvert.DeserializeObject<SecondGoodsList>(list);
        }

        public GoodsList GetGoodsByTypeID(string strTypeID)
        {
            var list = service.GetGoodsByTypeID(strTypeID);
            return JsonConvert.DeserializeObject<GoodsList>(list);
        }
    }
}
