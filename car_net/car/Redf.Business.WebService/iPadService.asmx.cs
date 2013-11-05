using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace Redf.Business.WebService
{
    /// <summary>
    /// Summary description for iPadService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class iPadService : System.Web.Services.WebService
    {
        /// <summary>
        /// 用户登录验证
        /// 输入参数包括：登录名（）、密码（）
        /// 返回结果：职员名称（EMPLOYEENAME）、职员编码（EMPLOYEEID）
        /// 备注：可缓存于iPad前端用于在新增账单时进行检验输入牌照是否有效
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string Authentication(string strLoginName, string strPassword)
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("EMPLOYEEID");
            dsResult.Tables[0].Columns.Add("EMPLOYEENAME");
            dsResult.Tables[0].Rows.Add(new object[] { "TS_Ece6a1a5747a5cf40", "拓天软件" });
            return JsonConvert.SerializeObject(dsResult);
        }
        /// <summary>
        /// 取所有牌照信息
        /// 返回结果包括：牌照号码（PLATE）
        /// 备注：可缓存于iPad前端用于在新增账单时进行检验输入牌照是否有效
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetAllPlate()
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("PLATE");
            dsResult.Tables[0].Rows.Add(new object[] { "辽A00008" });
            dsResult.Tables[0].Rows.Add(new object[] { "辽B00002" });
            dsResult.Tables[0].Rows.Add(new object[] { "辽C98888" });
            return JsonConvert.SerializeObject(dsResult);
        }
        /// <summary>
        /// 获取全部商品一级分类信息
        /// 返回结果：一级分类编码（GOODSCATEGORYID）、一级分类名称（GOODSCATEGORYNAME）
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetAllGoodsCategory()
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("GOODSCATEGORYID");
            dsResult.Tables[0].Columns.Add("GOODSCATEGORYNAME");

            dsResult.Tables[0].Rows.Add(new object[] { "TRI_74fb6869be042b80", "装饰用品" });
            dsResult.Tables[0].Rows.Add(new object[] { "TRI_60643b5f6dfb054e", "机修服务" });
            dsResult.Tables[0].Rows.Add(new object[] { "TRI_2af1e3c5b174b960", "钣喷服务" });
            dsResult.Tables[0].Rows.Add(new object[] { "TRI_f59c3cdea63eaaba", "汽车配件" });
            return JsonConvert.SerializeObject(dsResult);

        }
        /// <summary>
        /// 根据一级分类编码获取商品二级分类信息
        /// 返回结果：二级分类编码（GOODSTYPEID）、二级分类名称（GOODSTYPENAME）
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetGoodsTypeByCategoryID(string strCategoryID)
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("GOODSTYPEID");
            dsResult.Tables[0].Columns.Add("GOODSTYPENAME");

            dsResult.Tables[0].Rows.Add(new object[] { "TRI_6ca92e09985d2566", "香水" });
            dsResult.Tables[0].Rows.Add(new object[] { "TRI_b4b6eb9bb6ebe56a", "防滑垫" });
            return JsonConvert.SerializeObject(dsResult);
        }
        /// <summary>
        /// 根据二级分类编码获取商品信息
        /// 返回结果：商品编码（GOODSID）、名称（GOODSNAME）、价格（SALEPRICE）、图片地址（IMAGEURL）
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetGoodsByTypeID(string strTypeID)
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("GOODSID");
            dsResult.Tables[0].Columns.Add("GOODSNAME");
            dsResult.Tables[0].Columns.Add("SALEPRICE");
            dsResult.Tables[0].Columns.Add("IMAGEURL");
            dsResult.Tables[0].Columns.Add("REMARKS");

            dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac40c20f9e59ac18", "CD水", 980.00, "image01.jpg", "关于商品的描述" });
            dsResult.Tables[0].Rows.Add(new object[] { "TRI_f1bd864e91f106e2", "香儿香水", 1200.00, "image02.jpg", "关于商品的描述" });
            return JsonConvert.SerializeObject(dsResult);
        }
        /// <summary>
        /// 保存账单信息
        /// 上传数据中账单主表包括：单据编码(SALESID)、车牌照号(PLATE)、接待人编码(EMPLOYEEID,就是当前登录人)
        /// 上传数据中账单从表包括：商品编码(GOODSID)、数量（SUMNUMBER）、备注（REMARKS）;
        /// 
        /// 返回结果：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string UploadBillData(string strBillData)
        {
            //DataSet dsBill = new DataSet();
            //dsBill.Tables.Add("MASTER");
            //dsBill.Tables[0].Columns.Add("SALESID");
            //dsBill.Tables[0].Columns.Add("PLATE");
            //dsBill.Tables[0].Columns.Add("EMPLOYEEID");

            //dsBill.Tables.Add("DETAIL");
            //dsBill.Tables[1].Columns.Add("GOODSID");
            //dsBill.Tables[1].Columns.Add("SUMNUMBER");
            //dsBill.Tables[1].Columns.Add("REMARKS");

            //dsBill.Tables[0].Rows.Add(new object[] { "E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8", "辽B00001","00000000000000000000" });
            //dsBill.Tables[1].Rows.Add(new object[] { "TRI_74fb6869be042b80", "1.00","无"});
            //return JsonConvert.SerializeObject(dsBill);


            //这里我可以解析Josn字符串，还原成DataSet然后进行处理，处理完成后返回结果
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("ISSUCCESS");
            dsResult.Tables[0].Columns.Add("MESSAGE");
            dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
            return JsonConvert.SerializeObject(dsResult);
        }
        /// <summary>
        /// 保存账单信息
        /// 上传数据中包括：单据编码(SALESID)
        /// 
        /// 返回结果：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string DeleteBillData(string strBillID)
        {
            //这里我可以通过主单编码去删除账单，处理完成后返回结果
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("ISSUCCESS");
            dsResult.Tables[0].Columns.Add("MESSAGE");
            dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
            return JsonConvert.SerializeObject(dsResult);
        }
    }
}
