using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLoan.Model;
using StudentLoan.Common;
using StudentLoan.BLL;
using System.IO;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// upload_cert 的摘要说明
    /// </summary>
    public class upload_cert : IHttpHandler
    {
        //用于上传图片

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            int type = context.Request.Params["type"].Convert<int>();
            int userId = context.Request.Params["userId"].Convert<int>();

            HttpPostedFile file = context.Request.Files["fileData"];

            //根据用户Id分配图片保存路径
            string uploadPath = HttpContext.Current.Server.MapPath(string.Format("/upload_images/{0}/", userId.ToString()));

            string fileTicks = DateTime.Now.Ticks.ToString();
            //文件保存路径
            string fileName = string.Empty;

            if (file != null)
            {
                fileName = string.Format("{0}{1}_{2}", uploadPath, fileTicks, file.FileName);

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                file.SaveAs(fileName);

            }
            else
            {
                context.Response.Write("{\"result\":\"false\",\"url\":\"\"}");
                return;
            }


            UserCertificationEntityEx userCertModel = new UserCertificationBLL().GetModel(userId, type);

            bool result = false;

            if (userCertModel == null)
            {
                //新增
                userCertModel = new UserCertificationEntityEx()
                {
                    UserId = userId,
                    Type = type,
                    CertificationName = this.GetCertification(type).CertificationName,
                    Images = string.Format("/upload_images/{0}/{1}_{2}", userId, fileTicks, file.FileName),
                    Point = this.GetCertification(type).Point
                };

                result = new UserCertificationBLL().Insert(userCertModel);
            }
            else
            {
                //更新
                userCertModel = new UserCertificationEntityEx()
                {
                    UserId = userId,
                    Type = type,
                    Images = string.Format("/upload_images/{0}/{1}_{2}", userId, fileTicks, file.FileName),
                };

                result = new UserCertificationBLL().Update(userCertModel);
            }

            if (File.Exists(fileName) && result == true)
            {
                context.Response.Write("{\"result\":\"true\",\"url\":\"" + string.Format("/upload_images/{0}/{1}_{2}", userId, fileTicks, file.FileName) + "\"}");
            }
            else
            {
                context.Response.Write("{\"result\":\"false\",\"url\":\"\"}");
            }
        }


        public UserCertificationEntityEx GetCertification(int type)
        {
            UserCertificationEntityEx model = new UserCertificationEntityEx();

            switch (type)
            {
                case 0: model.CertificationName = "手持身份证照片"; model.Point = 0; break;
                case 1: model.CertificationName = "身份证正面"; model.Point = 15; break;
                case 2: model.CertificationName = "学生证正面"; model.Point = 0; break;
                case 3: model.CertificationName = "学生证内容"; model.Point = 15; break;
                case 4: model.CertificationName = "学信网截图"; model.Point = 2; break;
                case 5: model.CertificationName = "银行卡流水截图"; model.Point = 1; break;
                case 6: model.CertificationName = "网银或支付宝流水截图"; model.Point = 1; break;
                case 7: model.CertificationName = "手机通话记录清单"; model.Point = 1; break;
                case 8: model.CertificationName = "家长身份证正面"; model.Point = 1; break;
                case 9: model.CertificationName = "家长身份证背面"; model.Point = 1; break;
                case 10: model.CertificationName = "手持室友身份证照片"; model.Point = 0; break;
                case 11: model.CertificationName = "室友身份证正面"; model.Point = 1; break;
                case 12: model.CertificationName = "室友学生证正面"; model.Point = 0; break;
                case 13: model.CertificationName = "室友学生证内容"; model.Point = 2; break;
                case 14: model.CertificationName = "户口簿内容"; model.Point = 2; break;
                case 15: model.CertificationName = "行驶证内容"; model.Point = 1; break;
                case 16: model.CertificationName = "获奖证书内容"; model.Point = 5; break;
            }

            return model;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}