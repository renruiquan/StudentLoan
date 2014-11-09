using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System.Web.SessionState;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// upload_avatar 的摘要说明
    /// </summary>
    public class upload_avatar : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Result result = new Result();
            result.avatarUrls = new ArrayList();
            result.success = false;
            result.msg = "Failure!";
            //取服务器时间+8位随机码作为部分文件名，确保文件名无重复。
            string fileName = DateTime.Now.ToString("yyyyMMddhhmmssff") + CreateRandomCode(8);
            //定义一个变量用以储存当前头像的序号
            int avatarNumber = 1;

            int userId = context.Request.Params["userId"].Convert<int>();

            //遍历所有文件域
            foreach (string fieldName in context.Request.Files.AllKeys)
            {
                HttpPostedFile file = context.Request.Files[fieldName];
                //处理原始图片（默认的 file 域的名称是__source，可在插件配置参数中自定义。参数名：src_field_name）
                //如果在插件中定义可以上传原始图片的话，可在此处理，否则可以忽略。
                if (fieldName == "__source")
                {
                    //文件名，如果是本地或网络图片为原始文件名（不含扩展名）、如果是摄像头拍照则为 *FromWebcam
                    //fileName = file.FileName;
                    //当前头像基于原图的初始化参数（即只有上传原图时才会发送该数据），用于修改头像时保证界面的视图跟保存头像时一致，提升用户体验度。
                    //修改头像时设置默认加载的原图url为当前原图url+该参数即可，可直接附加到原图url中储存，不影响图片呈现。
                    string initParams = context.Request.Form["__initParams"];
                    result.sourceUrl = string.Format("/upload_avatar/source_{0}.jpg", fileName);
                    if (!Directory.Exists(context.Server.MapPath("/upload_avatar")))
                    {
                        Directory.CreateDirectory(context.Server.MapPath("/upload_avatar"));
                    }
                    file.SaveAs(context.Server.MapPath(result.sourceUrl));
                    result.sourceUrl += initParams;
                    /*
                        可在此将 result.sourceUrl 储存到数据库，如果有需要的话。
                    */
                }
                //处理头像图片(默认的 file 域的名称：__avatar1,2,3...，可在插件配置参数中自定义，参数名：avatar_field_names)
                else if (fieldName.StartsWith("__avatar"))
                {
                    string virtualPath = string.Format("/upload_avatar/avatar{0}_{1}.jpg", avatarNumber, fileName);
                    if (!Directory.Exists(context.Server.MapPath("/upload_avatar")))
                    {
                        Directory.CreateDirectory(context.Server.MapPath("/upload_avatar"));
                    }
                    result.avatarUrls.Add(virtualPath);
                    file.SaveAs(context.Server.MapPath(virtualPath));
                    /*
                        可在此将 virtualPath 储存到数据库，如果有需要的话。
                    */

                    if (avatarNumber == 1)
                    {
                        result.success = new UsersBLL().UpdateAvatar(new UsersEntityEx() { UserId = userId, Avatar = virtualPath });
                        if (result.success)
                        {
                            result.msg = "Success!";

                            UsersEntityEx userModel = new BasePage().GetUserModel();
                            userModel.Avatar = virtualPath;

                            context.Session[StudentLoanKeys.SESSION_USER_INFO] = userModel;
                        }
                        else
                        {
                            result.msg = "Fail!";
                        }
                    }

                    avatarNumber++;
                }
                /*
                else
                {
                    如下代码在上传接口Upload.aspx中定义了一个user=xxx的参数：
                    var swf = new fullAvatarEditor('swf', {
                        id: 'swf',
                        upload_url: 'Upload.aspx?user=xxx'
                    });
                    在此即可用Request.Form["user"]获取xxx。
                }
                */
            }


            //返回图片的保存结果（返回内容为json字符串，可自行构造，该处使用Newtonsoft.Json构造）
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 生成指定长度的随机码。
        /// </summary>
        private string CreateRandomCode(int length)
        {
            string[] codes = new string[36] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            StringBuilder randomCode = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                randomCode.Append(codes[rand.Next(codes.Length)]);
            }
            return randomCode.ToString();
        }
        /// <summary>
        /// 表示图片的上传结果。
        /// </summary>
        private struct Result
        {
            /// <summary>
            /// 表示图片是否已上传成功。
            /// </summary>
            public bool success;
            /// <summary>
            /// 自定义的附加消息。
            /// </summary>
            public string msg;
            /// <summary>
            /// 表示原始图片的保存地址。
            /// </summary>
            public string sourceUrl;
            /// <summary>
            /// 表示所有头像图片的保存地址，该变量为一个数组。
            /// </summary>
            public ArrayList avatarUrls;
        }
    }
}