using DAL;
using Data.Model.DBModel;
using Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Cache;
using Utils.Encrypt;
using Utils.Help;

namespace BLL
{
    public class UserInfoBLL : BaseBLL<UserInfo>
    {
        public override void SetDal()
        {
            _baseDal = new UserInfoDAL();
        }

        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <returns></returns>
        public JieCaiTable QueryTset()
        {
            _baseDal.FirstOrDefault();
            return (_baseDal as UserInfoDAL).QueryTset();
        }

        /// <summary>
        /// 检查用户登录 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public (bool, int) CheckLogin(ReqUserLogin userInfo)
        {
            bool validate = false;
            userInfo.pwd = userInfo.pwd.GetMD5FromString();
            var user = _baseDal.FirstOrDefault(x => x.Phone.Equals(userInfo.account) && x.Password.Equals(userInfo.pwd));
            int userId = 0;
            if (user != null)
            {
                userId = user.Id;
                validate = true;
            }
            return (validate, userId);
        }


    }
}
