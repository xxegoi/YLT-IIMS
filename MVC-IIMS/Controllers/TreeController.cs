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
    public class TreeController : Controller
    {
        IBLL.IBLL bll = new BLL.BaseBLL();
        // GET: Tree
        public ActionResult Index()
        {
            List<TreeNode> entryList = bll.Query<TreeNode>(p => true);

            List<TreeNodeViewModel> lst = new List<TreeNodeViewModel>();

            entryList.ForEach(p =>
            {
                lst.Add(new TreeNodeViewModel(p));
            });

            return View(lst);
        }


        public ActionResult Create()
        {
            TreeNodeViewModel model = new TreeNodeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NodeName")]TreeNodeViewModel model)
        {
            try
            {
                bll.Add<TreeNode>(model.ToTreeNode());
            }
            catch (Exception ex)
            {
                ViewBag.Ex = ex.Message;

                return View();
            }

            return RedirectToAction("Index");
        }
    }
}