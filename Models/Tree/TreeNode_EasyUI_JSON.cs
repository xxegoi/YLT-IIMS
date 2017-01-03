using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tree
{
    public class TreeNode_EasyUI_JSON
    {
        public int id { get; set; }

        public string text { get; set; }

        public string state { get; set; }

        public List<TreeNode_EasyUI_JSON> children { get; set; }

        public TreeNode_EasyUI_JSON(TreeNode entry)
        {
            this.id = entry.Id;
            this.text = entry.NodeName;
        }
    }
}
