using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Help
{

    public static class ObjectHelp
    {
        public static int ObjToInt(this object obj)
        {
            int.TryParse(obj.ToString(),out int result);
            return result;
        }
    }
}
