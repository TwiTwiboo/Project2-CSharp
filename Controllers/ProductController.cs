﻿using Microsoft.AspNetCore.Mvc;
using TripMeOn.BL.interfaces;
using TripMeOn.Models.Products;
using System.Linq;

namespace TripMeOn.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult SearchPackage(int destination, int theme)
        {
            var searchResults = _productService.SearchByDestinationAndTheme(destination, theme);
            return View("SearchBoxPackage", searchResults);
        }

        public IActionResult PackageList()
        {
            var packages = _productService.GetTourPackages();

            return View("PackageList", packages);
        }
        [HttpPost]
        public IActionResult CreatePackage(string name, string country, string themeName, string region, string city, string description, int startMonth, int endMonth, double price)
        {

            var newPackage = _productService.CreatePackage(name, country, themeName, region, city, description, startMonth, endMonth, price);

            var packages = _productService.GetTourPackages();

            return View("PackageList", packages);
        }
        //GetTourPackages return a collection , had to use using System.Linq;
        
        [HttpGet]
        public IActionResult ModifyPackage(int packageId)
        {
            var package = _productService.GetTourPackages()
                .FirstOrDefault(p => p.Id == packageId);

            if (package != null)
            {
                return View("ModifyPackage", package);
            }

            // Handle the case where the package is not found
            return RedirectToAction("PackageList");
        }


        [HttpPost]
        public IActionResult ModifyPackage(int packageId, string name, string country, string themeName, string region, string city, string description, int startMonth, int endMonth, double price)
        {
            var modifiedPackage = _productService.ModifyPackage(packageId, name, country, themeName, region, city, description, startMonth, endMonth, price);

            if (modifiedPackage != null)
            {
                return RedirectToAction("PackageList");
            }

            // Handle the case where the modification fails
            TourPackage originalPackage = _productService.GetTourPackages()
                .FirstOrDefault(p => p.Id == packageId);

            return View("ModifyPackage", originalPackage);
        }

        [HttpGet]
        public IActionResult ShowRemovePackage(int packageId)
        {
            var package = _productService.GetTourPackages().FirstOrDefault(p => p.Id == packageId);

            if (package != null)
            {
                return View("RemovePackage", package);
            }

            // Handle the case where the package is not found
            return RedirectToAction("PackageList");
        }

        [HttpPost]
        public IActionResult RemovePackage(int packageId)
        {
            var package = _productService.GetTourPackages().FirstOrDefault(p => p.Id == packageId);

            if (package != null)
            {
                _productService.RemovePackage(packageId);
            }

            return RedirectToAction("PackageList");
        }

    }

}
