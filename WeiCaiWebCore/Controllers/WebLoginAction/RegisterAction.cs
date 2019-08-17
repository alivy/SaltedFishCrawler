using BLL;
using Data.Model.DBModel;
using Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils.Encrypt;
using Utils.Help;

namespace WeiCaiWebCore.Controllers.WebLoginAction
{
    public class RegisterAction
    {
        private static UserInfoBLL user = new UserInfoBLL();


        private static BaseBLL<UserInfo> userBase = new BaseBLL<UserInfo>();
        /// <summary>
        /// 用户注册验证
        /// </summary>
        public static (bool, int) UserRegisterCheck(ReqUserRegister userRegister)
        {
            try
            {
                var checkEP = userBase.FirstOrDefault(c => c.Eamil.Equals(userRegister.Email) || c.Phone.Equals(userRegister.Phone));
                if (checkEP != null)
                {
                    return (false, 0);
                }
                userRegister.PassWord = userRegister.PassWord.GetMD5FromString();
                userBase.AddEntity(new UserInfo
                {
                    UserName = userRegister.UserName,
                    Eamil = userRegister.Email,
                    Password = userRegister.PassWord,
                    Phone = userRegister.Phone,
                    CreateData = DateTime.Now
                });

                var user = userBase.FirstOrDefault(c => c.Eamil.Equals(userRegister.Email) || c.Phone.Equals(userRegister.Phone) || c.Password.Equals(userRegister.PassWord));
                return (true, user.Id);
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, "用户注册出错", ex);
                return (false, 0);
            }        
        }
    }
}