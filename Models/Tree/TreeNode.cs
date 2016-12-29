using System.ComponentModel.DataAnnotations;
using Models.Common;

namespace Models.Tree
{
    public partial class TreeNode:BaseModel
    {
        [Required]
        public string NodeName { get; set; }

        public TreeNode Parent { get; set; }
    }
}
