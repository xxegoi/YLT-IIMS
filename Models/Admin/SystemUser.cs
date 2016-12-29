using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    public partial class SystemUser:BaseModel
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public bool IsAdmin { get; set; }
    }
}
