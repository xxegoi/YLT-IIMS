using System.Collections.Generic;
using Models.Tree;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace BLL
{
    public class TreeNodeBLL:BaseBLL,IBLL.ITreeNodeBLL
    {
        public List<TreeNode_EasyUI_JSON> GetTree(Expression<Func<TreeNode, bool>> where)
        {
            List<TreeNode> lst = dal.Query<TreeNode>(where);
            List<TreeNode_EasyUI_JSON> result = null;
            if (lst.Count > 0)
            {
                result = new List<TreeNode_EasyUI_JSON>();
                lst.ForEach(p =>
                {
                    TreeNode_EasyUI_JSON jsonNode = new TreeNode_EasyUI_JSON(p);
                    GetChildren(jsonNode);
                    result.Add(jsonNode);
                });
            }
            return result;
        }

        /// <summary>
        /// 递归出子节点
        /// </summary>
        /// <param name="jsonNode"></param>
        void GetChildren(TreeNode_EasyUI_JSON jsonNode)
        {
            List<TreeNode> lst = this.dal.Query<TreeNode>(p => p.ParentId == jsonNode.id);
             jsonNode.state = "closed";
            if (lst.Count > 0)
            {
               
                jsonNode.children = new List<TreeNode_EasyUI_JSON>();
                lst.ForEach(p =>
                {
                    TreeNode_EasyUI_JSON item = new TreeNode_EasyUI_JSON(p);
                    GetChildren(item);
                    jsonNode.children.Add(item);
                });
            }
        }

        /// <summary>
        /// 删除节点及其所有子孙节点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public  int Delete(TreeNode model)
        {
            int result = 0;
            List<TreeNode> lst = base.Query<TreeNode>(p => p.ParentId == model.Id);
            if (lst.Count > 0)
            {
                lst.ForEach(p =>
                {
                    result+= Delete(p);
                });
            }
            result+= base.Delete<TreeNode>(model);
            return result;
        }
    }
}
