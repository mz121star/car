﻿using System;
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
            if (strLoginName != "admin" || strPassword != "admin")
            {
                return JsonConvert.SerializeObject(dsResult);
            }
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
            if (strCategoryID == "TRI_74fb6869be042b80")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_6ca92e09985d2566", "香水" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_b4b6eb9bb6ebe56a", "防滑垫" });
            }
            else if (strCategoryID == "TRI_60643b5f6dfb054e")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_6ca92e09985d2013", "维修发动机" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_b4b6eb9bb6ebe59b", "维修变速箱" });
            }
            else if (strCategoryID == "TRI_2af1e3c5b174b960")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_6ca92e09856d2013", "钣金" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_b4j5kb9bb6ebe56a", "喷漆" });
            }
            else if (strCategoryID == "TRI_f59c3cdea63eaaba")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_6ca92e02356d2013", "贴膜" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_b4j5kb0nb6ebe56a", "发动机护板" });
            }
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

            if (strTypeID == "TRI_6ca92e09985d2566")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac40c20f9e59ac18", "CD水", 80.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_f1bd864e91f106e2", "香儿香水", 300.00, "image02.jpg", "关于商品的描述" });
            }
            else if (strTypeID == "TRI_b4b6eb9bb6ebe56a")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac40c30j9e59ac18", "防滑垫A", 198.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_f1bd587e91f106e2", "防滑垫B", 120.00, "image02.jpg", "关于商品的描述" });
            }
            else if (strTypeID == "TRI_6ca92e09985d2013")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac40c30j54g9ac18", "发动机大修", 980.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_23fd587e91f106e2", "发动机保养", 1200.00, "image02.jpg", "关于商品的描述" });
            }
            else if (strTypeID == "TRI_b4b6eb9bb6ebe59b")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac40c323fdg9ac18", "变速箱修理", 350.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_23457dsa91f106e2", "换变速箱油", 3000.00, "image02.jpg", "关于商品的描述" });
            }
            else if (strTypeID == "TRI_6ca92e09856d2013")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac40casfse59ac18", "钣金车门", 100.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_f1bd58fd912306e2", "钣金保险杠", 490.00, "image02.jpg", "关于商品的描述" });
            }
            else if (strTypeID == "TRI_b4j5kb9bb6ebe56a")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac40csa57eg9ac18", "穿大褂", 1000.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_23fd587e91f106e2", "喷车顶", 700.00, "image02.jpg", "关于商品的描述" });
            }
            else if (strTypeID == "TRI_6ca92e02356d2013")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac4iohf2454sac18", "贴全车膜", 4500.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_23fst4safsa106e2", "贴前挡膜", 900.00, "image02.jpg", "关于商品的描述" });
            }
            else if (strTypeID == "TRI_b4j5kb0nb6ebe56a")
            {
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_ac409823fd014c18", "钢护板", 350.00, "image01.jpg", "关于商品的描述" });
                dsResult.Tables[0].Rows.Add(new object[] { "TRI_23457d454suy06e2", "铝合金护板", 550.00, "image02.jpg", "关于商品的描述" });
            }

            return JsonConvert.SerializeObject(dsResult);
        }
        ///// <summary>
        ///// 保存账单信息
        ///// 上传数据中账单主表包括：单据编码(SALESID)、车牌照号(PLATE)、接待人编码(EMPLOYEEID,就是当前登录人)
        ///// 上传数据中账单从表包括：商品编码(GOODSID)、数量（SUMNUMBER）、备注（REMARKS）;
        ///// 
        ///// 返回结果：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        ///// </summary>
        ///// <returns></returns>
        //[WebMethod]
        //public string UploadBillData(string strBillData)
        //{
        //    //DataSet dsBill = new DataSet();
        //    //dsBill.Tables.Add("MASTER");
        //    //dsBill.Tables[0].Columns.Add("SALESID");
        //    //dsBill.Tables[0].Columns.Add("PLATE");
        //    //dsBill.Tables[0].Columns.Add("EMPLOYEEID");

        //    //dsBill.Tables.Add("DETAIL");
        //    //dsBill.Tables[1].Columns.Add("GOODSID");
        //    //dsBill.Tables[1].Columns.Add("SUMNUMBER");
        //    //dsBill.Tables[1].Columns.Add("REMARKS");

        //    //dsBill.Tables[0].Rows.Add(new object[] { "E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8", "辽B00001","00000000000000000000" });
        //    //dsBill.Tables[1].Rows.Add(new object[] { "TRI_74fb6869be042b80", "1.00","无"});
        //    //return JsonConvert.SerializeObject(dsBill);


        //    //这里我可以解析Josn字符串，还原成DataSet然后进行处理，处理完成后返回结果
        //    DataSet dsResult = new DataSet();
        //    dsResult.Tables.Add("RESULT");
        //    dsResult.Tables[0].Columns.Add("ISSUCCESS");
        //    dsResult.Tables[0].Columns.Add("MESSAGE");
        //    dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
        //    return JsonConvert.SerializeObject(dsResult);
        //}
        ///// <summary>
        ///// 保存账单信息
        ///// 上传数据中包括：单据编码(SALESID)
        ///// 
        ///// 返回结果：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        ///// </summary>
        ///// <returns></returns>
        //[WebMethod]
        //public string DeleteBillData(string strBillID)
        //{
        //    //这里我可以通过主单编码去删除账单，处理完成后返回结果
        //    DataSet dsResult = new DataSet();
        //    dsResult.Tables.Add("RESULT");
        //    dsResult.Tables[0].Columns.Add("ISSUCCESS");
        //    dsResult.Tables[0].Columns.Add("MESSAGE");
        //    dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
        //    return JsonConvert.SerializeObject(dsResult);
        //}

        /// <summary>
        /// 增加新单
        /// 参数Json字符串：单据编码(SALESID)、车牌照号(PLATE)、接待人编码(EMPLOYEEID,就是当前登录人)
        /// 返回Json字符串：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：不存在此车牌号等等）
        /// 
        /// 参数示例字符串：{"MASTER":[{"SALESID":"E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8","PLATE":"辽B00001","EMPLOYEEID":"00000000000000000000"}]}
        /// 返回示例字符串：{"RESULT":[{"ISSUCCESS":"1","MESSAGE":"保存成功"}]}
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string NewBill(string strBillData)
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

            //dsBill.Tables[0].Rows.Add(new object[] { "E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8", "辽B00001", "00000000000000000000" });
            //dsBill.Tables[1].Rows.Add(new object[] { "TRI_74fb6869be042b80", "1.00", "无" });
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
        /// 删除账单
        /// 一个字符串参数：单据编码(SALESID)
        /// 返回Json字符串：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        /// 
        /// 参数示例字符串：E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8
        /// 返回示例字符串：{"RESULT":[{"ISSUCCESS":"1","MESSAGE":"保存成功"}]}
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string DeleteBill(string strSalesID)
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("ISSUCCESS");
            dsResult.Tables[0].Columns.Add("MESSAGE");
            dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
            return JsonConvert.SerializeObject(dsResult);
        }

        /// <summary>
        /// 提交账单（结账）
        /// 一个字符串参数：单据编码(SALESID)
        /// 返回Json字符串：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        /// 
        /// 参数示例字符串：E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8
        /// 返回示例字符串：{"RESULT":[{"ISSUCCESS":"1","MESSAGE":"保存成功"}]}
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string ClosingBill(string strSalesID)
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("ISSUCCESS");
            dsResult.Tables[0].Columns.Add("MESSAGE");
            dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
            return JsonConvert.SerializeObject(dsResult);
        }

        /// <summary>
        /// 获取账单明细
        /// 一个字符串参数：单据编码
        /// 返回Json字符串：商品编码(GOODSID)、数量（SUMNUMBER）、备注（REMARKS）;
        /// 
        /// 参数示例字符串：E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8
        /// 返回示例字符串：{"DETAIL":[{"GOODSID":"TRI_74fb6869be042b80","SUMNUMBER":"1.00","REMARKS":"无"}]}
        /// 备注：如果返回数据为空说明当前车牌照对应单据已结账，或还没有新增商品
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string DownloadBill(string strSalesID)
        {
            DataSet dsBill = new DataSet();
            dsBill.Tables.Add("DETAIL");
            dsBill.Tables[0].Columns.Add("GOODSID");
            dsBill.Tables[0].Columns.Add("SUMNUMBER");
            dsBill.Tables[0].Columns.Add("REMARKS");
            dsBill.Tables[0].Rows.Add(new object[] { "TRI_74fb6869be042b80", "1.00", "无" });
            return JsonConvert.SerializeObject(dsBill);
        }

        /// <summary>
        /// 增加商品
        /// 参数Json字符串：单据编码(SALESID)、商品编码(GOODSID)、数量（SUMNUMBER）、备注（REMARKS）;
        /// 返回Json字符串：返回结果：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        /// 
        /// 参数示例字符串：{"DETAIL":[{"SALESID":"E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8","GOODSID":"TRI_74fb6869be042b80","SUMNUMBER":"1.00","REMARKS":"无"}]}
        /// 返回示例字符串：{"RESULT":[{"ISSUCCESS":"1","MESSAGE":"保存成功"}]}
        /// 备注：如果返回数据为空说明当前车牌照对应单据已结账，或还没有新增商品
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string AddGoods(string strSalesID)
        {
            //DataSet dsBill = new DataSet();
            //dsBill.Tables.Add("DETAIL");
            //dsBill.Tables[0].Columns.Add("SALESID");
            //dsBill.Tables[0].Columns.Add("GOODSID");
            //dsBill.Tables[0].Columns.Add("SUMNUMBER");
            //dsBill.Tables[0].Columns.Add("REMARKS");
            //dsBill.Tables[0].Rows.Add(new object[] { "E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8","TRI_74fb6869be042b80", "1.00", "无" });
            //return JsonConvert.SerializeObject(dsBill);

            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("ISSUCCESS");
            dsResult.Tables[0].Columns.Add("MESSAGE");
            dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
            return JsonConvert.SerializeObject(dsResult);
        }

        /// <summary>
        /// 删除商品
        /// 两个字符串参数：单据编码(SALESID)、商品编码(GOODSID)
        /// 返回Json字符串：返回结果：是否成功（ISSUCCESS：1表示成功、0表示失败）、详细信息（MESSAGE：用详细语言描述，包括：已经结账了等等）
        /// 
        /// 参数示例字符串：E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8,TRI_74fb6869be042b80
        /// 返回示例字符串：{"RESULT":[{"ISSUCCESS":"1","MESSAGE":"保存成功"}]}
        /// 备注：如果返回数据为空说明当前车牌照对应单据已结账，或还没有新增商品
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string DeleteGoods(string strSalesID, string strGoodsID)
        {
            //DataSet dsBill = new DataSet();
            //dsBill.Tables.Add("DETAIL");
            //dsBill.Tables[0].Columns.Add("SALESID");
            //dsBill.Tables[0].Columns.Add("GOODSID");
            //dsBill.Tables[0].Columns.Add("SUMNUMBER");
            //dsBill.Tables[0].Columns.Add("REMARKS");
            //dsBill.Tables[0].Rows.Add(new object[] { "E512E00F-CA44-6F7A-F9C6-10CCDDB92BB8","TRI_74fb6869be042b80", "1.00", "无" });
            //return JsonConvert.SerializeObject(dsBill);

            DataSet dsResult = new DataSet();
            dsResult.Tables.Add("RESULT");
            dsResult.Tables[0].Columns.Add("ISSUCCESS");
            dsResult.Tables[0].Columns.Add("MESSAGE");
            dsResult.Tables[0].Rows.Add(new object[] { "1", "保存成功" });
            return JsonConvert.SerializeObject(dsResult);
        }
    }
}
