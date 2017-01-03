using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Models.Tree;

namespace IBLL
{
    public interface ITreeNodeBLL
    {
        List<TreeNode_EasyUI_JSON> GetTree(Expression<Func<TreeNode, bool>> where);

        int Delete(TreeNode model);
    }

    
}
