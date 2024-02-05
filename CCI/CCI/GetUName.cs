using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCI
{
    class GetUName
    {
        static string Id;
        public static string id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
    }
}
