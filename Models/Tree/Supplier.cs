using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tree
{
    public class Supplier:Common.BaseModel
    {
        public string Name { get; set; }

        public string Addr { get; set; }

        public string LinkMan { get; set; }

        public string Phone { get; set; }
    }
}
