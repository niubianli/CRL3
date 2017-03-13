/**
* CRL 快速开发框架 V3.1
* Copyright (c) 2016 Hubro All rights reserved.
* GitHub https://github.com/hubro-xx/CRL3
* 主页 http://www.cnblogs.com/hubro
* 在线文档 http://crl.changqidongli.com/
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.BLL;
using Shopping.Model;
namespace Shopping.Web.Controllers
{
    public class ProductController : Core.Mvc.BaseController
    {
        public ActionResult Index(string k, string c = "", int page = 1, int pageSize = 15)
        {
            int count;

            count = 0;
            //var query = new CRL.ExpressionJoin<Product>(b => b.ProductStatus == CRL.Package.Product.ProductStatus.已上架);
            var query = BLL.ProductManage.Instance.GetLambdaQuery();//创建查询
            if (!string.IsNullOrEmpty(k))
            {
                query.Where(b => b.ProductName.Contains(k));
            }
            if (!string.IsNullOrEmpty(c))
            {
                query.Where(b => b.CategoryCode.StartsWith(c));
            }
            //使用缓存搜索
            IEnumerable<Product> products = BLL.ProductManage.Instance.QueryFromCache(b => b.ProductStatus == CRL.Package.Product.ProductStatus.已上架);
            products = products.OrderByDescending(b => b.Id);
            count = products.Count();
            var result = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var pageObj = new PageObj<Product>(result, page, count, pageSize);
            return View(pageObj);
        }

        public ActionResult Item(int id)
        {
            var item = ProductManage.Instance.QueryItemFromCache(b => b.Id == id);
            if (item == null)
            {
                return Content("not found");
            }
            return View(item);
        }
    }
}
