using System;
using System.Reflection;
using Utils.CustomAttribute;


namespace ViewModel
{
    public class ResMessage
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 状态消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据对象
        /// </summary>
        public object data { get; set; }

        public static ResMessage CreatMessage(Enum em)
        {
            return new ResMessage
            {
                code = Convert.ToInt32(em),
                msg = em.GetRemark(),
                data = ""
            };
        }


        public static ResMessage CreatMessage(Enum em, string msg)
        {
            return new ResMessage
            {
                code = Convert.ToInt32(em),
                msg = msg,
                data = string.Empty
            };
        }


        public static ResMessage CreatMessage(Enum em, object data)
        {
            return new ResMessage
            {
                code = Convert.ToInt32(em),
                msg = em.GetRemark(),
                data = data ?? ""
            };
        }


        public static ResMessage CreatMessage(Enum em, string msg, object data)
        {
            return new ResMessage
            {
                code = Convert.ToInt32(em),
                msg = msg ?? em.GetRemark(),
                data = data ?? ""
            };
        }
    }



}