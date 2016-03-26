﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BattonPhotography.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WeddingGallery()
        {
            ViewBag.Message = "Wedding Gallery";

            return View();
        }

        public ActionResult NatureGallery()
        {
            IEnumerable<string> naturePhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Nature/FullSize"));

            List<string> naturePhotosList = new List<string>();

            foreach (var photo in naturePhotos)
            {
                naturePhotosList.Add(photo);
            }

            ViewBag.Photos = naturePhotosList;
            ViewBag.PhotoCount = naturePhotosList.Count();

            return View();
        }

        public ActionResult EventGallery()
        {
            return View();
        }

        public ActionResult RequestPrint(string gallery, string file)
        {
            ViewBag.Gallery = gallery;
            ViewBag.FileName = file;

            return View();
        }
    }
}