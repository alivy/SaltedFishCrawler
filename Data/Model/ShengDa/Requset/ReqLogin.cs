using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ShengDa.Requset
{
    public class ReqLogin : BaseReq
    {

        public string user_name { get; set; }
        public string pass_word { get; set; }
        public string p_code { get; set; }
        public string client_type { get; set; }
      
    }
}
