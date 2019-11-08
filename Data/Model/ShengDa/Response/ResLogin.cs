using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ShengDa.Response
{
    /// <summary>
    /// 登录响应
    /// </summary>
    public class ResLogin
    {
        /// <summary>
        /// session_id
        /// </summary>
        public string session_id { get; set; }

        /// <summary>
        /// session_id
        /// </summary>
        public string user_info { get; set; }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class userInfo
    {
        /// <summary>
        /// session_id
        /// </summary>
        public string user_id { get; set; }


        /// <summary>
        /// user_name
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// nick_name
        /// </summary>
        public string nick_name { get; set; }


        /// <summary>
        /// user_image
        /// </summary>
        public string user_image { get; set; }


        /// <summary>
        /// is_agent
        /// </summary>
        public bool is_agent { get; set; }

        /// <summary>
        /// group_id
        /// </summary>
        public string group_id { get; set; }

        public string groups_tite { get; set; }
        public string is_high_hand { get; set; }
        public string point_type { get; set; }
        public string sys_point_type { get; set; }
        public string agent_id { get; set; }
        public string chat_room_role { get; set; }
        public string z_group_id { get; set; }
        public string is_anchor { get; set; }

    }
}
