using Models.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_IIMS.Models.IIMS
{
    public partial class TreeNodeViewModel
    {
        public int Id { get; set; }

        public string NodeName { get; set; }

        public virtual TreeNodeViewModel Parent { get; set; }

        public TreeNode ToTreeNode()
        {
            TreeNode entry = new TreeNode();
            entry.Id = this.Id;
            entry.NodeName = this.NodeName;
            if(this.Parent!=null)
                entry.ParentId = this.Parent.Id;

            return entry;
        }

        public TreeNodeViewModel(TreeNode entry)
        {
            if (entry != null)
            {
                this.Id = entry.Id;
                this.NodeName = entry.NodeName;
            }
           
        }

        public TreeNodeViewModel() { }
    }
}