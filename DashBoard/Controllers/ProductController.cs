using DashBoard.Models;
using Provider.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashBoard.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductProvider productProvider;
        public ProductController()
        {
            productProvider = new ProductProvider();
        }

        #region Action
        public ActionResult Product()
        {
            var productType = productProvider.GetProductType();
            TempData["ProductType"] = productType;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            DATA.Domains.Product product = new DATA.Domains.Product
            {
                CreatedOn = DateTime.Now,
                Name = model.Name,
                ProductTypyId = model.ProductTypeId,
                Size = model.Size,
                IsActive = true,
                IsDeleted = false
            };
            productProvider.AddProduct(product);

            TempData["alert"] = GetAlert("Product added successfully", "success");

            var productType = productProvider.GetProductType();
            TempData["ProductType"] = productType;

            return RedirectToAction("Product");
        }

        public ActionResult GetProducts()
        {
            return View();
        }

        #endregion

        #region private

        private Alerts GetAlert(string alertMessage, string alertType)
        {
            return new Alerts
            {
                AlertMessage = alertMessage,
                AlertType = alertType
            };
        }

        #endregion
    }
}