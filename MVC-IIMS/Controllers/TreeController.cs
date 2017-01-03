using IBLL;
using Models.Tree;
using MVC_IIMS.Models.IIMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_IIMS.Controllers
{
    [Authorize]
    public class TreeController : Controller
    {
        IBLL.IBLL bll = new BLL.TreeNodeBLL();
        // GET: Tree
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<TreeNode> entryList = bll.QueryOrderBy<TreeNode,string>(p=>!p.IsDeleted,m=>m.NodeName);

            List<TreeNodeViewModel> lst = new List<TreeNodeViewModel>();

            entryList.ForEach(p =>
            {
                TreeNodeViewModel model = new TreeNodeViewModel(p);
                GetParents(model);
                GetChilds(model);
                lst.Add(model);
            });
            return View(lst);
        }
        [AllowAnonymous]
        public JsonResult GetTree(int? id)
        {
            ITreeNodeBLL tree = bll as ITreeNodeBLL;
            if (id == null)
            {
                return Json(tree.GetTree(p => p.ParentId == null), JsonRequestBehavior.AllowGet);
            }
            return Json(tree.GetTree(p => p.ParentId == id), JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult MenuTree()
        {
            return View();
        }

        void GetParents(TreeNodeViewModel model)
        {
            if (model.ParentId != null)
            {
                model.Parent = new TreeNodeViewModel(bll.Query<TreeNode>(p => p.Id == model.ParentId).FirstOrDefault());
            }
        }

        void GetChilds(TreeNodeViewModel model)
        {
            List<TreeNode> enlst = bll.Query<TreeNode>(p => p.ParentId == model.Id);
            if (enlst.Count > 0)
            {
                model.Childs = new List<TreeNodeViewModel>();
                enlst.ForEach(p =>
                {
                    model.Childs.Add(new TreeNodeViewModel(p));
                });
            }

        }

        public ActionResult Create(int? id)
        {
            TreeNodeViewModel model = new TreeNodeViewModel();

            if (id != null)
            {
                TreeNodeViewModel Parent =new TreeNodeViewModel( bll.Query<TreeNode>(p=>p.Id==(int) id).FirstOrDefault());

                ViewBag.Parent = Parent;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NodeName,Parent")]TreeNodeViewModel model)
        {
            try
            {
                if (ModelState.IsValid) {
                    bll.Add<TreeNode>(model.ToTreeNode());
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Ex = ex.Message;

                return View();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TreeNodeViewModel model =new TreeNodeViewModel( bll.Query<TreeNode>(p => p.Id == id).FirstOrDefault());

            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            TreeNode entry = bll.Query<TreeNode>(p => p.Id == id).FirstOrDefault();
            if (entry != null)
            {
                ITreeNodeBLL tree = bll as ITreeNodeBLL;

                tree.Delete(entry);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            TreeNodeViewModel model = new TreeNodeViewModel(bll.Query<TreeNode>(p => p.Id == id).FirstOrDefault());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TreeNodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                TreeNode entry = model.ToTreeNode();

                bll.Modify(entry, "NodeName");
            }
            return RedirectToAction("Index");
        }
    }
}